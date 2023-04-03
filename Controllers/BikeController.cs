using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBike.Models.DBF;

namespace WebBike.Controllers
{
    public class BikeController : Controller
    {
        MyData data = new MyData();
        // GET: Bike
        public ActionResult Index()
        {
            List<Bike> listBike=data.Bikes.ToList();
            return View(listBike);
        }

        // GET: Bike/Details/5
        public ActionResult Details(int id)
        {
            if (id == null) { return HttpNotFound(); }
            var dBike = data.Bikes.First(x => x.Id == id);
            return View(dBike);
        }

        // GET: Bike/Create
        public ActionResult Create()
        {
            IEnumerable<Category> categories = data.Categories.ToList();
            IEnumerable<Brand> brands = data.Brands.ToList();
            ViewBag.Categories = categories;
            ViewBag.Brands = brands;   
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, Bike bikes)
        {
            var E_SLT = collection["SLT"];
            var E_NSX = collection["NSX"];
            var E_Gia = collection["Gia"];
            var E_NgayDangKy = collection["NgayDangKy"];
            var E_DTXilanh = collection["DTXilanh"];
            var E_LoaiId = collection["LoaiId"];
            var E_maHang = collection["maHang"];
            var E_BikeName = collection["Name"];
            var E_BikeImage = collection["Hinh"];
            var E_Description = collection["description"];
            if (string.IsNullOrEmpty(E_BikeName))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                bikes.Name = E_BikeName;
                bikes.Hinh = E_BikeImage;
                bikes.description = E_Description;
                bikes.SLT = int.Parse(E_SLT);
                bikes.NSX = E_NSX;
                bikes.NgayDangKy = DateTime.Parse(E_NgayDangKy);
                bikes.DTXiLanh = int.Parse(E_DTXilanh);
                bikes.LoaiId= int.Parse(E_LoaiId);
                bikes.maHang = int.Parse(E_maHang);
                data.Bikes.Add(bikes);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }

        // GET: Bike/Edit/5
        public ActionResult Edit(int id)
        {
            IEnumerable<Category> categories = data.Categories.ToList();
            IEnumerable<Brand> brands = data.Brands.ToList();
            ViewBag.Categories = categories;
            ViewBag.Brands = brands;
            var bike = data.Bikes.Find(id);
            return View(bike);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var bikes= data.Bikes.First(x => x.Id == id);
            var E_SLT = collection["SLT"];
            var E_NSX = collection["NSX"];
            var E_Gia = collection["Gia"];
            var E_NgayDangKy = collection["NgayDangKy"];
            var E_DTXilanh = collection["DTXilanh"];
            var E_LoaiId = collection["LoaiId"];
            var E_maHang = collection["maHang"];
            var E_BikeName = collection["Name"];
            var E_BikeImage = collection["Hinh"];
            var E_Description = collection["description"];
            if (string.IsNullOrEmpty(E_BikeName))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                bikes.Name = E_BikeName;
                bikes.Hinh = E_BikeImage;
                bikes.description = E_Description;
                bikes.SLT = int.Parse(E_SLT);
                bikes.NSX = E_NSX;
                bikes.NgayDangKy = DateTime.Parse(E_NgayDangKy);
                bikes.DTXiLanh = int.Parse(E_DTXilanh);
                bikes.LoaiId = int.Parse(E_LoaiId);
                bikes.maHang = int.Parse(E_maHang);
                UpdateModel(bikes);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }
        // GET: Bike/Delete/5
        public ActionResult Delete(int id)
        {
            var bike = data.Bikes.Find(id);
            return View(bike);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var bike = data.Bikes.Find(id);
            data.Bikes.Remove(bike);
            data.SaveChanges();
            return RedirectToAction("Index");
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/bikes/" + file.FileName));
            return "/Content/images/bikes/" + file.FileName;
        }
    }
 }

