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
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
namespace EPOS_API.Controllers
{
    public class ProductController : Controller
    {
        private IConfiguration _config;
        public IHostingEnvironment webHosting;
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        public ProductController(IConfiguration config, IHostingEnvironment hosting)
        {
            _config = config;
            webHosting = hosting;
        }
        [HttpPost("CrudProduct")]
        public string CrudProduct([FromForm] EPOS_API.Model.ProductModel obj)
        {
            var response = Crud_Prodcut(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic Crud_Prodcut(EPOS_API.Model.ProductModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {
                    var filePath = (obj.OperationId == 3 || obj.OperationId == 2) ? saveProductImage(obj, HttpContext) : "";

                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });
                    parm.Add(new SqlParameter() { ParameterName = "@ProductId", SqlDbType = SqlDbType.Int, Value = obj.ProductId });
                    parm.Add(new SqlParameter() { ParameterName = "@ProductCategoryId", SqlDbType = SqlDbType.Int, Value = obj.ProductCategoryId });
                    parm.Add(new SqlParameter() { ParameterName = "@ProductName", SqlDbType = SqlDbType.NVarChar, Value = obj.ProductName });
                    parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                    parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
                    parm.Add(new SqlParameter() { ParameterName = "@DisplayInPos", SqlDbType = SqlDbType.Bit, Value = obj.DisplayInPos });
                    parm.Add(new SqlParameter() { ParameterName = "@DisplayInWeb", SqlDbType = SqlDbType.Bit, Value = obj.DisplayInWeb });
                    parm.Add(new SqlParameter() { ParameterName = "@DisplayInOdms", SqlDbType = SqlDbType.Bit, Value = obj.DisplayInOdms });
                    parm.Add(new SqlParameter() { ParameterName = "@DisplayInMobile", SqlDbType = SqlDbType.Bit, Value = obj.DisplayInMobile });
                    parm.Add(new SqlParameter() { ParameterName = "@IsDeal", SqlDbType = SqlDbType.Bit, Value = obj.IsDeal });
                    parm.Add(new SqlParameter() { ParameterName = "@ProductImage", SqlDbType = SqlDbType.NVarChar, Value = filePath });
                    parm.Add(new SqlParameter() { ParameterName = "@IsExpiryMandatory", SqlDbType = SqlDbType.Bit, Value = obj.IsExpiryMandatory });

                    var spName = "SP_Product";
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
        public string saveProductImage([FromForm] EPOS_API.Model.ProductModel obj, HttpContext context)
        {
            if (HttpContext.Request.Form.Files.Count > 0)
            {
                IFormFile postedFile = HttpContext.Request.Form.Files[0];
                string uniqueFileName = null;

                var extension = Path.GetExtension(postedFile.FileName);

                string ImageName = "\\ProductImages\\" + Guid.NewGuid().ToString() + extension;
                uniqueFileName = webHosting.ContentRootPath + "\\wwwroot" + ImageName;


                string filePath = Path.Combine("", uniqueFileName);
                using (var fileStream = new FileStream(uniqueFileName, FileMode.Create))
                {
                    postedFile.CopyTo(fileStream);
                }
                return ImageName;
            }
            else
            {
                return "";
            }
        }
    }
}