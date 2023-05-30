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
    public partial class GUI_LoaiXM : Form
    {
        public GUI_LoaiXM()
        {
            InitializeComponent();
        }
        BUS_LoaiXe bus_lxm = new BUS_LoaiXe();

        void loaddgv()
        {
            //DataTable dt = bus_sp.getData();
            //dgvSanPham.DataSource = dt;

            dgLoaiXe.DataSource = bus_lxm.getData();
            dgLoaiXe.Columns[0].HeaderText = "Mã Loại ";
            dgLoaiXe.Columns[1].HeaderText = "Tên Loại";


        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            LoaiXe lx = new LoaiXe();
            lx.MaLoai = txtMaLoai.Text;
            lx.TenLoai = txtTenLoai.Text;
            if (bus_lxm.Sua(lx))
            {
                MessageBox.Show("Sửa thành công");
                loaddgv();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string MaLXe = txtMaLoai.Text;
            DialogResult kq = MessageBox.Show("Bạn có muốn xóa không", "Tiêu đề", MessageBoxButtons.YesNo);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                if (bus_lxm.Xoa(MaLXe))
                {
                    MessageBox.Show("Xóa thành công");
                    loaddgv();
                }
            }
        }

        private void dgLoaiXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtMaLoai.Text = dgLoaiXe[0, i].Value.ToString();
            txtTenLoai.Text = dgLoaiXe[1, i].Value.ToString();
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtMaLoai.ResetText();
            txtMaLoai.ResetText();
            txtMaLoai.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LoaiXe lx = new LoaiXe();

            lx.MaLoai = txtMaLoai.Text;
            lx.TenLoai = txtTenLoai.Text;
            if (bus_lxm.kiemtramatrung(txtMaLoai.Text) == 1)
            {
                MessageBox.Show("Mã đã tồn tại, vui lòng nhập lại mã!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (bus_lxm.ThemSP(lx) == true)
                {
                    MessageBox.Show("Thêm thành công!");
                    loaddgv();
                }
            }
        }

        private void GUI_LoaiXM_Load(object sender, EventArgs e)
        {
            loaddgv();
        }
    }
}
