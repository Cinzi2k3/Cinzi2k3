using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA1
{
    public partial class GUI_NhanVien : Form
    {
        BUS_NhanVien bus_nv = new BUS_NhanVien();
        public GUI_NhanVien()
        {
            InitializeComponent();
        }
        void loaddgv()
        {
            //DataTable dt = bus_sp.getData();
            //dgvSanPham.DataSource = dt;
            dgNhanVien.DataSource = bus_nv.getData();
            dgNhanVien.Columns[0].HeaderText = "Mã NV";
            dgNhanVien.Columns[1].HeaderText = "Tên NV";
            dgNhanVien.Columns[2].HeaderText = "Đơn Vị CT";
            dgNhanVien.Columns[3].HeaderText = "Ngày Sinh";
            dgNhanVien.Columns[4].HeaderText = "Giới tính";
            dgNhanVien.Columns[5].HeaderText = "Năm BDCT";
            dgNhanVien.Columns[6].HeaderText = "Quê Quán";
        }
        //void loadcbb()//tùy, một là tách hàm, 2 là viết trong load form
        //{
        //    cbDonViCT.DataSource = bus_nv.getData();
        //    cbDonViCT.DisplayMember = "TenNV";
        //    cbDonViCT.ValueMember = "MaNV";
        //    cbGioiTinh.DataSource = bus_nv.getData();
        //    cbDonViCT.DisplayMember = "TenNV";
        //    cbDonViCT.ValueMember = "MaNV";
        //}

        private void GUI_NhanVien_Load(object sender, EventArgs e)
        {
            loaddgv();
            //loadcbb();
        }

        private void dgNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtMaNV.Text = dgNhanVien[0, i].Value.ToString();
            txtTenNV.Text = dgNhanVien[1, i].Value.ToString();
            cbDonViCT.Text = dgNhanVien[2, i].Value.ToString();
            mkNgaySinh.Text = dgNhanVien[3, i].Value.ToString();
            cbGioiTinh.Text = dgNhanVien[4, i].Value.ToString();
            txtNamBDCT.Text = dgNhanVien[5, i].Value.ToString();
            txtQueQuan.Text = dgNhanVien[6, i].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            nv.MaNV = txtMaNV.Text;
            nv.TenNV = txtTenNV.Text;
            //nv.DonViCT = cbDonViCT.SelectedValue.ToString();
            nv.DonViCT = cbDonViCT.SelectedItem.ToString();
            nv.NgaySinh = mkNgaySinh.Text;
            nv.GioiTinh = cbGioiTinh.SelectedItem.ToString();
            nv.NamBDCT = int.Parse(txtNamBDCT.Text);
            nv.QueQuan = txtQueQuan.Text;
            if (bus_nv.kiemtramatrung(txtMaNV.Text) == 1)
            {
                MessageBox.Show("Mã đã tồn tại, vui lòng nhập lại mã!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (bus_nv.ThemNV(nv) == true)
                {
                    MessageBox.Show("Thêm thành công!");
                    loaddgv();
                }
            }
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtMaNV.ResetText();
            txtTenNV.ResetText();
            cbDonViCT.ResetText();
            mkNgaySinh.ResetText();
            cbGioiTinh.ResetText();
            txtNamBDCT.ResetText();
            txtQueQuan.ResetText();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string MaNV = txtMaNV.Text;
            DialogResult kq = MessageBox.Show("Bạn có muốn xóa không", "Tiêu đề", MessageBoxButtons.YesNo);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                if (bus_nv.XoaNV(MaNV))
                {
                    MessageBox.Show("Xóa thành công");
                    loaddgv();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            nv.MaNV = txtMaNV.Text;
            nv.TenNV = txtTenNV.Text;
            nv.DonViCT = cbDonViCT.Text;
            nv.NgaySinh = mkNgaySinh.Text;
            nv.GioiTinh = cbGioiTinh.Text;
            nv.NamBDCT = int.Parse(txtNamBDCT.Text);
            nv.QueQuan = txtQueQuan.Text;
            if (bus_nv.SuaNV(nv))
            {
                MessageBox.Show("Sửa thành công");
                loaddgv();
            }
        }
    }
}
