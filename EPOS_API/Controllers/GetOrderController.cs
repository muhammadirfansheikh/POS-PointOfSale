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
    public class GetOrderController : Controller
    {
        private IConfiguration _config;
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        public GetOrderController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("GetOrder")]
        public string GetOrder([FromBody] EPOS_API.Model.GetOrderModel obj)
        {
            var response = GetOrder(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        private dynamic GetOrder(EPOS_API.Model.GetOrderModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {

                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });
                    parm.Add(new SqlParameter() { ParameterName = "@AreaId", SqlDbType = SqlDbType.Int, Value = obj.AreaId });
                    parm.Add(new SqlParameter() { ParameterName = "@BranchId", SqlDbType = SqlDbType.Int, Value = obj.BranchId });
                    parm.Add(new SqlParameter() { ParameterName = "@OrderNumber", SqlDbType = SqlDbType.NVarChar, Value = obj.OrderNumber });
                    parm.Add(new SqlParameter() { ParameterName = "@CustomerId", SqlDbType = SqlDbType.Int, Value = obj.CustomerId });
                    parm.Add(new SqlParameter() { ParameterName = "@CustomerName", SqlDbType = SqlDbType.NVarChar, Value = obj.CustomerName });
                    parm.Add(new SqlParameter() { ParameterName = "@CustomerPhone", SqlDbType = SqlDbType.NVarChar, Value = obj.CustomerPhone });
                    parm.Add(new SqlParameter() { ParameterName = "@OrderModeId", SqlDbType = SqlDbType.Int, Value = obj.OrderModeId });
                    parm.Add(new SqlParameter() { ParameterName = "@OrderSourceId", SqlDbType = SqlDbType.Int, Value = obj.OrderSourceId });
                    parm.Add(new SqlParameter() { ParameterName = "@DateFrom", SqlDbType = SqlDbType.NVarChar, Value = obj.DateFrom });
                    parm.Add(new SqlParameter() { ParameterName = "@DateTo", SqlDbType = SqlDbType.NVarChar, Value = obj.DateTo });
                    parm.Add(new SqlParameter() { ParameterName = "@StatusId", SqlDbType = SqlDbType.Int, Value = obj.StatusId });
                    parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                    parm.Add(new SqlParameter() { ParameterName = "@CityId", SqlDbType = SqlDbType.Int, Value = obj.CityId });

                    var spName = "SP_GetOrder";
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
