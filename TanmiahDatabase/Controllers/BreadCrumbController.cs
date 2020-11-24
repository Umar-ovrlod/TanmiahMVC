using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using TanmiahDatabase.Models;
using Connect;
using TanmiahDatabase.Services;

namespace TanmiahDatabase.Controllers
{
    public class BreadCrumbController : Controller
    {
        
        // GET: BreadCrumb
        public ActionResult BreadCrumbAction()
        {
            BreadcrumbServices crumbService = new BreadcrumbServices();
            DataTable dtblProduct = new DataTable();
            int id = 1;
            dtblProduct = crumbService.GetBreadcrumb(id);
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
        [HttpGet]
        // GET: BreadCrumb/Edit/5
        public ActionResult Edit(int id)
        {
            ReadCrumb crumb = new ReadCrumb();
            BreadcrumbModel breadcrumb = crumb.Read(id);
            return View(breadcrumb);
        }

        // POST: BreadCrumb/Edit/5
        [HttpPost]
        public ActionResult Edit(BreadcrumbModel breadcrumb)
        {
            EditCrumb edit = new EditCrumb();
            SqlDataReader sqlCmd = edit.EditBread(breadcrumb);
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
