using EPOS_API.Data;
using EPOS_API.Model;
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
    public class InventoryAdjustmentController : Controller
    {
        private IConfiguration _config;
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        public InventoryAdjustmentController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("CrudAdjustment")]
        public string CrudAdjustment([FromBody] EPOS_API.Model.AdjustmentModel obj)
        {
            var response = Crud_Adjustment(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        private dynamic Crud_Adjustment(EPOS_API.Model.AdjustmentModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {
                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });
                    parm.Add(new SqlParameter() { ParameterName = "@BranchId", SqlDbType = SqlDbType.Int, Value = obj.BranchId });
                    parm.Add(new SqlParameter() { ParameterName = "@AdjustmentId", SqlDbType = SqlDbType.Int, Value = obj.AdjustmentId });
                    parm.Add(new SqlParameter() { ParameterName = "@AdjustmentNumber", SqlDbType = SqlDbType.NVarChar, Value = obj.AdjustmentNumber });
                    parm.Add(new SqlParameter() { ParameterName = "@Date", SqlDbType = SqlDbType.NVarChar, Value = obj.Date });
                    parm.Add(new SqlParameter() { ParameterName = "@IsSubmit", SqlDbType = SqlDbType.Bit, Value = obj.IsSubmit });
                    parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                    parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
                    parm.Add(new SqlParameter()
                    {
                        ParameterName = "@AdjustmentDetail",
                        SqlDbType = SqlDbType.Structured,
                        Value = obj.AdjustmentDetail.Count == 0 ? null :
                        CommonObjects.ToDataTable(obj.AdjustmentDetail.AsEnumerable().ToList())
                    });

                    var spName = "SP_AdjustmentInventory";
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
