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
    public class ListingController : Controller
    {
        public IListingServices ListingServices;
        public ICreateList CreateList;
        public IReadList ReadList;
        public IEditList EditList;
        public IDeleteList DeleteList;
        public ListingModel ListModelc;

        public ListingController(IListingServices services,ICreateList listCreate,IReadList listRead, IEditList listEdit, IDeleteList listDelete,ListingModel modelList)
        {
            this.ListingServices = services;
            this.CreateList = listCreate;
            this.ReadList = listRead;
            this.EditList = listEdit;
            this.DeleteList = listDelete;
            this.ListModelc = modelList;
        }

        // GET: Listing
        public ActionResult ListAction()
        {
            DataTable dtblList = new DataTable();
            dtblList = ListingServices.GetListing();
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
            SqlDataReader sqlRead = CreateList.CreateProdList(ListModel);
            return RedirectToAction("Index", "Home");
        }

        // GET: Listing/Edit/5
        public ActionResult Edit(int id)
        {
            ListModelc = ReadList.ReadListData(id);
            return View(ListModelc);
        }

        // POST: Listing/Edit/5
        [HttpPost]
        public ActionResult Edit(ListingModel ListModel)
        {
            SqlDataReader sqlread = EditList.EditListData(ListModel);
            return RedirectToAction("Index", "Home");
        }

        // GET: Listing/Delete/5
        public ActionResult Delete(int id)
        {
            ListModelc = ReadList.ReadListData(id);
            return View(ListModelc);
        }

        // POST: Listing/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,ListingModel listModel)
        {
            SqlDataReader sqlread = DeleteList.DeleteListData(id, listModel);
            return RedirectToAction("Index","Home");
        }
    }
}
