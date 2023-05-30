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
    public class BUS_HoaDonNhap
    {
        DAL_HoaDonNhap dal_hdn = new DAL_HoaDonNhap();
        public DataTable getData()
        {
            return dal_hdn.getData();//dữ liệu từ dal đã đc chuyển vào Bus
        }

        public DataTable TimkiemHDN(string tukhoa)
        {
            return dal_hdn.TimkiemHDN(tukhoa);
        }
        public int kiemtramatrung(string ma)
        {
            return dal_hdn.kiemtramatrung(ma);
        }
        public bool ThemSP(HoaDonNhap sp)
        {
            return dal_hdn.ThemSP(sp);
        }
        public bool Xoa(string ma)
        {
            return dal_hdn.Xoa(ma);
        }
        public bool Sua(HoaDonNhap x)
        {
            return dal_hdn.Sua(x);
        }
    }
}
