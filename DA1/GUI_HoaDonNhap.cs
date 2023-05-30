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
using System.Data.SqlClient;


namespace DA1
{
    public partial class GUI_HoaDonNhap : Form
    {
        public GUI_HoaDonNhap()
        {
            InitializeComponent();
        }
        //khởi tạo đối tượng của Bus_sp
        BUS_HoaDonNhap bus_hdn = new BUS_HoaDonNhap();
        BUS_XeMay bus_xe = new BUS_XeMay();
        BUS_ctHoaDonNhap bus_cthdn = new BUS_ctHoaDonNhap();
        BUS_NhanVien bus_nv = new BUS_NhanVien();
        BUS_NCC busncc = new BUS_NCC();
        public void loaddgv()
        {
            //DataTable dt = bus_sp.getData();
            //dgvSanPham.DataSource = dt;
            dgvHDN.DataSource = bus_hdn.getData();
            dgvHDN.Columns[0].HeaderText = "Mã HD";
            dgvHDN.Columns[1].HeaderText = "Ngày Nhập";
            dgvHDN.Columns[2].HeaderText = "Mã NV";
            dgvHDN.Columns[3].HeaderText = "Mã NCC";
        }
        public void loadcbbnv()
        {
            cbbTennv.DataSource = bus_nv.getData();
            cbbTennv.DisplayMember = "Manv";
            cbbTennv.ValueMember = "Manv";
        }
        public void loadcbbncc()
        {
            cbbmncc.DataSource = busncc.getData();
            cbbmncc.DisplayMember = "MaNCC";
            cbbmncc.ValueMember = "MaNCC";
        }
        public void loadcbbct()
        {
            cbbMaxe.DataSource = bus_xe.getData();
            cbbMaxe.DisplayMember = "MaXe";
            cbbMaxe.ValueMember = "MaXe";
        }
        

        public void loadcbbhd()
        {
            cbbMaHD.DataSource = bus_hdn.getData();
            cbbMaHD.DisplayMember = "MaHDN";
            cbbMaHD.ValueMember = "MaHDN";
        }

        public void loadcthnd()
        {
            dgvct.DataSource = bus_cthdn.getData();
            dgvct.Columns[0].HeaderText = "MactHDN";
            dgvct.Columns[1].HeaderText = "MaHD";
            dgvct.Columns[2].HeaderText = "MaDT";
            dgvct.Columns[3].HeaderText = "SoLuong";
            dgvct.Columns[4].HeaderText = "Dongia";
            dgvct.Columns[5].HeaderText = "TongTien";
            txtThanhTien.Enabled = false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string date = string.Format("{0}/{1}/{2}", dtNgayNhap.Value.Year, dtNgayNhap.Value.Month, dtNgayNhap.Value.Day);
            HoaDonNhap hdn = new HoaDonNhap();
            hdn.MaHDN = txtMa.Text;
            hdn.ngaynhap = dtNgayNhap.Text;
            //hdn.MaDT = cbbTennv.SelectedValue.ToString();
            hdn.MaNV = cbbTennv.SelectedValue.ToString();
            hdn.MaNCC = cbbmncc.SelectedValue.ToString();

            if (bus_xe.kiemtramatrung(txtMa.Text) == 1)
            {
                MessageBox.Show("Mã đã tồn tại, vui lòng nhập lại mã!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (bus_hdn.ThemSP(hdn) == true)
                {
                    MessageBox.Show("Thêm thành công!");
                    loaddgv();
                    loadcbbhd();
                }
            }
        }

        private void dgvHDN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtMa.Text = dgvHDN[0, i].Value.ToString();
            //loadcthnd(dgvHDN[0, i].Value.ToString());
            dtNgayNhap.Text = dgvHDN[1, i].Value.ToString();
            cbbTennv.Text = dgvHDN[2, i].Value.ToString();
            cbbmncc.Text = dgvHDN[3, i].Value.ToString();
        }

        private void GUI_HoaDonNhap_Load(object sender, EventArgs e)
        {
            loaddgv();
            //loadcbb();
            loadcbbhd();
            loadcbbct();
            loadcbbnv();
            loadcthnd();
            loadcbbncc();

        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi ứng dụng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                this.Close();
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtMa.ResetText();
            dtNgayNhap.ResetText();
            cbbTennv.ResetText();
            cbbmncc.ResetText();
            txtMa.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string date = string.Format("{0}/{1}/{2}", dtNgayNhap.Value.Year, dtNgayNhap.Value.Month, dtNgayNhap.Value.Day);
            HoaDonNhap hdn = new HoaDonNhap();
            hdn.MaHDN = txtMa.Text;
            hdn.ngaynhap = dtNgayNhap.Text;
            //hdn.MaDT = cbbTennv.SelectedValue.ToString();
            hdn.MaNV = cbbTennv.SelectedValue.ToString();
            hdn.MaNCC = cbbmncc.SelectedValue.ToString();
            if (bus_hdn.Sua(hdn))
            {
                MessageBox.Show("Sửa thành công");
                //txtTongTien.ResetText();
                loaddgv();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string MaDT = txtMa.Text;
            DialogResult kq = MessageBox.Show("Bạn có muốn xóa không", "Tiêu đề", MessageBoxButtons.YesNo);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                if (bus_hdn.Xoa(MaDT))
                {
                    MessageBox.Show("Xóa thành công");
                    loaddgv();
                }
            }
        }

        private void dgvct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMactHDN.Enabled = false;
            int i = e.RowIndex;
            txtMactHDN.Text = dgvct[0, i].Value.ToString();
            cbbMaHD.Text = dgvct[1, i].Value.ToString();
            //loadcthnd(dgvct[1, i].Value.ToString());
            cbbMaxe.Text = dgvct[2, i].Value.ToString();
            txtSoLuong.Text = dgvct[3, i].Value.ToString();
            txtDonGia.Text = dgvct[4, i].Value.ToString();
            txtThanhTien.Text = dgvct[5, i].Value.ToString();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string tukhoa = txtTimkiem.Text;
            dgvHDN.DataSource = bus_hdn.TimkiemHDN(tukhoa);
            dgvHDN.Columns[0].HeaderText = "Mã HD";
            dgvHDN.Columns[1].HeaderText = "Ngày Nhập";
            dgvHDN.Columns[2].HeaderText = "Mã NV";
        }

        private void btnMoict_Click(object sender, EventArgs e)
        {
            txtMactHDN.Enabled = true;
            txtMactHDN.ResetText();
            cbbMaHD.ResetText();
            cbbMaxe.ResetText();
            txtSoLuong.ResetText();
            txtDonGia.ResetText();
            txtThanhTien.ResetText();
            txtMactHDN.Focus();
        }

        private void btnThemct_Click(object sender, EventArgs e)
        {
            ctHoaDonNhap x = new ctHoaDonNhap();
            x.MactHDN = txtMactHDN.Text;
            x.MaHD = cbbMaHD.SelectedValue.ToString();
            x.MaXe = cbbMaxe.SelectedValue.ToString();
            x.Dongia = float.Parse(txtDonGia.Text);
            x.Soluong = int.Parse(txtSoLuong.Text);
            x.TongTien = x.Soluong * x.Dongia;
            if (bus_cthdn.kiemtramatrung(txtMactHDN.Text) == 1)
            {
                MessageBox.Show("Mã đã tồn tại, vui lòng nhập lại mã!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (bus_cthdn.ThemctHD(x) == true)
                {
                    MessageBox.Show("Thêm thành công!");
                    loaddgv();
                    loadcthnd();
                }
            }
        }

        private void btnSuact_Click(object sender, EventArgs e)
        {
            ctHoaDonNhap x = new ctHoaDonNhap();
            x.MactHDN = txtMactHDN.Text;
            x.MaHD = cbbMaHD.SelectedValue.ToString();
            x.MaXe = cbbMaxe.SelectedValue.ToString();
            x.Dongia = float.Parse(txtDonGia.Text);
            x.Soluong = int.Parse(txtSoLuong.Text);
            x.TongTien = x.Soluong * x.Dongia;
            if (bus_cthdn.SuactHD(x))
            {
                MessageBox.Show("Sửa thành công");
                //txtTongTien.ResetText();
                loaddgv();
                loadcthnd();

            }
        }

        private void btnXoact_Click(object sender, EventArgs e)
        {
            string ma = txtMactHDN.Text;
            DialogResult kq = MessageBox.Show("Bạn có muốn xóa không", "Tiêu đề", MessageBoxButtons.YesNo);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                if (bus_cthdn.XoactHD(ma))
                {
                    MessageBox.Show("Xóa thành công");
                    //loadcbb();
                    loaddgv();
                    loadcthnd();

                }
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
