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
    public class ListingController : Controller
    {
        string connectionString = ConfigurationManager.ConnectionStrings["FoodDbContext"].ConnectionString;
        // GET: Listing
        public ActionResult ListAction()
        {

            DataTable dtblList = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spListing", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType", "Select");
                sqlConn.Open();
                SqlDataReader sqlread = cmd.ExecuteReader();
                dtblList.Load(sqlread);
                sqlConn.Close();
            }
            return PartialView("_ListingView", dtblList);
        }

        // GET: Listing/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Listing/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Listing/Create
        [HttpPost]
        public ActionResult Create(ListingModel ListModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
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
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Listing/Edit/5
        public ActionResult Edit(int id)
        {
            ListingModel ListModel = new ListingModel();
            DataTable dtbllist = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
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
                    return View(ListModel);
            }
            else
                return RedirectToAction("Index");
        }

        // POST: Listing/Edit/5
        [HttpPost]
        public ActionResult Edit(ListingModel ListModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
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
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Listing/Delete/5
        public ActionResult Delete(int id)
        {
            ListingModel listModel = new ListingModel();
            DataTable dtbllist = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
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
                listModel.ListingID = Convert.ToInt32(dtbllist.Rows[0][0].ToString());
                listModel.ListingImg = dtbllist.Rows[0][1].ToString();
                listModel.ListingProd = dtbllist.Rows[0][2].ToString();
                listModel.ListingProdTitle = dtbllist.Rows[0][3].ToString();
                listModel.ListingDetail = dtbllist.Rows[0][4].ToString();
                return View(listModel);
            }
            else
                return RedirectToAction("Index");
        }

        // POST: Listing/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,ListingModel listModel)
        {
            DataTable dtbllist = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spListing", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType", "Delete");
                cmd.Parameters.AddWithValue("@listid", id);
                sqlConn.Open();
                SqlDataReader sqlread = cmd.ExecuteReader();
                dtbllist.Load(sqlread);
                sqlConn.Close();
            }
            if (dtbllist.Rows.Count == 1)
            {
                listModel.ListingID = Convert.ToInt32(dtbllist.Rows[0][0].ToString());
                listModel.ListingImg = dtbllist.Rows[0][1].ToString();
                listModel.ListingProd = dtbllist.Rows[0][2].ToString();
                listModel.ListingProdTitle = dtbllist.Rows[0][3].ToString();
                listModel.ListingDetail = dtbllist.Rows[0][4].ToString();
                return View(listModel);
            }
            else
                return RedirectToAction("Index","Home");
        }
    }
}
