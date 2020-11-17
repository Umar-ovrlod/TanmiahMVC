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
    public class CardController : Controller
    {
        string connectionString = ConfigurationManager.ConnectionStrings["FoodDbContext"].ConnectionString;
        // GET: Card
        public ActionResult CardAction()
        {
            DataTable dtblCard = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spCard", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType","Select");
                cmd.Parameters.AddWithValue("@prodID",1);
                sqlConn.Open();
                SqlDataReader sqlread = cmd.ExecuteReader();
                dtblCard.Load(sqlread);
                sqlConn.Close();
            }
             return PartialView("_CardView", dtblCard);
        }
           
      

        // GET: Card/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Card/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Card/Create
        [HttpPost]
        public ActionResult Create(cardModel card)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("spCard", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                //sqlCmd.Parameters.AddWithValue("@prodID", card.ProductID);
                //sqlCmd.Parameters.AddWithValue("@cardImg", card.CardImage);
                //sqlCmd.Parameters.AddWithValue("@cardTitle", card.ShortDescription);
                //sqlCmd.Parameters.AddWithValue("@cardText", card.ShortText);
                //sqlCmd.Parameters.AddWithValue("@StatementType", "Insert");
                sqlCmd.Parameters.AddWithValue("@cardImg", card.CardImage);
                sqlCmd.Parameters.AddWithValue("@cardTitle", card.ShortDescription);
                sqlCmd.Parameters.AddWithValue("@cardText", card.ShortText);
                sqlCmd.Parameters.AddWithValue("@StatementType", "Insert");
                sqlCon.Open();
                SqlDataReader sqlread = sqlCmd.ExecuteReader();
                sqlCon.Close();
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Card/Edit/5
        public ActionResult Edit(int id)
        {
            cardModel card = new cardModel();
            DataTable dtblCard = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                
                SqlCommand cmd = new SqlCommand("spCard", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType","select");
                cmd.Parameters.AddWithValue("@prodID",id);
                sqlConn.Open();
                SqlDataReader sqlread = cmd.ExecuteReader();
                dtblCard.Load(sqlread);
                sqlConn.Close();
            }
            if (dtblCard.Rows.Count == 1)
            {
                card.ProductID = Convert.ToInt32(dtblCard.Rows[0][0].ToString());
                card.CardImage = dtblCard.Rows[0][1].ToString();
                card.ShortDescription = dtblCard.Rows[0][2].ToString();
                card.ShortText = dtblCard.Rows[0][3].ToString();
                return View(card);
            }
            else
                return RedirectToAction("Index");
        }

        // POST: Card/Edit/5
        [HttpPost]
        public ActionResult Edit(cardModel card)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("spCard", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@prodID", card.ProductID);//miss
                sqlCmd.Parameters.AddWithValue("@cardImg", card.CardImage);
                sqlCmd.Parameters.AddWithValue("@cardTitle", card.ShortDescription);
                sqlCmd.Parameters.AddWithValue("@cardText", card.ShortText);
                sqlCmd.Parameters.AddWithValue("@StatementType", "Update");
                sqlCon.Open();
                SqlDataReader sqlread = sqlCmd.ExecuteReader();
                sqlCon.Close();
            }
            return RedirectToAction("Index", "Home");
           
        }

        // GET: Card/Delete/5
        public ActionResult Delete(int id)
        {
            cardModel card = new cardModel();
            DataTable dtblCard = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spCard", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType", "Select");
                cmd.Parameters.AddWithValue("@prodID", id);
                sqlConn.Open();
                SqlDataReader sqlread = cmd.ExecuteReader();
                dtblCard.Load(sqlread);
                sqlConn.Close();
            }
            if (dtblCard.Rows.Count == 1)
            {
                card.ProductID = Convert.ToInt32(dtblCard.Rows[0][0].ToString());
                card.CardImage = dtblCard.Rows[0][1].ToString();
                card.ShortDescription =dtblCard.Rows[0][2].ToString();
                card.ShortText = dtblCard.Rows[0][3].ToString();
                return View(card);
            }
            else
                return RedirectToAction("Index");
        }

        // POST: Card/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, cardModel card)
        {
            DataTable dtblcard = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spCard", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType", "Delete");
                cmd.Parameters.AddWithValue("@prodID", id);
                sqlConn.Open();
                SqlDataReader sqlread = cmd.ExecuteReader();
                dtblcard.Load(sqlread);
                sqlConn.Close();
            }
            if (dtblcard.Rows.Count == 1)
            {
                card.ProductID = Convert.ToInt32(dtblcard.Rows[0][0].ToString());
                card.CardImage = dtblcard.Rows[0][1].ToString();
                card.ShortDescription = dtblcard.Rows[0][2].ToString();
                card.ShortText = dtblcard.Rows[0][3].ToString();
                return View(card);
            }
            else
                return RedirectToAction("Index", "Home");
        }
    }
}
