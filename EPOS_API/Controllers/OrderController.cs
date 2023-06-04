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
    public class OrderController : Controller
    {

        private IConfiguration _config;
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        public OrderController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("CrudOrder")]
        public string CrudOrder([FromBody] EPOS_API.Model.OrderModel obj)
        {
            var response = Crud_Order(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        public dynamic Crud_Order(EPOS_API.Model.OrderModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {
                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                    parm.Add(new SqlParameter() { ParameterName = "@OrderMasterId", SqlDbType = SqlDbType.Int, Value = obj.OrderMasterId });
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });
                    parm.Add(new SqlParameter() { ParameterName = "@BranchId", SqlDbType = SqlDbType.Int, Value = obj.BranchId });
                    parm.Add(new SqlParameter() { ParameterName = "@AreaId", SqlDbType = SqlDbType.Int, Value = obj.AreaId });
                    parm.Add(new SqlParameter() { ParameterName = "@CustomerId", SqlDbType = SqlDbType.Int, Value = obj.CustomerId });
                    parm.Add(new SqlParameter() { ParameterName = "@PhoneId", SqlDbType = SqlDbType.Int, Value = obj.PhoneId });
                    parm.Add(new SqlParameter() { ParameterName = "@CustomerAddressId", SqlDbType = SqlDbType.Int, Value = obj.CustomerAddressId });
                    parm.Add(new SqlParameter() { ParameterName = "@RiderId", SqlDbType = SqlDbType.Int, Value = obj.RiderId });
                    parm.Add(new SqlParameter() { ParameterName = "@OrderStatusId", SqlDbType = SqlDbType.Int, Value = obj.OrderStatusId });
                    parm.Add(new SqlParameter() { ParameterName = "@IsAdvanceOrder", SqlDbType = SqlDbType.Bit, Value = obj.IsAdvanceOrder });
                    parm.Add(new SqlParameter() { ParameterName = "@SpecialInstruction", SqlDbType = SqlDbType.NVarChar, Value = obj.SpecialInstruction });
                    parm.Add(new SqlParameter() { ParameterName = "@OrderDate", SqlDbType = SqlDbType.NVarChar, Value = obj.OrderDate });
                    parm.Add(new SqlParameter() { ParameterName = "@OrderTime", SqlDbType = SqlDbType.NVarChar, Value = obj.OrderTime });
                    parm.Add(new SqlParameter() { ParameterName = "@TotalAmountWithoutGST", SqlDbType = SqlDbType.Float, Value = obj.TotalAmountWithoutGST });
                    parm.Add(new SqlParameter() { ParameterName = "@GSTId", SqlDbType = SqlDbType.Int, Value = obj.GSTId });
                    parm.Add(new SqlParameter() { ParameterName = "@TotalAmountWithGST", SqlDbType = SqlDbType.Float, Value = obj.TotalAmountWithGST });
                    parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
                    parm.Add(new SqlParameter() { ParameterName = "@AlternateNumber", SqlDbType = SqlDbType.NVarChar, Value = obj.AlternateNumber });
                    parm.Add(new SqlParameter() { ParameterName = "@AdvanceOrderDate", SqlDbType = SqlDbType.NVarChar, Value = obj.AdvanceOrderDate });
                    parm.Add(new SqlParameter() { ParameterName = "@DeliveryTime", SqlDbType = SqlDbType.Int, Value = obj.DeliveryTime });
                    parm.Add(new SqlParameter() { ParameterName = "@CLINumber", SqlDbType = SqlDbType.NVarChar, Value = obj.CLINumber });
                    parm.Add(new SqlParameter() { ParameterName = "@OrderSourceId", SqlDbType = SqlDbType.Int, Value = obj.OrderSourceId });
                    parm.Add(new SqlParameter() { ParameterName = "@OrderSourceValue", SqlDbType = SqlDbType.NVarChar, Value = obj.OrderSourceValue });
                    parm.Add(new SqlParameter() { ParameterName = "@DiscountId", SqlDbType = SqlDbType.Int, Value = obj.DiscountId });
                    parm.Add(new SqlParameter() { ParameterName = "@DeliveryCharges", SqlDbType = SqlDbType.Float, Value = obj.DeliveryCharges });
                    parm.Add(new SqlParameter() { ParameterName = "@OrderCancelReasonId", SqlDbType = SqlDbType.Int, Value = obj.OrderCancelReasonId });
                    parm.Add(new SqlParameter() { ParameterName = "@WaiterId", SqlDbType = SqlDbType.Int, Value = obj.WaiterId });
                    parm.Add(new SqlParameter() { ParameterName = "@ShiftDetailId", SqlDbType = SqlDbType.Int, Value = obj.ShiftDetailId });
                    parm.Add(new SqlParameter() { ParameterName = "@CounterDetailId", SqlDbType = SqlDbType.Int, Value = obj.CounterDetailId });
                    parm.Add(new SqlParameter() { ParameterName = "@OrderModeId", SqlDbType = SqlDbType.Int, Value = obj.OrderModeId });
                    parm.Add(new SqlParameter() { ParameterName = "@Cover", SqlDbType = SqlDbType.NVarChar, Value = obj.Cover });
                    parm.Add(new SqlParameter() { ParameterName = "@PaymentTypeId", SqlDbType = SqlDbType.Int, Value = obj.PaymentTypeId });
                    parm.Add(new SqlParameter() { ParameterName = "@DiscountAmount", SqlDbType = SqlDbType.Float, Value = obj.DiscountAmount });
                    parm.Add(new SqlParameter() { ParameterName = "@GSTAmount", SqlDbType = SqlDbType.Float, Value = obj.GSTAmount });
                    parm.Add(new SqlParameter() { ParameterName = "@CareOfId", SqlDbType = SqlDbType.Int, Value = obj.CareOfId });
                    parm.Add(new SqlParameter() { ParameterName = "@BillPrintCount", SqlDbType = SqlDbType.Int, Value = obj.BillPrintCount });
                    parm.Add(new SqlParameter() { ParameterName = "@PreviousOrderMasterId", SqlDbType = SqlDbType.Int, Value = obj.PreviousOrderMasterId });
                    parm.Add(new SqlParameter() { ParameterName = "@Remarks", SqlDbType = SqlDbType.NVarChar, Value = obj.Remarks });
                    parm.Add(new SqlParameter() { ParameterName = "@DiscountPercent", SqlDbType = SqlDbType.Float, Value = obj.DiscountPercent });
                    parm.Add(new SqlParameter() { ParameterName = "@GSTPercent", SqlDbType = SqlDbType.Float, Value = obj.GSTPercent });
                    parm.Add(new SqlParameter() { ParameterName = "@FinishWasteRemarks", SqlDbType = SqlDbType.NVarChar, Value = obj.FinishWasteRemarks });
                    parm.Add(new SqlParameter() { ParameterName = "@FinishWasteReasonId", SqlDbType = SqlDbType.Int, Value = obj.FinishWasteReasonId });
                    parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                    parm.Add(new SqlParameter() { ParameterName = "@TableId", SqlDbType = SqlDbType.Int, Value = obj.TableId });

                    parm.Add(new SqlParameter()
                    {
                        ParameterName = "@tblOrderDetail",
                        SqlDbType = SqlDbType.Structured,
                        Value = obj.tblOrderDetail == null ? null :
                        CommonObjects.ToDataTable(obj.tblOrderDetail.AsEnumerable().ToList())
                    });
                    parm.Add(new SqlParameter()
                    {
                        ParameterName = "@tblOrderKotAdd",
                        SqlDbType = SqlDbType.Structured,
                        Value = obj.tblOrderDetailAdd == null ? null :
                        CommonObjects.ToDataTable(obj.tblOrderDetailAdd.AsEnumerable().ToList())
                    });
                    parm.Add(new SqlParameter()
                    {
                        ParameterName = "@tblOrderKotLess",
                        SqlDbType = SqlDbType.Structured,
                        Value = obj.tblOrderDetailLess == null ? null :
                        CommonObjects.ToDataTable(obj.tblOrderDetailLess.AsEnumerable().ToList())
                    });
                    parm.Add(new SqlParameter()
                    {
                        ParameterName = "@tblOrderExtraCharges",
                        SqlDbType = SqlDbType.Structured,
                        Value = obj.tblOrderExtraCharges == null ? null :
                        CommonObjects.ToDataTable(obj.tblOrderExtraCharges.AsEnumerable().ToList())
                    });

                    string JsonOrder = JsonConvert.SerializeObject(obj);

                    parm.Add(new SqlParameter() { ParameterName = "@OrderJson", SqlDbType = SqlDbType.NVarChar, Value = JsonOrder });

                    var spName = "SP_CrudOrder";
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

        public dynamic Crud_OrderWithoutContext(EPOS_API.Model.OrderModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == false)
                {
                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                    parm.Add(new SqlParameter() { ParameterName = "@OrderMasterId", SqlDbType = SqlDbType.Int, Value = obj.OrderMasterId });
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });
                    parm.Add(new SqlParameter() { ParameterName = "@BranchId", SqlDbType = SqlDbType.Int, Value = obj.BranchId });
                    parm.Add(new SqlParameter() { ParameterName = "@AreaId", SqlDbType = SqlDbType.Int, Value = obj.AreaId });
                    parm.Add(new SqlParameter() { ParameterName = "@CustomerId", SqlDbType = SqlDbType.Int, Value = obj.CustomerId });
                    parm.Add(new SqlParameter() { ParameterName = "@PhoneId", SqlDbType = SqlDbType.Int, Value = obj.PhoneId });
                    parm.Add(new SqlParameter() { ParameterName = "@CustomerAddressId", SqlDbType = SqlDbType.Int, Value = obj.CustomerAddressId });
                    parm.Add(new SqlParameter() { ParameterName = "@RiderId", SqlDbType = SqlDbType.Int, Value = obj.RiderId });
                    parm.Add(new SqlParameter() { ParameterName = "@OrderStatusId", SqlDbType = SqlDbType.Int, Value = obj.OrderStatusId });
                    parm.Add(new SqlParameter() { ParameterName = "@IsAdvanceOrder", SqlDbType = SqlDbType.Bit, Value = obj.IsAdvanceOrder });
                    parm.Add(new SqlParameter() { ParameterName = "@SpecialInstruction", SqlDbType = SqlDbType.NVarChar, Value = obj.SpecialInstruction });
                    parm.Add(new SqlParameter() { ParameterName = "@OrderDate", SqlDbType = SqlDbType.NVarChar, Value = obj.OrderDate });
                    parm.Add(new SqlParameter() { ParameterName = "@OrderTime", SqlDbType = SqlDbType.NVarChar, Value = obj.OrderTime });
                    parm.Add(new SqlParameter() { ParameterName = "@TotalAmountWithoutGST", SqlDbType = SqlDbType.Float, Value = obj.TotalAmountWithoutGST });
                    parm.Add(new SqlParameter() { ParameterName = "@GSTId", SqlDbType = SqlDbType.Int, Value = obj.GSTId });
                    parm.Add(new SqlParameter() { ParameterName = "@TotalAmountWithGST", SqlDbType = SqlDbType.Float, Value = obj.TotalAmountWithGST });
                    parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
                    parm.Add(new SqlParameter() { ParameterName = "@AlternateNumber", SqlDbType = SqlDbType.NVarChar, Value = obj.AlternateNumber });
                    parm.Add(new SqlParameter() { ParameterName = "@AdvanceOrderDate", SqlDbType = SqlDbType.NVarChar, Value = obj.AdvanceOrderDate });
                    parm.Add(new SqlParameter() { ParameterName = "@DeliveryTime", SqlDbType = SqlDbType.Int, Value = obj.DeliveryTime });
                    parm.Add(new SqlParameter() { ParameterName = "@CLINumber", SqlDbType = SqlDbType.NVarChar, Value = obj.CLINumber });
                    parm.Add(new SqlParameter() { ParameterName = "@OrderSourceId", SqlDbType = SqlDbType.Int, Value = obj.OrderSourceId });
                    parm.Add(new SqlParameter() { ParameterName = "@OrderSourceValue", SqlDbType = SqlDbType.NVarChar, Value = obj.OrderSourceValue });
                    parm.Add(new SqlParameter() { ParameterName = "@DiscountId", SqlDbType = SqlDbType.Int, Value = obj.DiscountId });
                    parm.Add(new SqlParameter() { ParameterName = "@DeliveryCharges", SqlDbType = SqlDbType.Float, Value = obj.DeliveryCharges });
                    parm.Add(new SqlParameter() { ParameterName = "@OrderCancelReasonId", SqlDbType = SqlDbType.Int, Value = obj.OrderCancelReasonId });
                    parm.Add(new SqlParameter() { ParameterName = "@WaiterId", SqlDbType = SqlDbType.Int, Value = obj.WaiterId });
                    parm.Add(new SqlParameter() { ParameterName = "@ShiftDetailId", SqlDbType = SqlDbType.Int, Value = obj.ShiftDetailId });
                    parm.Add(new SqlParameter() { ParameterName = "@CounterDetailId", SqlDbType = SqlDbType.Int, Value = obj.CounterDetailId });
                    parm.Add(new SqlParameter() { ParameterName = "@OrderModeId", SqlDbType = SqlDbType.Int, Value = obj.OrderModeId });
                    parm.Add(new SqlParameter() { ParameterName = "@Cover", SqlDbType = SqlDbType.NVarChar, Value = obj.Cover });
                    parm.Add(new SqlParameter() { ParameterName = "@PaymentTypeId", SqlDbType = SqlDbType.Int, Value = obj.PaymentTypeId });
                    parm.Add(new SqlParameter() { ParameterName = "@DiscountAmount", SqlDbType = SqlDbType.Float, Value = obj.DiscountAmount });
                    parm.Add(new SqlParameter() { ParameterName = "@GSTAmount", SqlDbType = SqlDbType.Float, Value = obj.GSTAmount });
                    parm.Add(new SqlParameter() { ParameterName = "@CareOfId", SqlDbType = SqlDbType.Int, Value = obj.CareOfId });
                    parm.Add(new SqlParameter() { ParameterName = "@BillPrintCount", SqlDbType = SqlDbType.Int, Value = obj.BillPrintCount });
                    parm.Add(new SqlParameter() { ParameterName = "@PreviousOrderMasterId", SqlDbType = SqlDbType.Int, Value = obj.PreviousOrderMasterId });
                    parm.Add(new SqlParameter() { ParameterName = "@Remarks", SqlDbType = SqlDbType.NVarChar, Value = obj.Remarks });
                    parm.Add(new SqlParameter() { ParameterName = "@DiscountPercent", SqlDbType = SqlDbType.Float, Value = obj.DiscountPercent });
                    parm.Add(new SqlParameter() { ParameterName = "@GSTPercent", SqlDbType = SqlDbType.Float, Value = obj.GSTPercent });
                    parm.Add(new SqlParameter() { ParameterName = "@FinishWasteRemarks", SqlDbType = SqlDbType.NVarChar, Value = obj.FinishWasteRemarks });
                    parm.Add(new SqlParameter() { ParameterName = "@FinishWasteReasonId", SqlDbType = SqlDbType.Int, Value = obj.FinishWasteReasonId });
                    parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                    parm.Add(new SqlParameter() { ParameterName = "@TableId", SqlDbType = SqlDbType.Int, Value = obj.TableId });

                    parm.Add(new SqlParameter()
                    {
                        ParameterName = "@tblOrderDetail",
                        SqlDbType = SqlDbType.Structured,
                        Value = obj.tblOrderDetail == null ? null :
                        CommonObjects.ToDataTable(obj.tblOrderDetail.AsEnumerable().ToList())
                    });
                    parm.Add(new SqlParameter()
                    {
                        ParameterName = "@tblOrderKotAdd",
                        SqlDbType = SqlDbType.Structured,
                        Value = obj.tblOrderDetailAdd == null ? null :
                        CommonObjects.ToDataTable(obj.tblOrderDetailAdd.AsEnumerable().ToList())
                    });
                    parm.Add(new SqlParameter()
                    {
                        ParameterName = "@tblOrderKotLess",
                        SqlDbType = SqlDbType.Structured,
                        Value = obj.tblOrderDetailLess == null ? null :
                        CommonObjects.ToDataTable(obj.tblOrderDetailLess.AsEnumerable().ToList())
                    });
                    //parm.Add(new SqlParameter()
                    //{
                    //    ParameterName = "@tblOrderExtraCharges",
                    //    SqlDbType = SqlDbType.Structured,
                    //    Value = obj.tblOrderExtraCharges == null ? null :
                    //   CommonObjects.ToDataTable(obj.tblOrderExtraCharges.AsEnumerable().ToList())
                    //});

                    string JsonOrder = JsonConvert.SerializeObject(obj);

                    parm.Add(new SqlParameter() { ParameterName = "@OrderJson", SqlDbType = SqlDbType.NVarChar, Value = JsonOrder });

                    var spName = "SP_CrudOrder";
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

        [HttpPost("GenerateKot")]
        public string GenerateKot([FromBody] EPOS_API.Model.GenerateKotModel obj)
        {
            var response = Generate_Kot(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic Generate_Kot(EPOS_API.Model.GenerateKotModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {
                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                    parm.Add(new SqlParameter() { ParameterName = "@OrderMasterId", SqlDbType = SqlDbType.Int, Value = obj.OrderMasterId });
                    parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });

                    var spName = "SP_GenerateKot";
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

        [HttpPost("RecallOrder")]
        public string RecallOrder(int OrderMasterId, bool IsPos)
        {
            var response = Recall_Order(OrderMasterId, IsPos, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic Recall_Order(int OrderMasterId, bool IsPos, HttpContext context)
        {
            try
            {
                DataSet ds1 = new DataSet("ds1");
                DataSet ds2 = new DataSet("ds2");

                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {
                    string spName = "SP_RecallOrder";
                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@OrderMasterId", SqlDbType = SqlDbType.Int, Value = OrderMasterId });
                    parm.Add(new SqlParameter() { ParameterName = "@IsPos", SqlDbType = SqlDbType.Int, Value = IsPos == true ? 1 : 0 });

                    DapperManager dm = new DapperManager(_config.GetConnectionString("MyConnection"));
                    DataSet obj_response = dm.GetDataSet(spName, parm.ToArray());

                    if (obj_response != null)
                    {
                        int count1 = obj_response.Tables.Count;
                        for (int i = 0; i < 2; i++)
                        {
                            DataTable dt1 = obj_response.Tables[i].Copy();

                            ds1.Tables.Add(dt1);
                        }
                        for (int i = 0; i < count1; i++)
                        {
                            DataTable dt2 = obj_response.Tables[i].Copy();
                            //string TableName = "Table";
                            //if (i > 2)
                            //{
                            //    TableName = TableName + (i - 2).ToString();
                            //}
                            //dt2.TableName = TableName;
                            ds2.Tables.Add(dt2);
                        }

                        responseDetail = CommonObjects.GetRepsonsesWithMultipleDataSet(true, ResponseCodes.Success, ResponseMessages.Success, ds1, ds2);
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
        //private dynamic Recall_Order(int OrderMasterId, bool IsPos, HttpContext context)
        //{
        //    try
        //    {
        //        DataSet ds1 = new DataSet("ds1");
        //        DataSet ds2 = new DataSet("ds2");

        //        if (Convert.ToBoolean(context.Items["Validate"]) == true)
        //        {
        //            List<SqlParameter> parm = new List<SqlParameter>();
        //            parm.Add(new SqlParameter() { ParameterName = "@OrderMasterId", SqlDbType = SqlDbType.Int, Value = OrderMasterId });
        //            parm.Add(new SqlParameter() { ParameterName = "@IsPos", SqlDbType = SqlDbType.Int, Value = IsPos == true ? 1 : 0 });

        //            var spName = "SP_RecallOrder";
        //            DataSet obj_response = new DapperManager(_config.GetConnectionString("MyConnection")).GetDataSet(spName, parm.ToArray());
        //            if (obj_response != null)
        //            {
        //                int count1 = obj_response.Tables.Count;
        //                for (int i = 0; i < 2; i++)
        //                {
        //                    DataTable dt1 = obj_response.Tables[i].Copy();

        //                    ds1.Tables.Add(dt1);
        //                }
        //                for (int i = 2; i < count1; i++)
        //                {
        //                    DataTable dt2 = obj_response.Tables[i].Copy();
        //                    string TableName = "Table";
        //                    if (i > 2)
        //                    {
        //                        TableName = TableName + (i - 2).ToString();
        //                    }
        //                    dt2.TableName = TableName;
        //                    ds2.Tables.Add(dt2);
        //                }

        //                responseDetail = CommonObjects.GetRepsonsesWithMultipleDataSet(true, ResponseCodes.Success, ResponseMessages.Success, ds1, ds2);
        //            }
        //            else
        //            {
        //                responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
        //            }
        //        }
        //        else
        //        {
        //            responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.InvalidToken, ResponseMessages.InvalidToken);
        //        }
        //        return responseDetail;
        //    }
        //    catch (Exception ex)
        //    {
        //        return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
        //    }
        //}

        [HttpPost("OrderPayment")]
        public string OrderPayment([FromBody] EPOS_API.Model.OrderPaymentModel obj)
        {
            var response = Order_Payment(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic Order_Payment(EPOS_API.Model.OrderPaymentModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {
                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                    parm.Add(new SqlParameter() { ParameterName = "@OrderMasterId", SqlDbType = SqlDbType.Int, Value = obj.OrderMasterId });
                    parm.Add(new SqlParameter() { ParameterName = "@TerminalDetailId", SqlDbType = SqlDbType.Int, Value = obj.TerminalDetailId });
                    parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });
                    parm.Add(new SqlParameter()
                    {
                        ParameterName = "@tblOrderPayment",
                        SqlDbType = SqlDbType.Structured,
                        Value = obj.tblOrderPaymentDetail == null ? null :
                        CommonObjects.ToDataTable(obj.tblOrderPaymentDetail.AsEnumerable().ToList())
                    });
                    var spName = "SP_OrderPayment";
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
        //private dynamic Order_Payment(EPOS_API.Model.OrderPaymentModel obj, HttpContext context)
        //{
        //    try
        //    {
        //        if (Convert.ToBoolean(context.Items["Validate"]) == true)
        //        {
        //            List<SqlParameter> parm = new List<SqlParameter>();
        //            parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
        //            parm.Add(new SqlParameter() { ParameterName = "@OrderMasterId", SqlDbType = SqlDbType.Int, Value = obj.OrderMasterId });
        //            parm.Add(new SqlParameter() { ParameterName = "@TerminalDetailId", SqlDbType = SqlDbType.Int, Value = obj.TerminalDetailId });
        //            parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
        //            parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });
        //            parm.Add(new SqlParameter()
        //            {
        //                ParameterName = "@tblOrderPayment",
        //                SqlDbType = SqlDbType.Structured,
        //                Value = obj.tblOrderPaymentDetail == null ? null :
        //                CommonObjects.ToDataTable(obj.tblOrderPaymentDetail.AsEnumerable().ToList())
        //            });
        //            var spName = "SP_OrderPayment";
        //            DataSet obj_response = new DapperManager(_config.GetConnectionString("MyConnection")).GetDataSet(spName, parm.ToArray());
        //            if (obj_response != null)
        //            {
        //                responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
        //                string json = JsonConvert.SerializeObject(responseDetail, Formatting.Indented);

        //                List<FbrItemObject> lst = new List<FbrItemObject>();
        //                DataTable dt = responseDetail.DataSet.Tables[2];
        //                if (dt != null && dt.Rows.Count > 0)
        //                {

        //                    foreach (DataRow row in dt.Rows)
        //                    {
        //                        lst.Add(
        //                            new FbrItemObject()
        //                            {
        //                                ItemCode = row.Field<string>("ItemCode"),
        //                                ItemName = row.Field<string>("ItemName"),
        //                                Quantity = row.Field<double>("Quantity"),
        //                                PCTCode = row.Field<string>("PCTCode"),
        //                                TaxRate = row.Field<double>("TaxRate"),
        //                                SaleValue = row.Field<double>("SaleValue"),
        //                                TotalAmount = row.Field<double>("TotalAmount"),
        //                                TaxCharged = row.Field<double>("TaxCharged"),
        //                                Discount = row.Field<decimal>("Discount"),
        //                                FurtherTax = row.Field<decimal>("FurtherTax"),
        //                                InvoiceType = row.Field<int>("InvoiceType"),
        //                                RefUSIN = row.Field<string>("RefUSIN"),
        //                            });
        //                    }
        //                }

        //                DataTable dt1 = responseDetail.DataSet.Tables[1];
        //                if (dt1 != null && dt1.Rows.Count > 0)
        //                {
        //                    FbrInvoiceObject objInvoice = new FbrInvoiceObject();

        //                    objInvoice.USIN = Convert.ToString(dt1.Rows[0]["USIN"]);
        //                    objInvoice.InvoiceNumber = Convert.ToString(dt1.Rows[0]["InvoiceNumber"]);
        //                    objInvoice.DateTime = Convert.ToString(dt1.Rows[0]["DateTime"]);
        //                    objInvoice.BuyerNTN = Convert.ToString(dt1.Rows[0]["BuyerNTN"]);
        //                    objInvoice.BuyerCNIC = Convert.ToString(dt1.Rows[0]["BuyerCNIC"]);
        //                    objInvoice.BuyerName = Convert.ToString(dt1.Rows[0]["BuyerName"]);
        //                    objInvoice.BuyerPhoneNumber = Convert.ToString(dt1.Rows[0]["BuyerPhoneNumber"]);
        //                    objInvoice.RefUSIN = Convert.ToString(dt1.Rows[0]["RefUSIN"]);
        //                    objInvoice.TotalBillAmount = Convert.ToDouble(Convert.ToString(dt1.Rows[0]["TotalBillAmount"]));
        //                    objInvoice.TotalQuantity = Convert.ToSingle(Convert.ToString(dt1.Rows[0]["TotalQuantity"]));
        //                    objInvoice.TotalSaleValue = Convert.ToSingle(Convert.ToString(dt1.Rows[0]["TotalSaleValue"]));
        //                    objInvoice.TotalTaxCharged = Convert.ToSingle(Convert.ToString(dt1.Rows[0]["TotalTaxCharged"]));
        //                    objInvoice.Discount = Convert.ToSingle(Convert.ToString(dt1.Rows[0]["Discount"]));
        //                    objInvoice.FurtherTax = Convert.ToSingle(Convert.ToString(dt1.Rows[0]["FurtherTax"]));
        //                    objInvoice.PaymentMode = Convert.ToInt32(Convert.ToString(dt1.Rows[0]["PaymentMode"]));
        //                    objInvoice.POSID = Convert.ToInt32(Convert.ToString(dt1.Rows[0]["POSID"]));
        //                    objInvoice.InvoiceType = Convert.ToInt32(Convert.ToString(dt1.Rows[0]["InvoiceType"]));
        //                    objInvoice.Items = lst;

        //                    //responseDetail = new FbrSbrIntegration().getFbrInvoice(true, objInvoice);
        //                }
        //            }
        //            else
        //            {
        //                responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
        //            }
        //        }
        //        else
        //        {
        //            responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.InvalidToken, ResponseMessages.InvalidToken);
        //        }
        //        return responseDetail;
        //    }
        //    catch (Exception ex)
        //    {
        //        return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
        //    }
        //}

        [HttpPost("UpdateCoverWaiterRider")]
        public string UpdateCoverWaiterRider([FromBody] EPOS_API.Model.UpdateCoverWaiterRiderModel obj)
        {
            var response = Update_CoverWaiterRider(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        private dynamic Update_CoverWaiterRider(EPOS_API.Model.UpdateCoverWaiterRiderModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {
                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                    parm.Add(new SqlParameter() { ParameterName = "@OrderMasterId", SqlDbType = SqlDbType.Int, Value = obj.OrderMasterId });
                    parm.Add(new SqlParameter() { ParameterName = "@BranchId", SqlDbType = SqlDbType.Int, Value = obj.BranchId });
                    parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                    parm.Add(new SqlParameter() { ParameterName = "@WaiterId", SqlDbType = SqlDbType.Int, Value = obj.WaiterId });
                    parm.Add(new SqlParameter() { ParameterName = "@TableId", SqlDbType = SqlDbType.Int, Value = obj.TableId });
                    parm.Add(new SqlParameter() { ParameterName = "@RiderId", SqlDbType = SqlDbType.Int, Value = obj.RiderId });
                    parm.Add(new SqlParameter() { ParameterName = "@Cover", SqlDbType = SqlDbType.Int, Value = obj.Cover });

                    var spName = "SP_UpdateCoverWaiterRider";
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


        [HttpPost("UpdateOrderWithGST")]
        public string UpdateOrderWithGST([FromBody] EPOS_API.Model.UpdateOrderWithGST obj)
        {
            var response = UpdateOrderWithGST(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }
        public dynamic UpdateOrderWithGST(EPOS_API.Model.UpdateOrderWithGST obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {
                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@TotalAmountWithGST", SqlDbType = SqlDbType.Decimal, Value = obj.TotalAmountWithGST });
                    parm.Add(new SqlParameter() { ParameterName = "@GSTId", SqlDbType = SqlDbType.Int, Value = obj.GSTId });
                    parm.Add(new SqlParameter() { ParameterName = "@GSTPercent", SqlDbType = SqlDbType.Decimal, Value = obj.GSTPercent });
                    parm.Add(new SqlParameter() { ParameterName = "@PaymentTypeId", SqlDbType = SqlDbType.Int, Value = obj.PaymentTypeId });
                    parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                    parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
                    parm.Add(new SqlParameter() { ParameterName = "@OrderMasterId", SqlDbType = SqlDbType.Int, Value = obj.OrderMasterId });
                    parm.Add(new SqlParameter() { ParameterName = "@GSTAmount", SqlDbType = SqlDbType.Decimal, Value = obj.GSTAmount });

                    var spName = "SP_UpdateOrderWithGST";
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
