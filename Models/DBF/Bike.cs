namespace WebBike.Models.DBF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bike")]
    public partial class Bike
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Hinh { get; set; }

        public int? SLT { get; set; }

        [StringLength(4)]
        public string NSX { get; set; }

        public int? Gia { get; set; }

        public DateTime? NgayDangKy { get; set; }

        public int? DTXiLanh { get; set; }

        public int LoaiId { get; set; }

        public int maHang { get; set; }

        [StringLength(300)]
        public string description { get; set; }

        public virtual Category Category { get; set; }

        public virtual Brand Brand { get; set; }
    }
}
