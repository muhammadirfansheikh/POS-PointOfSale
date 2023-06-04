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
    public class WaiterController : Controller
    {
        private IConfiguration _config;
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        public WaiterController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("CrudWaiter")]
        public string CrudWaiter([FromBody] EPOS_API.Model.WaiterModal obj)
        {
            var response = CrudWaiter(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic CrudWaiter(EPOS_API.Model.WaiterModal obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {

                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });
                    parm.Add(new SqlParameter() { ParameterName = "@WaiterId", SqlDbType = SqlDbType.Int, Value = obj.WaiterId });
                    parm.Add(new SqlParameter() { ParameterName = "@WaiterName", SqlDbType = SqlDbType.NVarChar, Value = obj.WaiterName });
                    parm.Add(new SqlParameter() { ParameterName = "@WaiterCnic", SqlDbType = SqlDbType.NVarChar, Value = obj.WaiterCnic });
                    parm.Add(new SqlParameter() { ParameterName = "@Contact1", SqlDbType = SqlDbType.NVarChar, Value = obj.Contact1 });
                    parm.Add(new SqlParameter() { ParameterName = "@Contact2", SqlDbType = SqlDbType.NVarChar, Value = obj.Contact2 });
                    parm.Add(new SqlParameter() { ParameterName = "@Address", SqlDbType = SqlDbType.NVarChar, Value = obj.Address });
                    parm.Add(new SqlParameter() { ParameterName = "@BranchId", SqlDbType = SqlDbType.Int, Value = obj.BranchId });
                    parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                    parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });

                    var spName = "SP_Waiter";
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
