using Microsoft.AspNet.Identity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBike.Models;
using WebBike.Models.DBF;

namespace WebBike.Controllers
{
    public class HomeController : Controller
    {
        MyData data=new MyData();
        ApplicationDbContext userData=new ApplicationDbContext();
        [HttpGet]
        public void validateAdmin()
        {
            string userId = User.Identity.GetUserId();
            ApplicationUser user = userData.Users.Find(userId);
            if (User.Identity.IsAuthenticated && user.type == 1) ViewBag.IsAdmin = 1;
            else ViewBag.IsAdmin = 0;
        }
        [HttpGet]
        public ActionResult Index(int ? page)
        {
            if(page == null)  page=1;
            validateAdmin();
            var listBike=data.Bikes.ToList();
            int pageSize = 10;
            int pageNum = page ?? 1;
            return View(listBike.ToPagedList(pageNum,pageSize));
        }
        public ActionResult BikeDetails(int id)
        {
            validateAdmin();
            var dBike = data.Bikes.FirstOrDefault(x => x.Id == id);
            return View(dBike);
        }
        public ActionResult Category()
        {
            validateAdmin();
            var listCategory=data.Categories.ToList();
            return View(listCategory);
        }
        public ActionResult CategoryDetails(int id)
        {
            validateAdmin();
            var category = data.Categories.FirstOrDefault(x => x.LoaiId == id);
            var listBike=data.Bikes.Where(x=>x.LoaiId==id).ToList();
            ViewBag.ListBike=listBike;
            return View(category); 
        }
        public ActionResult Brand()
        {
            validateAdmin();
            var listBrand=data.Brands.ToList();
            return View(listBrand);
        }
        public ActionResult BrandDetails(int id)
        {
            validateAdmin();
            var listBike = data.Bikes.Where(x => x.maHang == id).ToList();
            ViewBag.ListBike = listBike;
            var dBrand = data.Brands.FirstOrDefault(x => x.maHang == id);
            return View(dBrand);
        }
        [HttpGet]
        public ActionResult AdminArea()
        {
            string userId = User.Identity.GetUserId();
            ApplicationUser user = userData.Users.Find(userId);
            if (User.Identity.IsAuthenticated && user.type == 1) return View();
            else return View("OnlyAdmin");
        }
    }
}