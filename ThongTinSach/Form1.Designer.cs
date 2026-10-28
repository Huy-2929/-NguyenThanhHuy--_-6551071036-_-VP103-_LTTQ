namespace ThongTinSach
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnThoat = new Button();
            label1 = new Label();
            txtMaSach = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtTenTheLoai = new TextBox();
            txtGiaSach = new TextBox();
            dgvThongTinSach = new DataGridView();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvThongTinSach).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnThem
            // 
            btnThem.Location = new Point(301, 27);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(416, 27);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 1;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(526, 27);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(647, 27);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 29);
            btnThoat.TabIndex = 3;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 34);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 4;
            label1.Text = "Mã sách";
            // 
            // txtMaSach
            // 
            txtMaSach.Location = new Point(16, 57);
            txtMaSach.Name = "txtMaSach";
            txtMaSach.Size = new Size(125, 27);
            txtMaSach.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 124);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 6;
            label2.Text = "Tên Sách";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 213);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 7;
            label3.Text = "Giá sách";
            // 
            // txtTenTheLoai
            // 
            txtTenTheLoai.Location = new Point(16, 147);
            txtTenTheLoai.Name = "txtTenTheLoai";
            txtTenTheLoai.Size = new Size(125, 27);
            txtTenTheLoai.TabIndex = 8;
            // 
            // txtGiaSach
            // 
            txtGiaSach.Location = new Point(16, 236);
            txtGiaSach.Name = "txtGiaSach";
            txtGiaSach.Size = new Size(125, 27);
            txtGiaSach.TabIndex = 9;
            // 
            // dgvThongTinSach
            // 
            dgvThongTinSach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvThongTinSach.Location = new Point(19, 38);
            dgvThongTinSach.MultiSelect = false;
            dgvThongTinSach.Name = "dgvThongTinSach";
            dgvThongTinSach.RowHeadersWidth = 51;
            dgvThongTinSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvThongTinSach.Size = new Size(496, 306);
            dgvThongTinSach.TabIndex = 10;
            dgvThongTinSach.SelectionChanged += dgvThongTinSach_SelectionChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvThongTinSach);
            groupBox1.Location = new Point(228, 76);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(537, 362);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách sách";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtGiaSach);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(txtMaSach);
            groupBox2.Controls.Add(txtTenTheLoai);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(27, 27);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(178, 303);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin sách";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 452);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnThoat);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvThongTinSach).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThoat;
        private Label label1;
        private TextBox txtMaSach;
        private Label label2;
        private Label label3;
        private TextBox txtTenTheLoai;
        private TextBox txtGiaSach;
        private DataGridView dgvThongTinSach;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}
