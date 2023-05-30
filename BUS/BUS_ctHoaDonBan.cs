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
    public class BUS_ctHoaDonBan
    {
        DAL_ctHoaDonBan dal_ctHdb = new DAL_ctHoaDonBan();
        public DataTable getData()
        {
            return dal_ctHdb.getData();
        }

        public int kiemtramatrung(string ma)
        {
            return dal_ctHdb.kiemtramatrung(ma);
        }

        public bool ThemctHD(ctHoaDonBan x)
        {
            return dal_ctHdb.ThemctHD(x);
        }
        public bool SuactHD(ctHoaDonBan x)
        {
            return dal_ctHdb.SuactHD(x);
        }
        public bool XoactHD(string ma)
        {
            return dal_ctHdb.XoactHD(ma);
        }
        public DataTable TimKiemctHD(string tukhoa)
        {
            return dal_ctHdb.TimKiemctHD(tukhoa);
        }
    }
}
