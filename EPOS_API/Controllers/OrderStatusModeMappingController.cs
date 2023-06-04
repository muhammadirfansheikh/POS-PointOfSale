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
    public class OrderStatusModeMappingController : Controller
    {

        private IConfiguration _config;
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        public OrderStatusModeMappingController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("CrudOrderStatusModeMapping")]
        public string CrudOrderStatusModeMapping([FromBody] EPOS_API.Model.OrderStatusModeMappingModel obj)
        {
            if (obj != null)
            {
                var response = CrudOrderStatusModeMapping(obj, HttpContext);
                string json = JsonConvert.SerializeObject(response, Formatting.Indented);
                return json;
            }
            return JsonConvert.SerializeObject(CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, "Bad request"), Formatting.Indented) ;
            
        }
        private dynamic CrudOrderStatusModeMapping(EPOS_API.Model.OrderStatusModeMappingModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {

                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                    parm.Add(new SqlParameter() { ParameterName = "@OrderStatusModeMappingId", SqlDbType = SqlDbType.Int, Value = obj.OrderStatusModeMappingId });
                    parm.Add(new SqlParameter() { ParameterName = "@OrderStatusId", SqlDbType = SqlDbType.Int, Value = obj.OrderStatusId });
                    parm.Add(new SqlParameter() { ParameterName = "@OrderModeId", SqlDbType = SqlDbType.Int, Value = obj.OrderModeId });
                    parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
                    parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId});
                    parm.Add(new SqlParameter() { ParameterName = "@IsActive", SqlDbType = SqlDbType.Int, Value = obj.IsActive});
                    
                    var spName = "SP_CRUD_OrderStatusModeMapping";
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
