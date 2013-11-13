using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HBM.GeneralManagement
{
    public class CurrencyTypes
    {
        public DataSet SelectAllDataset()
        {
            return (new CurrencyTypesDAO()).SelectAll();
        }
    }
}
