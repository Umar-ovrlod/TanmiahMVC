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
        public ICardServices CardService;
        public ICreateCard CardCreate;
        public IReadCard readCard;
        public IEditCard cardEdit;
        public IDeleteCard cardDelete;
        public cardModel ModelCardc;
        public CardController(ICardServices servicesCard, ICreateCard createCard, IReadCard cardRead, IEditCard editCard, IDeleteCard deleteCard, cardModel cardModel)
        {
            this.CardService = servicesCard;
            this.CardCreate = createCard;
            this.readCard = cardRead;
            this.cardEdit = editCard;
            this.cardDelete = deleteCard;
            this.ModelCardc = cardModel;
        }


        // GET: Card
        public ActionResult CardAction()
        {
            DataTable dtblCard = new DataTable();
            int id = 1;
            dtblCard = CardService.GetCard(id);
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
            if (ModelState.IsValid)
            {
                SqlDataReader sqlread = CardCreate.GenerateCard(card);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(card);
            }
        }

        [HttpGet]
        // GET: Card/Edit/5
        public ActionResult Edit(int id)
        {
            if (ModelState.IsValid)
            {
                ModelCardc = readCard.ReadCardData(id);
                return View(ModelCardc);
            }
            else
            {
                return View(ModelCardc);
            }
        }

        // POST: Card/Edit/5
        [HttpPost]
        public ActionResult Edit(cardModel card)
        {
            if (ModelState.IsValid)
            {
                SqlDataReader sqlread = cardEdit.EditCardData(card);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(card);
            }
        }


        // GET: Card/Delete/5
        public ActionResult Delete(int id)
        {
            ModelCardc = readCard.ReadCardData(id);
            return View(ModelCardc);
        }

        // POST: Card/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, cardModel card)
        {
            SqlDataReader sqlRead = cardDelete.DeleteCardData(card, id);
            return RedirectToAction("Index", "Home");
        }
    }
}
