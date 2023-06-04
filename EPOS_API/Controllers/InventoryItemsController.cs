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
    public class InventoryItemsController : Controller
    {
        private IConfiguration _config;
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        public InventoryItemsController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("InventoryItem")]
        public string CrudInventoryItem([FromBody] EPOS_API.Model.InventoryItemsModel obj)
        {
            var response = Crud_InventoryItem(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic Crud_InventoryItem(EPOS_API.Model.InventoryItemsModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {
                    DataTable dt = new DataTable("ProductDetailBarcode");

                    dt.Columns.Add("Product", typeof(int));
                    dt.Columns.Add("ProductCode", typeof(string));

                    dt.Rows.Add(0, "");

                    List<SqlParameter> parm = new List<SqlParameter>();
                
                    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });
                    parm.Add(new SqlParameter() { ParameterName = "@ProductDetailId", SqlDbType = SqlDbType.Int, Value = obj.ProductDetailId });
                    parm.Add(new SqlParameter() { ParameterName = "@ProductId", SqlDbType = SqlDbType.Int, Value = obj.ProductId });
                    parm.Add(new SqlParameter() { ParameterName = "@Price", SqlDbType = SqlDbType.Float, Value = obj.Price });
                    parm.Add(new SqlParameter() { ParameterName = "@ReOrderQuantity", SqlDbType = SqlDbType.Float, Value = obj.ReOrderQuantity });
                    parm.Add(new SqlParameter() { ParameterName = "@TaxPercent", SqlDbType = SqlDbType.Float, Value = obj.TaxPercent });
                    parm.Add(new SqlParameter() { ParameterName = "@OnlyForDeal", SqlDbType = SqlDbType.Bit, Value = obj.OnlyForDeal });
                    parm.Add(new SqlParameter() { ParameterName = "@IsEnable", SqlDbType = SqlDbType.Bit, Value = obj.IsEnable });
                    parm.Add(new SqlParameter() { ParameterName = "@BranchIds", SqlDbType = SqlDbType.NVarChar, Value = obj.BranchIds });
                    parm.Add(new SqlParameter() { ParameterName = "@SizeId", SqlDbType = SqlDbType.Int, Value = obj.SizeId });
                    parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                    parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
                    parm.Add(new SqlParameter() { ParameterName = "@FlavorId", SqlDbType = SqlDbType.Int, Value = obj.FlavorId });
                    parm.Add(new SqlParameter() { ParameterName = "@CategoryId", SqlDbType = SqlDbType.Int, Value = obj.CategoryId });
                    parm.Add(new SqlParameter()
                    {
                        ParameterName = "@BarcodeDetail",
                        SqlDbType = SqlDbType.Structured,
                        Value = obj.ProductDetailBarcode.Count == 0 ? dt :
                        CommonObjects.ToDataTable(obj.ProductDetailBarcode.AsEnumerable().ToList())
                    });



                    parm.Add(new SqlParameter() { ParameterName = "@IsSaleable", SqlDbType = SqlDbType.Bit, Value = obj.IsSaleable });
                    parm.Add(new SqlParameter() { ParameterName = "@IsProduction", SqlDbType = SqlDbType.Bit, Value = obj.IsProduction });
                    parm.Add(new SqlParameter() { ParameterName = "@IssuanceUnitId", SqlDbType = SqlDbType.Int, Value = obj.IssuanceUnitId });
                    parm.Add(new SqlParameter() { ParameterName = "@ConsumeUnitId", SqlDbType = SqlDbType.Int, Value = obj.ConsumeUnitId });
                    parm.Add(new SqlParameter() { ParameterName = "@PurchaseUnitId", SqlDbType = SqlDbType.Int, Value = obj.PurchaseUnitId });
                    parm.Add(new SqlParameter() { ParameterName = "@PurchaseIssueConversion", SqlDbType = SqlDbType.Float, Value = obj.PurchaseIssueConversion });
                    parm.Add(new SqlParameter() { ParameterName = "@IssueConsumeConversion", SqlDbType = SqlDbType.Float, Value = obj.IssueConsumeConversion });
                    parm.Add(new SqlParameter() { ParameterName = "@SKU", SqlDbType = SqlDbType.NVarChar, Value = obj.SKU });
                    parm.Add(new SqlParameter() { ParameterName = "@ParentProductDetailId", SqlDbType = SqlDbType.Int, Value = obj.ParentProductDetailId });

                    var spName = "SP_InventoryItems";
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
