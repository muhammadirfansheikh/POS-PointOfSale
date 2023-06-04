using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPOS_API.Utilities;

namespace EPOS_API
{
    public static class Common
    {
        static MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        public static string ToJson(DataTable dt)
        {
            List<Dictionary<string, object>> lst = new List<Dictionary<string, object>>();
            Dictionary<string, object> item;
            foreach (DataRow row in dt.Rows)
            {
                item = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    item.Add(col.ColumnName, (Convert.IsDBNull(row[col]) ? null : row[col]));
                }
                lst.Add(item);
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(lst);


        }

        public static dynamic DataTableToList(DataTable dt)
        {
            List<Dictionary<string, object>> lst = new List<Dictionary<string, object>>();
            Dictionary<string, object> item;
            foreach (DataRow row in dt.Rows)
            {
                item = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    item.Add(col.ColumnName, (Convert.IsDBNull(row[col]) ? null : row[col]));
                }
                lst.Add(item);
            }
            return lst;


        }

        public static string DataTableToJSONWithJSONNet(DataTable table)
        {
            var JSONString = new StringBuilder();
            if (table.Rows.Count > 0)
            {
                JSONString.Append("[");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    JSONString.Append("{");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (j < table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == table.Rows.Count - 1)
                    {
                        JSONString.Append("}");
                    }
                    else
                    {
                        JSONString.Append("},");
                    }
                }
                JSONString.Append("]");
            }
            return JSONString.ToString();
        }

        public static dynamic usp_Get_ApplicantApplicationData(DataSet obj_response)
        {
            try
            {

                //DataSet obj_response = _IApplicantDataDapperRepository.usp_Get_ApplicantApplicationData(CaseId, Tab_INDEX);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception e)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }

    }

}
