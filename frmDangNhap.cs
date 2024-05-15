using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_3layers
{
    public partial class frmDangNhap : Form
    {
        public string tendangnhap = "";
        public string loaitk = "";
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private string CreatePass(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if(cbbLoaiTaiKhoan.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn loại tài khoản","Tài khoản không được để trống");
                return;
            }
            if(string.IsNullOrEmpty(txtTenDangNhap.Text) )
            {
                MessageBox.Show("Vui lòng nhập tài khoản");
                return;
            }
            if(string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu","Mật khẩu không thể để trống");
                return;
            }    
            tendangnhap = txtTenDangNhap.Text;
            loaitk = "";
            
            switch (cbbLoaiTaiKhoan.Text)
            {
                case "Quản trị viên" :
                    loaitk = "admin";
                    break;
                case "Sinh viên":
                    loaitk = "sinhvien";
                    break;
                case "Giáo viên":
                    loaitk = "giaovien";
                    break;
            }
            

            List<CustomParameter> lstPara = new List<CustomParameter>()
            {
                new CustomParameter()
                {
                    key = "@loaitaikhoan",
                    value = loaitk
                },
                new CustomParameter()
                {
                    key = "@taikhoan",
                    value = txtTenDangNhap.Text
                },
                new CustomParameter()
                {
                    key = "@matkhau",
                    value = CreatePass(txtMatKhau.Text)
                }
            };

            var rs = new Database().SelectData("dangnhap", lstPara);
            if(rs.Rows.Count > 0)
            {
                this.Hide();
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại tên đăng nhập hoặc mật khẩu","Tài khoản hoặc mật khẩu không hợp lệ");
            }
            
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
