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
    public partial class GUI_KhachHang : Form
    {
        public GUI_KhachHang()
        {
            InitializeComponent();
        }
        BUS_KhachHang bus_kh = new BUS_KhachHang();
        void loaddgv()
        {
            //DataTable dt = bus_sp.getData();
            //dgvSanPham.DataSource = dt;
            dgvKH.DataSource = bus_kh.getData();
            dgvKH.Columns[0].HeaderText = "Mã KH";
            dgvKH.Columns[1].HeaderText = "Tên KH";
            dgvKH.Columns[2].HeaderText = "Giới tính";
            dgvKH.Columns[3].HeaderText = "Quê Quán";
            dgvKH.Columns[4].HeaderText = "SĐT";

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            kh.MaKH = txtMa.Text;
            kh.TenKH = txtTen.Text;
            kh.Gioitinh = cbbGioitINH.SelectedItem.ToString();
            kh.QueQuan = txtQue.Text;
            kh.SDT = int.Parse(txtSDT.Text);
            if (bus_kh.kiemtramatrung(txtMa.Text) == 1)
            {
                MessageBox.Show("Mã đã tồn tại, vui lòng nhập lại mã!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (bus_kh.ThemSP(kh) == true)
                {
                    MessageBox.Show("Thêm thành công!");
                    loaddgv();
                }
            }
        }

        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtMa.Text = dgvKH[0, i].Value.ToString();
            txtTen.Text = dgvKH[1, i].Value.ToString();
            cbbGioitINH.Text = dgvKH[2, i].Value.ToString();
            txtQue.Text = dgvKH[3, i].Value.ToString();
            txtSDT.Text = dgvKH[4, i].Value.ToString();
        }

        private void GUI_KhachHang_Load(object sender, EventArgs e)
        {
            loaddgv();
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
            cbbGioitINH.ResetText();
            txtQue.ResetText();
            txtSDT.ResetText();
            txtMa.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            kh.MaKH = txtMa.Text;
            kh.TenKH = txtTen.Text;
            kh.Gioitinh = cbbGioitINH.SelectedItem.ToString();
            kh.QueQuan = txtQue.Text;
            kh.SDT = int.Parse(txtSDT.Text);
            if (bus_kh.Sua(kh))
            {
                MessageBox.Show("Sửa thành công");
                loaddgv();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string MaKH = txtMa.Text;
            DialogResult kq = MessageBox.Show("Bạn có muốn xóa không", "Tiêu đề", MessageBoxButtons.YesNo);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                if (bus_kh.Xoa(MaKH))
                {
                    MessageBox.Show("Xóa thành công");
                    loaddgv();
                }
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string tukhoa = txtTimkiem.Text;
            dgvKH.DataSource = bus_kh.Timkiemkh(tukhoa);
            dgvKH.Columns[0].HeaderText = "Mã KH";
            dgvKH.Columns[1].HeaderText = "Tên KH";
            dgvKH.Columns[2].HeaderText = "Giới tính";
            dgvKH.Columns[3].HeaderText = "Quê Quán";
            dgvKH.Columns[4].HeaderText = "SĐT";
        }
    }
}
