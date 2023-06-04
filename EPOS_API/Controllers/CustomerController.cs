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
    public class CustomerController : Controller
    {
        private IConfiguration _config;
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        public CustomerController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("CrudCustomer")]
        public string CrudCustomer([FromBody] EPOS_API.Model.CustomerModel obj)
        {
            var response = Crud_Customer(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic Crud_Customer(EPOS_API.Model.CustomerModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {
                    DataSet obj_response = Crud_Customer_DS(obj, context);

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
        public DataSet Crud_Customer_DS(EPOS_API.Model.CustomerModel obj, HttpContext context)
        {
            try
            {
                List<SqlParameter> parm = new List<SqlParameter>();

                parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });
                parm.Add(new SqlParameter() { ParameterName = "@PhoneNumber", SqlDbType = SqlDbType.NVarChar, Value = obj.PhoneNumber });
                parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
                parm.Add(new SqlParameter() { ParameterName = "@CustomerName", SqlDbType = SqlDbType.NVarChar, Value = obj.CustomerName });
                parm.Add(new SqlParameter() { ParameterName = "@IsPrimary", SqlDbType = SqlDbType.Bit, Value = obj.IsPrimary });
                parm.Add(new SqlParameter() { ParameterName = "@AddressTypeId", SqlDbType = SqlDbType.Int, Value = obj.AddressTypeId });
                parm.Add(new SqlParameter() { ParameterName = "@CityId", SqlDbType = SqlDbType.Int, Value = obj.CityId });
                parm.Add(new SqlParameter() { ParameterName = "@AreaId", SqlDbType = SqlDbType.Int, Value = obj.AreaId });
                parm.Add(new SqlParameter() { ParameterName = "@LandMark", SqlDbType = SqlDbType.NVarChar, Value = obj.LandMark });
                parm.Add(new SqlParameter() { ParameterName = "@CompanyName", SqlDbType = SqlDbType.NVarChar, Value = obj.CompanyName });
                parm.Add(new SqlParameter() { ParameterName = "@Building", SqlDbType = SqlDbType.NVarChar, Value = obj.Building });
                parm.Add(new SqlParameter() { ParameterName = "@RoomHouse", SqlDbType = SqlDbType.NVarChar, Value = obj.RoomHouse });
                parm.Add(new SqlParameter() { ParameterName = "@BlockFloor", SqlDbType = SqlDbType.NVarChar, Value = obj.BlockFloor });
                parm.Add(new SqlParameter() { ParameterName = "@StreetRowLane", SqlDbType = SqlDbType.NVarChar, Value = obj.StreetRowLane });
                parm.Add(new SqlParameter() { ParameterName = "@RoomHouseCaptionId", SqlDbType = SqlDbType.Int, Value = obj.RoomHouseCaptionId });
                parm.Add(new SqlParameter() { ParameterName = "@BlockFloorCaptionId", SqlDbType = SqlDbType.Int, Value = obj.BlockFloorCaptionId });
                parm.Add(new SqlParameter() { ParameterName = "@StreetRowLaneCaptionId", SqlDbType = SqlDbType.Int, Value = obj.StreetRowLaneCaptionId });
                parm.Add(new SqlParameter() { ParameterName = "@Remarks", SqlDbType = SqlDbType.NVarChar, Value = obj.Remarks });
                parm.Add(new SqlParameter() { ParameterName = "@CustomerId", SqlDbType = SqlDbType.Int, Value = obj.CustomerId });
                parm.Add(new SqlParameter() { ParameterName = "@CustomerAddressId", SqlDbType = SqlDbType.NVarChar, Value = obj.CustomerAddressId });
                parm.Add(new SqlParameter() { ParameterName = "@PhoneTypeId", SqlDbType = SqlDbType.Int, Value = obj.PhoneTypeId });
                parm.Add(new SqlParameter() { ParameterName = "@BranchId", SqlDbType = SqlDbType.Int, Value = obj.BranchId });

                var spName = "SP_CrudCustomer";

                DataSet obj_response = new DapperManager(_config.GetConnectionString("MyConnection")).GetDataSet(spName, parm.ToArray());

                return obj_response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
