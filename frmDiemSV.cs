using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_3layers
{
    public partial class frmDiemSV : Form
    {
        private string masv;
        private string malop;
        public frmDiemSV(string masv, string malop)
        {
            this.malop = malop;
            this.masv = masv;
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            string sql = "";
            string diemlan1 = txtDiemlan1.Text;
            string diemlan2 = txtDiemLan2.Text;
            string diemlan3 = txtDiemLan3.Text;
            float diem1, diem2, diem3;
            if (!float.TryParse(diemlan1, out diem1) || diem1 < 0 || diem1 > 10)
            {
                MessageBox.Show("Điểm 1 không hợp lệ. Vui lòng nhập lại điểm số thực trong khoảng từ 0 đến 10.", "Cảnh báo");
                return;
            }

            if (!float.TryParse(diemlan2, out diem2) || diem2 < 0 || diem2 > 10)
            {
                MessageBox.Show("Điểm 2 không hợp lệ. Vui lòng nhập lại điểm số thực trong khoảng từ 0 đến 10.", "Cảnh báo");
                return;
            }

            if (!float.TryParse(diemlan3, out diem3) || diem3 < 0 || diem3 > 10)
            {
                MessageBox.Show("Điểm 3 không hợp lệ. Vui lòng nhập lại điểm số thực trong khoảng từ 0 đến 10.", "Cảnh báo");
                return;
            }
            sql = "updateDiemSV";
            lstPara.Add(new CustomParameter()
            {
                key = "@masinhvien",
                value = masv
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@malop",
                value = malop
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@diemlan1",
                value = txtDiemlan1.Text
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@diemlan2",
                value = txtDiemLan2.Text
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@diemlan3",
                value = txtDiemLan3.Text
            });
            new Database().Execute(sql, lstPara);
            MessageBox.Show("Sửa điểm sinh viên thành công");
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDiemSV_Load(object sender, EventArgs e)
        {
            this.Text = "Nhập điểm sinh viên";
            //var r = new Database().Select("selectSV '" + masv + "'");
            
            //txtHo.Text = r["ho"].ToString();
            var r = new Database().Select("selectDiemSV '" + masv + "','"+malop+"'");
            //MessageBox.Show(r["sinhvien"].ToString());
            txtTenmonhoc.Text = r["tenmonhoc"].ToString();
            txtSinhVien.Text = r["sinhvien"].ToString();
            txtDiemlan1.Text = r["diemlan1"].ToString();
            txtDiemLan2.Text = r["diemlan2"].ToString();
            txtDiemLan3.Text = r["diemlan3"].ToString();
        }
    }
}
