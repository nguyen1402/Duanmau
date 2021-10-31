using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using DAL_QLBH.Context;
using DAL_QLBH.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL_QLBH
{
    public class DAL_Nhanvien
    {
        private DatabaseContext dbContext;
        
        public dynamic LayDSNhanvien()
        {
            var ds = dbContext.NhanViens.Select(c => new
            {
                c.MaNv,
                c.Email,
                c.Tennv,
                c.Diachi,
                c.Vaitro,
                c.Tinhtrang
            }).ToList();
            return ds;
        }
    }
}
