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
    public class DAL_XeMay : DBConnect
    {
        DBConnect connect = new DBConnect();
        public DataTable getData()
        {
            string sql = "Select * from XeMay";
            return connect.getData(sql);//chứa dữ liệu bảng SanPham
        }

        public DataTable TimKiemXM(string tukhoa)
        {
            string sql = "SELECT * FROM XeMay WHERE MaXe LIKE N'%" + tukhoa.Trim() + "%' OR TenXe LIKE N'%" + tukhoa.Trim() + "%'";
            return connect.getData(sql);
        }

        public int kiemtramatrung(string ma)
        {
            string sql = "Select count(*) from XeMay where MaXe='" + ma.Trim() + "'";
            return connect.kiemtramatrung(ma, sql);
        }
        public bool ThemSP(XeMay sp)
        {
            string sql = string.Format("Insert into XeMay values('{0}','{1}', '{2}', '{3}', '{4}')", sp.MaXe, sp.TenXe, sp.SoLuong, sp.Giaban, sp.MaLoai);
            //xử lý ngày 
            //string date=string.Format("{0}/{1}/{2}", datetimePicker1.Now.Year,datetimePicker1.Now.Month,datetimePicker1.Now.Day);  

            thucthisql(sql);
            return true;
        }

        public bool Xoa(string ma)
        {
            string sql = "DELETE FROM XeMay WHERE MaXe = '" + ma.Trim() + "'";
            connect.thucthisql(sql);
            return true;
        }
        public bool Sua(XeMay x)
        {
            string sql = "UPDATE XeMay SET MaXe = '" + x.MaXe + "',TenXe = '" + x.TenXe + "',SoLuong =  '" + x.SoLuong + "',Giaban = '" + x.Giaban + "',MaLoai = '" + x.MaLoai + "' WHERE MaXe = '" + x.MaXe + "'";
            connect.thucthisql(sql);
            return true;
        }
    }
}
