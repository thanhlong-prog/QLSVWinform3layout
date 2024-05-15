namespace QLSV_3layers
{
    partial class frmDiemSV
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenmonhoc = new System.Windows.Forms.TextBox();
            this.txtSinhVien = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDiemlan1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiemLan2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDiemLan3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên môn học";
            // 
            // txtTenmonhoc
            // 
            this.txtTenmonhoc.Location = new System.Drawing.Point(181, 82);
            this.txtTenmonhoc.Name = "txtTenmonhoc";
            this.txtTenmonhoc.ReadOnly = true;
            this.txtTenmonhoc.Size = new System.Drawing.Size(287, 26);
            this.txtTenmonhoc.TabIndex = 1;
            // 
            // txtSinhVien
            // 
            this.txtSinhVien.Location = new System.Drawing.Point(181, 149);
            this.txtSinhVien.Name = "txtSinhVien";
            this.txtSinhVien.ReadOnly = true;
            this.txtSinhVien.Size = new System.Drawing.Size(287, 26);
            this.txtSinhVien.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sinh viên";
            // 
            // txtDiemlan1
            // 
            this.txtDiemlan1.Location = new System.Drawing.Point(181, 217);
            this.txtDiemlan1.Name = "txtDiemlan1";
            this.txtDiemlan1.Size = new System.Drawing.Size(287, 26);
            this.txtDiemlan1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Điểm lần 1";
            // 
            // txtDiemLan2
            // 
            this.txtDiemLan2.Location = new System.Drawing.Point(181, 274);
            this.txtDiemLan2.Name = "txtDiemLan2";
            this.txtDiemLan2.Size = new System.Drawing.Size(287, 26);
            this.txtDiemLan2.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Điểm lần 2";
            // 
            // txtDiemLan3
            // 
            this.txtDiemLan3.Location = new System.Drawing.Point(181, 344);
            this.txtDiemLan3.Name = "txtDiemLan3";
            this.txtDiemLan3.Size = new System.Drawing.Size(287, 26);
            this.txtDiemLan3.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 347);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Điểm lần 3";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(156, 435);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(85, 46);
            this.btnLuu.TabIndex = 10;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(340, 435);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(85, 46);
            this.btnHuy.TabIndex = 11;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // frmDiemSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 543);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.txtDiemLan3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDiemLan2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDiemlan1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSinhVien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTenmonhoc);
            this.Controls.Add(this.label1);
            this.Name = "frmDiemSV";
            this.Text = "frmDiemSV";
            this.Load += new System.EventHandler(this.frmDiemSV_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenmonhoc;
        private System.Windows.Forms.TextBox txtSinhVien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDiemlan1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiemLan2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDiemLan3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
    }
}