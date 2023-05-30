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
    public class BUS_HoaDonBan
    {
        DAL_HoaDonBan dal_hdb = new DAL_HoaDonBan();
        public DataTable getData()
        {
            return dal_hdb.getData();//dữ liệu từ dal đã đc chuyển vào Bus
        }

        public DataTable TimkiemHDB(string tukhoa)
        {
            return dal_hdb.TimkiemHDB(tukhoa);
        }
        public int kiemtramatrung(string ma)
        {
            return dal_hdb.kiemtramatrung(ma);
        }
        public bool ThemSP(HoaDonBan sp)
        {
            return dal_hdb.ThemSP(sp);
        }
        public bool Xoa(string ma)
        {
            return dal_hdb.Xoa(ma);
        }
        public bool Sua(HoaDonBan x)
        {
            return dal_hdb.Sua(x);
        }
    }
}
