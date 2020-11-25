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
        public IBannerService bannerInt;
        public ICreateBanner CreateBannerInt;
        public IReadBanner readBannerInt;
        public IEditBanner EditBannerInt;
        public IDeleteBanner deleteBannerInt;
        public BannerModel bannerModelc;

        public BannerController(IBannerService bannerService,ICreateBanner createBanner,IReadBanner readBanner,IEditBanner editBanner,IDeleteBanner deleteBanner,BannerModel modelBanner)
        {
            this.bannerInt = bannerService;
            this.CreateBannerInt = createBanner;
            this.readBannerInt = readBanner;
            this.EditBannerInt = editBanner;
            this.deleteBannerInt=deleteBanner;
            this.bannerModelc = modelBanner;
        }

        

        // GET: Banner
        public ActionResult Index()
        {
            DataTable dtblProduct = new DataTable();
            int id = 1;
            dtblProduct = bannerInt.GetDataTable(id);
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
            SqlDataReader sqlcmd = CreateBannerInt.CreateData(bannerModel);
            return RedirectToAction("Index", "Home");
        }

            
       
        [HttpGet]
        // GET: Banner/Edit/5
        public ActionResult Edit(int id)
        {
            bannerModelc = readBannerInt.ReadData(id);
            return View(bannerModelc);
        }



        // POST: Banner/Edit/5
        [HttpPost]
        public ActionResult Edit(BannerModel bannerModel)
        {
            SqlDataReader sqlCmd = EditBannerInt.EditData(bannerModel, "Update");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        // GET: Banner/Delete/5
        public ActionResult Delete(int id) {
            bannerModelc = readBannerInt.ReadData(id);
            return View(bannerModelc);
        }


        // POST: Banner/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,BannerModel bannerModel)
        {
            SqlDataReader sqlCmd = deleteBannerInt.DeleteData(id, bannerModel, "Delete");
            return RedirectToAction("Index", "Home");
        }
    }
}
