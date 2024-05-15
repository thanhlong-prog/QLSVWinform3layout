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
    public partial class frmQuanLyLop : Form
    {
        private string magv;
        public frmQuanLyLop(string magv)
        {
            this.magv = magv;
            InitializeComponent();
        }
        private void loadDSLop()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@magiaovien",
                value = magv
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@tukhoa",
                value = txtTukhoa.Text
            });
            dgvKQHT.DataSource = new Database().SelectData("tracuulop",lstPara);
            dgvKQHT.Columns["malophoc"].HeaderText = "Mã lớp học";
            dgvKQHT.Columns["mamonhoc"].HeaderText = "Mã môn học";
            dgvKQHT.Columns["tenmonhoc"].HeaderText = "Tên môn học";
            dgvKQHT.Columns["sotinchi"].HeaderText = "Số tín chỉ";
            dgvKQHT.Columns["siso"].HeaderText = "Sĩ số";
        }

        private void frmQuanLyLop_Load(object sender, EventArgs e)
        {
            loadDSLop();
        }

        private void btnTracuu_Click(object sender, EventArgs e)
        {
            loadDSLop();
        }

        private void dgvKQHT_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var malop = dgvKQHT.Rows[e.RowIndex].Cells["malophoc"].Value.ToString();
                new frmDSSVLopHoc(malop).ShowDialog();
                //MessageBox.Show(malop);
                loadDSLop() ;
            }
        }
    }
}
