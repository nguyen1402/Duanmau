using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLBH;

namespace GUI_QLBD
{
    public partial class frmNhanVien : Form
    {
        private BUS_Nhanvien busNhanvien;
        public frmNhanVien()
        {
            InitializeComponent();
            busNhanvien = new BUS_Nhanvien();
        }

        void HienthiDsNhanVien()
        {
            
        }
        private void btn_quaylai_Click(object sender, EventArgs e)
        {
            Form1 main = new Form1();
            this.Hide();
            main.Show();
        }
    }
}
