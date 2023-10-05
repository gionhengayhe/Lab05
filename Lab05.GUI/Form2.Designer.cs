
namespace Lab05.GUI
{
    partial class Form2
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
            this.dgvStudent = new System.Windows.Forms.DataGridView();
            this.clmMSSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHoten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmKhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRegister = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbKhoa = new System.Windows.Forms.ComboBox();
            this.cmbChuyennganh = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txttongsvchuadk = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStudent
            // 
            this.dgvStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmMSSV,
            this.clmHoten,
            this.clmKhoa,
            this.DTB});
            this.dgvStudent.Location = new System.Drawing.Point(16, 148);
            this.dgvStudent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvStudent.Name = "dgvStudent";
            this.dgvStudent.RowHeadersWidth = 51;
            this.dgvStudent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudent.Size = new System.Drawing.Size(992, 391);
            this.dgvStudent.TabIndex = 0;
            this.dgvStudent.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudent_CellClick);
            // 
            // clmMSSV
            // 
            this.clmMSSV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmMSSV.FillWeight = 36.16751F;
            this.clmMSSV.HeaderText = "MSSV";
            this.clmMSSV.MinimumWidth = 6;
            this.clmMSSV.Name = "clmMSSV";
            // 
            // clmHoten
            // 
            this.clmHoten.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmHoten.FillWeight = 36.16751F;
            this.clmHoten.HeaderText = "Họ tên";
            this.clmHoten.MinimumWidth = 6;
            this.clmHoten.Name = "clmHoten";
            // 
            // clmKhoa
            // 
            this.clmKhoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmKhoa.FillWeight = 36.16751F;
            this.clmKhoa.HeaderText = "Khoa";
            this.clmKhoa.MinimumWidth = 6;
            this.clmKhoa.Name = "clmKhoa";
            // 
            // DTB
            // 
            this.DTB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DTB.FillWeight = 36.16751F;
            this.DTB.HeaderText = "Điểm TB";
            this.DTB.MinimumWidth = 6;
            this.DTB.Name = "DTB";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(65, 546);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(100, 27);
            this.btnRegister.TabIndex = 1;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1027, 43);
            this.label1.TabIndex = 2;
            this.label1.Text = "Đăng ký chuyên ngành";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Khoa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(184, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Chuyên ngành";
            // 
            // cmbKhoa
            // 
            this.cmbKhoa.FormattingEnabled = true;
            this.cmbKhoa.Location = new System.Drawing.Point(312, 60);
            this.cmbKhoa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbKhoa.Name = "cmbKhoa";
            this.cmbKhoa.Size = new System.Drawing.Size(387, 24);
            this.cmbKhoa.TabIndex = 4;
            this.cmbKhoa.SelectedIndexChanged += new System.EventHandler(this.cmbChuyennganh_SelectedIndexChanged);
            // 
            // cmbChuyennganh
            // 
            this.cmbChuyennganh.FormattingEnabled = true;
            this.cmbChuyennganh.Location = new System.Drawing.Point(312, 106);
            this.cmbChuyennganh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbChuyennganh.Name = "cmbChuyennganh";
            this.cmbChuyennganh.Size = new System.Drawing.Size(387, 24);
            this.cmbChuyennganh.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(821, 551);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Số SV chưa đăng ký:";
            // 
            // txttongsvchuadk
            // 
            this.txttongsvchuadk.Enabled = false;
            this.txttongsvchuadk.Location = new System.Drawing.Point(958, 548);
            this.txttongsvchuadk.Name = "txttongsvchuadk";
            this.txttongsvchuadk.Size = new System.Drawing.Size(50, 22);
            this.txttongsvchuadk.TabIndex = 6;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 581);
            this.Controls.Add(this.txttongsvchuadk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbChuyennganh);
            this.Controls.Add(this.cmbKhoa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.dgvStudent);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form2";
            this.Text = "Đăng ký chuyên ngành";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStudent;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbKhoa;
        private System.Windows.Forms.ComboBox cmbChuyennganh;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMSSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHoten;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmKhoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txttongsvchuadk;
    }
}