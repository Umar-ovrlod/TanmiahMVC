using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using TanmiahDatabase.Models;

namespace TanmiahDatabase.Controllers
{
    public class BannerController : Controller
    {
        string connectionString = ConfigurationManager.ConnectionStrings["FoodDbContext"].ConnectionString;
        // GET: Banner
        public ActionResult Index()
        {
            DataTable dtblProduct = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spBanner", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType", "Select");
                cmd.Parameters.AddWithValue("@prodID", 1);
                sqlConn.Open();
                SqlDataReader sqlread = cmd.ExecuteReader();
                dtblProduct.Load(sqlread);
                sqlConn.Close();
            }
            return PartialView("_BannerView", dtblProduct);
        }

        // GET: Banner/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Banner/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Banner/Create
        [HttpPost]
        public ActionResult Create(BannerModel bannerModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
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
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        // GET: Banner/Edit/5
        public ActionResult Edit(int id)
        {
            BannerModel bannerModel = new BannerModel();
            DataTable dtblBanner = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                //sqlConn.Open();
                //string query = "Select * from Banner where ProductID=@ProductID";
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
                return View(bannerModel);
            }
            else
                return RedirectToAction("Index");
        }

        // POST: Banner/Edit/5
        [HttpPost]
        public ActionResult Edit(BannerModel bannerModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("spBanner", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@prodID", bannerModel.ProductID);
                sqlCmd.Parameters.AddWithValue("@prodType", bannerModel.ProductType);
                sqlCmd.Parameters.AddWithValue("@prodTitle", bannerModel.ProductTitle);
                sqlCmd.Parameters.AddWithValue("@prodDesc", bannerModel.ProductDescription);
                sqlCmd.Parameters.AddWithValue("@prodImage", bannerModel.ProductImage);
                sqlCmd.Parameters.AddWithValue("@StatementType", "Update");
                sqlCon.Open();
                SqlDataReader sqlread = sqlCmd.ExecuteReader();
                sqlCon.Close();
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Banner/Delete/5
        public ActionResult Delete(int id)
        {
            BannerModel bannerModel = new BannerModel();
            DataTable dtblBanner = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
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
                return View(bannerModel);
            }
            else
                return RedirectToAction("Index");
        }

        // POST: Banner/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BannerModel bannerModel)
        {
            DataTable dtblBanner = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spBanner", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType", "Delete");
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
                return View(bannerModel);
            }
            else
                return RedirectToAction("Index");
        }
    }
}
