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
    public partial class frmDSSVLopHoc : Form
    {
        private string malop;
        private string tukhoa = "";
        public frmDSSVLopHoc(string malop)
        {
            this.malop = malop;
            InitializeComponent();
        }

        private void loadDSSVLopHoc()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@tukhoa",
                value = txtTukhoa.Text
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@malop",
                value = malop
            });
            dgvSVTLH.DataSource = new Database().SelectData("SelectAllSinhVienTrongLH", lstPara);
        }

        private void frmDSSVLopHoc_Load(object sender, EventArgs e)
        {
            loadDSSVLopHoc();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            loadDSSVLopHoc();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTroLai_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvSVTLH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var masv = dgvSVTLH.Rows[e.RowIndex].Cells["masinhvien"].Value.ToString();
                new frmDiemSV(masv, malop).ShowDialog();
                //MessageBox.Show(masv);
                loadDSSVLopHoc();
            }
        }
    }
}
