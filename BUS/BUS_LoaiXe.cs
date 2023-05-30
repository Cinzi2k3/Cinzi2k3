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
    public class BUS_LoaiXe
    {
        DAL_LoaiXe dal_loaixe = new DAL_LoaiXe();
        public DataTable getData()
        {
            return dal_loaixe.getData();//dữ liệu từ dal đã đc chuyển vào Bus

        }
        public int kiemtramatrung(string ma)
        {
            return dal_loaixe.kiemtramatrung(ma);
        }
        public bool ThemSP(LoaiXe sp)
        {
            return dal_loaixe.ThemSP(sp);
        }
        public bool Xoa(string ma)
        {
            return dal_loaixe.Xoa(ma);
        }
        public bool Sua(LoaiXe x)
        {
            return dal_loaixe.Sua(x);
        }
    }
}
