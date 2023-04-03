using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBike.Models;
using WebBike.Models.DBF;

namespace WebBike.Controllers
{
    public class CartController : Controller
    {
        MyData data = new MyData();
        // GET: Cart
        public List<Cart> GetCarts()
        {
            List<Cart> list = Session["Cart"] as List<Cart>;
            if (list == null)
            {
                list = new List<Cart>();
                Session["Cart"] = list;
            }
            return list;
        }
        [HttpGet]
        public ActionResult AddToCart(int id, string strURL)
        {
            List<Cart> list = GetCarts();
            Cart product = list.Find(m => m.Id == id);

            if (product == null)
            {
                product = new Cart(id,User.Identity.GetUserId());
                list.Add(product);
                return Redirect(strURL);
            }
            else
            {
                product.number++;
                return Redirect(strURL);
            }
        }
        private int totalNumber()
        {
            int total = 0;
            List<Cart> list = Session["Cart"] as List<Cart>;
            if (list != null)
            {
                total = list.Sum(n => n.number);
            }
            return total;
        }
        private int productNumber()
        {
            int total = 0;
            List<Cart> list = Session["Cart"] as List<Cart>;
            if (list != null)
            {
                total = list.Count();
            }
            return total;
        }
        private int totalCost()
        {
            int total = 0;
            List<Cart> list = Session["Cart"] as List<Cart>;
            if (list != null)
            {
                total = list.Sum(n => n.total);
            }
            return total;
        }
        public ActionResult Cart()
        {
            ViewBag.Username=User.Identity.GetUserName();
            List<Cart> list = GetCarts();
            ViewBag.totalNumber = totalNumber();
            ViewBag.totalCost = totalCost();
            ViewBag.productNumber = productNumber();
            return View(list);
        }
        public ActionResult PartialCart()
        {
            ViewBag.totalNumber = totalNumber();
            ViewBag.totalCost = totalCost();
            ViewBag.productNumber = productNumber();
            return PartialView();
        }
        public ActionResult Delete(int id)
        {
            List<Cart> list = GetCarts();
            Cart product = list.SingleOrDefault(n => n.Id == id);
            if (product != null)
            {
                list.RemoveAll(n => n.Id == id);
                return RedirectToAction("Cart");
            }
            return RedirectToAction("Cart");
        }
        public ActionResult CartUpdate(int id, FormCollection collection)
        {
            List<Cart> list = GetCarts();
            Cart product = list.SingleOrDefault(n => n.Id == id);
            if (product != null)
            {
                product.number = int.Parse(collection["txtSoLg"].ToString());
            }
            return RedirectToAction("Cart");
        }
        public ActionResult CartDelete()
        {
            List<Cart> list = GetCarts();
            list.Clear();
            return RedirectToAction("Cart");
        }
        public ActionResult Confirm()
        {
            List<Cart> list = GetCarts();
            foreach (Cart c in list)
            {
                var bike = data.Bikes.First(m => m.Id == c.Id);
                bike.SLT -= c.number;
                UpdateModel(bike);
            }
            data.SaveChanges();
            return RedirectToAction("Index", "Home");

        }
    }
}