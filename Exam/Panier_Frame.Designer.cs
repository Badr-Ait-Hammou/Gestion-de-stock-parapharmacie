namespace Exam
{
    partial class Panier_Frame
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Panier_Frame));
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.svglabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tablepanier = new Guna.UI2.WinForms.Guna2DataGridView();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printbtn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GradientButton9 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.submitorderbtn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2CustomGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablepanier)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.Controls.Add(this.printbtn);
            this.guna2CustomGradientPanel1.Controls.Add(this.guna2GradientButton9);
            this.guna2CustomGradientPanel1.Controls.Add(this.guna2HtmlLabel2);
            this.guna2CustomGradientPanel1.Controls.Add(this.submitorderbtn);
            this.guna2CustomGradientPanel1.Controls.Add(this.guna2HtmlLabel1);
            this.guna2CustomGradientPanel1.Controls.Add(this.svglabel);
            this.guna2CustomGradientPanel1.Controls.Add(this.tablepanier);
            this.guna2CustomGradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(1, -4);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(678, 495);
            this.guna2CustomGradientPanel1.TabIndex = 1;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.8209F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.Red;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(597, 334);
            this.guna2HtmlLabel2.MinimumSize = new System.Drawing.Size(50, 0);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(50, 28);
            this.guna2HtmlLabel2.TabIndex = 30;
            this.guna2HtmlLabel2.Text = "DH";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Enabled = false;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.8209F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(275, 334);
            this.guna2HtmlLabel1.MinimumSize = new System.Drawing.Size(140, 0);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(140, 28);
            this.guna2HtmlLabel1.TabIndex = 28;
            this.guna2HtmlLabel1.Text = "Prix Total :";
            // 
            // svglabel
            // 
            this.svglabel.BackColor = System.Drawing.Color.Transparent;
            this.svglabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.8209F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.svglabel.ForeColor = System.Drawing.Color.Red;
            this.svglabel.Location = new System.Drawing.Point(437, 334);
            this.svglabel.MinimumSize = new System.Drawing.Size(120, 0);
            this.svglabel.Name = "svglabel";
            this.svglabel.Size = new System.Drawing.Size(120, 2);
            this.svglabel.TabIndex = 27;
            this.svglabel.Text = null;
            // 
            // tablepanier
            // 
            this.tablepanier.AllowUserToAddRows = false;
            this.tablepanier.AllowUserToDeleteRows = false;
            this.tablepanier.AllowUserToResizeColumns = false;
            this.tablepanier.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.74627F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.tablepanier.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tablepanier.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.MediumAquamarine;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Uighur", 16.1194F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.MediumAquamarine;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablepanier.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.tablepanier.ColumnHeadersHeight = 35;
            this.tablepanier.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.74627F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tablepanier.DefaultCellStyle = dataGridViewCellStyle3;
            this.tablepanier.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.tablepanier.Location = new System.Drawing.Point(11, 51);
            this.tablepanier.Name = "tablepanier";
            this.tablepanier.ReadOnly = true;
            this.tablepanier.RowHeadersVisible = false;
            this.tablepanier.RowHeadersWidth = 57;
            this.tablepanier.RowTemplate.Height = 60;
            this.tablepanier.Size = new System.Drawing.Size(652, 277);
            this.tablepanier.TabIndex = 26;
            this.tablepanier.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.tablepanier.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.tablepanier.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.tablepanier.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.tablepanier.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.tablepanier.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.tablepanier.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.tablepanier.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(255)))));
            this.tablepanier.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.tablepanier.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Uighur", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tablepanier.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.tablepanier.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tablepanier.ThemeStyle.HeaderStyle.Height = 35;
            this.tablepanier.ThemeStyle.ReadOnly = true;
            this.tablepanier.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.tablepanier.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.tablepanier.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.74627F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tablepanier.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.tablepanier.ThemeStyle.RowsStyle.Height = 60;
            this.tablepanier.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.tablepanier.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.tablepanier.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablepanier_CellContentClick);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printbtn
            // 
            this.printbtn.BackColor = System.Drawing.Color.Transparent;
            this.printbtn.BorderRadius = 10;
            this.printbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.printbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.printbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.printbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.printbtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.printbtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.printbtn.ForeColor = System.Drawing.Color.White;
            this.printbtn.Image = global::Exam.Properties.Resources.invoice;
            this.printbtn.ImageSize = new System.Drawing.Size(45, 45);
            this.printbtn.Location = new System.Drawing.Point(11, 417);
            this.printbtn.Name = "printbtn";
            this.printbtn.Size = new System.Drawing.Size(132, 56);
            this.printbtn.TabIndex = 32;
            this.printbtn.Click += new System.EventHandler(this.printbtn_Click);
            // 
            // guna2GradientButton9
            // 
            this.guna2GradientButton9.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton9.BorderRadius = 10;
            this.guna2GradientButton9.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton9.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton9.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton9.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton9.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton9.FillColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton9.FillColor2 = System.Drawing.Color.Transparent;
            this.guna2GradientButton9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GradientButton9.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton9.Image = global::Exam.Properties.Resources.close;
            this.guna2GradientButton9.ImageSize = new System.Drawing.Size(42, 42);
            this.guna2GradientButton9.Location = new System.Drawing.Point(625, 3);
            this.guna2GradientButton9.Name = "guna2GradientButton9";
            this.guna2GradientButton9.Size = new System.Drawing.Size(50, 42);
            this.guna2GradientButton9.TabIndex = 31;
            this.guna2GradientButton9.Click += new System.EventHandler(this.guna2GradientButton9_Click);
            // 
            // submitorderbtn
            // 
            this.submitorderbtn.BackColor = System.Drawing.Color.Transparent;
            this.submitorderbtn.BorderRadius = 10;
            this.submitorderbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.submitorderbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.submitorderbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.submitorderbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.submitorderbtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.submitorderbtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.submitorderbtn.ForeColor = System.Drawing.Color.White;
            this.submitorderbtn.Image = global::Exam.Properties.Resources.shopping_bag__1_;
            this.submitorderbtn.ImageSize = new System.Drawing.Size(50, 50);
            this.submitorderbtn.Location = new System.Drawing.Point(516, 417);
            this.submitorderbtn.Name = "submitorderbtn";
            this.submitorderbtn.Size = new System.Drawing.Size(147, 56);
            this.submitorderbtn.TabIndex = 29;
            this.submitorderbtn.Click += new System.EventHandler(this.submitorderbtn_Click);
            // 
            // Panier_Frame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 492);
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Panier_Frame";
            this.Text = "Panier";
            this.Load += new System.EventHandler(this.panier_load);
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.guna2CustomGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablepanier)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2DataGridView tablepanier;
        private Guna.UI2.WinForms.Guna2HtmlLabel svglabel;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button submitorderbtn;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton9;
        private Guna.UI2.WinForms.Guna2Button printbtn;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}