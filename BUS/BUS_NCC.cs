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
    public class BUS_NCC
    {
        DAL_NCC dal_ncc = new DAL_NCC();
        public DataTable getData()
        {
            return dal_ncc.getData();//dữ liệu từ dal đã đc chuyển vào Bus
        }
        public int kiemtramatrung(string ma)
        {
            return dal_ncc.kiemtramatrung(ma);
        }
        public bool ThemSP(NCC sp)
        {
            return dal_ncc.ThemSP(sp);
        }
        public bool Xoa(string ma)
        {
            return dal_ncc.Xoa(ma);
        }
        public bool Sua(NCC x)
        {
            return dal_ncc.Sua(x);
        }
        public DataTable Timkiemncc(string tukhoa)
        {
            return dal_ncc.Timkiemncc(tukhoa);
        }
    }
}
