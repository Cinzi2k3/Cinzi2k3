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
    public class DAL_HoaDonNhap : DBConnect
    {
        DBConnect connect = new DBConnect();
        public DataTable getData()
        {
            string sql = "Select * from HoaDonNhap";
            return connect.getData(sql);//chứa dữ liệu bảng SanPham
        }

        public DataTable TimkiemHDN(string tukhoa)
        {
            string sql = "SELECT * FROM HoaDonNhap WHERE MaHDN LIKE N'%" + tukhoa.Trim() + "%' ";
            return connect.getData(sql);
        }
        public int kiemtramatrung(string ma)
        {
            string sql = "Select count(*) from HoaDonNhap where MaHDN ='" + ma.Trim() + "'";
            return connect.kiemtramatrung(ma, sql);
        }
        public bool ThemSP(HoaDonNhap sp)
        {
            string sql = string.Format("Insert into HoaDonNhap values('{0}','{1}', '{2}','{3}')", sp.MaHDN, sp.ngaynhap, sp.MaNV, sp.MaNCC);
            //xử lý ngày 
            //string date=string.Format("{0}/{1}/{2}", datetimePicker1.Now.Year,datetimePicker1.Now.Month,datetimePicker1.Now.Day);  

            thucthisql(sql);
            return true;
        }

        public bool Xoa(string ma)
        {
            string sql = "DELETE FROM HoaDonNhap WHERE MaHDN = '" + ma.Trim() + "'";
            connect.thucthisql(sql);
            return true;
        }
        public bool Sua(HoaDonNhap x)
        {
            string sql = "UPDATE HoaDonNhap SET MaHDN = '" + x.MaHDN + "',NgayNhap = '" + x.ngaynhap + "',MaNV = '" + x.MaNV + "',MaNCC = '" + x.MaNCC + "' WHERE MaHDN = '" + x.MaHDN + "'";
            connect.thucthisql(sql);
            return true;
        }
    }
}
