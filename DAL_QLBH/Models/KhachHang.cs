using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAL_QLBH.Models
{
    [Table("KhachHang")]
    public partial class KhachHang
    {
        public KhachHang()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        [Column("MaKH")]
        [StringLength(6)]
        public string MaKh { get; set; }
        [Required]
        [StringLength(50)]
        public string Dienthoai { get; set; }
        [Required]
        [StringLength(50)]
        public string Ten { get; set; }
        [Required]
        [StringLength(50)]
        public string Diachi { get; set; }
        public bool Gioitinh { get; set; }
        [Required]
        [Column("MaNV")]
        [StringLength(6)]
        public string MaNv { get; set; }

        [ForeignKey(nameof(MaNv))]
        [InverseProperty(nameof(NhanVien.KhachHangs))]
        public virtual NhanVien MaNvNavigation { get; set; }
        [InverseProperty(nameof(HoaDon.MaKhNavigation))]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
