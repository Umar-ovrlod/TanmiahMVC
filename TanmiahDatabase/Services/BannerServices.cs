//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;
//using TanmiahDatabase.Models;

//namespace TanmiahDatabase.Services
//{
//    public class BannerServices
//    {
//        public BannerModel Banner()
//        {
//            BannerModel bannerModel = new BannerModel();
//            System.Data.DataTable dtblBanner = new DataTable();
//            using (SqlConnection sqlConn = new SqlConnection(connectionString))
//            {
//                //sqlConn.Open();
//                //string query = "Select * from Banner where ProductID=@ProductID";
//                SqlCommand cmd = new SqlCommand("spBanner", sqlConn);
//                cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                cmd.Parameters.AddWithValue("@StatementType", "Select");
//                cmd.Parameters.AddWithValue("@prodID", id);
//                sqlConn.Open();
//                SqlDataReader sqlread = cmd.ExecuteReader();
//                dtblBanner.Load(sqlread);
//                sqlConn.Close();
//            }
//            if (dtblBanner.Rows.Count == 1)
//            {
//                bannerModel.ProductID = Convert.ToInt32(dtblBanner.Rows[0][0].ToString());
//                bannerModel.ProductType = dtblBanner.Rows[0][1].ToString();
//                bannerModel.ProductTitle = dtblBanner.Rows[0][2].ToString();
//                bannerModel.ProductDescription = dtblBanner.Rows[0][3].ToString();
//                return bannerModel;
//            }
//    }
//}