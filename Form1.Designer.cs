
namespace kampyeri
{
    partial class FormKampY
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
            this.dataGView = new System.Windows.Forms.DataGridView();
            this.btnGetData = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.indata1 = new System.Windows.Forms.TextBox();
            this.indata2 = new System.Windows.Forms.TextBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.BtnConnect = new System.Windows.Forms.Button();
            this.lblConnection = new System.Windows.Forms.Label();
            this.cmbxTable = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGView
            // 
            this.dataGView.AllowUserToAddRows = false;
            this.dataGView.AllowUserToDeleteRows = false;
            this.dataGView.AllowUserToResizeRows = false;
            this.dataGView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGView.Location = new System.Drawing.Point(423, 65);
            this.dataGView.Name = "dataGView";
            this.dataGView.ReadOnly = true;
            this.dataGView.Size = new System.Drawing.Size(279, 178);
            this.dataGView.TabIndex = 0;
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(423, 278);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(279, 44);
            this.btnGetData.TabIndex = 1;
            this.btnGetData.Text = "Data al";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(238, 144);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "baglanti kapa";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button2_Click);
            // 
            // indata1
            // 
            this.indata1.Location = new System.Drawing.Point(80, 114);
            this.indata1.Name = "indata1";
            this.indata1.Size = new System.Drawing.Size(100, 23);
            this.indata1.TabIndex = 3;
            // 
            // indata2
            // 
            this.indata2.Location = new System.Drawing.Point(80, 144);
            this.indata2.Name = "indata2";
            this.indata2.Size = new System.Drawing.Size(100, 23);
            this.indata2.TabIndex = 4;
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(80, 174);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(100, 23);
            this.btnInsert.TabIndex = 5;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(80, 228);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(52, 15);
            this.lblError.TabIndex = 6;
            this.lblError.Text = "LABEEEL";
            // 
            // BtnConnect
            // 
            this.BtnConnect.Location = new System.Drawing.Point(238, 114);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(88, 23);
            this.BtnConnect.TabIndex = 7;
            this.BtnConnect.Text = "Baglan";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // lblConnection
            // 
            this.lblConnection.Location = new System.Drawing.Point(12, 9);
            this.lblConnection.MinimumSize = new System.Drawing.Size(100, 50);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(100, 50);
            this.lblConnection.TabIndex = 8;
            this.lblConnection.Text = "label1";
            // 
            // cmbxTable
            // 
            this.cmbxTable.FormattingEnabled = true;
            this.cmbxTable.Location = new System.Drawing.Point(423, 249);
            this.cmbxTable.Name = "cmbxTable";
            this.cmbxTable.Size = new System.Drawing.Size(279, 23);
            this.cmbxTable.TabIndex = 9;
            // 
            // FormKampY
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbxTable);
            this.Controls.Add(this.lblConnection);
            this.Controls.Add(this.BtnConnect);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.indata2);
            this.Controls.Add(this.indata1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.dataGView);
            this.Name = "FormKampY";
            this.Text = "Kamp Yeri";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGView;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox indata1;
        private System.Windows.Forms.TextBox indata2;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.ComboBox cmbxTable;
    }
}

