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
    public class GeneralLedgerController : Controller
    {

        private IConfiguration _config;
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        public GeneralLedgerController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("GeneralLedger_FillControl")]
        public string GeneralLedger_FillControl([FromBody] EPOS_API.Model.GenerateLedgerModel obj)
        {
            var response = GeneralLedger_FillControl(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic GeneralLedger_FillControl(EPOS_API.Model.GenerateLedgerModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {

                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyID });
                    parm.Add(new SqlParameter() { ParameterName = "@BranchId", SqlDbType = SqlDbType.Int, Value = obj.BranchID });

                    var spName = "Sp_GeneralLedger_FillControl";
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
        [HttpPost("Generate_Ledger")]
        public string Generate_Ledger([FromBody] EPOS_API.Model.GenerateLedgerModel obj)
        {
            var response = Generate_Ledger(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic Generate_Ledger(EPOS_API.Model.GenerateLedgerModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {

                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@Param_FromDate", SqlDbType = SqlDbType.Date, Value = obj.FromDate });
                    parm.Add(new SqlParameter() { ParameterName = "@Param_ToDate", SqlDbType = SqlDbType.Date, Value = obj.ToDate });
                    parm.Add(new SqlParameter() { ParameterName = "@Param_COAID", SqlDbType = SqlDbType.NVarChar, Value = obj.COAID });
                    parm.Add(new SqlParameter() { ParameterName = "@Param_CustomerID", SqlDbType = SqlDbType.Int, Value = obj.CustomerID });
                    parm.Add(new SqlParameter() { ParameterName = "@Param_VendorID", SqlDbType = SqlDbType.Int, Value = obj.VendorID});
                    parm.Add(new SqlParameter() { ParameterName = "@Param_CompanyID", SqlDbType = SqlDbType.Int, Value = obj.CompanyID});
                    parm.Add(new SqlParameter() { ParameterName = "@Param_BranchID", SqlDbType = SqlDbType.Int, Value = obj.BranchID});
                   
                    var spName = "Generate_Ledger";
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
