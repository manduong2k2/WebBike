using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebBike.Models.DBF
{
    public partial class MyData : DbContext
    {
        public MyData()
            : base("name=MyData")
        {
        }

        public virtual DbSet<Bike> Bikes { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bike>()
                .Property(e => e.Hinh)
                .IsUnicode(false);

            modelBuilder.Entity<Bike>()
                .Property(e => e.NSX)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bike>()
                .Property(e => e.description)
                .IsFixedLength();

            modelBuilder.Entity<Brand>()
                .HasMany(e => e.Bikes)
                .WithRequired(e => e.Brand)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.hinh)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .Property(e => e.description)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Bikes)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);
        }

        public System.Data.Entity.DbSet<WebBike.Models.Cart> Carts { get; set; }
    }
}
