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
    public class DAL_NCC : DBConnect
    {
        DBConnect connect = new DBConnect();
        public DataTable getData()
        {
            string sql = "Select * from NCC";
            return connect.getData(sql);//chứa dữ liệu bảng SanPham
        }

        public DataTable Timkiemncc(string tukhoa)
        {
            string sql = "SELECT * FROM NCC WHERE MaNCC LIKE N'%" + tukhoa.Trim() + "%' OR Tenncc LIKE N'%" + tukhoa.Trim() + "%'";
            return connect.getData(sql);
        }
        public int kiemtramatrung(string ma)
        {
            string sql = "Select count(*) from ncc where MaNCC='" + ma.Trim() + "'";
            return connect.kiemtramatrung(ma, sql);
        }
        public bool ThemSP(NCC ncc)
        {
            string sql = string.Format("Insert into NCC values('{0}','{1}', '{2}', '{3}', '{4}')", ncc.MaNCC, ncc.TenNCC, ncc.Diachi, ncc.Sdt);
            //xử lý ngày 
            //string date=string.Format("{0}/{1}/{2}", datetimePicker1.Now.Year,datetimePicker1.Now.Month,datetimePicker1.Now.Day);  

            thucthisql(sql);
            return true;
        }

        public bool Xoa(string ma)
        {
            string sql = "DELETE FROM NCC WHERE MaNCC = '" + ma.Trim() + "'";
            connect.thucthisql(sql);
            return true;
        }
        public bool Sua(NCC x)
        {
            string sql = "UPDATE NCC SET MaNCC = '" + x.MaNCC + "',TenNCC = '" + x.TenNCC + "',Diachi = '" + x.Diachi + "',Sdt = '" + x.Sdt + "' WHERE MaNCC = '" + x.MaNCC + "'";
            connect.thucthisql(sql);
            return true;
        }
    }
}
