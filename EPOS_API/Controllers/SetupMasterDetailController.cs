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
    public class SetupMasterDetailController : Controller
    {
        private IConfiguration _config;
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        public SetupMasterDetailController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("CrudMasterDetail")]
        public string CrudBranch([FromBody] EPOS_API.Model.SetupMasterDetailModel obj)
        {
            var response = CrudMasterDetail(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic CrudMasterDetail(EPOS_API.Model.SetupMasterDetailModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {
                    DataSet obj_response = Crud_MasterDetail(obj);

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

        [HttpPost("GetBusinessTypeList")]
        public string GetBusinessTypeList([FromBody] EPOS_API.Model.SetupMasterDetailModel obj)
        {
            var response = Get_BusinessTypeList(obj);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic Get_BusinessTypeList(EPOS_API.Model.SetupMasterDetailModel obj)
        {
            try
            {
                obj.SetupMasterId = 1;
                obj.CompanyId = null;
                DataSet obj_response = Crud_MasterDetail(obj);

                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }

                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }

        private DataSet Crud_MasterDetail(EPOS_API.Model.SetupMasterDetailModel obj)
        {
            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
            parm.Add(new SqlParameter() { ParameterName = "@SetupMasterId", SqlDbType = SqlDbType.Int, Value = obj.SetupMasterId });
            parm.Add(new SqlParameter() { ParameterName = "@ParentId", SqlDbType = SqlDbType.Int, Value = obj.ParentId });
            parm.Add(new SqlParameter() { ParameterName = "@SetupDetailName", SqlDbType = SqlDbType.NVarChar, Value = obj.SetupDetailName });
            parm.Add(new SqlParameter() { ParameterName = "@Flex1", SqlDbType = SqlDbType.NVarChar, Value = obj.Flex1 });
            parm.Add(new SqlParameter() { ParameterName = "@Flex2", SqlDbType = SqlDbType.NVarChar, Value = obj.Flex2 });
            parm.Add(new SqlParameter() { ParameterName = "@Flex3", SqlDbType = SqlDbType.NVarChar, Value = obj.Flex3 });
            parm.Add(new SqlParameter() { ParameterName = "@SetupDetailId", SqlDbType = SqlDbType.Int, Value = obj.SetupDetailId });
            parm.Add(new SqlParameter() { ParameterName = "@CreatedBy", SqlDbType = SqlDbType.Int, Value = obj.UserId });
            parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
            parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });

            var spName = "SP_MasterDetail_Operation";

            DataSet obj_response = new DapperManager(_config.GetConnectionString("MyConnection")).GetDataSet(spName, parm.ToArray());

            return obj_response;
        }
    }
}
