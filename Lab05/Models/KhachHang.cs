namespace Lab05.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            DonHang = new HashSet<DonHang>();
        }

        [Key]
        public int makh { get; set; }

        [StringLength(50)]
        public string hoten { get; set; }

        [StringLength(20)]
        public string tendangnhap { get; set; }

        [StringLength(10)]
        public string matkhau { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(100)]
        public string diachi { get; set; }

        [StringLength(15)]
        public string dienthoai { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaysinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHang { get; set; }
    }
}
