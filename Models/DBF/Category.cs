namespace WebBike.Models.DBF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Bikes = new HashSet<Bike>();
        }

        [Key]
        public int LoaiId { get; set; }

        [StringLength(50)]
        public string TenLoai { get; set; }

        [StringLength(50)]
        public string hinh { get; set; }

        [StringLength(300)]
        public string description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bike> Bikes { get; set; }
    }
}
