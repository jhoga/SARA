using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SaraD2.Class;
using System.Windows;

namespace SaraD2
{
    public class DataRepository
    {
        public DataSet get_sigCatData(string sender)
        {
            string TableName = sender;
            var cnSig = new SqlConnection(Connections.csSig);
            var dsSig = new DataSet();
            var daSig = new SqlDataAdapter("select * from " + TableName, cnSig);
            var testString = "select * from " + TableName;
            daSig.Fill(dsSig, TableName);
            int rCount;
            rCount = dsSig.Tables[0].Rows.Count;
            return dsSig;
        }
        public DataSet get_signCatData(string sender)
        {
            string TableName = sender;
            var cnSign = new SqlConnection(Connections.csSign);
            var dsSign = new DataSet();
            var daSign = new SqlDataAdapter("select * from " + TableName, cnSign);
            var testString = "select * from " + TableName;
            daSign.Fill(dsSign, TableName);
            int rCount;
            rCount = dsSign.Tables[0].Rows.Count;
            return dsSign;
        }

        public DataSet get_ITCatData(string sender)
        {
            var TableName = sender;
            var cnSQL = new SqlConnection(Connections.csSQL);
            var dsIT = new DataSet();
            var daIT = new SqlDataAdapter("select * from " + TableName, cnSQL);
            var testString = "select * from " + TableName;
            daIT.Fill(dsIT, TableName);
            int rCount;
            rCount = dsIT.Tables[0].Rows.Count;
            return dsIT;

        }
        public DataSet get_ITRes(string sender)
        {
            var Category = sender;
            var cnIT = new SqlConnection(Connections.csSQL);
            var dsIT = new DataSet();
            var testString = "select * from  TechResTable where " + Category + " = true";
            var daIT = new SqlDataAdapter("select * from  TechResTable where " + Category + " = 1", cnIT);
           
            daIT.Fill(dsIT, Category);
            int rCount;
            rCount = dsIT.Tables[0].Rows.Count;
            return dsIT;

        }
        public DataSet get_FireCatData(string sender)
        {
            var TableName = sender;
            var cnIT = new SqlConnection(Connections.csSQL);
            var dsIT = new DataSet();
            var daIT = new SqlDataAdapter("select * from " + TableName, cnIT);
            var testString = "select * from " + TableName;
            daIT.Fill(dsIT, TableName);
            int rCount;
            rCount = dsIT.Tables[0].Rows.Count;
            return dsIT;

        }
        public void add_NewIT(string[] arr)
        {
            string test1 = arr[0].ToString();
            var cn = new SqlConnection(Connections.csSQL);
            var MyCon = new SqlCommand();
            MyCon.Connection = cn;
            MyCon.CommandType = CommandType.StoredProcedure;
            MyCon.CommandText = "new_add_ticket";
            MyCon.Parameters.Add("@Date_Entered", SqlDbType.DateTime).Value = arr[0];
            MyCon.Parameters.Add("@Requestor", SqlDbType.VarChar).Value = arr[1];
            MyCon.Parameters.Add("@Email", SqlDbType.VarChar).Value = arr[2];
            MyCon.Parameters.Add("@Status", SqlDbType.VarChar).Value = arr[3];
            MyCon.Parameters.Add("@Assigned_to", SqlDbType.VarChar).Value = arr[4];
            MyCon.Parameters.Add("@Problem_detail", SqlDbType.VarChar).Value = arr[10];
            MyCon.Parameters.Add("@Department", SqlDbType.VarChar).Value = arr[4];
            MyCon.Parameters.Add("@Category", SqlDbType.VarChar).Value = arr[5];
            MyCon.Parameters.Add("@SubCategory", SqlDbType.VarChar).Value = arr[6];
            MyCon.Parameters.Add("@Alert_Level", SqlDbType.Int).Value = arr[8];
            MyCon.Parameters.Add("@Requestor_Telep", SqlDbType.VarChar).Value = arr[9];
            MyCon.Parameters.Add("@Equipnum", SqlDbType.VarChar).Value = arr[7];

            cn.Open();
            try
            {
                MyCon.ExecuteNonQuery();
            }

            catch (SqlException myException)
            {
                MessageBox.Show(("Source: " + myException.Source + "\r" +
                                   "Number: " + myException.Number.ToString() + "\r" +
                                   "State: " + myException.State.ToString() + "\r" +
                                   "Class: " + myException.Class.ToString() + "\r" +
                                   "Server: " + myException.Server + "\r" +
                                   "Message: " + myException.Message + "\r" +
                                   "Procedure: " + myException.Procedure + "\r" +
                                   "Line: " + myException.LineNumber.ToString()));
            }
        }
        public void add_NewFAC(string[] arr)
        {
            string test1 = arr[0].ToString();
            var cn = new SqlConnection(Connections.csFAC);
            var MyCon = new SqlCommand();
            MyCon.Connection = cn;
            MyCon.CommandType = CommandType.StoredProcedure;
            MyCon.CommandText = "new_add_ticket";
            MyCon.Parameters.Add("@in_date", SqlDbType.DateTime).Value = arr[0];
            MyCon.Parameters.Add("@user", SqlDbType.VarChar).Value = arr[1];
            MyCon.Parameters.Add("@email", SqlDbType.VarChar).Value = arr[2];
            MyCon.Parameters.Add("@Location", SqlDbType.VarChar).Value = arr[3];
            MyCon.Parameters.Add("@Type", SqlDbType.VarChar).Value = arr[4];
            MyCon.Parameters.Add("@SubType", SqlDbType.VarChar).Value = arr[5];
            MyCon.Parameters.Add("@description", SqlDbType.VarChar).Value = arr[6];
            MyCon.Parameters.Add("@severity", SqlDbType.Int).Value = arr[7];
            cn.Open();
            try
            {
                MyCon.ExecuteNonQuery();
            }

            catch (SqlException myException)
            {
                MessageBox.Show(("Source: " + myException.Source + "\r" +
                                   "Number: " + myException.Number.ToString() + "\r" +
                                   "State: " + myException.State.ToString() + "\r" +
                                   "Class: " + myException.Class.ToString() + "\r" +
                                   "Server: " + myException.Server + "\r" +
                                   "Message: " + myException.Message + "\r" +
                                   "Procedure: " + myException.Procedure + "\r" +
                                   "Line: " + myException.LineNumber.ToString()));
            }
        }
        public DataSet getMax()
        {
            
            var cnIT = new SqlConnection(Connections.csSQL);
            var dsIT = new DataSet();
            var testString = "select max(TicketID) as ID from Tickets" ;
            var daIT = new SqlDataAdapter(testString, cnIT);

            daIT.Fill(dsIT, "Tickets");
            int rCount;
            rCount = dsIT.Tables[0].Rows.Count;
            return dsIT;
        }
        public DataSet get_FacTables(string tableName)
        {
            var cnFac = new SqlConnection(Connections.csFAC);
            var dsFac = new DataSet();
            var daFac = new SqlDataAdapter("select * from " + tableName + " order by description" , cnFac);
             daFac.Fill(dsFac, tableName);
            int rCount;
            rCount = dsFac.Tables[0].Rows.Count;
            return dsFac;

        }
        public DataSet get_Locations()
        {
            var cnFac = new SqlConnection(Connections.csFAC);
            var dsFac = new DataSet();
            var daFac = new SqlDataAdapter("select * from Locations order by Location" , cnFac);
            daFac.Fill(dsFac, "Locations");
            int rCount;
            rCount = dsFac.Tables[0].Rows.Count;
            return dsFac;


        }
        public DataSet get_FacCat()
        {
            var cnFac = new SqlConnection(Connections.csFAC);
            var dsFac = new DataSet();
            var daFac = new SqlDataAdapter("select * from FacCatMain", cnFac);
            daFac.Fill(dsFac, "FacCatMain");
            int rCount;
            rCount = dsFac.Tables[0].Rows.Count;
            return dsFac;

        }

    }
}
