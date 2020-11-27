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
        public IDescriptionServices ServicesDesc;
        public ICreateDescription CreateDesc;
        public IReadDescription ReadDesc;
        public IEditDescription EditDesc;
        public IDeleteDescription DeleteDesc;
        public DescriptionModel DescModelc;

        public DescriptionController(IDescriptionServices descriptionServices, ICreateDescription createDescription,IReadDescription readDescription,IEditDescription editDescription,IDeleteDescription deleteDescription,DescriptionModel ModelDesc)
        {
            this.ServicesDesc = descriptionServices;
            this.CreateDesc = createDescription;
            this.ReadDesc = readDescription;
            this.EditDesc = editDescription;
            this.DeleteDesc = deleteDescription;
            this.DescModelc = ModelDesc;
        }

        // GET: Description
        public ActionResult DescriptionAction()
        {
            DataTable dtblProduct = new DataTable();
            int id = 1;
            dtblProduct = ServicesDesc.GetDescription(id);
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
            if (ModelState.IsValid)
            {
                SqlDataReader sqlread = CreateDesc.CreateDesc(descModel);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(descModel);
            }
        }


        // GET: Description/Edit/5
        public ActionResult Edit(int id)
        {
            if (ModelState.IsValid)
            {
                DescModelc = ReadDesc.ReadDescData(id);
                return View(DescModelc);
            }
            else
            {
                return View(DescModelc);
            }
        }


        // POST: Description/Edit/5
        [HttpPost]
        public ActionResult Edit(DescriptionModel descModel)
        {
            if (ModelState.IsValid)
            {
                SqlDataReader sqlread = EditDesc.EditDescData(descModel);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(descModel);
            }
        }

        // GET: Description/Delete/5
        public ActionResult Delete(int id)
        {
            DescModelc = ReadDesc.ReadDescData(id);
            return View(DescModelc);
        }

        // POST: Description/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, DescriptionModel descModel)//Continue
        {
            SqlDataReader sqlread = DeleteDesc.DeleteDescData(id, descModel);
            return RedirectToAction("Index", "Home");
        }
    }
}
