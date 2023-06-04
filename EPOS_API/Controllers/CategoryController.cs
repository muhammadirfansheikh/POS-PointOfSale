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
    public class CategoryController : ControllerBase
    {

        private IConfiguration _config;

        public IHostingEnvironment webHosting;
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        public CategoryController(IConfiguration config, IHostingEnvironment hosting)
        {
            _config = config;
            webHosting = hosting;
        }
        [HttpPost("CrudCategory")]
        public string CrudCategory([FromForm] EPOS_API.Model.CategoryModel obj)
        {
            var response = Crud_Category(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic Crud_Category(EPOS_API.Model.CategoryModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {

                    var filePath = (obj.OperationId == 3 || obj.OperationId == 2) ? saveImage(obj, HttpContext) : "";

                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });
                    parm.Add(new SqlParameter() { ParameterName = "@CategoryId", SqlDbType = SqlDbType.Int, Value = obj.CategoryId });
                    parm.Add(new SqlParameter() { ParameterName = "@DepartmentId", SqlDbType = SqlDbType.Int, Value = obj.DepartmentId });
                    parm.Add(new SqlParameter() { ParameterName = "@CategoryName", SqlDbType = SqlDbType.NVarChar, Value = obj.CategoryName });
                    parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                    parm.Add(new SqlParameter() { ParameterName = "@CategoryImage", SqlDbType = SqlDbType.NVarChar, Value = filePath });
                    parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
                    var spName = "SP_Category";
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

        public string saveImage([FromForm] EPOS_API.Model.CategoryModel obj, HttpContext context)
        {
            if (HttpContext.Request.Form.Files.Count > 0)
            {
                IFormFile postedFile = HttpContext.Request.Form.Files[0];
                string uniqueFileName = null;

                var extension = Path.GetExtension(postedFile.FileName);

                string ImageName = "\\CategoryImages\\" + Guid.NewGuid().ToString() + extension;
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
