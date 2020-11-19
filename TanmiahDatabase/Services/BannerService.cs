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

    public class BannerService
    {
        //function for fetching index data 
        public DataTable getDataTable(int id)
        {
            using (SqlConnection sqlConn = new SqlConnection(Sql.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spBanner", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType", "Select");
                cmd.Parameters.AddWithValue("@prodID", id);
                sqlConn.Open();
                SqlDataReader sqlread = cmd.ExecuteReader();
                DataTable dtblProduct = new DataTable();
                dtblProduct.Load(sqlread);
                sqlConn.Close();
                return dtblProduct;
            }
        }
    }
    public class CreateBanner
    {
        public SqlDataReader createData(BannerModel bannerModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(Sql.ConnectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("spBanner", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@prodType", bannerModel.ProductType);
                sqlCmd.Parameters.AddWithValue("@prodTitle", bannerModel.ProductTitle);
                sqlCmd.Parameters.AddWithValue("@prodDesc", bannerModel.ProductDescription);
                sqlCmd.Parameters.AddWithValue("@prodImage", bannerModel.ProductImage);
                sqlCmd.Parameters.AddWithValue("@StatementType", "Insert");
                sqlCon.Open();
                SqlDataReader sqlread = sqlCmd.ExecuteReader();
                sqlCon.Close();
                return sqlread;
            }
        }
}

    public class ReadBanner
    {
         public BannerModel ReadData(int id)
        {
            BannerModel bannerModel = new BannerModel();
            DataTable dtblBanner = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(Sql.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spBanner", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType", "Select");
                cmd.Parameters.AddWithValue("@prodID", id);
                sqlConn.Open();
                SqlDataReader sqlread = cmd.ExecuteReader();
                dtblBanner.Load(sqlread);
                sqlConn.Close();
            }
            if (dtblBanner.Rows.Count == 1)
            {
                bannerModel.ProductID = Convert.ToInt32(dtblBanner.Rows[0][0].ToString());
                bannerModel.ProductType = dtblBanner.Rows[0][1].ToString();
                bannerModel.ProductTitle = dtblBanner.Rows[0][2].ToString();
                bannerModel.ProductDescription = dtblBanner.Rows[0][3].ToString();
                bannerModel.ProductImage = dtblBanner.Rows[0][4].ToString();
            }
            return bannerModel;
        }
    }

    public class EditBanner
    {
        public SqlDataReader EditData(BannerModel bannerModel, string statement)
        {
            using (SqlConnection sqlCon = new SqlConnection(Sql.ConnectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("spBanner", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@prodID", bannerModel.ProductID);
                sqlCmd.Parameters.AddWithValue("@prodType", bannerModel.ProductType);
                sqlCmd.Parameters.AddWithValue("@prodTitle", bannerModel.ProductTitle);
                sqlCmd.Parameters.AddWithValue("@prodDesc", bannerModel.ProductDescription);
                sqlCmd.Parameters.AddWithValue("@prodImage", bannerModel.ProductImage);
                sqlCmd.Parameters.AddWithValue("@StatementType", statement);
                sqlCon.Open();
                SqlDataReader sqlread = sqlCmd.ExecuteReader();
                sqlCon.Close();
                return sqlread;
            }
        }
    }


    public class DeleteBanner
    {
        public SqlDataReader DeleteData(int id, BannerModel bannerModel, string statement)
        {
            using (SqlConnection sqlCon = new SqlConnection(Sql.ConnectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("spBanner", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@prodID", id);
                sqlCmd.Parameters.AddWithValue("@prodType", bannerModel.ProductType);
                sqlCmd.Parameters.AddWithValue("@prodTitle", bannerModel.ProductTitle);
                sqlCmd.Parameters.AddWithValue("@prodDesc", bannerModel.ProductDescription);
                sqlCmd.Parameters.AddWithValue("@prodImage", bannerModel.ProductImage);
                sqlCmd.Parameters.AddWithValue("@StatementType", statement);
                sqlCon.Open();
                SqlDataReader sqlread = sqlCmd.ExecuteReader();
                sqlCon.Close();
                return sqlread;
            }
        }
   }
}
