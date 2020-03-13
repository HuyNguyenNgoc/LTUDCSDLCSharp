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
    public partial class Frm_TaoKetNoi : Form
    {
        public Frm_TaoKetNoi()
        {
            InitializeComponent();
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        ReadConnectionString rcString;
        string err = string.Empty;
        Database data;
        private void Frm_TaoKetNoi_Load(object sender, EventArgs e)
        {
            rcString = new ReadConnectionString(System.Configuration.ConfigurationManager.AppSettings["MyconnectionString"]);
            HienthithongtinKetNoi();
        }

        private void HienthithongtinKetNoi()
        {
            txtDatabasename.Text = rcString.DatabaseName;
            txtServername.Text = rcString.ServerName;
            txtUserName.Text = rcString.Uid;
            txtPass.Text = rcString.Pwd;
            chk_WinNT.Checked = rcString.WinNT;
        }

        private void btnKuuKetNoi_Click(object sender, EventArgs e)
        {
            GetData();
            rcString.LuuChuoiKetNoiVaoFile(string.Format(@"{0}\connect.ini", Application.StartupPath));
        }

        private void GetData()
        {
            rcString.ServerName = txtServername.Text;
            rcString.DatabaseName = txtDatabasename.Text;
            rcString.Uid = txtUserName.Text;
            rcString.Pwd = txtPass.Text;
            rcString.WinNT = chk_WinNT.Checked;
        }

        private void btnKiemtra_Click(object sender, EventArgs e)
        {
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

        private void chk_WinNT_CheckedChanged(object sender, EventArgs e)
        {
                txtUserName.Enabled = !chk_WinNT.Checked;
                txtPass.Enabled = !chk_WinNT.Checked;
        }
    }
}
