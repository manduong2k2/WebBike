namespace WebBike.Models.DBF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Brand")]
    public partial class Brand
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Brand()
        {
            Bikes = new HashSet<Bike>();
        }

        [Key]
        public int maHang { get; set; }

        [Required]
        [StringLength(50)]
        public string tenHang { get; set; }

        [StringLength(50)]
        public string hinh { get; set; }

        [StringLength(300)]
        public string description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bike> Bikes { get; set; }
    }
}
