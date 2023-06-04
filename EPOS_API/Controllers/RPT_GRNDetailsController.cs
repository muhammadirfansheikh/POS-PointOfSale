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

namespace EPOS_API.Controllers
{
    public class RPT_GRNDetailsController : Controller
    {
        private IConfiguration _config;
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        public RPT_GRNDetailsController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("CrudRPTGRNDetail")]
        public string RPT_GRNDetail([FromBody] EPOS_API.Model.RPT_GRNDetailsModel obj)
        {
            var response = Crud_RPT_GRNDetail(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic Crud_RPT_GRNDetail(EPOS_API.Model.RPT_GRNDetailsModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {

                    //if (obj.GRId.ToString().Length > 1 ) { responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure); }
                    //else
                    //{
                    //    responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success);
                    //}
                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@GRNId", SqlDbType = SqlDbType.Int, Value = obj.GRId });
                    parm.Add(new SqlParameter() { ParameterName = "@BranchId", SqlDbType = SqlDbType.Int, Value = obj.BranchId });
                    parm.Add(new SqlParameter() { ParameterName = "@DateFrom", SqlDbType = SqlDbType.NVarChar, Value = obj.DateFrom });
                    parm.Add(new SqlParameter() { ParameterName = "@DateTo", SqlDbType = SqlDbType.NVarChar, Value = obj.DateTo });

                    var spName = "SP_RPT_GRNDetails";
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
