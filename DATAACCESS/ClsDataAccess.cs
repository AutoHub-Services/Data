using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AutoHubWITHSQL
{
    public class ClsDataAccess
    {
        public SqlConnection OpenSqlConnection()
        {
            SqlConnection sqlcon = null;
            string sSqlcCon = @"Data Source=103.21.58.193;Initial Catalog=AutoHub;Persist Security Info=True;User ID=OTGS_DB_User;password=OTGS#AutoHub2017;";
            try
            {
                sqlcon = new SqlConnection(sSqlcCon);
                if (sqlcon.State.Equals(ConnectionState.Open))
                {
                    sqlcon.Close();
                    sqlcon.Open();
                }
                else
                    sqlcon.Open();
            }
            catch (Exception ex)
            {

            }
            return sqlcon;
        }
        public string AlterDB(string sSQLQuery)
        {
            string sMessage = "";
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = OpenSqlConnection();
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sSQLQuery;
                sMessage = cmd.ExecuteNonQuery().ToString().Equals("0") ? "Faild" : "Sucess";
            }
            catch (Exception ex)
            {
                sMessage = ex.Message.ToString();
            }
            SqlConnection.ClearAllPools();
            return sMessage;
        }
        public string GetData(string sSQLQuery)
        {
            string sMessage = "";
            SqlCommand cmd = new SqlCommand();
            DataTable dtdata = new DataTable();
            try
            {
                cmd.Connection = OpenSqlConnection();
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sSQLQuery;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtdata);
                if (dtdata.Rows.Count > 0)
                    sMessage = DataTableToJSONWithJSONNet(dtdata);
                else
                    sMessage = "No Data Found";
            }
            catch (Exception ex)
            {
                sMessage = "No Data Found "+ ex.Message.ToString();
            } 
            SqlConnection.ClearAllPools();
            return sMessage;
        }
         
        public string DataTableToJSONWithJSONNet(DataTable table)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(table);
            return JSONString;
        }  
    }
}