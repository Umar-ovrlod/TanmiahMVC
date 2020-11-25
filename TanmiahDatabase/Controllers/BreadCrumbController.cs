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
        public IBreadcrumbServices breadcrumbServicesInt;
        public IReadCrumb readCrumbInt;
        public IEditCrumb editCrumbInt;
        public BreadcrumbModel crumbModelc;

        public BreadCrumbController(IBreadcrumbServices breadcrumbServices,IReadCrumb readCrumb,IEditCrumb editCrumb,BreadcrumbModel breadcrumb)
        {
            this.breadcrumbServicesInt = breadcrumbServices;
            this.readCrumbInt = readCrumb;
            this.editCrumbInt = editCrumb;
            this.crumbModelc = breadcrumb;
        }

        // GET: BreadCrumb
        public ActionResult BreadCrumbAction()
        {
            DataTable dtblProduct = new DataTable();
            int id = 1;
            dtblProduct = breadcrumbServicesInt.GetBreadcrumb(id);
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
            crumbModelc = readCrumbInt.Read(id);
            return View(crumbModelc);
        }

        // POST: BreadCrumb/Edit/5
        [HttpPost]
        public ActionResult Edit(BreadcrumbModel breadcrumb)
        {
            SqlDataReader sqlCmd = editCrumbInt.EditBread(breadcrumb);
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
