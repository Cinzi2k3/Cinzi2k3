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
    public class DAL_NhanVien : DBConnect
    {
        DBConnect connect = new DBConnect();
        public DataTable getData()
        {
            string sql = "Select * from tbNhanVien";
            return connect.getData(sql);//chứa dữ liệu bảng tbNhanVien
        }
        public int kiemtramatrung(string ma)
        {
            string sql = "Select count(*) from tbNhanVien where MaNV='" + ma.Trim() + "'";
            return connect.kiemtramatrung(ma, sql);
        }
        public bool ThemNV(NhanVien nv)
        {
            string sql = string.Format("Insert into tbNhanVien values('{0}',N'{1}', N'{2}', N'{3}', N'{4}', '{5}',N'{6}')", nv.MaNV, nv.TenNV, nv.DonViCT, nv.NgaySinh, nv.GioiTinh, nv.NamBDCT, nv.QueQuan);
            //xử lý ngày 
            //string date=string.Format("{0}/{1}/{2}", datetimePicker1.Now.Year,datetimePicker1.Now.Month,datetimePicker1.Now.Day);  

            thucthisql(sql);
            return true;
        }
        public bool XoaNV(string MaNV)
        {
            string sql = "DELETE FROM tbNhanVien WHERE MaNV = '" + MaNV.Trim() + "'";
            connect.thucthisql(sql);
            return true;
        }
        public bool SuaNV(NhanVien nv)
        {
            string sql = "UPDATE tbNhanVien SET MaNV = '" + nv.MaNV + "',TenNV = '" + nv.TenNV + "',DonViCT = '" + nv.DonViCT + "',NgaySinh = '" + nv.NgaySinh + "',GioiTinh =  '" + nv.GioiTinh + "',NamBDCT = '" + nv.NamBDCT + "',QueQuan = '" + nv.QueQuan + "' WHERE MaNV = '" + nv.MaNV + "'";
            connect.thucthisql(sql);
            return true;
        }
    }
}
