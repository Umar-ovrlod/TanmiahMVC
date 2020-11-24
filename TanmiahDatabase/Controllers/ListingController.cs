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
        //string connectionString = ConfigurationManager.ConnectionStrings["FoodDbContext"].ConnectionString;
        // GET: Listing
        public ActionResult ListAction()
        {
            //int id = 1;
            DataTable dtblList = new DataTable();
            ListingServices ProdList = new ListingServices();
            dtblList = ProdList.GetListing();
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
            CreateList addList = new CreateList();
            SqlDataReader sqlRead = addList.CreateProdList(ListModel);
            return RedirectToAction("Index", "Home");
        }

        // GET: Listing/Edit/5
        public ActionResult Edit(int id)
        {
            ReadList read = new ReadList();
            ListingModel ListModel = read.ReadListData(id);
            return View(ListModel);
        }

        // POST: Listing/Edit/5
        [HttpPost]
        public ActionResult Edit(ListingModel ListModel)
        {
            EditList editListItems = new EditList();
            SqlDataReader sqlread = editListItems.EditListData(ListModel);
            return RedirectToAction("Index", "Home");
        }

        // GET: Listing/Delete/5
        public ActionResult Delete(int id)
        {
            ReadList read = new ReadList();
            ListingModel ListModel = read.ReadListData(id);
            return View(ListModel);
        }

        // POST: Listing/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,ListingModel listModel)
        {
            DeleteList dltList = new DeleteList();
            SqlDataReader sqlread = dltList.DeleteListData(id, listModel);
            return RedirectToAction("Index","Home");
        }
    }
}
