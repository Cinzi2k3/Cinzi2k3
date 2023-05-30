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

namespace DA1
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_NhanVien qlnv = new GUI_NhanVien();
            qlnv.ShowDialog();
        }

        private void quảnLýLoạiXeMáyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_LoaiXM qllxm = new GUI_LoaiXM();
            qllxm.ShowDialog();
        }

        private void quảnLýXeMáyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_XeMay qlxm = new GUI_XeMay();
            qlxm.ShowDialog();
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_KhachHang qlkh = new GUI_KhachHang();
            qlkh.ShowDialog();
        }

        private void quảnLýHóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_HoaDonNhap qlhdn = new GUI_HoaDonNhap();
            qlhdn.ShowDialog();
        }

        private void quảnLýHóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_HoaDonBan qlhdb = new GUI_HoaDonBan();
            qlhdb.ShowDialog();
        }
        private void quảnLýNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_NCC qlncc = new GUI_NCC();
            qlncc.ShowDialog();
        }
        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
