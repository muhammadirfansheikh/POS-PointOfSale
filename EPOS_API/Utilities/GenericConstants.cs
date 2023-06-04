using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPOS_API.Utilities
{
    public struct GenericConstants
    {
        public const string ConnectionStringKey = "ConnectionString";

        public static int Sql_CommandTimeout = 36000;
        public const string DefaultDateFormat = "MMM dd,yyyy";
        public const string DefaultDateFormatWithTime = "MMM dd,yyyy HH:mm:ss";
        public const string DateFormatDDMMYYYY = "dd-MM-yyyy";
        public const string TimeFormatLong = "HH:mm:ss";
        public const string TimeFormatAMPM = "hh:mm:ss tt";
        public const string ErrorLog = "Logs/ExceptionsLogs";
        public const string GetDefaultPage = "/Default.aspx";
        public const string EmailLog = "Logs/EmailLog";
        public const string Password = "concavepos123";
        #region DB_NAMES

        public const string DB_Setup = "SW_Setup";
        public const string DB_HRMS = "SW_HRMS";
        public const string DB_TMS = "SW_TMS";

        #endregion
        #region Connection String
        //public const string ConnectionString = @"Data Source = 192.168.61.32\MSSQLSERVER2017;Initial Catalog =SabSath1; User ID=sa;pwd=Sybr1d123;";
        //public const string ConnectionString = @"Data Source = 192.168.61.34\MSSQLSERVER2017;Initial Catalog =SabSath; User ID=sa;pwd=Sybr1d123;";
        public const string ConnectionString = @"Data Source = 192.168.61.233;Initial Catalog =DB_Sab_Sath_Live; User ID=sa;pwd=Sybr1d123;";
        //public const string ConnectionString = @"Data Source = 124.29.235.14;Initial Catalog =DB_Sab_Sath_Live; User ID=sa;pwd=Sybr1d123;";
        //public const string ConnectionString = @"Data Source = 192.168.61.32\\MSSQLSERVER2017;Initial Catalog =SabSath; User ID=sa;pwd=Sybr1d123;";


        #endregion
    }
    public struct Roles
    {
        public const int SuperAdmin = 1;
        public const int Admin = 2;
        public const int Incharge = 3;
        public const int Employee = 4;
    }
    public struct Setup_Master
    {
        public const int OperationTypes = 1;
    }
    public struct Setup_MasterDetail
    {
        public const int Select = 1;
        public const int Insert = 2;
        public const int Update = 3;
        public const int Delete = 4;
    }
    public struct Feature
    {
        public const int Add = 1;
        public const int Edit = 2;
        public const int Delete = 3;
        public const int View = 4;
    }
    public class ResponseKeys
    {
        public static string Data = "Data";
        public static string Response = "Response";
        public static string ResponseCode = "ResponseCode";
        public static string ErrorMessage = "ErrorMessage";
        public static string ResponseMessage = "ResponseMessage";
        public static string Token = "Token";
    }

    public class ResponseCodes
    {
        public static string Success = "00";
        public static string TokenExpired = "01";
        public static string NotGeneratedAgainstThisUser = "02";
        public static string InvalidToken = "03";
        public static string InvalidCredentials = "04";
        public static string Exception = "05";
        public static string ValidationError = "07";
        public static string Failure = "11";
    }

    public class ResponseMessages
    {
        public static string Success = "Success";
        public static string TokenExpired = "Token Expired";
        public static string NotGeneratedAgainstThisUser = "Token is not valid for this user";
        public static string InvalidToken = "Invalid Token";
        public static string InvalidCredentials = "Invalid Credentials";
        public static string InvalidErrorCode = "Invalid Error Code";
        public static string Failure = "Failure";
        public static string Exception = "An Exception has been occured";
        public static string NoData = "No Data Found";
        public static string ExceptionMessage = "An Exception has occured. Some thing went wrong";
        public static string InvalidPatientId = "Invalid Patient";
        public static string SuccessfullyRegistered = "SuccessfullyRegistered";
        public static string InvalidParameters = "Invalid Parameters";
        public static string SuccessfullyUpdated = "Successfully Updated";
        public static string SuccessfullyAdded = "Successfully Added";
        public static string SuccessfullyDeleted = "Successfully Deleted";
    }
    public class MessageDate<T>
    {
        public bool Response { get; set; }
        public string ResponseCodes { get; set; }
        public string ResponseMessage { get; set; }
        public T Data { get; set; }
        public DataSet DataSet { get; set; }
        
    }

    public class MessageDate_M<T>
    {
        public T Data { get; set; }
    }

    public struct OperationTypes
    {
        public const string Select = "Select";
        public const string Insert = "Insert";
        public static string Update = "Update";
        public const string Delete = "Delete";
    }

    public class Menu
    {
        public string path { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public string component { get; set; }
        public string layout { get; set; }

        public string SubNode { get; set; }

        public int MenuId { get; set; }

        public int ApplicationId { get; set; }

        public string Menu_Name { get; set; }
        
        public int Parent_Id { get; set; }

        public string Value { get; set; }

        public string Menu_URL { get; set; }
        

        public List<SubMenu> SubMenus { get; set; }
    }
    public class SubMenu
    {
        public string path { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public string component { get; set; }
        public string layout { get; set; }



        public int MenuItemId { get; set; }

        public int ApplicationId { get; set; }
        public string Value { get; set; }
        public string parent { get; set; }
        public Boolean Checked { get; set; }
        public string Label { get; set; }
    }

    public class ParentMenu
    {
        public int value { get; set; }
        public string label { get; set; }
        public List<Features> ParentFeature { get; set; }
        public List<ChildMenu> children { get; set; }
    }
    public class ChildMenu
    {
        public int value { get; set; }
        public string label { get; set; }
        public List<Features> children { get; set; }
    }
    public class Features
    {
        public int value { get; set; }
        public string label { get; set; }
    }
}
