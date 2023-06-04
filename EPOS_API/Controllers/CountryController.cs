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
    public class CountryController : Controller
    {
        private IConfiguration _config;
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();

        public CountryController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("CrudCountry")]
        public string CrudCountry([FromBody] EPOS_API.Model.CountryModel obj)
        {
            var response = Crud_Country(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        private dynamic Crud_Country(EPOS_API.Model.CountryModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {
                    DataSet obj_response = SP_Country(obj);
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

        [HttpPost("CrudAllCountry")]
        public string CrudAllCountry([FromBody] EPOS_API.Model.CountryModel obj)
        {
            var response = Crud_AllCountry(obj);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        private dynamic Crud_AllCountry(EPOS_API.Model.CountryModel obj)
        {
            try
            {
                DataSet obj_response = SP_Country(obj);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }

        private DataSet SP_Country(EPOS_API.Model.CountryModel obj)
        {
            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
            parm.Add(new SqlParameter() { ParameterName = "@CountryName", SqlDbType = SqlDbType.NVarChar, Value = obj.CountryName });
            parm.Add(new SqlParameter() { ParameterName = "@CountryId", SqlDbType = SqlDbType.Int, Value = obj.CountryId });
            parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
            parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });

            var spName = "SP_Country";

            DataSet obj_response = new DapperManager(_config.GetConnectionString("MyConnection")).GetDataSet(spName, parm.ToArray());

            return obj_response;
        }
    }
}