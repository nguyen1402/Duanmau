using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAL_QLBH.Models
{
    [Table("HoaDon")]
    public partial class HoaDon
    {
        public HoaDon()
        {
            HoaDonCts = new HashSet<HoaDonCt>();
        }

        [Key]
        [Column("MaHD")]
        public int MaHd { get; set; }
        [Required]
        [Column("MaKH")]
        [StringLength(6)]
        public string MaKh { get; set; }
        [Required]
        [Column("MaNV")]
        [StringLength(6)]
        public string MaNv { get; set; }
        [Column("NgayLapHD", TypeName = "datetime")]
        public DateTime NgayLapHd { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Ngaynhanhang { get; set; }

        [ForeignKey(nameof(MaKh))]
        [InverseProperty(nameof(KhachHang.HoaDons))]
        public virtual KhachHang MaKhNavigation { get; set; }
        [ForeignKey(nameof(MaNv))]
        [InverseProperty(nameof(NhanVien.HoaDons))]
        public virtual NhanVien MaNvNavigation { get; set; }
        [InverseProperty(nameof(HoaDonCt.MaHdNavigation))]
        public virtual ICollection<HoaDonCt> HoaDonCts { get; set; }
    }
}
