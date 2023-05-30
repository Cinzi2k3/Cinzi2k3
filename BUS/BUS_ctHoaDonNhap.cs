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
    public class BUS_ctHoaDonNhap
    {
        DAL_ctHoaDonNhap dal_ctHdn = new DAL_ctHoaDonNhap();
        public DataTable getData()
        {
            return dal_ctHdn.getData();
        }

        public int kiemtramatrung(string ma)
        {
            return dal_ctHdn.kiemtramatrung(ma);
        }

        public bool ThemctHD(ctHoaDonNhap x)
        {
            return dal_ctHdn.ThemctHD(x);
        }
        public bool SuactHD(ctHoaDonNhap x)
        {
            return dal_ctHdn.SuactHD(x);
        }
        public bool XoactHD(string ma)
        {
            return dal_ctHdn.XoactHD(ma);
        }
        public DataTable TimKiemctHD(string tukhoa)
        {
            return dal_ctHdn.TimKiemctHD(tukhoa);
        }
    }
}
