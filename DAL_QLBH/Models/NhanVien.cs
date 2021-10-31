using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAL_QLBH.Models
{
    [Table("NhanVien")]
    public partial class NhanVien
    {
        public NhanVien()
        {
            HoaDons = new HashSet<HoaDon>();
            KhachHangs = new HashSet<KhachHang>();
            SanPhams = new HashSet<SanPham>();
        }

        [Key]
        [Column("MaNV")]
        [StringLength(6)]
        public string MaNv { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Tennv { get; set; }
        [Required]
        [StringLength(50)]
        public string Diachi { get; set; }
        [Required]
        [StringLength(50)]
        public string Vaitro { get; set; }
        public bool Tinhtrang { get; set; }
        [Required]
        [StringLength(50)]
        public string Matkhau { get; set; }

        [InverseProperty(nameof(HoaDon.MaNvNavigation))]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
        [InverseProperty(nameof(KhachHang.MaNvNavigation))]
        public virtual ICollection<KhachHang> KhachHangs { get; set; }
        [InverseProperty(nameof(SanPham.MaNvNavigation))]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
