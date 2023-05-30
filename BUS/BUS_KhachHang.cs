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
    public class BUS_KhachHang
    {
        DAL_KhachHang dal_kh = new DAL_KhachHang();
        public DataTable getData()
        {
            return dal_kh.getData();//dữ liệu từ dal đã đc chuyển vào Bus
        }
        public int kiemtramatrung(string ma)
        {
            return dal_kh.kiemtramatrung(ma);
        }
        public bool ThemSP(KhachHang sp)
        {
            return dal_kh.ThemSP(sp);
        }
        public bool Xoa(string ma)
        {
            return dal_kh.Xoa(ma);
        }
        public bool Sua(KhachHang x)
        {
            return dal_kh.Sua(x);
        }
        public DataTable Timkiemkh(string tukhoa)
        {
            return dal_kh.Timkiemkh(tukhoa);
        }
    }
}
