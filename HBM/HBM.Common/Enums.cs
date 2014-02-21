using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HBM.Common
{
    public class Enums
    {
        /// <summary>
        /// Types of status
        /// </summary>
        public enum HBMStatus
        {
            Active = 1,
            InActive = 2,
            Confirmed = 3,
            Modify = 4,
            CheckIn = 5,
            Cancel = 6,
            NoShow = 7,
            Reserved = 8,
            CheckOut = 9,
        }

        /// <summary>
        /// Types of Companies
        /// </summary>
        public enum HBMCompanyTypes
        {
            Hote = 1
        }

        /// <summary>
        /// Different types of customers
        /// </summary>
        public enum CustomerModes
        {
            Individual = 1,
            Group = 2,
        }

        /// <summary>
        /// Types of Payments
        /// </summary>
        public enum PaymentType
        {
            Cash = 1,
            CreditCard = 2,
            Check = 3,
            BankTransfer = 4,
            Other = 5
        }

        /// <summary>
        /// Use the Below format to add new Items to this Enum
        /// MODULE_SUBMODULE_RIGHT
        /// </summary>
        public enum Rights
        {
            UserManagement_User_Add = 1,
            UserManagement_User_Edit = 2,
            UserManagement_User_Delete = 3,
            UserManagement_User_View = 4,
            UserManagement_Roles_Add = 5,
            UserManagement_Roles_Edit = 6,
            UserManagement_Roles_Delete = 7,
            UserManagement_Roles_View = 8,
            CustomerManagement_Customer_Add = 9,
            CustomerManagement_Customer_Edit = 10,
            CustomerManagement_Customer_Delete = 11,
            CustomerManagement_Customer_View = 12,
            CustomerManagement_Customer_Search = 13,
            UserManagement_User_Search = 14,
            UserManagement_Roles_Search = 15,
            CompanyManagement_Company_Add = 16,
            CompanyManagement_Company_Edit = 17,
            CompanyManagement_Company_Delete = 18,
            CompanyManagement_Company_View = 19,
            CompanyManagement_Company_Search = 20,
            GeneralManagement_Switchboard_View = 21,
            GeneralManagement_Bedtypes_Add = 22,
            GeneralManagement_Bedtypes_Edit = 23,
            GeneralManagement_Bedtypes_Delete = 24,
            GeneralManagement_Departments_Add = 25,
            GeneralManagement_Departments_Edit = 26,
            GeneralManagement_Departments_Delete = 27,
            GeneralManagement_Bedtypes_View = 28,
            GeneralManagement_Departments_View = 29,
            GeneralManagement_Gaurantee_Add = 30,
            GeneralManagement_Gaurantee_Edit = 31,
            GeneralManagement_Gaurantee_Delete = 32,
            GeneralManagement_Gaurantee_View = 33,
            GeneralManagement_Rooms_Add = 34,
            GeneralManagement_Rooms_Edit = 35,
            GeneralManagement_Rooms_Delete = 36,
            GeneralManagement_Rooms_View = 37,
            GeneralManagement_RatePlan_Add = 38,
            GeneralManagement_RatePlan_Edit = 39,
            GeneralManagement_RatePlan_Delete = 40,
            GeneralManagement_RatePlan_View = 41,
            GeneralManagement_Source_Add = 42,
            GeneralManagement_Source_Edit = 43,
            GeneralManagement_Source_Delete = 44,
            GeneralManagement_Source_View = 45,
            GeneralManagement_TaxType_Add = 46,
            GeneralManagement_TaxType_Edit = 47,
            GeneralManagement_TaxType_Delete = 48,
            GeneralManagement_TaxType_View = 49,
            ReservationManagement_Reservation_Add = 50,
            ReservationManagement_Reservation_Edit = 51,
            ReservationManagement_Reservation_View = 52,
            ReservationManagement_Reservation_Search = 53,
            ReservationManagement_Reservation_Delete = 54,
            GeneralManagement_GuestType_Add = 55,
            GeneralManagement_GuestType_Edit = 56,
            GeneralManagement_GuestType_View = 57,
            GeneralManagement_GuestType_Delete = 58,
            GeneralManagement_AdditionalServices_Add = 59,
            GeneralManagement_AdditionalServices_Edit = 60,
            GeneralManagement_AdditionalServices_View = 61,
            GeneralManagement_AdditionalServices_Delete = 62,
            GeneralManagement_AdditionalServiceType_Add = 63,
            GeneralManagement_AdditionalServiceType_Edit = 64,
            GeneralManagement_AdditionalServiceType_Delete = 65,
            GeneralManagement_AdditionalServiceType_View = 66,
            GeneralManagement_CreditCardType_Add = 67,
            GeneralManagement_CreditCardType_Edit = 68,
            GeneralManagement_CreditCardType_Delete = 69,
            GeneralManagement_CreditCardType_View = 70,
            GeneralManagement_PaymentType_Add = 71,
            GeneralManagement_PaymentType_Edit = 72,
            GeneralManagement_PaymentType_View = 73,
            GeneralManagement_PaymentType_Delete = 74,
            GeneralManagement_RoomRatePlan_Add = 75,
            GeneralManagement_RoomRatePlan_Edit = 76,
            GeneralManagement_RoomRatePlan_View = 77,
            GeneralManagement_RoomRatePlan_Delete = 78,
            GeneralManagement_ServiceMethod_Add = 79,
            GeneralManagement_ServiceMethod_Edit = 80,
            GeneralManagement_ServiceMethod_View = 81,
            GeneralManagement_ServiceMethod_Delete = 82,

        }
    }
}
