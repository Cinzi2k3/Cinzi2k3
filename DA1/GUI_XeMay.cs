using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace DA1
{
    public partial class GUI_XeMay : Form
    {
        public GUI_XeMay()
        {
            InitializeComponent();
        }
        //khởi tạo đối tượng của Bus_sp
        BUS_XeMay bus_dt = new BUS_XeMay();
        BUS_LoaiXe bus_loaidt = new BUS_LoaiXe();
        void loaddgv()
        {
            //DataTable dt = bus_sp.getData();
            //dgvSanPham.DataSource = dt;
            dgvXM.DataSource = bus_dt.getData();
            dgvXM.Columns[0].HeaderText = "Mã SP";
            dgvXM.Columns[1].HeaderText = "Tên SP";
            dgvXM.Columns[2].HeaderText = "Số lượng";
            dgvXM.Columns[3].HeaderText = "Đơn giá";
            dgvXM.Columns[4].HeaderText = "Mã loại";

        }
        void loadcbb()//tùy, một là tách hàm, 2 là viết trong load form
        {
            cbbLoai.DataSource = bus_loaidt.getData();
            cbbLoai.DisplayMember = "MaLoai";
            cbbLoai.ValueMember = "MaLoai";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            XeMay dt = new XeMay();
            dt.MaXe = txtMa.Text;
            dt.TenXe = txtTen.Text;
            dt.SoLuong = int.Parse(txtSoluong.Text);
            dt.Giaban = float.Parse(txtGia.Text);
            dt.MaLoai = cbbLoai.SelectedValue.ToString();
            if (bus_dt.kiemtramatrung(txtMa.Text) == 1)
            {
                MessageBox.Show("Mã đã tồn tại, vui lòng nhập lại mã!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (bus_dt.ThemSP(dt) == true)
                {
                    MessageBox.Show("Thêm thành công!");
                    loaddgv();
                }
            }
        }

        private void dgvXM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtMa.Text = dgvXM[0, i].Value.ToString();
            txtTen.Text = dgvXM[1, i].Value.ToString();
            txtSoluong.Text = dgvXM[2, i].Value.ToString();
            txtGia.Text = dgvXM[3, i].Value.ToString();
            cbbLoai.Text = dgvXM[4, i].Value.ToString();
        }

        private void GUI_XeMay_Load(object sender, EventArgs e)
        {
            loaddgv();
            loadcbb();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi ứng dụng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                this.Close();
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtMa.ResetText();
            txtTen.ResetText();
            txtSoluong.ResetText();
            txtGia.ResetText();
            cbbLoai.ResetText();
            txtMa.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            XeMay dt = new XeMay();
            dt.MaXe = txtMa.Text;
            dt.TenXe = txtTen.Text;
            dt.SoLuong = int.Parse(txtSoluong.Text);
            dt.Giaban = float.Parse(txtGia.Text);
            dt.MaLoai = cbbLoai.SelectedValue.ToString();
            if (bus_dt.Sua(dt))
            {
                MessageBox.Show("Sửa thành công");
                loaddgv();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string MaDT = txtMa.Text;
            DialogResult kq = MessageBox.Show("Bạn có muốn xóa không", "Tiêu đề", MessageBoxButtons.YesNo);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                if (bus_dt.Xoa(MaDT))
                {
                    MessageBox.Show("Xóa thành công");
                    loaddgv();
                }
            }
        }

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string tukhoa = txtTimkiem.Text;
            dgvXM.DataSource = bus_dt.TimKiemXM(tukhoa);
            dgvXM.Columns[0].HeaderText = "Mã Xe";
            dgvXM.Columns[1].HeaderText = "Tên Xe";
            dgvXM.Columns[2].HeaderText = "Số lượng";
            dgvXM.Columns[3].HeaderText = "Đơn giá";
            dgvXM.Columns[4].HeaderText = "Mã loại";
        }

       
    }
}

