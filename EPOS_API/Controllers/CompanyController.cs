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
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Controllers
{
    public class CompanyController : Controller
    {
        private IConfiguration _config;
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        HttpContext context;
        //int? IntNull = null;
        public CompanyController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("CrudCompany")]
        public string CrudCompany([FromBody] EPOS_API.Model.CompanyModel obj)
        {
            var response = Crud_Company(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        private dynamic Crud_Company(EPOS_API.Model.CompanyModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {
                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyName", SqlDbType = SqlDbType.NVarChar, Value = obj.CompanyName });
                    parm.Add(new SqlParameter() { ParameterName = "@NoOfTerminals", SqlDbType = SqlDbType.Int, Value = obj.NoOfTerminals });
                    parm.Add(new SqlParameter() { ParameterName = "@BusinessTypeId", SqlDbType = SqlDbType.Int, Value = obj.BusinessTypeId });
                    parm.Add(new SqlParameter() { ParameterName = "@CountryId", SqlDbType = SqlDbType.Int, Value = obj.CountryId });
                    parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                    parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyLogo", SqlDbType = SqlDbType.NVarChar, Value = obj.CompanyLogo });
                    parm.Add(new SqlParameter() { ParameterName = "@EmailAddress", SqlDbType = SqlDbType.NVarChar, Value = obj.EmailAddress });

                    var spName = "SP_SetupCompany";

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
