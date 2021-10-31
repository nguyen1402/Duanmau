using System;
using System.Data.Common;
using DAL_QLBH;

namespace BUS_QLBH
{
    public class BUS_Nhanvien
    {
        private DAL_Nhanvien dalNhanvien = new DAL_Nhanvien();

        public BUS_Nhanvien()
        {
            dalNhanvien = new DAL_Nhanvien();
        }

        public void LayDSNhanvien(DatagridView dg)
        {
            dg = dalNhanvien.LayDSNhanvien();
        }
    }
}
