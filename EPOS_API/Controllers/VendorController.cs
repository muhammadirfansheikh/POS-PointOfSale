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
    public class VendorController : ControllerBase
    {

        private IConfiguration _config;
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        public VendorController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("CrudVendor")]
        public string CrudVendor([FromBody] EPOS_API.Model.VendorModel obj)
        {
            var response = Crud_Vendor(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic Crud_Vendor(EPOS_API.Model.VendorModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {

                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });
                    parm.Add(new SqlParameter() { ParameterName = "@VendorId", SqlDbType = SqlDbType.Int, Value = obj.VendorId });
                    parm.Add(new SqlParameter() { ParameterName = "@VendorName", SqlDbType = SqlDbType.NVarChar, Value = obj.VendorName });
                    parm.Add(new SqlParameter() { ParameterName = "@Address", SqlDbType = SqlDbType.NVarChar, Value = obj.Address });
                    parm.Add(new SqlParameter() { ParameterName = "@ContactNumber", SqlDbType = SqlDbType.NVarChar, Value = obj.ContactNumber });
                    parm.Add(new SqlParameter() { ParameterName = "@Email", SqlDbType = SqlDbType.NVarChar, Value = obj.Email });
                    parm.Add(new SqlParameter() { ParameterName = "@PocDetail", SqlDbType = SqlDbType.Structured, Value = (obj.PocDetail.Count == 0 || obj.PocDetail == null) ? null : CommonObjects.ToDataTable(obj.PocDetail.AsEnumerable().ToList()) });
                    parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
                    parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                    var spName = "SP_Vendor";


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
