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
    public partial class frmKetQuaHocTap : Form
    {
        private string masv;
        public frmKetQuaHocTap(string masv)
        {
            this.masv = masv;
            InitializeComponent();
        }

        private void frmKetQuaHocTap_Load(object sender, EventArgs e)
        {
            loadKQHT();
        }
        private void loadKQHT()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@masinhvien",
                value = masv
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@tukhoa",
                value = txtTukhoa.Text
            });
            dgvKQHT.DataSource = new Database().SelectData("tracuudiem", lstPara);
            dgvKQHT.Columns["mamonhoc"].HeaderText = "Mã MH";
            dgvKQHT.Columns["tenmonhoc"].HeaderText = "Tên môn học";
            dgvKQHT.Columns["lanhoc"].HeaderText = "Lần học";
            dgvKQHT.Columns["gvien"].HeaderText = "Giáo viên";
            dgvKQHT.Columns["diemlan1"].HeaderText = "Điểm lần 1";
            dgvKQHT.Columns["diemlan2"].HeaderText = "Điểm lần 2";
            dgvKQHT.Columns["diemlan3"].HeaderText = "Điểm lần 3";
        }

        private void btnTracuu_Click(object sender, EventArgs e)
        {
            loadKQHT();
        }
    }
}
