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
    public class DemandController : ControllerBase
    {

        private IConfiguration _config;
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        public DemandController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("CrudDemand")]
        public string CrudDemand([FromBody] EPOS_API.Model.DemandModel obj)
        {
            var response = Crud_Demand(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic Crud_Demand(EPOS_API.Model.DemandModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {
                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });
                    parm.Add(new SqlParameter() { ParameterName = "@BranchId", SqlDbType = SqlDbType.Int, Value = obj.BranchId });
                    parm.Add(new SqlParameter() { ParameterName = "@DemandMasterId", SqlDbType = SqlDbType.Int, Value = obj.DemandMasterId });
                    parm.Add(new SqlParameter() { ParameterName = "@StatusId", SqlDbType = SqlDbType.Int, Value = obj.StatusId });
                    parm.Add(new SqlParameter() { ParameterName = "@IsSubmit", SqlDbType = SqlDbType.Bit, Value = obj.IsSubmit });
                    parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                    parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
                    parm.Add(new SqlParameter() { ParameterName = "@DemandDetailList", SqlDbType = SqlDbType.Structured, Value = obj.DemandDetailList.Count == 0 ? null : CommonObjects.ToDataTable(obj.DemandDetailList.AsEnumerable().ToList()) });
                    parm.Add(new SqlParameter() { ParameterName = "@DemandDate", SqlDbType = SqlDbType.NVarChar, Value = obj.DemandDate });
                    parm.Add(new SqlParameter() { ParameterName = "@DemandNumber", SqlDbType = SqlDbType.NVarChar, Value = obj.DemandNumber });

                    var spName = "SP_CrudDemand";
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
