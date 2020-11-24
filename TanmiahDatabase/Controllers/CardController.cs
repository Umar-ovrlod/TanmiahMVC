using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using TanmiahDatabase.Models;
using TanmiahDatabase.Services;

namespace TanmiahDatabase.Controllers
{
    public class CardController : Controller
    {
        // GET: Card
        public ActionResult CardAction()
        {
            DataTable dtblCard = new DataTable();
            CardServices card = new CardServices();
            int id = 1;
            dtblCard = card.GetCard(id);
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
            CreateCard create = new CreateCard();
            SqlDataReader sqlread = create.GenerateCard(card);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        // GET: Card/Edit/5
        public ActionResult Edit(int id)
        {
            ReadCard read = new ReadCard();
            cardModel card = read.ReadCardData(id);
            return View(card);
        }

        // POST: Card/Edit/5
        [HttpPost]
        public ActionResult Edit(cardModel card)
        {
            EditCard edit = new EditCard();
            SqlDataReader sqlread= edit.EditCardData(card);
            return RedirectToAction("Index", "Home");
        }
           
        

        // GET: Card/Delete/5
        public ActionResult Delete(int id)
        {
            ReadCard read = new ReadCard();
            cardModel card = read.ReadCardData(id);
            return View(card);
        }

        // POST: Card/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, cardModel card)
        {
            //datatable dtblcard = new datatable();
            DeleteCard dltCard = new DeleteCard();
            SqlDataReader sqlRead = dltCard.DeleteCardData(card,id);
            return RedirectToAction("Index", "Home");
        }
    }
}
