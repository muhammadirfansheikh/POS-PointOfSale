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
    public class RecieveablePayableController : Controller
    {

        private IConfiguration _config;
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        public RecieveablePayableController(IConfiguration config)
        {
            _config = config;
        }


        [HttpPost("CrudRecieveablePayable")]
        public string CrudRecieveablePayable([FromBody] EPOS_API.Model.RecieveablePayableModel obj)
        {
            var response = CrudRecieveablePayable(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic CrudRecieveablePayable(EPOS_API.Model.RecieveablePayableModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {

                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@COAID", SqlDbType = SqlDbType.Int, Value = obj.COAID });
                    parm.Add(new SqlParameter() { ParameterName = "@Amount", SqlDbType = SqlDbType.Decimal, Value = obj.Amount });
                    parm.Add(new SqlParameter() { ParameterName = "@IsActive", SqlDbType = SqlDbType.Bit, Value = obj.IsActive });
                    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });
                    parm.Add(new SqlParameter() { ParameterName = "@BranchId", SqlDbType = SqlDbType.Int, Value = obj.BranchID });
                    parm.Add(new SqlParameter() { ParameterName = "@PaymentModeId", SqlDbType = SqlDbType.Int, Value = obj.PaymentModeID });
                    parm.Add(new SqlParameter() { ParameterName = "@PaymentAccountId", SqlDbType = SqlDbType.Int, Value = obj.PaymentAccountID });
                    parm.Add(new SqlParameter() { ParameterName = "@VoucherIDD", SqlDbType = SqlDbType.Int, Value = obj.VoucherIDD });
                    parm.Add(new SqlParameter() { ParameterName = "@Date", SqlDbType = SqlDbType.Date, Value = obj.Date });
                    parm.Add(new SqlParameter() { ParameterName = "@Description", SqlDbType = SqlDbType.NVarChar, Value = obj.Description });
                    parm.Add(new SqlParameter() { ParameterName = "@InvoiceNo", SqlDbType = SqlDbType.VarChar, Value = obj.InvoiceNo });
                    parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                    parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
                    parm.Add(new SqlParameter() { ParameterName = "@ChequeNo", SqlDbType = SqlDbType.VarChar, Value = obj.ChequeNo });
                    parm.Add(new SqlParameter() { ParameterName = "@FromDate", SqlDbType = SqlDbType.Date, Value = obj.FromDate });
                    parm.Add(new SqlParameter() { ParameterName = "@ToDate", SqlDbType = SqlDbType.Date, Value = obj.ToDate });
                    parm.Add(new SqlParameter() { ParameterName = "@IS_IN", SqlDbType = SqlDbType.Bit, Value = obj.IS_IN });
                    parm.Add(new SqlParameter() { ParameterName = "@Rate", SqlDbType = SqlDbType.Decimal, Value = obj.Rate });

                    parm.Add(new SqlParameter() { ParameterName = "@VendorID", SqlDbType = SqlDbType.Int, Value = obj.VendorID });
                    parm.Add(new SqlParameter() { ParameterName = "@CustomerID", SqlDbType = SqlDbType.Int, Value = obj.CustomerID });
                    parm.Add(new SqlParameter() { ParameterName = "@IS_CASH", SqlDbType = SqlDbType.Bit, Value = obj.IS_CASH });

                    if (obj.lst_REC_PAY_COA != null)
                        parm.Add(new SqlParameter() { ParameterName = "@REC_PAY_COA_TAB", SqlDbType = SqlDbType.Structured, Value = CommonObjects.ToDataTable(obj.lst_REC_PAY_COA.AsEnumerable().ToList()) });

                    if (obj.lst_REC_PAY_PAYMENT != null)
                        parm.Add(new SqlParameter() { ParameterName = "@REC_PAY_PAYMENT_TAB", SqlDbType = SqlDbType.Structured, Value = CommonObjects.ToDataTable(obj.lst_REC_PAY_PAYMENT.AsEnumerable().ToList()) });

                    var spName = "SP_CRUD_Recieveable_Payable";
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


        [HttpPost("PayableRecieveable_FillControl")]
        public string PayableRecieveable_FillControl([FromBody] EPOS_API.Model.RecieveablePayableModel obj)
        {
            var response = PayableRecieveable_FillControl(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic PayableRecieveable_FillControl(EPOS_API.Model.RecieveablePayableModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {

                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });
                    parm.Add(new SqlParameter() { ParameterName = "@BranchId", SqlDbType = SqlDbType.Int, Value = obj.BranchID });

                    var spName = "Sp_PayableRecieveable_FillControl";

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
