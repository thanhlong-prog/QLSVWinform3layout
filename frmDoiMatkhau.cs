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
    public partial class frmDoiMatkhau : Form
    {
        private string loaitk;
        private string taikhoan;
        public frmDoiMatkhau(string loaitk, string taikhoan)
        {
            this.loaitk = loaitk;
            this.taikhoan = taikhoan;
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

        private void frmDoiMatkhau_Load(object sender, EventArgs e)
        {
            this.Text = "Thay đổi mật khẩu";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(loaitk) && !string.IsNullOrEmpty(taikhoan))
            {
                string matkhaucu = txtMKC.Text;
                string matkhaumoi = txtMKM.Text;
                string xacnhanmk = txtXNLMK.Text;
                
                if (string.IsNullOrEmpty(matkhaucu))
                {
                    MessageBox.Show("Hãy nhập mật khẩu cũ", "Cảnh báo");
                    return;
                }
                
                if (string.IsNullOrEmpty(matkhaumoi))
                {
                    MessageBox.Show("Hãy nhập mật khẩu mới", "Cảnh báo");
                    return;
                }
                if (string.IsNullOrEmpty(xacnhanmk))
                {
                    MessageBox.Show("Hãy nhập xác nhận lại mật khẩu mới", "Cảnh báo");
                    return;
                }
                if(!txtMKM.Text.Equals(txtXNLMK.Text)) 
                {
                    MessageBox.Show("Xác nhận mật khẩu sai", "Cảnh báo");
                    return;
                }
                List<CustomParameter> lstPara = new List<CustomParameter>();
                string sql = "";
                if (loaitk.Equals("admin"))
                {
                    var r = new Database().Select("selectTKAdmin '" + taikhoan + "'");
                    if (!CreatePass(txtMKC.Text).Equals(r["matkhau"].ToString()))
                    {
                        MessageBox.Show("Nhập mật khẩu cũ sai", "Cảnh báo");
                        return;
                    }
                    sql = "updateMKAdmin";
                    lstPara.Add(new CustomParameter()
                    {
                        key = "@matkhau",
                        value = CreatePass(txtMKM.Text),
                    });
                    lstPara.Add(new CustomParameter()
                    {
                        key = "@taikhoan",
                        value = taikhoan,
                    });
                    new Database().Execute(sql, lstPara);
                    MessageBox.Show("Đổi mật khẩu thành công", "Success");
                    this.Close();
                    //MessageBox.Show(r[0].ToString());
                }
                else if (loaitk.Equals("giaovien"))
                {
                    var r = new Database().Select("selectTKGiaoVien '" + taikhoan + "'");
                    if (!CreatePass(txtMKC.Text).Equals(r["matkhau"].ToString()))
                    {
                        MessageBox.Show("Nhập mật khẩu cũ sai", "Cảnh báo");
                        return;
                    }
                    sql = "updateMKGiaoVien";
                    lstPara.Add(new CustomParameter()
                    {
                        key = "@matkhau",
                        value = CreatePass(txtMKM.Text),
                    });
                    lstPara.Add(new CustomParameter()
                    {
                        key = "@taikhoan",
                        value = taikhoan,
                    });
                    new Database().Execute(sql, lstPara);
                    MessageBox.Show("Đổi mật khẩu thành công", "Success");
                    this.Close();
                    //MessageBox.Show(r[0].ToString());
                }
                else if (loaitk.Equals("sinhvien"))
                {
                    var r = new Database().Select("selectTKSinhVien '" + taikhoan + "'");
                    if (!CreatePass(txtMKC.Text).Equals(r["matkhau"].ToString()))
                    {
                        MessageBox.Show("Nhập mật khẩu cũ sai", "Cảnh báo");
                        return;
                    }
                    sql = "updateMKSinhVien";
                    lstPara.Add(new CustomParameter()
                    {
                        key = "@matkhau",
                        value = CreatePass(txtMKM.Text),
                    });
                    lstPara.Add(new CustomParameter()
                    {
                        key = "@taikhoan",
                        value = taikhoan,
                    });
                    new Database().Execute(sql, lstPara);
                    MessageBox.Show("Đổi mật khẩu thành công", "Success");
                    this.Close();
                    //MessageBox.Show(r[0].ToString());
                }
                //txtHo.Text = r["ho"].ToString();
            }
        }
    }
}
