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
    public class DescriptionController : Controller
    {
        string connectionString = ConfigurationManager.ConnectionStrings["FoodDbContext"].ConnectionString;
        // GET: Description
        public ActionResult DescriptionAction()
        {
            DataTable dtblProduct = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDescription", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType", "Select");
                cmd.Parameters.AddWithValue("@prodID", 1);
                sqlConn.Open();
                SqlDataReader sqlread = cmd.ExecuteReader();
                dtblProduct.Load(sqlread);
                sqlConn.Close();
            }

            return PartialView("_DescriptionView", dtblProduct);
        }

        // GET: Description/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Description/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Description/Create
        [HttpPost]
        public ActionResult Create(DescriptionModel descModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("spDescription", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@DescTitle", descModel.DescTitle);
                sqlCmd.Parameters.AddWithValue("@DescText", descModel.DescText);
                sqlCmd.Parameters.AddWithValue("@DescDec", descModel.DescDec);
                sqlCmd.Parameters.AddWithValue("@pack", descModel.PerPack);
                sqlCmd.Parameters.AddWithValue("@energy", descModel.Energy);
                sqlCmd.Parameters.AddWithValue("@carbohydrates", descModel.Carbo);
                sqlCmd.Parameters.AddWithValue("@protiens", descModel.Protiens);
                sqlCmd.Parameters.AddWithValue("@Fat", descModel.Fat);
                sqlCmd.Parameters.AddWithValue("@ProtienPP", descModel.ProtiensPerPack);
                sqlCmd.Parameters.AddWithValue("@FatPP", descModel.FatPerPack);
                sqlCmd.Parameters.AddWithValue("@StatementType", "Insert");
                sqlCon.Open();
                SqlDataReader sqlread = sqlCmd.ExecuteReader();
                sqlCon.Close();
            }
            return RedirectToAction("Index", "Home");
        }
    

        // GET: Description/Edit/5
        public ActionResult Edit(int id)
        {
        DescriptionModel descModel = new DescriptionModel();
        DataTable dtblDesc = new DataTable();
        using (SqlConnection sqlConn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("spDescription", sqlConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StatementType", "Select");
            cmd.Parameters.AddWithValue("@prodID", id);
            sqlConn.Open();
            SqlDataReader sqlread = cmd.ExecuteReader();
            dtblDesc.Load(sqlread);
            sqlConn.Close();
        }
        if (dtblDesc.Rows.Count == 1)
        {
            descModel.ProductID = Convert.ToInt32(dtblDesc.Rows[0][0].ToString());
            descModel.DescTitle = dtblDesc.Rows[0][1].ToString();
            descModel.DescText = dtblDesc.Rows[0][2].ToString();
            descModel.DescDec = dtblDesc.Rows[0][3].ToString();
            descModel.PerPack = dtblDesc.Rows[0][4].ToString();
            descModel.Energy = dtblDesc.Rows[0][5].ToString();
            descModel.Carbo = dtblDesc.Rows[0][6].ToString();
            descModel.Protiens = dtblDesc.Rows[0][7].ToString();
            descModel.Fat = dtblDesc.Rows[0][8].ToString();
            descModel.ProtiensPerPack = dtblDesc.Rows[0][9].ToString();
            descModel.FatPerPack = dtblDesc.Rows[0][10].ToString();
            return View(descModel);
        }
        else
            return RedirectToAction("Index");
        }


        // POST: Description/Edit/5
        [HttpPost]
        public ActionResult Edit(DescriptionModel descModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("spDescription", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@prodID", descModel.ProductID);
                sqlCmd.Parameters.AddWithValue("@DescTitle", descModel.DescTitle);
                sqlCmd.Parameters.AddWithValue("@DescText", descModel.DescText);
                sqlCmd.Parameters.AddWithValue("@DescDec", descModel.DescDec);
                sqlCmd.Parameters.AddWithValue("@pack", descModel.PerPack);
                sqlCmd.Parameters.AddWithValue("@energy", descModel.Energy);
                sqlCmd.Parameters.AddWithValue("@carbohydrates", descModel.Carbo);
                sqlCmd.Parameters.AddWithValue("@protiens", descModel.Protiens);
                sqlCmd.Parameters.AddWithValue("@Fat", descModel.Fat);
                sqlCmd.Parameters.AddWithValue("@ProtienPP", descModel.ProtiensPerPack);
                sqlCmd.Parameters.AddWithValue("@FatPP", descModel.FatPerPack);
                sqlCmd.Parameters.AddWithValue("@StatementType", "Update");
                sqlCon.Open();
                SqlDataReader sqlread = sqlCmd.ExecuteReader();
                sqlCon.Close();//check here
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Description/Delete/5
        public ActionResult Delete(int id)
        {
            DescriptionModel descModel = new DescriptionModel();
            DataTable dtblDesc = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDescription", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType", "Select");
                cmd.Parameters.AddWithValue("@prodID", id);
                sqlConn.Open();
                SqlDataReader sqlread = cmd.ExecuteReader();
                dtblDesc.Load(sqlread);
                sqlConn.Close();
            }
            if (dtblDesc.Rows.Count == 1)
            {
                descModel.ProductID = Convert.ToInt32(dtblDesc.Rows[0][0].ToString());
                descModel.DescTitle = dtblDesc.Rows[0][1].ToString();
                descModel.DescText = dtblDesc.Rows[0][2].ToString();
                descModel.DescDec = dtblDesc.Rows[0][3].ToString();
                descModel.PerPack = dtblDesc.Rows[0][4].ToString();
                descModel.Energy = dtblDesc.Rows[0][5].ToString();
                descModel.Carbo = dtblDesc.Rows[0][6].ToString();
                descModel.Protiens = dtblDesc.Rows[0][7].ToString();
                descModel.Fat = dtblDesc.Rows[0][8].ToString();
                descModel.ProtiensPerPack = dtblDesc.Rows[0][9].ToString();
                descModel.FatPerPack = dtblDesc.Rows[0][10].ToString();
                return View(descModel);
            }
            else
                return RedirectToAction("Index");
        }

        // POST: Description/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,DescriptionModel descModel)
        {
            DataTable dtblDesc = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDescription", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType", "delete");
                cmd.Parameters.AddWithValue("@prodID", id);
                sqlConn.Open();
                SqlDataReader sqlread = cmd.ExecuteReader();
                dtblDesc.Load(sqlread);
                sqlConn.Close();
            }
            if (dtblDesc.Rows.Count == 1)
            {
                descModel.ProductID = Convert.ToInt32(dtblDesc.Rows[0][0].ToString());
                descModel.DescTitle = dtblDesc.Rows[0][1].ToString();
                descModel.DescText = dtblDesc.Rows[0][2].ToString();
                descModel.DescDec = dtblDesc.Rows[0][3].ToString();
                descModel.PerPack = dtblDesc.Rows[0][4].ToString();
                descModel.Energy = dtblDesc.Rows[0][5].ToString();
                descModel.Carbo = dtblDesc.Rows[0][6].ToString();
                descModel.Protiens = dtblDesc.Rows[0][7].ToString();
                descModel.Fat = dtblDesc.Rows[0][8].ToString();
                descModel.ProtiensPerPack = dtblDesc.Rows[0][9].ToString();
                descModel.FatPerPack = dtblDesc.Rows[0][10].ToString();
                return View(descModel);
            }
            else
                return RedirectToAction("Index","Home");
        }
    }
}
