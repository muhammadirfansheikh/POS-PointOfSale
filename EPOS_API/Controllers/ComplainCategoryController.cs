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
    public class ComplainCategoryController : Controller
    {
        private IConfiguration _config;
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        public ComplainCategoryController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("CrudComplainCategory")]
        public string CrudComplainCategory([FromBody] EPOS_API.Model.ComplainCategoryModel obj)
        {
            var response = Crud_ComplainCategory(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic Crud_ComplainCategory(EPOS_API.Model.ComplainCategoryModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {

                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });
                    parm.Add(new SqlParameter() { ParameterName = "@ComplainCategoryId", SqlDbType = SqlDbType.Int, Value = obj.ComplainCategoryId });
                    parm.Add(new SqlParameter() { ParameterName = "@ComplainCategoryName", SqlDbType = SqlDbType.NVarChar, Value = obj.ComplainCategoryName });
                    parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                    parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
                    parm.Add(new SqlParameter() { ParameterName = "@ComplainTypeId", SqlDbType = SqlDbType.Int, Value = obj.ComplainTypeId });

                    var spName = "SP_ComplainCategory";
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

        [HttpPost("CrudComplain")]
        public string CrudComplain([FromBody] EPOS_API.Model.ComplainModel obj)
        {
            var response = Crud_Complain(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic Crud_Complain(EPOS_API.Model.ComplainModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {

                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });
                    parm.Add(new SqlParameter() { ParameterName = "@OrderMasterId", SqlDbType = SqlDbType.Int, Value = obj.OrderMasterId });
                    parm.Add(new SqlParameter() { ParameterName = "@ComplainMasterId", SqlDbType = SqlDbType.Int, Value = obj.ComplainMasterId });
                    parm.Add(new SqlParameter() { ParameterName = "@ComplainStatusId", SqlDbType = SqlDbType.Int, Value = obj.ComplainStatusId });
                    parm.Add(new SqlParameter() { ParameterName = "@ComplainTypeId", SqlDbType = SqlDbType.Int, Value = obj.ComplainTypeId });
                    parm.Add(new SqlParameter() { ParameterName = "@ComplainCategoryId", SqlDbType = SqlDbType.Int, Value = obj.ComplainCategoryId });
                    parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                    parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
                    parm.Add(new SqlParameter() { ParameterName = "@Remarks", SqlDbType = SqlDbType.NVarChar, Value = obj.Remarks });
                    parm.Add(new SqlParameter() { ParameterName = "@ComplainNumber", SqlDbType = SqlDbType.NVarChar, Value = obj.ComplainNumber });

                    var spName = "SP_CrudComplain";
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
