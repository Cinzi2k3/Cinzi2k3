using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DTO;

namespace DA1
{
    public partial class GUI_NCC : Form
    {
        public GUI_NCC()
        {
            InitializeComponent();
        }
        BUS_NCC bus_ncc = new BUS_NCC();
        bool ok;
        void loaddgv()
        {
            //DataTable dt = bus_sp.getData();
            //dgvSanPham.DataSource = dt;
            dgvncc.DataSource = bus_ncc.getData();
            dgvncc.Columns[0].HeaderText = "Mã NCC";
            dgvncc.Columns[1].HeaderText = "Tên NCC";
            dgvncc.Columns[2].HeaderText = "Sdt";
            dgvncc.Columns[3].HeaderText = "Địa chỉ";

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            NCC ncc = new NCC();
            ncc.MaNCC = txtma.Text;
            ncc.TenNCC = txtten.Text;
            ncc.Sdt = int.Parse(txtsdt.Text);
            ncc.Diachi = txtdiachi.Text;
            if (bus_ncc.kiemtramatrung(txtma.Text) == 1)
            {
                MessageBox.Show("Mã đã tồn tại, vui lòng nhập lại mã!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (bus_ncc.ThemSP(ncc) == true)
                {
                    MessageBox.Show("Thêm thành công!");
                    loaddgv();
                }
            }
        }

        private void dgvncc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtma.Text = dgvncc[0, i].Value.ToString();
            txtten.Text = dgvncc[1, i].Value.ToString();
            txtsdt.Text = dgvncc[2, i].Value.ToString();
            txtdiachi.Text = dgvncc[3, i].Value.ToString();
        }

        private void GUI_NCC_Load(object sender, EventArgs e)
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
            txtma.ResetText();
            txtten.ResetText();
            txtdiachi.ResetText();
            txtsdt.ResetText();
            txtma.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            NCC ncc = new NCC();
            ncc.MaNCC = txtma.Text;
            ncc.TenNCC = txtten.Text;
            ncc.Diachi = txtdiachi.Text;
            ncc.Sdt = int.Parse(txtsdt.Text);
            if (bus_ncc.Sua(ncc))
            {
                MessageBox.Show("Sửa thành công");
                loaddgv();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string Mancc = txtma.Text;
            DialogResult kq = MessageBox.Show("Bạn có muốn xóa không", "Tiêu đề", MessageBoxButtons.YesNo);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                if (bus_ncc.Xoa(Mancc))
                {
                    MessageBox.Show("Xóa thành công");
                    loaddgv();
                }
            }
        }

        private void txtSdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string tunccoa = txttimkiem.Text;
            dgvncc.DataSource = bus_ncc.Timkiemncc(tunccoa);
            dgvncc.Columns[0].HeaderText = "Mã NCC";
            dgvncc.Columns[1].HeaderText = "Tên NCC";
            dgvncc.Columns[3].HeaderText = "Địa chỉ";
            dgvncc.Columns[4].HeaderText = "Sdt";
        }

    }
}