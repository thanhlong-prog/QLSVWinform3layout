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
    public partial class frmDSLopHoc : Form
    {
        private string tukhoa = "";
        public frmDSLopHoc()
        {
            InitializeComponent();
        }

        private void frmDSLopHoc_Load(object sender, EventArgs e)
        {
            loadDSLH();
        }
        private void loadDSLH()
        {
            string sql = "allLopHoc";
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@tukhoa",
                value = tukhoa
            });
            dgvLopHoc.DataSource = new Database().SelectData(sql, lstPara);
            dgvLopHoc.Columns["malophoc"].HeaderText = "Mã lớp học";
            dgvLopHoc.Columns["gv"].HeaderText = "Giáo viên";
            dgvLopHoc.Columns["tenmonhoc"].HeaderText = "Tên môn học";
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            tukhoa = txtTimkiem.Text;
            loadDSLH();
        }

        private void btnThemmoi_Click(object sender, EventArgs e)
        {
            new frmLopHoc(null).ShowDialog();
            loadDSLH();
        }

        private void dgvLopHoc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0) 
            {
                new frmLopHoc(dgvLopHoc.Rows[e.RowIndex].Cells["malophoc"].Value.ToString()).ShowDialog();
                loadDSLH() ;    
            }
        }

        private void dgvLopHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvLopHoc.Columns["btnDelete"].Index)
                {
                    if (MessageBox.Show("Bạn có muốn xóa lớp học " + dgvLopHoc.Rows[e.RowIndex].Cells["tenmonhoc"].Value.ToString() + "?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var maLH = dgvLopHoc.Rows[e.RowIndex].Cells["malophoc"].Value.ToString();
                        //MessageBox.Show(maLH);
                        var sql = "deleteLH";
                        var lstPara = new List<CustomParameter>()
                        {
                            new CustomParameter
                            {
                                key = "@malophoc",
                                value = maLH,
                            }
                        };
                        new Database().Execute(sql, lstPara);

                        MessageBox.Show("Xóa lớp học thành công");

                        loadDSLH();
                    }
                }
            }
        }
    }
}
