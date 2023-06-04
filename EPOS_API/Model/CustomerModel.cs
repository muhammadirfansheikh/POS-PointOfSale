using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPOS_API.Model
{
    public class CustomerModel
    {
        public int OperationId { get; set; }
        public int CompanyId { get; set; }
        public string PhoneNumber { get; set; }
        public int UserId { get; set; }
        public string UserIP { get; set; }
        public string CustomerName { get; set; }
        public bool IsPrimary { get; set; }
        public int? AddressTypeId { get; set; }
        public int? CityId { get; set; }
        public int? AreaId { get; set; }
        public string LandMark { get; set; }
        public string CompanyName { get; set; }
        public string Building { get; set; }
        public string RoomHouse { get; set; }
        public string BlockFloor { get; set; }
        public string StreetRowLane { get; set; }
        public int? RoomHouseCaptionId { get; set; }
        public int? BlockFloorCaptionId { get; set; }
        public int? StreetRowLaneCaptionId { get; set; }
        public string Remarks { get; set; }
        public int? CustomerId { get; set; }
        public int? CustomerAddressId { get; set; }
        public int? PhoneTypeId { get; set; }
        public int? BranchId { get; set; }


    }
}
