namespace ArduinoToBluetooth
{
	partial class FormData
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
			this.components = new System.ComponentModel.Container();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.table = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panelSend1 = new System.Windows.Forms.Panel();
			this.txtSend1 = new System.Windows.Forms.TextBox();
			this.btnSend1 = new System.Windows.Forms.Button();
			this.lblStats1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panelSend2 = new System.Windows.Forms.Panel();
			this.txtSend2 = new System.Windows.Forms.TextBox();
			this.btnSend2 = new System.Windows.Forms.Button();
			this.lblStats2 = new System.Windows.Forms.Label();
			this.chkClear1 = new System.Windows.Forms.CheckBox();
			this.chkClear2 = new System.Windows.Forms.CheckBox();
			this.panelLineBreak1 = new System.Windows.Forms.Panel();
			this.lblLineBreak1 = new System.Windows.Forms.Label();
			this.cbLineBreak1 = new System.Windows.Forms.ComboBox();
			this.panelLineBreak2 = new System.Windows.Forms.Panel();
			this.cbLineBreak2 = new System.Windows.Forms.ComboBox();
			this.lblLineBreak2 = new System.Windows.Forms.Label();
			this.table.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panelSend1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panelSend2.SuspendLayout();
			this.panelLineBreak1.SuspendLayout();
			this.panelLineBreak2.SuspendLayout();
			this.SuspendLayout();
			// 
			// timer
			// 
			this.timer.Interval = 1000;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// table
			// 
			this.table.ColumnCount = 2;
			this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.table.Controls.Add(this.groupBox1, 0, 0);
			this.table.Controls.Add(this.groupBox2, 1, 0);
			this.table.Dock = System.Windows.Forms.DockStyle.Fill;
			this.table.Location = new System.Drawing.Point(0, 0);
			this.table.Name = "table";
			this.table.RowCount = 1;
			this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.table.Size = new System.Drawing.Size(454, 161);
			this.table.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel1);
			this.groupBox1.Controls.Add(this.lblStats1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(221, 155);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.chkClear1);
			this.panel1.Controls.Add(this.panelLineBreak1);
			this.panel1.Controls.Add(this.panelSend1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 21);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(215, 86);
			this.panel1.TabIndex = 1;
			// 
			// panelSend1
			// 
			this.panelSend1.Controls.Add(this.txtSend1);
			this.panelSend1.Controls.Add(this.btnSend1);
			this.panelSend1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelSend1.Location = new System.Drawing.Point(0, 0);
			this.panelSend1.Name = "panelSend1";
			this.panelSend1.Size = new System.Drawing.Size(215, 25);
			this.panelSend1.TabIndex = 0;
			// 
			// txtSend1
			// 
			this.txtSend1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtSend1.Location = new System.Drawing.Point(0, 0);
			this.txtSend1.Name = "txtSend1";
			this.txtSend1.Size = new System.Drawing.Size(140, 25);
			this.txtSend1.TabIndex = 0;
			this.txtSend1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSend1_KeyDown);
			// 
			// btnSend1
			// 
			this.btnSend1.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSend1.Location = new System.Drawing.Point(140, 0);
			this.btnSend1.Name = "btnSend1";
			this.btnSend1.Size = new System.Drawing.Size(75, 25);
			this.btnSend1.TabIndex = 1;
			this.btnSend1.Text = "Enviar";
			this.btnSend1.UseVisualStyleBackColor = true;
			this.btnSend1.Click += new System.EventHandler(this.btnSend1_Click);
			// 
			// lblStats1
			// 
			this.lblStats1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lblStats1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblStats1.Location = new System.Drawing.Point(3, 107);
			this.lblStats1.Name = "lblStats1";
			this.lblStats1.Size = new System.Drawing.Size(215, 45);
			this.lblStats1.TabIndex = 0;
			this.lblStats1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.panel2);
			this.groupBox2.Controls.Add(this.lblStats2);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(230, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(221, 155);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.chkClear2);
			this.panel2.Controls.Add(this.panelLineBreak2);
			this.panel2.Controls.Add(this.panelSend2);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(3, 21);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(215, 86);
			this.panel2.TabIndex = 2;
			// 
			// panelSend2
			// 
			this.panelSend2.Controls.Add(this.txtSend2);
			this.panelSend2.Controls.Add(this.btnSend2);
			this.panelSend2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelSend2.Location = new System.Drawing.Point(0, 0);
			this.panelSend2.Name = "panelSend2";
			this.panelSend2.Size = new System.Drawing.Size(215, 25);
			this.panelSend2.TabIndex = 0;
			// 
			// txtSend2
			// 
			this.txtSend2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtSend2.Location = new System.Drawing.Point(0, 0);
			this.txtSend2.Name = "txtSend2";
			this.txtSend2.Size = new System.Drawing.Size(140, 25);
			this.txtSend2.TabIndex = 0;
			this.txtSend2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSend2_KeyDown);
			// 
			// btnSend2
			// 
			this.btnSend2.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSend2.Location = new System.Drawing.Point(140, 0);
			this.btnSend2.Name = "btnSend2";
			this.btnSend2.Size = new System.Drawing.Size(75, 25);
			this.btnSend2.TabIndex = 1;
			this.btnSend2.Text = "Enviar";
			this.btnSend2.UseVisualStyleBackColor = true;
			this.btnSend2.Click += new System.EventHandler(this.btnSend2_Click);
			// 
			// lblStats2
			// 
			this.lblStats2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lblStats2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblStats2.Location = new System.Drawing.Point(3, 107);
			this.lblStats2.Name = "lblStats2";
			this.lblStats2.Size = new System.Drawing.Size(215, 45);
			this.lblStats2.TabIndex = 1;
			this.lblStats2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// chkClear1
			// 
			this.chkClear1.AutoSize = true;
			this.chkClear1.Dock = System.Windows.Forms.DockStyle.Top;
			this.chkClear1.Location = new System.Drawing.Point(0, 58);
			this.chkClear1.Name = "chkClear1";
			this.chkClear1.Size = new System.Drawing.Size(215, 21);
			this.chkClear1.TabIndex = 2;
			this.chkClear1.Text = "Apagar ao enviar";
			this.chkClear1.UseVisualStyleBackColor = true;
			// 
			// chkClear2
			// 
			this.chkClear2.AutoSize = true;
			this.chkClear2.Dock = System.Windows.Forms.DockStyle.Top;
			this.chkClear2.Location = new System.Drawing.Point(0, 58);
			this.chkClear2.Name = "chkClear2";
			this.chkClear2.Size = new System.Drawing.Size(215, 21);
			this.chkClear2.TabIndex = 2;
			this.chkClear2.Text = "Apagar ao enviar";
			this.chkClear2.UseVisualStyleBackColor = true;
			// 
			// panelLineBreak1
			// 
			this.panelLineBreak1.Controls.Add(this.cbLineBreak1);
			this.panelLineBreak1.Controls.Add(this.lblLineBreak1);
			this.panelLineBreak1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelLineBreak1.Location = new System.Drawing.Point(0, 25);
			this.panelLineBreak1.Name = "panelLineBreak1";
			this.panelLineBreak1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
			this.panelLineBreak1.Size = new System.Drawing.Size(215, 33);
			this.panelLineBreak1.TabIndex = 1;
			// 
			// lblLineBreak1
			// 
			this.lblLineBreak1.Dock = System.Windows.Forms.DockStyle.Left;
			this.lblLineBreak1.Location = new System.Drawing.Point(0, 4);
			this.lblLineBreak1.Name = "lblLineBreak1";
			this.lblLineBreak1.Size = new System.Drawing.Size(108, 25);
			this.lblLineBreak1.TabIndex = 0;
			this.lblLineBreak1.Text = "Quebra de linha";
			this.lblLineBreak1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbLineBreak1
			// 
			this.cbLineBreak1.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbLineBreak1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbLineBreak1.FormattingEnabled = true;
			this.cbLineBreak1.Items.AddRange(new object[] {
            "-",
            "LF - \\n",
            "CR - \\r",
            "CRLF - \\r\\n"});
			this.cbLineBreak1.Location = new System.Drawing.Point(108, 4);
			this.cbLineBreak1.Name = "cbLineBreak1";
			this.cbLineBreak1.Size = new System.Drawing.Size(106, 25);
			this.cbLineBreak1.TabIndex = 1;
			// 
			// panelLineBreak2
			// 
			this.panelLineBreak2.Controls.Add(this.cbLineBreak2);
			this.panelLineBreak2.Controls.Add(this.lblLineBreak2);
			this.panelLineBreak2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelLineBreak2.Location = new System.Drawing.Point(0, 25);
			this.panelLineBreak2.Name = "panelLineBreak2";
			this.panelLineBreak2.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
			this.panelLineBreak2.Size = new System.Drawing.Size(215, 33);
			this.panelLineBreak2.TabIndex = 1;
			// 
			// cbLineBreak2
			// 
			this.cbLineBreak2.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbLineBreak2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbLineBreak2.FormattingEnabled = true;
			this.cbLineBreak2.Items.AddRange(new object[] {
            "-",
            "LF - \\n",
            "CR - \\r",
            "CRLF - \\r\\n"});
			this.cbLineBreak2.Location = new System.Drawing.Point(108, 4);
			this.cbLineBreak2.Name = "cbLineBreak2";
			this.cbLineBreak2.Size = new System.Drawing.Size(106, 25);
			this.cbLineBreak2.TabIndex = 1;
			// 
			// lblLineBreak2
			// 
			this.lblLineBreak2.Dock = System.Windows.Forms.DockStyle.Left;
			this.lblLineBreak2.Location = new System.Drawing.Point(0, 4);
			this.lblLineBreak2.Name = "lblLineBreak2";
			this.lblLineBreak2.Size = new System.Drawing.Size(108, 25);
			this.lblLineBreak2.TabIndex = 0;
			this.lblLineBreak2.Text = "Quebra de linha";
			this.lblLineBreak2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FormData
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(454, 161);
			this.Controls.Add(this.table);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(32767, 200);
			this.MinimumSize = new System.Drawing.Size(470, 200);
			this.Name = "FormData";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Arduino To Bluetooth";
			this.table.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panelSend1.ResumeLayout(false);
			this.panelSend1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panelSend2.ResumeLayout(false);
			this.panelSend2.PerformLayout();
			this.panelLineBreak1.ResumeLayout(false);
			this.panelLineBreak2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.TableLayoutPanel table;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lblStats1;
		private System.Windows.Forms.Label lblStats2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panelSend1;
		private System.Windows.Forms.Button btnSend1;
		private System.Windows.Forms.TextBox txtSend1;
		private System.Windows.Forms.Panel panelSend2;
		private System.Windows.Forms.TextBox txtSend2;
		private System.Windows.Forms.Button btnSend2;
		private System.Windows.Forms.CheckBox chkClear1;
		private System.Windows.Forms.CheckBox chkClear2;
		private System.Windows.Forms.Panel panelLineBreak1;
		private System.Windows.Forms.ComboBox cbLineBreak1;
		private System.Windows.Forms.Label lblLineBreak1;
		private System.Windows.Forms.Panel panelLineBreak2;
		private System.Windows.Forms.ComboBox cbLineBreak2;
		private System.Windows.Forms.Label lblLineBreak2;

	}
}