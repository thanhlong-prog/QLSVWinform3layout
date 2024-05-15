namespace QLSV_3layers
{
    partial class frmDSSVLopHoc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.txtTukhoa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSVTLH = new System.Windows.Forms.DataGridView();
            this.btnTroLai = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSVTLH)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.AllowDrop = true;
            this.btnTimkiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimkiem.Location = new System.Drawing.Point(946, 40);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(126, 36);
            this.btnTimkiem.TabIndex = 6;
            this.btnTimkiem.Text = "Tìm kiếm";
            this.btnTimkiem.UseVisualStyleBackColor = true;
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
            // 
            // txtTukhoa
            // 
            this.txtTukhoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTukhoa.Location = new System.Drawing.Point(540, 45);
            this.txtTukhoa.Name = "txtTukhoa";
            this.txtTukhoa.Size = new System.Drawing.Size(371, 26);
            this.txtTukhoa.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(468, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Từ khóa";
            // 
            // dgvSVTLH
            // 
            this.dgvSVTLH.AllowUserToAddRows = false;
            this.dgvSVTLH.AllowUserToDeleteRows = false;
            this.dgvSVTLH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSVTLH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSVTLH.Location = new System.Drawing.Point(12, 110);
            this.dgvSVTLH.MultiSelect = false;
            this.dgvSVTLH.Name = "dgvSVTLH";
            this.dgvSVTLH.ReadOnly = true;
            this.dgvSVTLH.RowHeadersWidth = 62;
            this.dgvSVTLH.RowTemplate.Height = 28;
            this.dgvSVTLH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSVTLH.Size = new System.Drawing.Size(1079, 448);
            this.dgvSVTLH.TabIndex = 7;
            this.dgvSVTLH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dgvSVTLH.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSVTLH_CellDoubleClick);
            // 
            // btnTroLai
            // 
            this.btnTroLai.Location = new System.Drawing.Point(56, 31);
            this.btnTroLai.Name = "btnTroLai";
            this.btnTroLai.Size = new System.Drawing.Size(103, 45);
            this.btnTroLai.TabIndex = 9;
            this.btnTroLai.Text = "Quay lại";
            this.btnTroLai.UseVisualStyleBackColor = true;
            this.btnTroLai.Click += new System.EventHandler(this.btnTroLai_Click);
            // 
            // frmDSSVLopHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 570);
            this.Controls.Add(this.btnTroLai);
            this.Controls.Add(this.dgvSVTLH);
            this.Controls.Add(this.btnTimkiem);
            this.Controls.Add(this.txtTukhoa);
            this.Controls.Add(this.label1);
            this.Name = "frmDSSVLopHoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách sinh viên trong lớp";
            this.Load += new System.EventHandler(this.frmDSSVLopHoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSVTLH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.TextBox txtTukhoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSVTLH;
        private System.Windows.Forms.Button btnTroLai;
    }
}