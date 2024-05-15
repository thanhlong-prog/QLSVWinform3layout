using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_3layers
{
    public partial class frmGV : Form
    {
        private string mgv;
        private string nguoithucthi = "admin";
        private string matkhaukhoitao = "";
        public frmGV(string mgv)
        {
            this.mgv = mgv;
            InitializeComponent();
        }

        private void GenerateRandomPassword()
        {
            Random random = new Random();
            int randomNumber = random.Next(100000, 1000000);
            matkhaukhoitao = randomNumber.ToString();
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

        private void SendEmail(string toAddress, string subject, string body)
        {
            string fromAddress = "thanhlongtivip@gmail.com";
            string fromPassword = "vqwq rlal trmz ggwq";

            MailMessage message = new MailMessage(fromAddress, toAddress);
            message.Subject = subject;
            message.Body = body;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential(fromAddress, fromPassword);

            try
            {
                smtpClient.Send(message);
                MessageBox.Show("Email gửi mật khẩu cho giáo viên thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi gửi email: " + ex.Message);
            }
        }

        private void frmGV_Load(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(mgv))
            {
                this.Text = "Thêm mới giáo viên";
                txtDLMK.Visible = false;
                label10.Visible = false;
            }
            else
            {
                this.Text = "Cập nhật giáo viên";
                var r = new Database().Select("selectGV '" + int.Parse(mgv) + "'");
                txtHo.Text = r["ho"].ToString();
                txtTendem.Text = r["tendem"].ToString();
                txtTen.Text = r["ten"].ToString();
                if (r["gioitinh"].ToString() == "1")
                {
                    rbtNam.Checked = true;
                }
                else
                {
                    rbtNu.Checked = true;
                }
                mtbNgaysinh.Text = r["ngsinh"].ToString();
                txtDienthoai.Text = r["dienthoai"].ToString();
                txtEmail.Text = r["email"].ToString();
                txtDiachi.Text = r["diachi"].ToString();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql = "";
            DateTime ngaysinh;
            List<CustomParameter> lstPara = new List<CustomParameter>();
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
            if (string.IsNullOrEmpty(mgv)) 
            {
                sql = "insertGV";
                lstPara.Add(new CustomParameter
                {
                    key = "@nguoitao",
                    value = nguoithucthi,
                });
                GenerateRandomPassword();
                string tmpPassword = CreatePass(matkhaukhoitao);
                lstPara.Add(new CustomParameter()
                {
                    key = "@matkhaukhoitao",
                    value = tmpPassword,
                });
            }
            else
            {
                sql = "updateGV";
                lstPara.Add(new CustomParameter
                {
                    key = "@nguoicapnhat",
                    value = nguoithucthi,
                });

                lstPara.Add(new CustomParameter 
                {
                    key = "@magiaovien",
                    value = mgv,
                });
                if (!string.IsNullOrEmpty(txtDLMK.Text))
                {
                    List<CustomParameter> lst = new List<CustomParameter>();
                    lst.Add(new CustomParameter()
                    {
                        key = "@matkhau",
                        value = CreatePass(txtDLMK.Text),
                    });
                    lst.Add(new CustomParameter()
                    {
                        key = "@taikhoan",
                        value = mgv,
                    });
                    new Database().Execute("updateMKGiaoVien", lst);
                }
            }
            lstPara.Add(new CustomParameter
            {
                key = "@ho",
                value = txtHo.Text
            });
            lstPara.Add(new CustomParameter
            {
                key = "@tendem",
                value = txtTendem.Text
            });
            lstPara.Add(new CustomParameter
            {
                key = "@ten",
                value = txtTen.Text
            });
            lstPara.Add(new CustomParameter
            {
                key = "@ngaysinh",
                value = ngaysinh.ToString("yyyy-MM-dd")
            });
            lstPara.Add(new CustomParameter
            {
                key = "@gioitinh",
                value = rbtNam.Checked?"1":"0"
            });
            lstPara.Add(new CustomParameter
            {
                key = "@email",
                value = txtEmail.Text
            });
            lstPara.Add(new CustomParameter
            {
                key = "@diachi",
                value = txtDiachi.Text
            });
            lstPara.Add(new CustomParameter
            {
                key = "@dienthoai",
                value = txtDienthoai.Text
            });
            var rs = new Database().Execute(sql, lstPara);
            if(rs == 1)
            {
                if(string.IsNullOrEmpty(mgv))
                {
                    var newStudentID = new Database().Select("giaovienmoiMSSV");
                    string toAddress = "thanhtyu147@gmail.com";
                    string subject = "Mật khẩu mới cho giáo viên";
                    string body = "Mã giáo viên mới: " + newStudentID["msgvmoi"].ToString() + "\nMật khẩu mới của giáo viên là: " + matkhaukhoitao;
                    SendEmail(toAddress, subject, body);
                    MessageBox.Show("Thêm mới giáo viên thành công");
                }
                else
                {
                    MessageBox.Show("Cập nhật mới giáo viên thành công");
                }
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Thực thi truy vấn thất bại");
            }
        }

        private void bntHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
