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
    public class BankController : Controller
    {

        private IConfiguration _config;
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        public BankController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("CrudBank")]
        public string CrudBank([FromBody] EPOS_API.Model.BankModel obj)
        {
            var response = Crud_Bank(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic Crud_Bank(EPOS_API.Model.BankModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {

                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                    parm.Add(new SqlParameter() { ParameterName = "@BankId", SqlDbType = SqlDbType.Int, Value = obj.BankId });
                    parm.Add(new SqlParameter() { ParameterName = "@BankName", SqlDbType = SqlDbType.NVarChar, Value = obj.BankName });
                    parm.Add(new SqlParameter() { ParameterName = "@UserIp", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
                    parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId});
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyID", SqlDbType = SqlDbType.Int, Value = obj.CompanyID});
                    parm.Add(new SqlParameter() { ParameterName = "@BranchID", SqlDbType = SqlDbType.Int, Value = obj.BranchID});

                    if(obj.BankDetail!=null)
                        parm.Add(new SqlParameter() { ParameterName = "@BANK_ACCOUNTS", SqlDbType = SqlDbType.Structured, Value = CommonObjects.ToDataTable(obj.BankDetail.AsEnumerable().ToList()) });

                    var spName = "SP_CRUD_BANK";
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
