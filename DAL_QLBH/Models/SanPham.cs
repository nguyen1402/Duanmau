using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAL_QLBH.Models
{
    [Table("SanPham")]
    public partial class SanPham
    {
        public SanPham()
        {
            HoaDonCts = new HashSet<HoaDonCt>();
        }

        [Key]
        [Column("MaSP")]
        [StringLength(6)]
        public string MaSp { get; set; }
        [Required]
        [Column("TenSP")]
        [StringLength(100)]
        public string TenSp { get; set; }
        public int Soluong { get; set; }
        public double Dongiaban { get; set; }
        public double Dongianhap { get; set; }
        [Required]
        [StringLength(100)]
        public string Ghichu { get; set; }
        [Column("MaNV")]
        [StringLength(6)]
        public string MaNv { get; set; }

        [ForeignKey(nameof(MaNv))]
        [InverseProperty(nameof(NhanVien.SanPhams))]
        public virtual NhanVien MaNvNavigation { get; set; }
        [InverseProperty(nameof(HoaDonCt.MaSpNavigation))]
        public virtual ICollection<HoaDonCt> HoaDonCts { get; set; }
    }
}
