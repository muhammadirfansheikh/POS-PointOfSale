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
    public class DiscountController : Controller
    {
        private IConfiguration _config;
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        public DiscountController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("CrudDiscount")]
        public string CrudArea([FromBody] EPOS_API.Model.DiscountModel obj)
        {
            var response = Crud_Discount(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic Crud_Discount(EPOS_API.Model.DiscountModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {

                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });
                    parm.Add(new SqlParameter() { ParameterName = "@DiscountId", SqlDbType = SqlDbType.Int, Value = obj.DiscountId });
                    parm.Add(new SqlParameter() { ParameterName = "@DiscountPercent", SqlDbType = SqlDbType.Float, Value = obj.DiscountPercent });
                    parm.Add(new SqlParameter() { ParameterName = "@DiscountTimeStart", SqlDbType = SqlDbType.NVarChar, Value = obj.DiscountTimeStart });
                    parm.Add(new SqlParameter() { ParameterName = "@DiscountTimeEnd", SqlDbType = SqlDbType.NVarChar, Value = obj.DiscountTimeEnd });
                    parm.Add(new SqlParameter() { ParameterName = "@DiscountName", SqlDbType = SqlDbType.NVarChar, Value = obj.DiscountName });
                    parm.Add(new SqlParameter() { ParameterName = "@StartDate", SqlDbType = SqlDbType.NVarChar, Value = obj.StartDate });
                    parm.Add(new SqlParameter() { ParameterName = "@EndDate", SqlDbType = SqlDbType.NVarChar, Value = obj.EndDate });
                    parm.Add(new SqlParameter() { ParameterName = "@DiscountTypeId", SqlDbType = SqlDbType.Int, Value = obj.DiscountTypeId });
                    parm.Add(new SqlParameter() { ParameterName = "@AreaId", SqlDbType = SqlDbType.NVarChar, Value = obj.AreaId });
                    parm.Add(new SqlParameter() { ParameterName = "@BranchId", SqlDbType = SqlDbType.NVarChar, Value = obj.BranchId });
                    parm.Add(new SqlParameter() { ParameterName = "@OrderMode", SqlDbType = SqlDbType.NVarChar, Value = obj.OrderMode });
                    parm.Add(new SqlParameter() { ParameterName = "@OrderType", SqlDbType = SqlDbType.NVarChar, Value = obj.OrderType });
                    parm.Add(new SqlParameter() { ParameterName = "@ProductDetail", SqlDbType = SqlDbType.NVarChar, Value = obj.ProductDetail });
                    parm.Add(new SqlParameter() { ParameterName = "@IsActiveInWeb", SqlDbType = SqlDbType.Bit, Value = obj.IsActiveInWeb });
                    parm.Add(new SqlParameter() { ParameterName = "@IsActiveInPOS", SqlDbType = SqlDbType.Bit, Value = obj.IsActiveInPOS });
                    parm.Add(new SqlParameter() { ParameterName = "@IsActiveInODMS", SqlDbType = SqlDbType.Bit, Value = obj.IsActiveInODMS });
                    parm.Add(new SqlParameter() { ParameterName = "@IsActiveInMobile", SqlDbType = SqlDbType.Bit, Value = obj.IsActiveInMobile });
                    parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
                    parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                    parm.Add(new SqlParameter() { ParameterName = "@DiscountAvailability", SqlDbType = SqlDbType.Structured, Value = CommonObjects.ToDataTable(obj.DiscountAvailability.AsEnumerable().ToList()) });

                    var spName = "SP_Discount";
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

        [HttpPost("GetDiscount")]
        public string GetDiscount([FromBody] EPOS_API.Model.GetDiscountModel obj)
        {
            var response = Get_Discount(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic Get_Discount(EPOS_API.Model.GetDiscountModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {

                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@OrderModeId", SqlDbType = SqlDbType.Int, Value = obj.OrderModeId });
                    parm.Add(new SqlParameter() { ParameterName = "@OrderMasterId", SqlDbType = SqlDbType.Int, Value = obj.OrderMasterId });
                    parm.Add(new SqlParameter() { ParameterName = "@AreaId", SqlDbType = SqlDbType.Int, Value = obj.AreaId });
                    parm.Add(new SqlParameter() { ParameterName = "@OrderSourceId", SqlDbType = SqlDbType.Int, Value = obj.OrderSourceId });
                    parm.Add(new SqlParameter() { ParameterName = "@BranchId", SqlDbType = SqlDbType.Int, Value = obj.BranchId });
                    parm.Add(new SqlParameter() { ParameterName = "@Date", SqlDbType = SqlDbType.NVarChar, Value = obj.Date });
                    parm.Add(new SqlParameter() { ParameterName = "@IsActiveInWeb", SqlDbType = SqlDbType.Bit, Value = obj.IsActiveInWeb });
                    parm.Add(new SqlParameter() { ParameterName = "@IsActiveInPOS", SqlDbType = SqlDbType.Bit, Value = obj.IsActiveInPOS });
                    parm.Add(new SqlParameter() { ParameterName = "@IsActiveInODMS", SqlDbType = SqlDbType.Bit, Value = obj.IsActiveInODMS });
                    parm.Add(new SqlParameter() { ParameterName = "@IsActiveInMobile", SqlDbType = SqlDbType.BigInt, Value = obj.IsActiveInMobile });

                    var spName = "GET_DISCOUNT";
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
