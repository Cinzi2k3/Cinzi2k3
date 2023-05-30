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
    public partial class GUI_HoaDonBan : Form
    {
        public GUI_HoaDonBan()
        {
            InitializeComponent();
        }
        BUS_HoaDonBan bus_HoaDonBan = new BUS_HoaDonBan();
        BUS_XeMay bus_dt = new BUS_XeMay();
        BUS_KhachHang bus_kh = new BUS_KhachHang();
        BUS_NhanVien bus_nv = new BUS_NhanVien();
        BUS_ctHoaDonBan bus_cthdb = new BUS_ctHoaDonBan();
        public void loaddgvhdb()
        {
            dgvHDB.DataSource = bus_HoaDonBan.getData();
            dgvHDB.Columns[0].HeaderText = "Mã Hóa Đơn Bán";
            dgvHDB.Columns[1].HeaderText = "Ngày Bán";
            dgvHDB.Columns[2].HeaderText = "Mã NV";
            dgvHDB.Columns[3].HeaderText = "Mã KH";

        }
        public void loadcbbnv()
        {
            cbbNhanvien.DataSource = bus_nv.getData();
            cbbNhanvien.DisplayMember = "Manv";
            cbbNhanvien.ValueMember = "Manv";
        }
        public void loadcbbkh()
        {
            cbbMaKh.DataSource = bus_kh.getData();
            cbbMaKh.DisplayMember = "MaKH";
            cbbMaKh.ValueMember = "MaKH";
        }
        public void loadcbbCTDT()
        {
            cbbMaXe.DataSource = bus_dt.getData();
            cbbMaXe.DisplayMember = "MaXe";
            cbbMaXe.ValueMember = "MaXe";
        }
        public void loadcbbCTHDB()
        {
            cbbMaHDB.DataSource = bus_HoaDonBan.getData();
            cbbMaHDB.DisplayMember = "MaHDB";
            cbbMaHDB.ValueMember = "MaHDB";
        }
        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtMa.Enabled = true;
            txtMa.ResetText();
            dtNgayBan.ResetText();
            cbbNhanvien.ResetText();
            cbbMaKh.ResetText();
            txtMa.Focus();
        }
        public void loadcthnb()
        {
            dgvctHDB.DataSource = bus_cthdb.getData();
            dgvctHDB.Columns[0].HeaderText = "MactHDN";
            dgvctHDB.Columns[1].HeaderText = "MaHD";
            dgvctHDB.Columns[2].HeaderText = "MaXe";
            dgvctHDB.Columns[3].HeaderText = "SoLuong";
            dgvctHDB.Columns[4].HeaderText = "Dongia";
            dgvctHDB.Columns[5].HeaderText = "TongTien";
            txtThanhtien.Enabled = false;
        }
        private void GUI_HoaDonBan_Load(object sender, EventArgs e)
        {
            loaddgvhdb();
            loadcbbkh();
            loadcbbnv();
            loadcbbCTDT();
            loadcbbCTHDB();
            loadcthnb();
        }

        private void dgvHDB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Enabled = false;
            int i = e.RowIndex;
            txtMa.Text = dgvHDB[0, i].Value.ToString();
            dtNgayBan.Text = dgvHDB[1, i].Value.ToString();
            cbbNhanvien.Text = dgvHDB[2, i].Value.ToString();
            cbbMaKh.Text = dgvHDB[3, i].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string date = string.Format("{0}/{1}/{2}", dtNgayBan.Value.Year, dtNgayBan.Value.Month, dtNgayBan.Value.Day);
            HoaDonBan hdb = new HoaDonBan();
            hdb.MaHDB = txtMa.Text;
            hdb.NgayBan = dtNgayBan.Text;
            hdb.MaNV = cbbNhanvien.SelectedValue.ToString();
            hdb.MaKH = cbbMaKh.SelectedValue.ToString();
            if (bus_HoaDonBan.kiemtramatrung(txtMa.Text) == 1)
            {
                MessageBox.Show("Mã đã tồn tại, vui lòng nhập lại mã!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (bus_HoaDonBan.ThemSP(hdb) == true)
                {
                    MessageBox.Show("Thêm thành công!");
                    loaddgvhdb();
                    loadcbbCTHDB();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string date = string.Format("{0}/{1}/{2}", dtNgayBan.Value.Year, dtNgayBan.Value.Month, dtNgayBan.Value.Day);
            HoaDonBan hdb = new HoaDonBan();
            hdb.MaHDB = txtMa.Text;
            hdb.NgayBan = dtNgayBan.Text;
            hdb.MaNV = cbbNhanvien.SelectedValue.ToString();
            hdb.MaKH = cbbMaKh.SelectedValue.ToString();
            if (bus_HoaDonBan.Sua(hdb))
            {
                MessageBox.Show("Sửa thành công");
                loaddgvhdb();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string MaDT = txtMa.Text;
            DialogResult kq = MessageBox.Show("Bạn có muốn xóa không", "Tiêu đề", MessageBoxButtons.YesNo);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                if (bus_HoaDonBan.Xoa(MaDT))
                {
                    MessageBox.Show("Xóa thành công");
                    loaddgvhdb();
                }
            }
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi ứng dụng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                this.Close();
        }

        private void dgvctHDB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtctHDB.Enabled = false;
            int i = e.RowIndex;
            txtctHDB.Text = dgvctHDB[0, i].Value.ToString();
            cbbMaHDB.Text = dgvctHDB[1, i].Value.ToString();
            //loadcthnd(dgvct[1, i].Value.ToString());
            cbbMaXe.Text = dgvctHDB[2, i].Value.ToString();
            txtSoLuong.Text = dgvctHDB[3, i].Value.ToString();
            txtDongia.Text = dgvctHDB[4, i].Value.ToString();
            txtThanhtien.Text = dgvctHDB[5, i].Value.ToString();
        }

        private void btnMoict_Click(object sender, EventArgs e)
        {
            txtctHDB.Enabled = true;
            txtctHDB.ResetText();
            cbbMaHDB.ResetText();
            cbbMaXe.ResetText();
            txtSoLuong.ResetText();
            txtDongia.ResetText();
            txtThanhtien.ResetText();
            txtctHDB.Focus();
        }

        private void btnThemct_Click(object sender, EventArgs e)
        {
            ctHoaDonBan x = new ctHoaDonBan();
            x.MactHDB = txtctHDB.Text;
            x.MaHD = cbbMaHDB.SelectedValue.ToString();
            x.MaXe = cbbMaXe.SelectedValue.ToString();
            x.SoLuong = int.Parse(txtSoLuong.Text);
            x.DonGia = float.Parse(txtDongia.Text);
            x.TongTien = x.SoLuong * x.DonGia;
            if (bus_cthdb.kiemtramatrung(txtctHDB.Text) == 1)
            {
                MessageBox.Show("Mã đã tồn tại, vui lòng nhập lại mã!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (bus_cthdb.ThemctHD(x) == true)
                {
                    MessageBox.Show("Thêm thành công!");
                    loadcthnb();
                }
            }
        }

        private void btnSuact_Click(object sender, EventArgs e)
        {
            ctHoaDonBan x = new ctHoaDonBan();
            x.MactHDB = txtctHDB.Text;
            x.MaHD = cbbMaHDB.SelectedValue.ToString();
            x.MaXe = cbbMaXe.SelectedValue.ToString();
            x.SoLuong = int.Parse(txtSoLuong.Text);
            x.DonGia = float.Parse(txtDongia.Text);
            x.TongTien = x.SoLuong * x.DonGia;
            if (bus_cthdb.SuactHD(x))
            {
                MessageBox.Show("Sửa thành công");
                //txtTongTien.ResetText();
                loadcthnb();
            }
        }

        private void btnXoact_Click(object sender, EventArgs e)
        {
            string ma = txtctHDB.Text;
            DialogResult kq = MessageBox.Show("Bạn có muốn xóa không", "Tiêu đề", MessageBoxButtons.YesNo);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                if (bus_cthdb.XoactHD(ma))
                {
                    MessageBox.Show("Xóa thành công");
                    loadcthnb();

                }
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string tukhoa = txtTimkiem.Text;
            dgvHDB.DataSource = bus_HoaDonBan.TimkiemHDB(tukhoa);
            dgvHDB.Columns[0].HeaderText = "Mã Hóa Đơn Bán";
            dgvHDB.Columns[1].HeaderText = "Ngày Bán";
            dgvHDB.Columns[2].HeaderText = "Mã NV";
            dgvHDB.Columns[3].HeaderText = "Mã KH";
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDongia_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
