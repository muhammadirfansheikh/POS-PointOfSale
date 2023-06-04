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
    public class DepartmentController : Controller
    {
        private IConfiguration _config;
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        public DepartmentController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("CrudDepartment")]
        public string CrudDepartment([FromBody] EPOS_API.Model.DepartmentModel obj)
        {
            var response = Crud_Department(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic Crud_Department(EPOS_API.Model.DepartmentModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {
                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });
                    parm.Add(new SqlParameter() { ParameterName = "@DepartmentId", SqlDbType = SqlDbType.Int, Value = obj.DepartmentId });
                    parm.Add(new SqlParameter() { ParameterName = "@DepartmentName", SqlDbType = SqlDbType.NVarChar, Value = obj.DepartmentName });
                    parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                    parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
                    var spName = "SP_Department";
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
