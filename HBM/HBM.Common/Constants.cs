using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HBM.Common
{
    public  class Constants
    {
        #region Database Connection

        public static readonly string HBMCONNECTIONSTRING = "HBMConnectionString";

        #endregion

        #region Stored Procedures

        
        public static readonly string SP_GUARANTEESELECT = "usp_GuaranteeSelect";
        public static readonly string SP_GUARANTEEINSERT = "usp_GuaranteeInsert";
        public static readonly string SP_GUARANTEEUPDATE = "usp_GuaranteeUpdate";
        public static readonly string SP_GUARANTEEDELETE = "usp_GuaranteeDelete";
        public static readonly string SP_RATEPLANSSELECT = "usp_RatePlansSelect";
        public static readonly string SP_RATEPLANSINSERT = "usp_RatePlansInsert";
        public static readonly string SP_RATEPLANSUPDATE = "usp_RatePlansUpdate";
        public static readonly string SP_RATEPLANSDELETE = "usp_RatePlansDelete";
        public static readonly string SP_RESERVATIONSELECT = "usp_ReservationSelect";
        public static readonly string SP_RESERVATIONINSERT = "usp_ReservationInsert";
        public static readonly string SP_RESERVATIONUPDATE = "usp_ReservationUpdate";
        public static readonly string SP_RESERVATIONDELETE = "usp_ReservationDelete";
        public static readonly string SP_RESERVATIONADDITIONALSERVICESELECT = "usp_ReservationAdditionalServiceSelect";
        public static readonly string SP_RESERVATIONADDITIONALSERVICEINSERT = "usp_ReservationAdditionalServiceInsert";
        public static readonly string SP_RESERVATIONADDITIONALSERVICEUPDATE = "usp_ReservationAdditionalServiceUpdate";
        public static readonly string SP_RESERVATIONGUESTSELECT = "usp_ReservationGuestSelect";
        public static readonly string SP_RESERVATIONGUESTINSERT = "usp_ReservationGuestInsert";
        public static readonly string SP_RESERVATIONGUESTUPDATE = "usp_ReservationGuestUpdate";
        public static readonly string SP_RESERVATIONPAYMENTSELECT = "usp_ReservationPaymentSelect";
        public static readonly string SP_RESERVATIONPAYMENTINSERT = "usp_ReservationPaymentInsert";
        public static readonly string SP_RESERVATIONPAYMENTUPDATE = "usp_ReservationPaymentUpdate";
        public static readonly string SP_RESERVATIONROOMSELECT = "usp_ReservationRoomSelect";
        public static readonly string SP_RESERVATIONROOMINSERT = "usp_ReservationRoomInsert";
        public static readonly string SP_RESERVATIONROOMUPDATE = "usp_ReservationRoomUpdate";
        public static readonly string SP_ROOMRATEPLANSELECT = "usp_RoomRatePlanSelect";
        public static readonly string SP_ROOMRATEPLANINSERT = "usp_RoomRatePlanInsert";
        public static readonly string SP_ROOMRATEPLANUPDATE = "usp_RoomRatePlanUpdate";
        public static readonly string SP_ROOMRATEPLANDELETE = "usp_RoomRatePlanDelete";
        public static readonly string SP_SOURCESELECT = "usp_SourceSelect";
        public static readonly string SP_SOURCEINSERT = "usp_SourceInsert";
        public static readonly string SP_SOURCEUPDATE = "usp_SourceUpdate";
        public static readonly string SP_SOURCEDELETE = "usp_SourceDelete";
  

        #endregion

        #region Page Path's

        public static readonly string URL_DEFAULTBACKPAGE = "Dashboard.aspx";
        public static readonly string URL_LOGIN = "~/Login.aspx";
        public static readonly string URL_BEDTYPE = "/ControlPanel/BedType.aspx";
        public static readonly string URL_DEPARTMENT = "/ControlPanel/Department.aspx";
        public static readonly string URL_GAURANTEE = "/ControlPanel/Gaurantee.aspx";
        public static readonly string URL_RATEPLAN = "/ControlPanel/RatePlan.aspx";
        public static readonly string URL_ROOMS = "/ControlPanel/Rooms.aspx";
        public static readonly string URL_RATEPLANS= "/ControlPanel/RatePlans.aspx";
        public static readonly string URL_SOURCE = "/ControlPanel/Source.aspx";
        public static readonly string URL_TAXTYPES= "/ControlPanel/TaxType.aspx";
        public static readonly string URL_ADDITIONALSERVICETYPE = "/ControlPanel/AdditionalServiceType.aspx";
        public static readonly string URL_ADDITIONALSERVICE= "/ControlPanel/AdditionalService.aspx";

        public static readonly string URL_GUESTTYPES = "/ControlPanel/GuestTypes.aspx";
        public static readonly string URL_CREDITCARDTYPE = "/ControlPanel/CreditCardType.aspx";
        public static readonly string URL_PAYMENTTYPES = "/ControlPanel/PaymentTypes.aspx";

        public static readonly string URL_CUSTOMERSEARCH = "/Customer/CustomerSearch.aspx";
        public static readonly string URL_CUSTOMERS = "/Customer/Customers.aspx";

        public static readonly string URL_RESERVATIONSEARCH = "/Reservation/SearchReservation.aspx";
        public static readonly string URL_RESERVATION = "/Reservation/Reservation.aspx";


       

        #endregion

        #region Sessions

        public static readonly string SESSION_BEDTYPES = "BedTypes";
        public static readonly string SESSION_DEPARTMENT = "Departments";
        public static readonly string SESSION_GAURANTEE = "Gaurantee";
        public static readonly string SESSION_ROOMS = "Rooms";
        public static readonly string SESSION_SOURCE = "Source";
        public static readonly string SESSION_LOGGEDUSER = "LoggedUser";
        public static readonly string SESSION_CURRENTCOMPANY = "CurrentCompany";
        public static readonly string SESSION_RATEPLANS = "RatePlans";
        public static readonly string SESSION_TAXTYPES= "TaxTypes";
        public static readonly string SESSION_ADDITIONALSERVICETYPE = "AdditionalServiceType";
        public static readonly string SESSION_ADDITIONALSERVICE = "AdditionalService";
        public static readonly string SESSION_CREDITCARDTYPE = "CreditCardType";
        public static readonly string SESSION_GUESTTYPE = "GuestType";
        public static readonly string SESSION_PAYMENTTYPES = "PaymentTypes";
        public static readonly string SESSION_RESERVATION_ADDTIONALSERVICE= "ReservationAddtionalService";
        public static readonly string SESSION_RESERVATION_PAYMENTINFORMATION= "ReservationPaymentInformation";
        public static readonly string SESSION_RESERVATION_ROOMINFORMATION = "ReservationRoomInformation";
        public static readonly string SESSION_ARRIVALS = "ArrivalsList";
        public static readonly string SESSION_DEPARTURES = "DeparturesList";
        public static readonly string SESSION_DIRTYROOMS = "DirtyRoomsList";
        

        #endregion

        #region To be moved to config table

        public static readonly int CHECKIN_ADD_DAYS = 1;
        public static readonly int CHECKOUT_ADD_DAYS = 2;

        #endregion 

        #region Common Settings

        public static readonly int GRID_PAGESIZE = 15;

        #endregion

    }
}
