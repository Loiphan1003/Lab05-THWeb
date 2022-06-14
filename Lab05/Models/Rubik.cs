namespace Lab05.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rubik")]
    public partial class Rubik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rubik()
        {
            ChiTietDonHang = new HashSet<ChiTietDonHang>();
        }

        public int id { get; set; }

        public int? maloai { get; set; }

        [Required]
        [StringLength(100)]
        public string ten { get; set; }

        public string mota { get; set; }

        [StringLength(50)]
        public string hang { get; set; }

        public decimal? gia { get; set; }

        [StringLength(50)]
        public string hinh { get; set; }

        public int? soluongton { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ngaycapnhat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }

        public virtual Loai Loai { get; set; }
    }
}
