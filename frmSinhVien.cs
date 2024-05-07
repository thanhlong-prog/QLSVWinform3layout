using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_3layers
{
    public partial class frmSinhVien : Form
    {
        private string msv;
        public frmSinhVien(string msv)
        {
            this.msv = msv;
            InitializeComponent();
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(msv)) 
            {
                this.Text = "Thêm mới sinh viên";
            }
            else 
            {
                this.Text = "Cập nhật thông tin sinh viên";
                var r = new Database().Select("selectSV '" + msv + "'");
                //MessageBox.Show(r[0].ToString());
                txtHo.Text = r["ho"].ToString();
                txtTendem.Text = r["tendem"].ToString();
                txtTen.Text = r["ten"].ToString();
                mtbNgaysinh.Text = r["ngsinh"].ToString();
                if (r["gtinh"].ToString() == "Nam") 
                {
                    rbtNam.Checked = true;
                }
                else
                {
                    rbtNu.Checked = true;
                }
                txtQuequan.Text = r["quequan"].ToString();
                txtDiachi.Text = r["diachi"].ToString();
                txtDienthoai.Text = r["dienthoai"].ToString();
                txtEmail.Text = r["email"].ToString();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql = "";
            string ho = txtHo.Text;
            string tendem = txtTendem.Text;
            string ten = txtTen.Text;
            DateTime ngaysinh;
            try
            {
                ngaysinh = DateTime.ParseExact(mtbNgaysinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                MessageBox.Show("Ngày sinh không hợp lệ");
                mtbNgaysinh.Select();
                return;
            }
            string quequan = txtQuequan.Text;
            string diachi = txtDiachi.Text;
            string email = txtEmail.Text;
            string dienthoai = txtDienthoai.Text;
            string gioitinh = rbtNam.Checked ? "1" : "0";

            List<CustomParameter> lstPara = new List<CustomParameter>();

            if(string.IsNullOrEmpty(msv)) 
            {
                sql = "ThemMoiSV";
               
            }
            else
            {
                sql = "updateSV";
                lstPara.Add(new CustomParameter()
                {
                    key = "@masinhvien",
                    value = msv,
                });
            }
            lstPara.Add(new CustomParameter()
            {
                key = "@ho",
                value = ho,
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@tendem",
                value = tendem,
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@ten",
                value = ten,
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@gioitinh",
                value = gioitinh,
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@ngaysinh",
                value = ngaysinh.ToString("yyyy-MM-dd"),
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@quequan",
                value = quequan,
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@diachi",
                value = diachi,
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@dienthoai",
                value = dienthoai,
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@email",
                value = email,
            });
            var rs = new Database().Execute(sql, lstPara);
            if(rs == 1)
            {
                if(string.IsNullOrEmpty(sql))
                {
                    MessageBox.Show("Thêm mới sinh viên thành công");
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin thành công");
                }
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Thực thi thất bại");
            }
        }
    }
}
