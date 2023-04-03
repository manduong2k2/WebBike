using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBike.Models.DBF;

namespace WebBike.Controllers
{
    public class CategoryController : Controller
    {
        MyData data = new MyData();
        // GET: Category
        public ActionResult Index()
        {
            var listCategory=data.Categories.ToList();
            return View(listCategory);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            if (id == null) return HttpNotFound();
            var dCategory = data.Categories.Find(id);
            return View(dCategory);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, Category category)
        {
            var E_CategoryName = collection["tenloai"];
            var E_CategoryImage = collection["hinh"];
            var E_Description = collection["description"];
            if (string.IsNullOrEmpty(E_CategoryName))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                category.TenLoai = E_CategoryName;
                category.hinh = E_CategoryImage;
                category.description = E_Description;
                data.Categories.Add(category);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }
        public ActionResult Edit(int id)
        {
            var category = data.Categories.Find(id);
        return View(category);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var Brand = data.Categories.First(x => x.LoaiId == id);
            var E_BrandName = collection["tenLoai"];
            var E_BrandImage = collection["hinh"];
            var E_Description = collection["description"];
            if (string.IsNullOrEmpty(E_BrandName))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                Brand.TenLoai = E_BrandName;
                Brand.hinh = E_BrandImage;
                Brand.description = E_Description;
                UpdateModel(Brand);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }
        public ActionResult Delete(int id)
        {
            var category = data.Categories.Find(id);
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var category=data.Categories.Find(id);
            data.Categories.Remove(category);
            data.SaveChanges();
            return RedirectToAction("Index");
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/category/" + file.FileName));
            return "/Content/images/category/" + file.FileName;
        }
    }
}
