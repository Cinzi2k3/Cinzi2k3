using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DAL_ctHoaDonNhap : DBConnect
    {
        DBConnect connect = new DBConnect();

        public DataTable getData()
        {
            string sql = "SELECT * FROM ctHDN";
            return connect.getData(sql);
        }

        public DataTable TimKiemctHD(string tukhoa)
        {
            string sql = "SELECT * FROM ctHDN WHERE MactHDN LIKE N'%" + tukhoa.Trim() + "%' ";
            return connect.getData(sql);
        }

        public int kiemtramatrung(string ma)
        {
            string sql = "SELECT COUNT(*) FROM ctHDN WHERE MactHDN = '" + ma.Trim() + "'";
            return connect.kiemtramatrung(ma, sql);
        }

        public bool ThemctHD(ctHoaDonNhap x)
        {
            string sql = "INSERT INTO ctHDN VALUES('" + x.MactHDN + "',N'" + x.MaHD + "',N'" + x.MaXe + "','" + x.Soluong + "','" + x.Dongia + "',N'" + x.TongTien + "')";
            connect.thucthisql(sql);
            return true;
        }
        public bool SuactHD(ctHoaDonNhap x)
        {
            string sql = "UPDATE ctHDN SET MaHD = N'" + x.MaHD + "', MaXe = N'" + x.MaXe + "',SoLuong = '" + x.Soluong + "',Dongia = '" + x.Dongia + "', TongTien = N'" + x.TongTien + "' WHERE MactHDN = '" + x.MactHDN.Trim() + "'";
            connect.thucthisql(sql);
            return true;
        }
        public bool XoactHD(string ma)
        {
            string sql = "DELETE FROM ctHDN WHERE MactHDN = '" + ma.Trim() + "'";
            connect.thucthisql(sql);
            return true;
        }
    }
}
