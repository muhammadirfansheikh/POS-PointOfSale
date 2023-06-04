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
    public class AreaController : Controller
    {

        private IConfiguration _config;
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        public AreaController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("CrudArea")]
        public string CrudArea([FromBody] EPOS_API.Model.AreaModel obj)
        {
            var response = Crud_Area(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic Crud_Area(EPOS_API.Model.AreaModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {

                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });
                    parm.Add(new SqlParameter() { ParameterName = "@AreaId", SqlDbType = SqlDbType.Int, Value = obj.AreaId });
                    parm.Add(new SqlParameter() { ParameterName = "@AreaName", SqlDbType = SqlDbType.NVarChar, Value = obj.AreaName });
                    parm.Add(new SqlParameter() { ParameterName = "@CityId", SqlDbType = SqlDbType.Int, Value = obj.CityId });
                    parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                    parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
                    parm.Add(new SqlParameter() { ParameterName = "@IsEnable", SqlDbType = SqlDbType.Bit, Value = obj.IsEnable });
                    parm.Add(new SqlParameter() { ParameterName = "@StartTime", SqlDbType = SqlDbType.NVarChar, Value = obj.StartTime });
                    parm.Add(new SqlParameter() { ParameterName = "@EndTime", SqlDbType = SqlDbType.NVarChar, Value = obj.EndTime });
                    parm.Add(new SqlParameter() { ParameterName = "@ProvinceId", SqlDbType = SqlDbType.Int, Value = obj.ProvinceId });
                    parm.Add(new SqlParameter() { ParameterName = "@CountryId", SqlDbType = SqlDbType.Int, Value = obj.CountryId });

                    var spName = "SP_Area";
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
