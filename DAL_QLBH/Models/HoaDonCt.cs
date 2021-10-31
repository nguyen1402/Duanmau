using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAL_QLBH.Models
{
    [Table("HoaDonCT")]
    public partial class HoaDonCt
    {
        [Key]
        [Column("MaHD")]
        public int MaHd { get; set; }
        [Key]
        [Column("MaSP")]
        [StringLength(6)]
        public string MaSp { get; set; }
        public int Soluong { get; set; }

        [ForeignKey(nameof(MaHd))]
        [InverseProperty(nameof(HoaDon.HoaDonCts))]
        public virtual HoaDon MaHdNavigation { get; set; }
        [ForeignKey(nameof(MaSp))]
        [InverseProperty(nameof(SanPham.HoaDonCts))]
        public virtual SanPham MaSpNavigation { get; set; }
    }
}
