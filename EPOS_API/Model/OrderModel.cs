using EPOS_API.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class OrderModel
    {
        public int OperationId { get; set; }
        public int? OrderMasterId { get; set; }
        public int? CompanyId { get; set; }
        public int? BranchId { get; set; }
        public int? AreaId { get; set; }
        public int? CustomerId { get; set; }
        public int? PhoneId { get; set; }
        public int? CustomerAddressId { get; set; }
        public int? RiderId { get; set; }
        public int? TableId { get; set; }
        public int? OrderStatusId { get; set; }
        public bool IsAdvanceOrder { get; set; }
        public string SpecialInstruction { get; set; }
        public string OrderDate { get; set; }
        public string OrderTime { get; set; }
        public float? TotalAmountWithoutGST { get; set; }
        public int? GSTId { get; set; }
        public float? TotalAmountWithGST { get; set; }
        public string UserIP { get; set; }
        public string AlternateNumber { get; set; }
        public string AdvanceOrderDate { get; set; }
        public int? DeliveryTime { get; set; }
        public string CLINumber { get; set; }
        public int? OrderSourceId { get; set; }
        public string OrderSourceValue { get; set; }
        public int? DiscountId { get; set; }
        public int? DeliveryCharges { get; set; }
        public int? OrderCancelReasonId { get; set; }
        public int? WaiterId { get; set; }
        public int? ShiftDetailId { get; set; }
        public int? CounterDetailId { get; set; }
        public int? OrderModeId { get; set; }
        public int? Cover { get; set; }
        public int? PaymentTypeId { get; set; }
        public float? DiscountAmount { get; set; }
        public float? GSTAmount { get; set; }
        public int? CareOfId { get; set; }
        public int? BillPrintCount { get; set; }
        public int? PreviousOrderMasterId { get; set; }
        public string Remarks { get; set; }
        public float? DiscountPercent { get; set; }
        public float? GSTPercent { get; set; }
        public string FinishWasteRemarks { get; set; }
        public int? FinishWasteReasonId { get; set; }
        public int UserId { get; set; }
        public List<OrderDetail> tblOrderDetail { get; set; }
        public List<OrderDetailAdd> tblOrderDetailAdd { get; set; }
        public List<OrderDetailLess> tblOrderDetailLess { get; set; }
        public List<WebCustomerDetail> tblWebCustomerDetail { get; set; }
        public List<OrderExtraCharges> tblOrderExtraCharges { get; set; }
    }

    public class OrderDetail
    {
        public int? OrderMasterId { get; set; }
        public int? ProductDetailId { get; set; }
        public float Quantity { get; set; }
        public float PriceWithoutGST { get; set; }
        public int? GSTId { get; set; }
        public float PriceWithGST { get; set; }
        public int? OrderParentId { get; set; }
        public string SpecialInstruction { get; set; }
        public int? DealItemId { get; set; }
        public float DiscountPercent { get; set; }
        public int RandomId { get; set; }
        public bool? IsTopping { get; set; }
        public bool? HalfAndHalf { get; set; }
    }

    public class OrderDetailAdd
    {
        public int? OrderMasterId { get; set; }
        public int? ProductDetailId { get; set; }
        public float Quantity { get; set; }
        public float PriceWithoutGST { get; set; }
        public float AmountWithoutGST { get; set; }
    }

    public class OrderDetailLess
    {
        public int? OrderMasterId { get; set; }
        public int? ProductDetailId { get; set; }
        public float Quantity { get; set; }
        public float PriceWithoutGST { get; set; }
        public float AmountWithoutGST { get; set; }
    }

    public class GenerateKotModel
    {
        public int OperationId { get; set; }
        public int? OrderMasterId { get; set; }
        public int? CompanyId { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int? UserId { get; set; }
    }

    public class OrderPaymentModel
    {
        public int? OrderMasterId { get; set; }
        public int? OperationId { get; set; }
        public int? TerminalDetailId { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public List<OrderPaymentDetail> tblOrderPaymentDetail { get; set; }
    }
    public class OrderPaymentDetail
    {
        public int? PaymentModeId { get; set; }
        public float? TotalAmount { get; set; }
        public float? ReceivedAmount { get; set; }
        
    }
    public class UpdateCoverWaiterRiderModel
    {
        public int? OrderMasterId { get; set; }
        public int? OperationId { get; set; }
        public int? BranchId { get; set; }
        public int UserId { get; set; }
        public int? TableId { get; set; }
        public int? WaiterId { get; set; }
        public int? RiderId { get; set; }
        public int? Cover { get; set; }
    }
    public class OrderExtraCharges
    {
        public int ExtraChargesId { get; set; }
        public float ExtraChargesAmount { get; set; }
        public float Percentage { get; set; }
    }
    public class UpdateOrderWithGST:CommonModel
    {
        public int OrderMasterId { get; set; }
        public decimal TotalAmountWithGST { get; set; }
        public int GSTId { get; set; }
        public decimal GSTPercent { get; set; }
        public int? PaymentTypeId { get; set; }
        public decimal GSTAmount { get; set; }
    }
}
