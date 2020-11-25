using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Connect;
using TanmiahDatabase.Models;

namespace TanmiahDatabase.Services
{
    public class BreadcrumbServices : IBreadcrumbServices
    {
        public DataTable GetBreadcrumb(int id)
        {
            DataTable dtblProduct = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(Sql.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spBreadcrumb", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType", "Select");
                cmd.Parameters.AddWithValue("@prodID", id);
                sqlConn.Open();
                SqlDataReader sqlread = cmd.ExecuteReader();
                dtblProduct.Load(sqlread);
                sqlConn.Close();
                return dtblProduct;
            }
        }
    }

    public class ReadCrumb : IReadCrumb
    {
        public BreadcrumbModel Read(int id)
        {
            BreadcrumbModel breadcrumb = new BreadcrumbModel();
            DataTable dtblBread = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(Sql.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spBreadcrumb", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType", "Select");
                cmd.Parameters.AddWithValue("@prodID", id);
                sqlConn.Open();
                SqlDataReader sqlread = cmd.ExecuteReader();
                dtblBread.Load(sqlread);
                sqlConn.Close();
            }
            if (dtblBread.Rows.Count == 1)
            {
                breadcrumb.ProductID = Convert.ToInt32(dtblBread.Rows[0][0].ToString());
                breadcrumb.ProductTitle = dtblBread.Rows[0][1].ToString();
            }
            return breadcrumb;
        }
    }

    public class EditCrumb : IEditCrumb
    {
        public SqlDataReader EditBread(BreadcrumbModel breadcrumb)
        {
            using (SqlConnection sqlCon = new SqlConnection(Sql.ConnectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("spBreadcrumb", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@prodID", breadcrumb.ProductID);
                sqlCmd.Parameters.AddWithValue("@prodTitle", breadcrumb.ProductTitle);
                sqlCmd.Parameters.AddWithValue("@StatementType", "Update");
                sqlCon.Open();
                SqlDataReader sqlread = sqlCmd.ExecuteReader();
                sqlCon.Close();
                return sqlread;
            }
        }
    }
}