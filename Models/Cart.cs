using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBike.Models.DBF;

namespace WebBike.Models
{
    public class Cart
    {
        MyData data = new MyData();
        ApplicationDbContext context=new ApplicationDbContext();
        public string UserId { get; set; }
        public int Id { get; set; }
        public string bikeName { get; set; }
        public string bikeImage { get; set; }
        public int price { get; set; }
        public int number { get; set; }
        public int total { get { return number * price; } }
        public Cart(int id, string userId)
        {
            Id = id;
            UserId = userId;
            Bike bike = data.Bikes.Single(n => n.Id == Id);
            bikeName = bike.Name;
            bikeImage = bike.Hinh;
            price = int.Parse(bike.Gia.ToString());
            number = 1;
            UserId = userId;
        }
    }
}