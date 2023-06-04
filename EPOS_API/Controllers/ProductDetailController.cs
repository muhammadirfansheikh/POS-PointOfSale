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
    public class ProductDetailController : ControllerBase
    {
        private IConfiguration _config;
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        public ProductDetailController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("CrudProductDetail")]
        public string CrudProductDetail([FromBody] EPOS_API.Model.ProductDetail obj)
        {
            var response = Crud_ProductDetail(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic Crud_ProductDetail(EPOS_API.Model.ProductDetail obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {
                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });
                    parm.Add(new SqlParameter() { ParameterName = "@ProductDetailId", SqlDbType = SqlDbType.Int, Value = obj.ProductDetailId });
                    parm.Add(new SqlParameter() { ParameterName = "@ProductId", SqlDbType = SqlDbType.Int, Value = obj.ProductId });
                    parm.Add(new SqlParameter() { ParameterName = "@Price", SqlDbType = SqlDbType.Float, Value = obj.Price });
                    parm.Add(new SqlParameter() { ParameterName = "@TaxPercent", SqlDbType = SqlDbType.Float, Value = obj.TaxPercent });
                    parm.Add(new SqlParameter() { ParameterName = "@OnlyForDeal", SqlDbType = SqlDbType.Bit, Value = obj.OnlyForDeal });
                    parm.Add(new SqlParameter() { ParameterName = "@IsTopping", SqlDbType = SqlDbType.Bit, Value = obj.IsTopping });
                    parm.Add(new SqlParameter() { ParameterName = "@IsEnable", SqlDbType = SqlDbType.Bit, Value = obj.IsEnable });
                    parm.Add(new SqlParameter() { ParameterName = "@BranchIds", SqlDbType = SqlDbType.NVarChar, Value = obj.BranchIds });
                    parm.Add(new SqlParameter() { ParameterName = "@SizeId", SqlDbType = SqlDbType.Int, Value = obj.SizeId });
                    parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                    parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
                    parm.Add(new SqlParameter() { ParameterName = "@FlavorId", SqlDbType = SqlDbType.Int, Value = obj.FlavorId });
                    parm.Add(new SqlParameter() { ParameterName = "@CategoryId", SqlDbType = SqlDbType.Int, Value = obj.CategoryId });
                    parm.Add(new SqlParameter() { ParameterName = "@BarcodeDetail", SqlDbType = SqlDbType.Structured, Value = CommonObjects.ToDataTable(obj.ProductDetailBarcode.AsEnumerable().ToList()) });
                    parm.Add(new SqlParameter() { ParameterName = "@ProductDetailProperty", SqlDbType = SqlDbType.Structured, Value = CommonObjects.ToDataTable(obj.ProductDetailProperty.AsEnumerable().ToList()) });

                    var spName = "SP_ProductDetail";
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
        private dynamic Crud_ProductDetailMapping(EPOS_API.Model.ProductDetailMapping obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {
                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });
                    parm.Add(new SqlParameter() { ParameterName = "@BranchId", SqlDbType = SqlDbType.Int, Value = obj.BranchId });
                    parm.Add(new SqlParameter() { ParameterName = "@CategoryId", SqlDbType = SqlDbType.Int, Value = obj.CategoryId });
                    parm.Add(new SqlParameter() { ParameterName = "@ProductId", SqlDbType = SqlDbType.Int, Value = obj.ProductId });
                    parm.Add(new SqlParameter() { ParameterName = "@SizeId", SqlDbType = SqlDbType.Int, Value = obj.SizeId });
                    parm.Add(new SqlParameter() { ParameterName = "@VariantId", SqlDbType = SqlDbType.Int, Value = obj.VariantId });
                    parm.Add(new SqlParameter() { ParameterName = "@CityId", SqlDbType = SqlDbType.Int, Value = obj.CityId });
                    parm.Add(new SqlParameter() { ParameterName = "@ProductBranchId", SqlDbType = SqlDbType.Int, Value = obj.ProductBranchId });
                    parm.Add(new SqlParameter() { ParameterName = "@IsEnable", SqlDbType = SqlDbType.Bit, Value = obj.IsEnable });
                    parm.Add(new SqlParameter() { ParameterName = "@ValidFrom", SqlDbType = SqlDbType.NVarChar, Value = obj.ValidFrom });
                    parm.Add(new SqlParameter() { ParameterName = "@ValidTo", SqlDbType = SqlDbType.NVarChar, Value = obj.ValidTo });
                    parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                    parm.Add(new SqlParameter() { ParameterName = "@ProductAvailability", SqlDbType = SqlDbType.Structured, Value = obj.ProductAvailability == null ? null :
                        CommonObjects.ToDataTable(obj.ProductAvailability.AsEnumerable().ToList()) });

                    var spName = "SP_ProductMapping";
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
        
        [HttpPost("CrudProductDetailMapping")]
        public string CrudProductDetailMapping([FromBody] EPOS_API.Model.ProductDetailMapping obj)
        {
            var response = Crud_ProductDetailMapping(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
    }
}
