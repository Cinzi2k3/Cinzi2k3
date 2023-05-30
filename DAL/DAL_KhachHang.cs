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
    public class DAL_KhachHang : DBConnect
    {
        DBConnect connect = new DBConnect();
        public DataTable getData()
        {
            string sql = "Select * from KhachHang";
            return connect.getData(sql);//chứa dữ liệu bảng SanPham
        }

        public DataTable Timkiemkh(string tukhoa)
        {
            string sql = "SELECT * FROM KhachHang WHERE MaKH LIKE N'%" + tukhoa.Trim() + "%' OR Tenkh LIKE N'%" + tukhoa.Trim() + "%'";
            return connect.getData(sql);
        }
        public int kiemtramatrung(string ma)
        {
            string sql = "Select count(*) from KhachHang where MaKH='" + ma.Trim() + "'";
            return connect.kiemtramatrung(ma, sql);
        }
        public bool ThemSP(KhachHang kh)
        {
            string sql = string.Format("Insert into KhachHang values('{0}','{1}', '{2}', '{3}', '{4}')", kh.MaKH, kh.TenKH, kh.Gioitinh, kh.QueQuan, kh.SDT);
            //xử lý ngày 
            //string date=string.Format("{0}/{1}/{2}", datetimePicker1.Now.Year,datetimePicker1.Now.Month,datetimePicker1.Now.Day);  

            thucthisql(sql);
            return true;
        }

        public bool Xoa(string ma)
        {
            string sql = "DELETE FROM KhachHang WHERE MaKH = '" + ma.Trim() + "'";
            connect.thucthisql(sql);
            return true;
        }
        public bool Sua(KhachHang x)
        {
            string sql = "UPDATE KhachHang SET MaKH = '" + x.MaKH + "',TenKH = '" + x.TenKH + "',GioiTinh =  '" + x.Gioitinh + "',QueQuan = '" + x.QueQuan + "',SDT = '" + x.SDT + "' WHERE MaKH = '" + x.MaKH + "'";
            connect.thucthisql(sql);
            return true;
        }
    }
}
