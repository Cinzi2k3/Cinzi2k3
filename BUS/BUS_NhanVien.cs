using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;

namespace BUS
{
    public class BUS_NhanVien
    {
        DAL_NhanVien dal_nv = new DAL_NhanVien();
        public DataTable getData()
        {
            return dal_nv.getData();//dữ liệu từ dal đã đc chuyển vào Bus
        }
        public int kiemtramatrung(string ma)
        {
            return dal_nv.kiemtramatrung(ma);
        }
        public bool ThemNV(NhanVien nv)
        {
            return dal_nv.ThemNV(nv);
        }
        public bool XoaNV(string MaNV)
        {
            return dal_nv.XoaNV(MaNV);
        }
        public bool SuaNV(NhanVien nv)
        {
            return dal_nv.SuaNV(nv);
        }
    }
}
