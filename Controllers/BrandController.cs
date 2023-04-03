using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBike.Models.DBF;

namespace WebBike.Controllers
{
    public class BrandController : Controller
    {
        MyData data = new MyData();

        // GET: Brand
        public ActionResult Index()
        {
            var listBrand=data.Brands.ToList();
            return View(listBrand);
        }
        public ActionResult Details(int id)
        {
            var dBrand = data.Brands.FirstOrDefault(x => x.maHang == id);
            return View(dBrand);
        }
        public ActionResult Edit(int id)
        {
            var brand=data.Brands.First(x=>x.maHang == id);
            return View(brand);
        }
        [HttpPost]
        public ActionResult Edit(int id,FormCollection collection) 
        {
            var Brand=data.Brands.First(x=>x.maHang==id);
            var E_BrandName = collection["tenHang"];
            var E_BrandImage= collection["hinh"];
            var E_Description = collection["description"];
            if (string.IsNullOrEmpty(E_BrandName))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                Brand.tenHang = E_BrandName;
                Brand.hinh = E_BrandImage;
                Brand.description = E_Description;
                UpdateModel(Brand);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection,Brand brand)
        {
            var E_BrandName = collection["tenHang"];
            var E_BrandImage = collection["hinh"];
            var E_Description = collection["description"];
            if (string.IsNullOrEmpty(E_BrandName))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                brand.tenHang = E_BrandName;
                brand.hinh = E_BrandImage;
                brand.description = E_Description;
                data.Brands.Add(brand);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }
        public ActionResult Delete(int id)
        {
            if (id == null) return HttpNotFound();
            var dBrand = data.Brands.Find(id);
            if (dBrand == null) return HttpNotFound();
            return View(dBrand);
        }
        [HttpPost]
        public ActionResult Delete(int id,FormCollection collection)
        {
            if (id == null) return HttpNotFound();
            var dBrand = data.Brands.Find(id);
            if (dBrand == null) return HttpNotFound();
            data.Brands.Remove(dBrand);
            data.SaveChanges();
            return RedirectToAction("Index");
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/brands/" + file.FileName));
            return "/Content/images/brands/" + file.FileName;
        }
    }
}