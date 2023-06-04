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
    public class RecipeController : Controller
    {
        private IConfiguration _config;
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        public RecipeController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("CrudRecipe")]
        public string CrudRecipe([FromBody] EPOS_API.Model.RecipeModel obj)
        {
            var response = Crud_Recipe(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic Crud_Recipe(EPOS_API.Model.RecipeModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {

                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });
                    parm.Add(new SqlParameter() { ParameterName = "@RecipeId", SqlDbType = SqlDbType.Int, Value = obj.RecipeId });
                    parm.Add(new SqlParameter() { ParameterName = "@CategoryId", SqlDbType = SqlDbType.Int, Value = obj.CategoryId });
                    parm.Add(new SqlParameter() { ParameterName = "@ProductDetailId", SqlDbType = SqlDbType.Int, Value = obj.ProductDetailId });
                    parm.Add(new SqlParameter() { ParameterName = "@SubRecipeItemId", SqlDbType = SqlDbType.Int, Value = obj.SubRecipeItemId });
                    parm.Add(new SqlParameter() { ParameterName = "@ItemCode", SqlDbType = SqlDbType.NVarChar, Value = obj.ItemCode });
                    parm.Add(new SqlParameter() { ParameterName = "@ProductName", SqlDbType = SqlDbType.NVarChar, Value = obj.ProductName });
                    parm.Add(new SqlParameter() { ParameterName = "@RecipeDetail", SqlDbType = SqlDbType.Structured, Value = CommonObjects.ToDataTable(obj.RecipeDetail.AsEnumerable().ToList()) });
                    parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
                    parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                    var spName = "SP_Recipe";


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
