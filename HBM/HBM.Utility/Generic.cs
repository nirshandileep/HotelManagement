using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using HBM.Common;

namespace HBM.Utility
{
    public class Generic
    {
        /// <summary>
        /// Returns an entity by PrimaryKey. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="PrimaryKey"></param>
        /// <param name="ExecutedBy"></param>
        /// <param name="dbTransaction"></param>
        /// <returns></returns>
        public static T Get<T>(int PrimaryKey, int companyId) where T : new()
        {
            T entity = default(T);

            string TypeName = typeof(T).Name.Replace("Entity", "");

            Database db = DatabaseFactory.CreateDatabase(Constants.HBMCONNECTIONSTRING);
            DbCommand dbCommand = db.GetStoredProcCommand("usp_" + TypeName + "Select");

            db.AddInParameter(dbCommand, TypeName + "Id", DbType.Int32, PrimaryKey);
            db.AddInParameter(dbCommand, "CompanyId", DbType.Int32, companyId);

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    entity = new T();
                    AssignDataReaderToEntity(dataReader, entity);
                }
            }

            return entity;
        }

        /// <summary>
        /// This function loops through each column in the datareader and assigns
        /// the value to the associated property on the entity (if it exists).
        /// </summary>
        /// <param name="dataReader"></param>
        /// <param name="entity"></param>
        /// <param name="enforceAllDbFieldsExist">Throws an exception if the DB returns a field which is not on the entity</param>
        protected static void AssignDataReaderToEntity(IDataReader dataReader, object entity)
        {
            System.Reflection.PropertyInfo entityProperty;

            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                if (dataReader[i] != DBNull.Value)
                {
                    string fieldName = dataReader.GetName(i);

                    // fieldName is case sensitive, check the entity class members to match up with
                    // the field names returned by the database query for case sensitivity
                    entityProperty = entity.GetType().GetProperty(fieldName);

                    //If we couldnt find the property, do a case insensitive search
                    if (entityProperty == null)
                    {
                        entityProperty = entity.GetType().GetProperty(fieldName,
                                BindingFlags.IgnoreCase |
                                BindingFlags.Public |
                                BindingFlags.Instance);
                    }

                    // If the property exists on this entity:
                    if (entityProperty != null)
                    {
                        // And if the property is writable:
                        if (entityProperty.CanWrite)
                        {
                            // Assign the datareader value to the entity
                            entityProperty.SetValue(entity, dataReader[i], null);
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Returns a collection of T. T must be an Entity class
        /// </summary>
        public static List<T> GetAll<T>(int companyId) where T : new()
        {
            List<T> returnEntityCollection = new List<T>();

            string TypeName = typeof(T).Name;

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("usp_" + TypeName + "_GetAll");
            db.AddInParameter(dbCommand, "companyId", DbType.Int32, companyId);

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    T entity = new T();

                    AssignDataReaderToEntity(dataReader, entity);
                    returnEntityCollection.Add(entity);
                }
            }

            return returnEntityCollection;
        }

    }
}
