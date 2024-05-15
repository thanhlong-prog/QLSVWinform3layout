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
    public partial class frmLopHoc : Form
    {
        private string malophoc;
        private Database db;
        private string nguoithuchien = "admin";
        public frmLopHoc(string malophoc)
        {
            this.malophoc = malophoc;
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmLopHoc_Load(object sender, EventArgs e)
        {
            db = new Database();
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@tukhoa",
                value = ""
            });
            cbbMonhoc.DataSource = db.SelectData("selectAllMonHoc", lstPara);
            cbbMonhoc.DisplayMember = "tenmonhoc";
            cbbMonhoc.ValueMember = "mamonhoc";
            cbbMonhoc.SelectedIndex = -1;

            cbbGiaovien.DataSource = db.SelectData("selectAllGV", lstPara);
            cbbGiaovien.DisplayMember = "hoten";
            cbbGiaovien.ValueMember = "magiaovien";
            cbbGiaovien.SelectedIndex = -1;
            if (string.IsNullOrEmpty(malophoc))
            {
                this.Text = "Thêm mới lớp học";
            }
            else
            {
                this.Text = "Cập nhật lớp học";
                var r = db.Select("exec selectLopHoc '" + malophoc + "'");
                cbbGiaovien.SelectedValue = r["magiaovien"].ToString();
                cbbMonhoc.SelectedValue = r["mamonhoc"].ToString();
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql = "";
            if(cbbGiaovien.SelectedIndex < 0) 
            {
                MessageBox.Show("Vui lòng chọn giáo viên");
                return;
            }
            if (cbbMonhoc.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn môn học");
                return;
            }
            List<CustomParameter> lstPara = new List<CustomParameter>();
            if(string.IsNullOrEmpty(malophoc)) 
            {
                sql = "insertLopHoc";
                lstPara.Add(new CustomParameter()
                {
                    key = "@nguoitao",
                    value = nguoithuchien
                });
            }
            else
            {
                sql = "updateLopHoc";
                lstPara.Add(new CustomParameter()
                {
                    key = "@nguoicapnhat",
                    value = nguoithuchien
                });
                lstPara.Add(new CustomParameter()
                {
                    key = "@malophoc",
                    value = malophoc
                });
            }
            lstPara.Add(new CustomParameter()
            {
                key = "@mamonhoc",
                value = cbbMonhoc.SelectedValue.ToString()
            }) ;
            lstPara.Add(new CustomParameter()
            {
                key = "@magiaovien",
                value = cbbGiaovien.SelectedValue.ToString()
            });
            var kq = db.Execute(sql,lstPara);
            if(kq == 1)
            {
                if(string.IsNullOrEmpty(malophoc))
                {
                    MessageBox.Show("Thêm mới lớp học thành công");
                }
                else
                {
                    MessageBox.Show("Cập nhật lớp học thành công");
                }
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Lưu dữ liệu thất bại");
            }
        }
    }
}
