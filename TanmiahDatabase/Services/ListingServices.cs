using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TanmiahDatabase.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlTypes;
using Connect;

namespace TanmiahDatabase.Services
{

    public class ListingServices
    {
        public DataTable GetListing()
        {
            DataTable dtblList = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(Sql.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spListing", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType", "Select");
                sqlConn.Open();
                SqlDataReader sqlread = cmd.ExecuteReader();
                dtblList.Load(sqlread);
                sqlConn.Close();
                return dtblList;
            }
        }
    }

    public class CreateList
    {
        public SqlDataReader CreateProdList(ListingModel ListModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(Sql.ConnectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("spListing", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@listImg", ListModel.ListingImg);
                sqlCmd.Parameters.AddWithValue("@listCat", ListModel.ListingProd);
                sqlCmd.Parameters.AddWithValue("@listTitle", ListModel.ListingProdTitle);
                sqlCmd.Parameters.AddWithValue("@listText", ListModel.ListingDetail);
                sqlCmd.Parameters.AddWithValue("@StatementType", "Insert");
                sqlCon.Open();
                SqlDataReader sqlread = sqlCmd.ExecuteReader();
                sqlCon.Close();
                return sqlread;
            }
        }
    }
    public class ReadList
    {
        public ListingModel ReadListData(int id)
        {
            ListingModel ListModel = new ListingModel();
            DataTable dtbllist = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(Sql.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spListing", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType", "SelectEdit");
                cmd.Parameters.AddWithValue("@listid", id);
                sqlConn.Open();
                SqlDataReader sqlread = cmd.ExecuteReader();
                dtbllist.Load(sqlread);
                sqlConn.Close();
            }
            if (dtbllist.Rows.Count == 1)
            {
                ListModel.ListingID = Convert.ToInt32(dtbllist.Rows[0][0].ToString());
                ListModel.ListingImg = dtbllist.Rows[0][1].ToString();
                ListModel.ListingProd = dtbllist.Rows[0][2].ToString();
                ListModel.ListingProdTitle = dtbllist.Rows[0][3].ToString();
                ListModel.ListingDetail = dtbllist.Rows[0][4].ToString();

            }
            return ListModel;
        }
    }

    public class EditList
    {
        public SqlDataReader EditListData(ListingModel ListModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(Sql.ConnectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("spListing", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@listid", ListModel.ListingID);
                sqlCmd.Parameters.AddWithValue("@listImg", ListModel.ListingImg);
                sqlCmd.Parameters.AddWithValue("@listCat", ListModel.ListingProd);
                sqlCmd.Parameters.AddWithValue("@listTitle", ListModel.ListingProdTitle);
                sqlCmd.Parameters.AddWithValue("@listText", ListModel.ListingDetail);
                sqlCmd.Parameters.AddWithValue("@StatementType", "Update");
                sqlCon.Open();
                SqlDataReader sqlread = sqlCmd.ExecuteReader();
                sqlCon.Close();
                return sqlread;
            }
        }
    }

    public class DeleteList
    {
        public SqlDataReader DeleteListData(int id, ListingModel listModel)
        {
            DataTable dtbllist = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(Sql.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spListing", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType", "Delete");
                cmd.Parameters.AddWithValue("@listid", id);
                sqlConn.Open();
                SqlDataReader sqlread = cmd.ExecuteReader();
                dtbllist.Load(sqlread);
                sqlConn.Close();
                return sqlread;
            } 
        }
    }


}