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

namespace EPOS_API.Model
{
    public class IssuanceController : Controller
    {
        private IConfiguration _config;
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        public IssuanceController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("CrudIssuance")]
        public string CrudIssuance([FromBody] EPOS_API.Model.IssuanceModel obj)
        {
            var response = Crud_Issuance(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic Crud_Issuance(EPOS_API.Model.IssuanceModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {
                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });
                    parm.Add(new SqlParameter() { ParameterName = "@BranchId", SqlDbType = SqlDbType.Int, Value = obj.BranchId });
                    parm.Add(new SqlParameter() { ParameterName = "@IssuanceMasterId", SqlDbType = SqlDbType.Int, Value = obj.IssuanceMasterId });
                    parm.Add(new SqlParameter() { ParameterName = "@DemandMasterId", SqlDbType = SqlDbType.Int, Value = obj.DemandMasterId });
                    parm.Add(new SqlParameter() { ParameterName = "@TotalIssuanceQuantity", SqlDbType = SqlDbType.Float, Value = obj.TotalIssuanceQuantity });
                    parm.Add(new SqlParameter() { ParameterName = "@IsSubmit", SqlDbType = SqlDbType.Bit, Value = obj.IsSubmit });
                    parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                    parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
                    parm.Add(new SqlParameter() { ParameterName = "@IssuanceDetailList", SqlDbType = SqlDbType.Structured, Value = obj.IssuanceDetailList.Count == 0 ? null : CommonObjects.ToDataTable(obj.IssuanceDetailList.AsEnumerable().ToList()) });
                    parm.Add(new SqlParameter() { ParameterName = "@IssuanceDate", SqlDbType = SqlDbType.NVarChar, Value = obj.IssuanceDate });
                    parm.Add(new SqlParameter() { ParameterName = "@IssuanceNumber", SqlDbType = SqlDbType.NVarChar, Value = obj.IssuanceNumber });


                    var spName = "SP_CrudIssuance";
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
