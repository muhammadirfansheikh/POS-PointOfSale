using EPOS_API.Data;
using EPOS_API.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EPOS_API.Controllers
{
    public class ExpenseController : Controller
    {
        private IConfiguration _config;
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        public ExpenseController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("CrudExpense")]
        public string CrudExpense([FromBody] EPOS_API.Model.ExpenseModel obj)
        {
            var response = Crud_EXPENSE(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic Crud_EXPENSE(EPOS_API.Model.ExpenseModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {

                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@ExpenseTypeID", SqlDbType = SqlDbType.Int, Value = obj.ExpenseTypeID });
                    parm.Add(new SqlParameter() { ParameterName = "@ExpenseAmount", SqlDbType = SqlDbType.Decimal, Value = obj.ExpenseAmount });
                    parm.Add(new SqlParameter() { ParameterName = "@IsActive", SqlDbType = SqlDbType.Bit, Value = obj.IsActive });
                    parm.Add(new SqlParameter() { ParameterName = "@OperationID", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyID", SqlDbType = SqlDbType.Int, Value = obj.CompanyID });
                    parm.Add(new SqlParameter() { ParameterName = "@BranchID", SqlDbType = SqlDbType.Int, Value = obj.BranchID }); 
                    parm.Add(new SqlParameter() { ParameterName = "@PaymentModeID", SqlDbType = SqlDbType.Int, Value = obj.PaymentModeID });
                    parm.Add(new SqlParameter() { ParameterName = "@PaymentAccountID", SqlDbType = SqlDbType.Int, Value = obj.PaymentAccountID });
                    parm.Add(new SqlParameter() { ParameterName = "@ExpenseID", SqlDbType = SqlDbType.Int, Value = obj.ExpenseID });
                    parm.Add(new SqlParameter() { ParameterName = "@Date", SqlDbType = SqlDbType.Date, Value = obj.Date });
                    parm.Add(new SqlParameter() { ParameterName = "@Description", SqlDbType = SqlDbType.NVarChar, Value = obj.Description });
                    parm.Add(new SqlParameter() { ParameterName = "@InvoiceNo", SqlDbType = SqlDbType.VarChar, Value = obj.InvoiceNo });
                    parm.Add(new SqlParameter() { ParameterName = "@UserID", SqlDbType = SqlDbType.Int, Value = obj.UserID });
                    parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
                    parm.Add(new SqlParameter() { ParameterName = "@ChequeNo", SqlDbType = SqlDbType.VarChar, Value = obj.ChequeNo });
                    parm.Add(new SqlParameter() { ParameterName = "@FromDate", SqlDbType = SqlDbType.Date, Value = obj.FromDate });
                    parm.Add(new SqlParameter() { ParameterName = "@ToDate", SqlDbType = SqlDbType.Date, Value = obj.ToDate });

                    var spName = "SP_CRUD_EXPENSE";
                    DataSet obj_response = new DapperManager(_config.GetConnectionString("MyConnection")).GetDataSet(spName, parm.ToArray());
                    if (obj_response != null)
                    {
                        responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                    }
                    else
                    {
                        responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                    }
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.InvalidToken, ResponseMessages.InvalidToken);
                }
                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }

        [HttpPost("GetExpenseControlsValue")]
        public string GetExpenseControlsValue([FromBody] EPOS_API.Model.CompanyModel obj)
        {
            var response = GetExpenseControlsValue(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic GetExpenseControlsValue(EPOS_API.Model.CompanyModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {

                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });

                    var spName = "SP_GetExpenseControlValues";
                    DataSet obj_response = new DapperManager(_config.GetConnectionString("MyConnection")).GetDataSet(spName, parm.ToArray());
                    if (obj_response != null)
                    {
                        responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                    }
                    else
                    {
                        responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                    }
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.InvalidToken, ResponseMessages.InvalidToken);
                }
                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }
    }
}
