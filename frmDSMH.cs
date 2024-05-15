﻿using System;
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
    public partial class frmDSMH : Form
    {
        private string tukhoa = "";
        public frmDSMH()
        {
            InitializeComponent();
        }

        private void dgvDSMH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                var mamh = dgvDSMH.Rows[e.RowIndex].Cells["mamonhoc"].Value.ToString();
                new frmMonHoc(mamh).ShowDialog();
                loadDSMH();
            }
        }

        private void btnThemmoi_Click(object sender, EventArgs e)
        {
            new frmMonHoc(null).ShowDialog();
            loadDSMH();
        }
        private void loadDSMH()
        {
            List<CustomParameter> lstPara= new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@tukhoa",
                value = tukhoa
            });
            dgvDSMH.DataSource = new Database().SelectData("selectAllMonHoc", lstPara);
        }

        private void frmDSMH_Load(object sender, EventArgs e)
        {
            loadDSMH();
            dgvDSMH.Columns["mamonhoc"].HeaderText = "Mã MH";
            dgvDSMH.Columns["tenmonhoc"].HeaderText = "Tên môn học";
            dgvDSMH.Columns["sotinchi"].HeaderText = "Số tín chỉ";
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            tukhoa = txtTimkiem.Text;
            loadDSMH();
        }
    }
}
