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
        public partial class frmDSSV : Form
        {
            private string tukhoa = "";
            public frmDSSV()
            {
                InitializeComponent();
            }

            private void frmDSSV_Load(object sender, EventArgs e)
            {
                LoadDSSV();
            }
            private void LoadDSSV()
            {
                List<CustomParameter> lstPara = new List<CustomParameter>();
                lstPara.Add(new CustomParameter()
                {
                    key = "@tukhoa",
                    value = tukhoa
                });
                dgvSinhVien.DataSource = new Database().SelectData("SelectAllSinhVien", lstPara);

                dgvSinhVien.Columns["masinhvien"].HeaderText = "Mã SV";
                dgvSinhVien.Columns["hoten"].HeaderText = "Họ Tên";
                dgvSinhVien.Columns["ngsinh"].HeaderText = "Ngày sinh";
                dgvSinhVien.Columns["gioitinh"].HeaderText = "Giới tính";
                dgvSinhVien.Columns["diachi"].HeaderText = "Địa chỉ";
                dgvSinhVien.Columns["dienthoai"].HeaderText = "Điện Thoại";
                dgvSinhVien.Columns["email"].HeaderText = "Email";
                dgvSinhVien.Columns["quequan"].HeaderText = "Quê quán";
            }
            private void dgvSinhVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
            {
                if(e.RowIndex >= 0) 
                {
                    var msv = dgvSinhVien.Rows[e.RowIndex].Cells["masinhvien"].Value.ToString();
                    new frmSinhVien(msv).ShowDialog();
                    LoadDSSV();
                }
            }

            private void btnThemmoi_Click(object sender, EventArgs e)
            {
                new frmSinhVien(null).ShowDialog();
                LoadDSSV();
            }

            private void btnTimkiem_Click(object sender, EventArgs e)
            {
                tukhoa = txtTukhoa.Text;
                LoadDSSV();
            }
        }
    }
