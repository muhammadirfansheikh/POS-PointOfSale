using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EPOS_API.Utilities
{
    public class FbrInvoiceObject
    {
        public string InvoiceNumber { get; set; }
        public int POSID { get; set; }
        public string USIN { get; set; }
        public string DateTime { get; set; }
        public string BuyerNTN { get; set; }
        public string BuyerCNIC { get; set; }
        public string BuyerName { get; set; }
        public string BuyerPhoneNumber { get; set; }
        public double TotalBillAmount { get; set; }
        public float TotalQuantity { get; set; }
        public float TotalSaleValue { get; set; }
        public float TotalTaxCharged { get; set; }
        public float Discount { get; set; }
        public float FurtherTax { get; set; }
        public int PaymentMode { get; set; }
        public string RefUSIN { get; set; }
        public int InvoiceType { get; set; }
        public List<FbrItemObject> Items { get; set; }
    }
    public class FbrItemObject
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public double? Quantity { get; set; }
        public string PCTCode { get; set; }
        public double? TaxRate { get; set; }
        public double? SaleValue { get; set; }
        public double? TotalAmount { get; set; }
        public double? TaxCharged { get; set; }
        public decimal? Discount { get; set; }
        public decimal? FurtherTax { get; set; }
        public int InvoiceType { get; set; }
        public string RefUSIN { get; set; }
    }

    public class FbrSbrIntegration
    {
        public FbrSbrIntegration() { }

        public HttpResponseMessage getFbrInvoice(Boolean FBRCheck, FbrInvoiceObject fbrInvoiceObject)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            if (FBRCheck == true)
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client = new HttpClient(clientHandler);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "1298b5eb-b252-3d97-8622-a4a69d5bf818");
                StringContent content = new StringContent(JsonConvert.SerializeObject(fbrInvoiceObject), Encoding.UTF8, "application/json");
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                response = client.PostAsync("https://esp.fbr.gov.pk:8244/FBR/v1/api/Live/PostData", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }
                return response;
            }
            else
            {
                return response;
            }
        }
        public string getSbrInvoice(Boolean SBRcheck)
        {
            FbrInvoiceObject fbrInvoiceObject = new FbrInvoiceObject();
            if (SBRcheck == true)
            {
                return "";
            }
            else
            {
                return "";
            }
        }
    }
}
