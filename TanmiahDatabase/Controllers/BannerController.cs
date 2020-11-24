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
    public class BannerController : Controller
    {
      
        // GET: Banner
        public ActionResult Index()
        {
            BannerService banner = new BannerService();
            DataTable dtblProduct = new DataTable();
            int id = 1;
            dtblProduct = banner.getDataTable(id);
            return PartialView("_BannerView", dtblProduct);
        }

        // GET: Banner/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Banner/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Banner/Create
        [HttpPost]
        public ActionResult Create(BannerModel bannerModel)
        { 
            CreateBanner banner = new CreateBanner();
            SqlDataReader sqlCmd = banner.createData(bannerModel);
            return RedirectToAction("Index", "Home");
        }

            
       
        [HttpGet]
        // GET: Banner/Edit/5
        public ActionResult Edit(int id)
        {
            ReadBanner read = new ReadBanner();
            BannerModel bannerModel = read.ReadData(id);
            return View(bannerModel);
        }



        // POST: Banner/Edit/5
        [HttpPost]
        public ActionResult Edit(BannerModel bannerModel)
        {
            EditBanner edit = new EditBanner();
            SqlDataReader sqlCmd = edit.EditData(bannerModel, "Update");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        // GET: Banner/Delete/5
        public ActionResult Delete(int id) {
            ReadBanner read = new ReadBanner();
            BannerModel bannerModel = new BannerModel();
            bannerModel = read.ReadData(id);
            return View(bannerModel);
        }


        // POST: Banner/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,BannerModel bannerModel)
        {
            DeleteBanner dlt = new DeleteBanner();
            SqlDataReader sqlCmd = dlt.DeleteData(id,bannerModel,"Delete");
            return RedirectToAction("Index", "Home");
        }
    }
}
