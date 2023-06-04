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
    public class BatchController : Controller
    {
        private IConfiguration _config;
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        public BatchController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("CrudBatch")]
        public string CrudBatch([FromBody] EPOS_API.Model.BatchModel obj)
        {
            var response = Crud_Batch(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic Crud_Batch(EPOS_API.Model.BatchModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {
                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });
                    parm.Add(new SqlParameter() { ParameterName = "@BatchId", SqlDbType = SqlDbType.Int, Value = obj.BatchId });
                    parm.Add(new SqlParameter() { ParameterName = "@ProductDetailId", SqlDbType = SqlDbType.Int, Value = obj.ProductDetailId });
                    parm.Add(new SqlParameter() { ParameterName = "@BatchNumber", SqlDbType = SqlDbType.NVarChar, Value = obj.BatchNumber });
                    parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                    parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
                    parm.Add(new SqlParameter() { ParameterName = "@Quantity", SqlDbType = SqlDbType.Float, Value = obj.Quantity });
                    parm.Add(new SqlParameter() { ParameterName = "@Price", SqlDbType = SqlDbType.Float, Value = obj.Price });
                    parm.Add(new SqlParameter() { ParameterName = "@ManufactureDate", SqlDbType = SqlDbType.NVarChar, Value = (obj.ManufactureDate == "" || obj.ManufactureDate == null) ? null : Convert.ToDateTime(obj.ManufactureDate)});
                    parm.Add(new SqlParameter() { ParameterName = "@ExpiryDate", SqlDbType = SqlDbType.NVarChar, Value = (obj.ExpiryDate == "" || obj.ExpiryDate == null) ? null : Convert.ToDateTime(obj.ExpiryDate) });
                    parm.Add(new SqlParameter() { ParameterName = "@CategoryId", SqlDbType = SqlDbType.Int, Value = obj.CategoryId });
                    parm.Add(new SqlParameter() { ParameterName = "@ProductId", SqlDbType = SqlDbType.Int, Value = obj.ProductId });
                    parm.Add(new SqlParameter() { ParameterName = "@ProductSizeId", SqlDbType = SqlDbType.Int, Value = obj.ProductSizeId });
                    parm.Add(new SqlParameter() { ParameterName = "@FlavorId", SqlDbType = SqlDbType.Int, Value = obj.FlavorId });

                    var spName = "SP_Batch";
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
