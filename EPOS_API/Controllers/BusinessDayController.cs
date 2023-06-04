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
    public class BusinessDayController : Controller
    {
        private IConfiguration _config;
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        public BusinessDayController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("BusinessDayShiftTerminal")]
        public string UpdateOrderStatus([FromBody] EPOS_API.Model.BusinessDayModel obj)
        {
            var response = Update_Order_Status(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic Update_Order_Status(EPOS_API.Model.BusinessDayModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {
                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });
                    parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                    parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
                    parm.Add(new SqlParameter() { ParameterName = "@BranchId", SqlDbType = SqlDbType.Int, Value = obj.BranchId });
                    parm.Add(new SqlParameter() { ParameterName = "@BusinessDayId", SqlDbType = SqlDbType.Int, Value = obj.BusinessDayId });
                    parm.Add(new SqlParameter() { ParameterName = "@ShiftDetailId", SqlDbType = SqlDbType.Int, Value = obj.ShiftDetailId });
                    parm.Add(new SqlParameter() { ParameterName = "@TerminalDetailId", SqlDbType = SqlDbType.Int, Value = obj.TerminalDetailId });
                    parm.Add(new SqlParameter() { ParameterName = "@ShiftId", SqlDbType = SqlDbType.Int, Value = obj.ShiftId });
                    parm.Add(new SqlParameter() { ParameterName = "@TerminalId", SqlDbType = SqlDbType.Int, Value = obj.TerminalId });
                    parm.Add(new SqlParameter() { ParameterName = "@TerminalOpeningAmount", SqlDbType = SqlDbType.Int, Value = obj.TerminalOpeningAmount });
                    parm.Add(new SqlParameter() { ParameterName = "@TerminalClosingAmount", SqlDbType = SqlDbType.Int, Value = obj.TerminalClosingAmount });
                    parm.Add(new SqlParameter() { ParameterName = "@UniqueId", SqlDbType = SqlDbType.NVarChar, Value = obj.UniqueId });



                    var spName = "SP_BusinessDayShiftTerminal";

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
