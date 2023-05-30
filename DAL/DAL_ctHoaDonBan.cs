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
    public class DAL_ctHoaDonBan
    {
        DBConnect connect = new DBConnect();

        public DataTable getData()
        {
            string sql = "SELECT * FROM ctHDB ";
            return connect.getData(sql);
        }

        public DataTable TimKiemctHD(string tukhoa)
        {
            string sql = "SELECT * FROM ctHDB WHERE MactHDB LIKE N'%" + tukhoa.Trim() + "%' ";
            return connect.getData(sql);
        }

        public int kiemtramatrung(string ma)
        {
            string sql = "SELECT COUNT(*) FROM ctHDB WHERE MactHDB = '" + ma.Trim() + "'";
            return connect.kiemtramatrung(ma, sql);
        }

        public bool ThemctHD(ctHoaDonBan x)
        {
            string sql = "INSERT INTO ctHDB VALUES('" + x.MactHDB + "',N'" + x.MaHD + "',N'" + x.MaXe + "','" + x.SoLuong + "','" + x.DonGia + "',N'" + x.TongTien + "')";
            connect.thucthisql(sql);
            return true;
        }
        public bool SuactHD(ctHoaDonBan x)
        {
            string sql = "UPDATE ctHDB SET MaHD = N'" + x.MaHD + "', MaXe = N'" + x.MaXe + "',SoLuong = '" + x.SoLuong + "',DonGia = '" + x.DonGia + "', TongTien = N'" + x.TongTien + "' WHERE MactHDB = '" + x.MactHDB.Trim() + "'";
            connect.thucthisql(sql);
            return true;
        }
        public bool XoactHD(string ma)
        {
            string sql = "DELETE FROM ctHDB WHERE MactHDB = '" + ma.Trim() + "'";
            connect.thucthisql(sql);
            return true;
        }
    }
}
