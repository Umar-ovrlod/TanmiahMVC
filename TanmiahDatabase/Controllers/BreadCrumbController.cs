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
    public class BreadCrumbController : Controller
    {
        string connectionString = ConfigurationManager.ConnectionStrings["FoodDbContext"].ConnectionString;
        // GET: BreadCrumb
        public ActionResult BreadCrumbAction()
        {
            DataTable dtblProduct = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spBreadcrumb", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType", "Select");
                cmd.Parameters.AddWithValue("@prodID", 1);
                sqlConn.Open();
                SqlDataReader sqlread = cmd.ExecuteReader();
                dtblProduct.Load(sqlread);
                sqlConn.Close();
            }
            return PartialView("_BreadcrumbView", dtblProduct);
        }

        // GET: BreadCrumb/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BreadCrumb/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BreadCrumb/Create
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

        // GET: BreadCrumb/Edit/5
        public ActionResult Edit(int id)
        {
            BreadcrumbModel breadcrumb = new BreadcrumbModel();
            DataTable dtblBread = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                //sqlConn.Open();
                //string query = "Select * from Banner where ProductID=@ProductID";
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
                breadcrumb.ProductTitle = dtblBread.Rows[0][2].ToString();
                return View(breadcrumb);
            }
            else
                return RedirectToAction("Index");
        }

        // POST: BreadCrumb/Edit/5
        [HttpPost]
        public ActionResult Edit(BreadcrumbModel breadcrumb)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("spBanner", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@prodID", breadcrumb.ProductID);
                sqlCmd.Parameters.AddWithValue("@prodTitle", breadcrumb.ProductTitle);
                sqlCon.Open();
                SqlDataReader sqlread = sqlCmd.ExecuteReader();
                sqlCon.Close();
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: BreadCrumb/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BreadCrumb/Delete/5
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
