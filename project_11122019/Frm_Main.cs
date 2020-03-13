using project_11122019.Datalayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_11122019
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        Database data;
        string err = string.Empty;
        private void Frm_Main_Load(object sender, EventArgs e)
        {
            timer1.Start();
            data = new Database(string.Format(@"{0}\connect.ini", Application.StartupPath));
            if (data.TestConnect(ref err))
            {
                MessageBox.Show("Kết nối thành công \n");
            }
            else
            {
                MessageBox.Show(string.Format("Kết nối thất bại \nLỗi: {0} \t", err));
                Frm_TaoKetNoi taoketnoi = new Frm_TaoKetNoi();
                taoketnoi.ShowDialog();
            }
        }

        private void kếtNốiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_TaoKetNoi taoketnoi = new Frm_TaoKetNoi();
            taoketnoi.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtTime.Text = string.Format("Giờ hệ thống: {0}", DateTime.Now.ToLongTimeString());
        }

        private void txtServerName_Click(object sender, EventArgs e)
        {
            
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }




    }
}
