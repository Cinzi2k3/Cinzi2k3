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
    public class BUS_XeMay
    {
        DAL_XeMay dal_xm = new DAL_XeMay();
        public DataTable getData()
        {
            return dal_xm.getData();//dữ liệu từ dal đã đc chuyển vào Bus
        }
        public int kiemtramatrung(string ma)
        {
            return dal_xm.kiemtramatrung(ma);
        }
        public bool ThemSP(XeMay sp)
        {
            return dal_xm.ThemSP(sp);
        }
        public bool Xoa(string ma)
        {
            return dal_xm.Xoa(ma);
        }
        public bool Sua(XeMay x)
        {
            return dal_xm.Sua(x);
        }
        public DataTable TimKiemXM(string tukhoa)
        {
            return dal_xm.TimKiemXM(tukhoa);
        }
    }
}
