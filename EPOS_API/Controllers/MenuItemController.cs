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
    public class MenuItemController : Controller
    {
        private IConfiguration _config;
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        public MenuItemController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("CrudMenuItem")]
        public string CrudMenuItem([FromBody] EPOS_API.Model.MenuItemModel obj)
        {
            var response = CrudMenuItem(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic CrudMenuItem(EPOS_API.Model.MenuItemModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {
                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                    parm.Add(new SqlParameter() { ParameterName = "@MenuId", SqlDbType = SqlDbType.Int, Value = obj.MenuId });
                    parm.Add(new SqlParameter() { ParameterName = "@Parent_Id", SqlDbType = SqlDbType.Int, Value = obj.Parent_Id });
                    parm.Add(new SqlParameter() { ParameterName = "@Menu_Name", SqlDbType = SqlDbType.NVarChar, Value = obj.Menu_Name });
                    parm.Add(new SqlParameter() { ParameterName = "@Menu_URL", SqlDbType = SqlDbType.NVarChar, Value = obj.Menu_URL });
                    parm.Add(new SqlParameter() { ParameterName = "@Is_Displayed_In_Menu", SqlDbType = SqlDbType.Bit, Value = obj.Is_Displayed_In_Menu });
                    parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                    parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
                    parm.Add(new SqlParameter() { ParameterName = "@SortOrder", SqlDbType = SqlDbType.Bit, Value = obj.SortOrder });
                    var spName = "SP_MenuItem";
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
