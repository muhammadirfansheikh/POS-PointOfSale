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
    public class WebOrderController : Controller
    {
        private IConfiguration _config;
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        //int? IntNull = null;
        public WebOrderController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("GetWebOrderAddress")]
        public string Get_Address([FromBody] EPOS_API.Model.WebOrderModel obj)
        {
            var response = Get_Address(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        private dynamic Get_Address(EPOS_API.Model.WebOrderModel obj, HttpContext context)
        {
            try
            {
                bool? boolNull = null;

                if (Convert.ToBoolean(context.Items["Validate"]) == false)
                {
                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });
                    parm.Add(new SqlParameter() { ParameterName = "@BranchId", SqlDbType = SqlDbType.Int, Value = obj.BranchId });
                    parm.Add(new SqlParameter() { ParameterName = "@AreaId", SqlDbType = SqlDbType.Int, Value = obj.AreaId });
                    parm.Add(new SqlParameter() { ParameterName = "@IsWeb", SqlDbType = SqlDbType.Bit, Value = !obj.IsWeb ? boolNull : obj.IsWeb });
                    parm.Add(new SqlParameter() { ParameterName = "@IsMobile", SqlDbType = SqlDbType.Bit, Value = !obj.IsMobile ? boolNull : obj.IsMobile });

                    var spName = "SP_GetWebOrderAddress";

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

        [HttpPost("CrudWebMobileOrder")]
        public string CrudWebMobileOrder([FromBody] EPOS_API.Model.OrderModel obj)
        {

            //int? CustomerId = null, CustomerAddressId = null, PhoneId = null;
            //CustomerController objC = new CustomerController(_config);
            //OrderController objOrder = new OrderController(_config);

            //EPOS_API.Model.CustomerModel tblWebCustomerDetail = new EPOS_API.Model.CustomerModel
            //{
            //    OperationId = 1,
            //    CompanyId = Convert.ToInt32(obj.CompanyId),
            //    PhoneNumber = obj.tblWebCustomerDetail[0].PhoneNumber
            //};

            //DataSet ds = objC.Crud_Customer_DS(tblWebCustomerDetail, HttpContext);

            //if (ds != null && ds.Tables.Count > 0)
            //{
            //    DataTable dt1 = ds.Tables[0];
            //    DataTable dt2 = ds.Tables[1];
            //    DataTable dt3 = ds.Tables[2];

            //    if (dt1 != null && dt1.Rows.Count > 0)
            //    {
            //        PhoneId = Convert.ToInt32(Convert.ToString(dt1.Rows[0]["PhoneId"]));
            //    }

            //    if (dt2 != null && dt2.Rows.Count > 0)
            //    {
            //        DataView dv2 = dt2.DefaultView;
            //        dv2.RowFilter = "CustomerName = '" + obj.tblWebCustomerDetail[0].CustomerName + "'";
            //        DataTable CustomerDetail = dv2.ToTable();

            //        if (CustomerDetail != null && CustomerDetail.Rows.Count > 0)
            //        {
            //            CustomerId = Convert.ToInt32(Convert.ToString(CustomerDetail.Rows[0]["CustomerId"]));
            //        }
            //    }

            //    if (dt3 != null && dt3.Rows.Count > 0)
            //    {
            //        DataView dv3 = dt3.DefaultView;
            //        dv3.RowFilter = "Remarks = '" + obj.tblWebCustomerDetail[0].Remarks + "'";
            //        DataTable CustomerAddressDetail = dv3.ToTable();

            //        if (CustomerAddressDetail != null && CustomerAddressDetail.Rows.Count > 0)
            //        {
            //            CustomerAddressId = Convert.ToInt32(Convert.ToString(CustomerAddressDetail.Rows[0]["CustomerAddressId"]));
            //        }
            //    }

            //    if (CustomerId == null || CustomerAddressId == null)
            //    {
            //        tblWebCustomerDetail = new EPOS_API.Model.CustomerModel
            //        {
            //            OperationId = 2,
            //            CompanyId = Convert.ToInt32(obj.CompanyId),
            //            PhoneNumber = obj.tblWebCustomerDetail[0].PhoneNumber,
            //            CustomerName = obj.tblWebCustomerDetail[0].CustomerName,
            //            Remarks = obj.tblWebCustomerDetail[0].Remarks,
            //            LandMark = obj.tblWebCustomerDetail[0].LandMark,
            //            AreaId = obj.tblWebCustomerDetail[0].AreaId,
            //            IsPrimary = true,
            //            AddressTypeId = 133,
            //            CityId = 40,
            //            RoomHouse = "",
            //            BlockFloor = "",

            //        };

            //        DataSet ds2 = objC.Crud_Customer_DS(tblWebCustomerDetail, HttpContext);

            //        if (ds2 != null && ds2.Tables.Count > 0)
            //        {
            //            DataTable dt11 = ds2.Tables[1];
            //            DataTable dt21 = ds2.Tables[2];
            //            DataTable dt31 = ds2.Tables[3];

            //            CustomerId = Convert.ToInt32(Convert.ToString(dt21.Rows[dt21.Rows.Count - 1]["CustomerId"]));
            //            CustomerAddressId = Convert.ToInt32(Convert.ToString(dt31.Rows[dt31.Rows.Count - 1]["CustomerAddressId"]));
            //        }
            //    }

            //    obj.CustomerAddressId = CustomerAddressId;
            //    obj.CustomerId = CustomerId;
            //    obj.OrderSourceId = 194;
            //    obj.OrderStatusId = 25;
            //}

            //var response = objOrder.Crud_Order(obj, HttpContext);
            //string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            //return json;

            var response = Crud_WebMobileOrder(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        private dynamic Crud_WebMobileOrder(EPOS_API.Model.OrderModel obj, HttpContext context)
        {
            if (Convert.ToBoolean(context.Items["Validate"]) == false)
            {
                int? CustomerId = null, CustomerAddressId = null, PhoneId = null;
                CustomerController objC = new CustomerController(_config);
                OrderController objOrder = new OrderController(_config);

                EPOS_API.Model.CustomerModel tblWebCustomerDetail = new EPOS_API.Model.CustomerModel
                {
                    OperationId = 1,
                    CompanyId = Convert.ToInt32(obj.CompanyId),
                    PhoneNumber = obj.tblWebCustomerDetail[0].PhoneNumber
                };

                DataSet ds = objC.Crud_Customer_DS(tblWebCustomerDetail, HttpContext);

                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt1 = ds.Tables[0];
                    DataTable dt2 = ds.Tables[1];
                    DataTable dt3 = ds.Tables[2];

                    if (dt1 != null && dt1.Rows.Count > 0)
                    {
                        PhoneId = Convert.ToInt32(Convert.ToString(dt1.Rows[0]["PhoneId"]));
                    }

                    if (dt2 != null && dt2.Rows.Count > 0)
                    {
                        DataView dv2 = dt2.DefaultView;
                        dv2.RowFilter = "CustomerName = '" + obj.tblWebCustomerDetail[0].CustomerName + "'";
                        DataTable CustomerDetail = dv2.ToTable();

                        if (CustomerDetail != null && CustomerDetail.Rows.Count > 0)
                        {
                            CustomerId = Convert.ToInt32(Convert.ToString(CustomerDetail.Rows[0]["CustomerId"]));
                        }
                    }

                    if (dt3 != null && dt3.Rows.Count > 0)
                    {
                        DataView dv3 = dt3.DefaultView;
                        dv3.RowFilter = "Remarks = '" + obj.tblWebCustomerDetail[0].Remarks + "'";
                        DataTable CustomerAddressDetail = dv3.ToTable();

                        if (CustomerAddressDetail != null && CustomerAddressDetail.Rows.Count > 0)
                        {
                            CustomerAddressId = Convert.ToInt32(Convert.ToString(CustomerAddressDetail.Rows[0]["CustomerAddressId"]));
                        }
                    }

                    if (CustomerId == null || CustomerAddressId == null)
                    {
                        tblWebCustomerDetail = new EPOS_API.Model.CustomerModel
                        {
                            OperationId = 2,
                            CompanyId = Convert.ToInt32(obj.CompanyId),
                            PhoneNumber = obj.tblWebCustomerDetail[0].PhoneNumber,
                            CustomerName = obj.tblWebCustomerDetail[0].CustomerName,
                            Remarks = obj.tblWebCustomerDetail[0].Remarks,
                            LandMark = obj.tblWebCustomerDetail[0].LandMark,
                            AreaId = obj.tblWebCustomerDetail[0].AreaId,
                            IsPrimary = true,
                            AddressTypeId = 133,
                            CityId = 40,
                            RoomHouse = "",
                            BlockFloor = "",

                        };

                        DataSet ds2 = objC.Crud_Customer_DS(tblWebCustomerDetail, HttpContext);

                        if (ds2 != null && ds2.Tables.Count > 0)
                        {
                            DataTable dt11 = ds2.Tables[1];
                            DataTable dt21 = ds2.Tables[2];
                            DataTable dt31 = ds2.Tables[3];

                            CustomerId = Convert.ToInt32(Convert.ToString(dt21.Rows[dt21.Rows.Count - 1]["CustomerId"]));
                            CustomerAddressId = Convert.ToInt32(Convert.ToString(dt31.Rows[dt31.Rows.Count - 1]["CustomerAddressId"]));
                        }
                    }

                    obj.CustomerAddressId = CustomerAddressId;
                    obj.CustomerId = CustomerId;
                    //obj.OrderSourceId = 194;
                    obj.OrderStatusId = 25;
                }

                //var response = objOrder.Crud_Order(obj, HttpContext);
                //string json = JsonConvert.SerializeObject(response, Formatting.Indented);
                //return json;

                responseDetail = objOrder.Crud_OrderWithoutContext(obj, HttpContext);
            }
            else
            {
                responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.InvalidToken, ResponseMessages.InvalidToken);
            }
            return responseDetail;
        }
    }
}
