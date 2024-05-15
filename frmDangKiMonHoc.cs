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
    public partial class frmDangKiMonHoc : Form
    {
        private string masv;
        public frmDangKiMonHoc(string masv)
        {
            this.masv = masv;
            InitializeComponent();
        }

        private void frmDangKiMonHoc_Load(object sender, EventArgs e)
        {
            loadDSLH();
        }
        private void loadDSLH()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@masinhvien",
                value = masv,
            });
            dgvDSLH.DataSource = new Database().SelectData("dsLopChuaDKy",lstPara);
            dgvDSLH.Columns["malophoc"].HeaderText = "Mã lớp học";
            dgvDSLH.Columns["mamonhoc"].HeaderText = "Mã môn học";
            dgvDSLH.Columns["tenmonhoc"].HeaderText = "Tên môn học";
            dgvDSLH.Columns["sotinchi"].HeaderText = "Số tín chỉ";
            dgvDSLH.Columns["gvien"].HeaderText = "Giáo viên";
            dgvDSLH.Columns["mamonhoc"].Visible = false;
        }

        private void dgvDSLH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDSLH.Rows[e.RowIndex].Index >= 0)
            {
                if(DialogResult.Yes == MessageBox.Show("Bạn muốn đăng kí học phần: " + dgvDSLH.Rows[e.RowIndex].Cells["tenmonhoc"].Value.ToString(), "Xác nhận đăng kí", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    List<CustomParameter> lstPara = new List<CustomParameter>();
                    lstPara.Add(new CustomParameter() { 
                        key = "@masinhvien",
                        value = masv
                    });
                    lstPara.Add(new CustomParameter()
                    {
                        key = "@malophoc",
                        value = dgvDSLH.Rows[e.RowIndex].Cells["malophoc"].Value.ToString()
                    });
                    var rs = new Database().Execute("[dkyhoc]", lstPara);
                    if (rs == -1)
                    {
                        MessageBox.Show("Học phần này bạn đã được đăng kí", "Cảnh báo!!!");
                        return;
                    }
                    if (rs == 1)
                    {
                        MessageBox.Show("Học phần này bạn đã đăng kí thành công", "Success!!!");
                        loadDSLH();
                    }
                }
            }
        }
    }
}
