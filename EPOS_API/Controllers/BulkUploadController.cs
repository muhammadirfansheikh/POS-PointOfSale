using EPOS_API.Data;
using EPOS_API.Utilities;
using ExcelDataReader;
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

namespace EPOS_API.Controllers
{
    public class BulkUploadController : Controller
    {
        private IConfiguration _config;
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        public BulkUploadController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("BulkUpload")]
        public string BulkUpload([FromForm] EPOS_API.Model.BulkUploadModel obj)
        {
            var response = Bulk_Upload(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        public dynamic Bulk_Upload([FromForm] EPOS_API.Model.BulkUploadModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {
                    if (HttpContext.Request.Form.Files.Count > 0)
                    {
                        IFormFile file = HttpContext.Request.Form.Files[0];

                        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                        using (var stream = new MemoryStream())
                        {
                            file.CopyTo(stream);
                            stream.Position = 0;
                            using (var reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                DataTable dt = new DataTable();
                                int a = 0;
                                while (reader.Read()) //Each row of the file
                                {
                                    if (a > 0)
                                    {
                                        DataRow dr = dt.NewRow();
                                        for (int i = 0; i < reader.FieldCount; i++)
                                        {
                                            string colValue = reader.GetValue(i).ToString();
                                            dr[i] = colValue;
                                        }
                                        dt.Rows.Add(dr);
                                    }
                                    else
                                    {
                                        for (int j = 0; j < reader.FieldCount; j++)
                                        {
                                            string colName = reader.GetValue(j).ToString();
                                            dt.Columns.Add(colName);
                                        }
                                    }
                                    a++;
                                }

                                if (dt != null)
                                {
                                    List<SqlParameter> parm = new List<SqlParameter>();
                                    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                                    parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.NVarChar, Value = obj.CompanyId });
                                    parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                                    parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
                                    parm.Add(new SqlParameter()
                                    {
                                        ParameterName = "@BulkUpload",
                                        SqlDbType = SqlDbType.Structured,
                                        Value = (dt != null || dt.Rows.Count > 0) ? dt : null
                                    });

                                    var spName = "SP_BulkUpload";

                                    DataSet obj_response = new DapperManager(_config.GetConnectionString("MyConnection")).GetDataSet(spName, parm.ToArray());
                                    if (obj_response != null)
                                    {
                                        responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                                    }
                                    else
                                    {
                                        responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                                    }

                                    //DataSet ds = new DataSet();
                                    //ds.Tables.Add(dt);

                                    //responseDetail = CommonObjects.GetRepsonsesWithMultipleDataSet(true, ResponseCodes.Success, ResponseMessages.Success, ds);
                                }
                                else
                                {
                                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                                }
                            }
                        }

                        return responseDetail;
                    }
                    else
                    {
                        return responseDetail;
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
