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
    public class DescriptionController : Controller
    {
        // GET: Description
        public ActionResult DescriptionAction()
        {
            DataTable dtblProduct = new DataTable();
            DescriptionServices desc = new DescriptionServices();
            int id = 1;
            dtblProduct = desc.GetDescription(id);
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
            CreateDescription desc = new CreateDescription();
            SqlDataReader sqlread = desc.CreateDesc(descModel);
            return RedirectToAction("Index", "Home");
        }


        // GET: Description/Edit/5
        public ActionResult Edit(int id)
        {
            DescriptionModel descModel = new DescriptionModel();
            ReadDescription desc = new ReadDescription();
            descModel = desc.ReadDescData(id);
            return View(descModel);
        }


        // POST: Description/Edit/5
        [HttpPost]
        public ActionResult Edit(DescriptionModel descModel)
        {
            EditDescription edit = new EditDescription();
            SqlDataReader sqlread = edit.EditDescData(descModel);
            return RedirectToAction("Index", "Home");
        }

        // GET: Description/Delete/5
        public ActionResult Delete(int id)
        {
            DescriptionModel descModel = new DescriptionModel();
            ReadDescription desc = new ReadDescription();
            descModel = desc.ReadDescData(id);
            return View(descModel);
        }

        // POST: Description/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, DescriptionModel descModel)//Continue
        {
            DataTable dtblDesc = new DataTable();
            DeleteDescription dlt = new DeleteDescription();
            SqlDataReader sqlread = dlt.DeleteDescData(id, descModel);
            return RedirectToAction("Index", "Home");
        }
    }
}
