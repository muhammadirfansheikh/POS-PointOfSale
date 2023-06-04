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
    public class BranchController : Controller
    {

        private IConfiguration _config;
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        public BranchController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("CrudBranch")]
        public string CrudBranch([FromBody] EPOS_API.Model.BranchModel obj)
        {
            var response = CrudBranch(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic CrudBranch(EPOS_API.Model.BranchModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {

                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });
                    parm.Add(new SqlParameter() { ParameterName = "@BranchId", SqlDbType = SqlDbType.Int, Value = obj.BranchId });
                    parm.Add(new SqlParameter() { ParameterName = "@IsWarehouse", SqlDbType = SqlDbType.Bit, Value = obj.IsWarehouse });
                    parm.Add(new SqlParameter() { ParameterName = "@BranchName", SqlDbType = SqlDbType.NVarChar, Value = obj.BranchName });
                    parm.Add(new SqlParameter() { ParameterName = "@CityId", SqlDbType = SqlDbType.Int, Value = obj.CityId });
                    parm.Add(new SqlParameter() { ParameterName = "@NTNNumber", SqlDbType = SqlDbType.NVarChar, Value = obj.NTNNumber });
                    parm.Add(new SqlParameter() { ParameterName = "@NTNName", SqlDbType = SqlDbType.NVarChar, Value = obj.NTNName });
                    parm.Add(new SqlParameter() { ParameterName = "@BusinessDayStartTime", SqlDbType = SqlDbType.DateTime, Value = Convert.ToDateTime(obj.BusinessDayStartTime) });
                    parm.Add(new SqlParameter() { ParameterName = "@BusinessDayEndTime", SqlDbType = SqlDbType.DateTime, Value = Convert.ToDateTime(obj.BusinessDayEndTime) });
                    parm.Add(new SqlParameter() { ParameterName = "@IsCallCenter", SqlDbType = SqlDbType.Bit, Value = obj.IsCallCenter });
                    parm.Add(new SqlParameter() { ParameterName = "@IsEnable", SqlDbType = SqlDbType.Bit, Value = obj.IsEnable });
                    parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                    parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
                    parm.Add(new SqlParameter() { ParameterName = "@BranchDetail", SqlDbType = SqlDbType.Structured, Value = CommonObjects.ToDataTable(obj.BranchDetail.AsEnumerable().ToList()) });
                    var spName = "SP_BranchMaster";


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
