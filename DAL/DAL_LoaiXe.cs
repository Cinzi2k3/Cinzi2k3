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
    public class DAL_LoaiXe : DBConnect
    {
        DBConnect connect = new DBConnect();
        public DataTable getData()
        {
            return connect.getData("Select * from LoaiXe");
        }

        public int kiemtramatrung(string ma)
        {
            string sql = "Select count(*) from LoaiXe where MaLoai='" + ma.Trim() + "'";
            return connect.kiemtramatrung(ma, sql);
        }
        public bool ThemSP(LoaiXe sp)
        {
            string sql = string.Format("Insert into LoaiXe values('{0}','{1}')", sp.MaLoai, sp.TenLoai);
            //xử lý ngày 
            //string date=string.Format("{0}/{1}/{2}", datetimePicker1.Now.Year,datetimePicker1.Now.Month,datetimePicker1.Now.Day);  

            thucthisql(sql);
            return true;
        }

        public bool Xoa(string ma)
        {
            string sql = "DELETE FROM LoaiXe WHERE MaLoai = '" + ma.Trim() + "'";
            connect.thucthisql(sql);
            return true;
        }
        public bool Sua(LoaiXe x)
        {
            string sql = "UPDATE LoaiXe SET MaLoai = '" + x.MaLoai + "',TenLoai = '" + x.TenLoai + "' WHERE MaLoai = '" + x.MaLoai + "'";
            connect.thucthisql(sql);
            return true;
        }
    }
}
