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
    public class DAL_HoaDonBan : DBConnect
    {
        DBConnect connect = new DBConnect();
        public DataTable getData()
        {
            string sql = "Select * from HoaDonBan";
            return connect.getData(sql);//chứa dữ liệu bảng SanPham
        }

        public DataTable TimkiemHDB(string tukhoa)
        {
            string sql = "SELECT * FROM HoaDonBan WHERE MaHDB LIKE N'%" + tukhoa.Trim() + "%' ";
            return connect.getData(sql);
        }
        public int kiemtramatrung(string ma)
        {
            string sql = "Select count(*) from HoaDonBan where MaHDB ='" + ma.Trim() + "'";
            return connect.kiemtramatrung(ma, sql);
        }
        public bool ThemSP(HoaDonBan sp)
        {
            string sql = string.Format("Insert into HoaDonBan values('{0}','{1}', '{2}', '{3}')", sp.MaHDB, sp.NgayBan, sp.MaNV, sp.MaKH);
            //xử lý ngày 
            //string date=string.Format("{0}/{1}/{2}", datetimePicker1.Now.Year,datetimePicker1.Now.Month,datetimePicker1.Now.Day);  

            thucthisql(sql);
            return true;
        }

        public bool Xoa(string ma)
        {
            string sql = "DELETE FROM HoaDonBan WHERE MaHDB = '" + ma.Trim() + "'";
            connect.thucthisql(sql);
            return true;
        }
        public bool Sua(HoaDonBan x)
        {
            string sql = "UPDATE HoaDonBan SET MaHDB = '" + x.MaHDB + "',NgayBan = '" + x.NgayBan + "',Manv =  '" + x.MaNV + "',MaKH = '" + x.MaKH + "'  WHERE MaHDB = '" + x.MaHDB + "'";
            connect.thucthisql(sql);
            return true;
        }
    }
}
