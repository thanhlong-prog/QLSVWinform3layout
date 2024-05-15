using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_3layers
{
    public partial class frmSinhVien : Form
    {
        private string msv;
        private string matkhaukhoitao = "";
        public frmSinhVien(string msv)
        {
            this.msv = msv;
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
                MessageBox.Show("Email gửi mật khẩu cho sinh viên thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi gửi email: " + ex.Message);
            }
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(msv)) 
            {
                this.Text = "Thêm mới sinh viên";
                txtDLMK.Visible = false;
                label10.Visible = false;
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
                sql = "updateSV";
                lstPara.Add(new CustomParameter()
                {
                    key = "@masinhvien",
                    value = msv,
                });
                if(!string.IsNullOrEmpty(txtDLMK.Text))
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
                        value = msv,
                    });
                    new Database().Execute("updateMKSinhVien", lst);
                }
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
                if(string.IsNullOrEmpty(msv))
                {
                    var newStudentID = new Database().Select("hocsinhmoiMSSV");
                    string toAddress = "thanhtyu147@gmail.com";
                    string subject = "Mật khẩu mới cho sinh viên";
                    string body = "Mã sinh viên mới: " + newStudentID["mssvmoi"].ToString() + "\nMật khẩu mới của sinh viên là: " + matkhaukhoitao;
                    SendEmail(toAddress, subject, body);
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
