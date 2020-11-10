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
                sqlConn.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("Select * from Banner where ProductID=1", sqlConn);
                sqlData.Fill(dtblProduct);
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        // GET: Banner/Edit/5
        public ActionResult Edit(int id)
        {
            BannerModel bannerModel = new BannerModel();
            DataTable dtblBanner = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                sqlConn.Open();
                string query = "Select * from Banner where ProductID=@ProductID";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlConn);
                sqlDa.SelectCommand.Parameters.AddWithValue("@ProductID", id);
                sqlDa.Fill(dtblBanner);
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

        // POST: Banner/Edit/5
        [HttpPost]
        public ActionResult Edit(BannerModel bannerModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "update Banner Set ProductType = @Type, ProductTitle = @Title, ProductDescription = @Desc where ProductID = @ID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@ID", bannerModel.ProductID);
                sqlCmd.Parameters.AddWithValue("@Type", bannerModel.ProductType);
                sqlCmd.Parameters.AddWithValue("@Title", bannerModel.ProductTitle);
                sqlCmd.Parameters.AddWithValue("@Desc", bannerModel.ProductDescription);
               
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Banner/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Banner/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
