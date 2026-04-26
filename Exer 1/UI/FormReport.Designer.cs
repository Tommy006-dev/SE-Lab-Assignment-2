namespace UI
{
    partial class FormReport
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
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboItem = new System.Windows.Forms.ComboBox();
            this.btnFilterItem = new System.Windows.Forms.Button();
            this.dgvItemAgent = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboAgent = new System.Windows.Forms.ComboBox();
            this.btnFilterAgent = new System.Windows.Forms.Button();
            this.dgvAgentItem = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvBestItem = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudTop = new System.Windows.Forms.NumericUpDown();
            this.btnFilterBest = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemAgent)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgentItem)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBestItem)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTop)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(301, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO & THỐNG KÊ";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvItemAgent);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(579, 334);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Hàng → Đại lý mua";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnFilterItem);
            this.groupBox3.Controls.Add(this.cboItem);
            this.groupBox3.Location = new System.Drawing.Point(15, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(547, 81);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chọn sản phẩm";
            // 
            // cboItem
            // 
            this.cboItem.FormattingEnabled = true;
            this.cboItem.Location = new System.Drawing.Point(15, 21);
            this.cboItem.Name = "cboItem";
            this.cboItem.Size = new System.Drawing.Size(191, 24);
            this.cboItem.TabIndex = 0;
            // 
            // btnFilterItem
            // 
            this.btnFilterItem.Location = new System.Drawing.Point(308, 21);
            this.btnFilterItem.Name = "btnFilterItem";
            this.btnFilterItem.Size = new System.Drawing.Size(89, 38);
            this.btnFilterItem.TabIndex = 1;
            this.btnFilterItem.Text = "Lọc";
            this.btnFilterItem.UseVisualStyleBackColor = true;
            this.btnFilterItem.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvItemAgent
            // 
            this.dgvItemAgent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemAgent.Location = new System.Drawing.Point(15, 102);
            this.dgvItemAgent.Name = "dgvItemAgent";
            this.dgvItemAgent.RowHeadersWidth = 51;
            this.dgvItemAgent.RowTemplate.Height = 24;
            this.dgvItemAgent.Size = new System.Drawing.Size(547, 168);
            this.dgvItemAgent.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvAgentItem);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(579, 334);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Đại lý → Hàng mua";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnFilterAgent);
            this.groupBox2.Controls.Add(this.cboAgent);
            this.groupBox2.Location = new System.Drawing.Point(22, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(535, 75);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chọn đại lý";
            // 
            // cboAgent
            // 
            this.cboAgent.FormattingEnabled = true;
            this.cboAgent.Location = new System.Drawing.Point(6, 21);
            this.cboAgent.Name = "cboAgent";
            this.cboAgent.Size = new System.Drawing.Size(217, 24);
            this.cboAgent.TabIndex = 0;
            // 
            // btnFilterAgent
            // 
            this.btnFilterAgent.Location = new System.Drawing.Point(384, 21);
            this.btnFilterAgent.Name = "btnFilterAgent";
            this.btnFilterAgent.Size = new System.Drawing.Size(90, 36);
            this.btnFilterAgent.TabIndex = 1;
            this.btnFilterAgent.Text = "Lọc";
            this.btnFilterAgent.UseVisualStyleBackColor = true;
            this.btnFilterAgent.Click += new System.EventHandler(this.btnFilterAgent_Click);
            // 
            // dgvAgentItem
            // 
            this.dgvAgentItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAgentItem.Location = new System.Drawing.Point(28, 104);
            this.dgvAgentItem.Name = "dgvAgentItem";
            this.dgvAgentItem.RowHeadersWidth = 51;
            this.dgvAgentItem.RowTemplate.Height = 24;
            this.dgvAgentItem.Size = new System.Drawing.Size(529, 167);
            this.dgvAgentItem.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.dgvBestItem);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(579, 334);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Item bán chạy";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvBestItem
            // 
            this.dgvBestItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBestItem.Location = new System.Drawing.Point(28, 77);
            this.dgvBestItem.Name = "dgvBestItem";
            this.dgvBestItem.RowHeadersWidth = 51;
            this.dgvBestItem.RowTemplate.Height = 24;
            this.dgvBestItem.Size = new System.Drawing.Size(528, 190);
            this.dgvBestItem.TabIndex = 3;
            this.dgvBestItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnFilterBest);
            this.groupBox1.Controls.Add(this.nudTop);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(28, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 62);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bộ lọc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Hiển thị Top";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // nudTop
            // 
            this.nudTop.Location = new System.Drawing.Point(120, 27);
            this.nudTop.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudTop.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTop.Name = "nudTop";
            this.nudTop.Size = new System.Drawing.Size(62, 22);
            this.nudTop.TabIndex = 1;
            this.nudTop.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // btnFilterBest
            // 
            this.btnFilterBest.Location = new System.Drawing.Point(370, 26);
            this.btnFilterBest.Name = "btnFilterBest";
            this.btnFilterBest.Size = new System.Drawing.Size(75, 23);
            this.btnFilterBest.TabIndex = 2;
            this.btnFilterBest.Text = "Lọc";
            this.btnFilterBest.UseVisualStyleBackColor = true;
            this.btnFilterBest.Click += new System.EventHandler(this.btnFilterBest_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "label3";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(108, 43);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(587, 363);
            this.tabControl1.TabIndex = 2;
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Name = "FormReport";
            this.Text = "FormReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormReport_Load);
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemAgent)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgentItem)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBestItem)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTop)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvItemAgent;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnFilterItem;
        private System.Windows.Forms.ComboBox cboItem;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvAgentItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnFilterAgent;
        private System.Windows.Forms.ComboBox cboAgent;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFilterBest;
        private System.Windows.Forms.NumericUpDown nudTop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvBestItem;
        private System.Windows.Forms.TabControl tabControl1;
    }
}