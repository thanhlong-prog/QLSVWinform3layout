using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_3layers
{
    public partial class frmDSMHDaDK : Form
    {
        private string masv;
        public frmDSMHDaDK(string masv)
        {
            this.masv = masv;
            InitializeComponent();
        }

        private void frmDSMHDaDK_Load(object sender, EventArgs e)
        {
            loadMonDaDK();
        }
        private void loadMonDaDK()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@masinhvien",
                value = masv
            });
            dgvDSMHDKy.DataSource = new Database().SelectData("monDaDKy",lstPara);
        }

        private void btnDangkymoi_Click(object sender, EventArgs e)
        {
            new frmDangKiMonHoc(masv).ShowDialog();
            loadMonDaDK();
        }
    }
}
