namespace ArduinoToBluetooth
{
	partial class FormMain
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
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuStart = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuStop = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSep = new System.Windows.Forms.ToolStripSeparator();
			this.lblCOM1 = new System.Windows.Forms.ToolStripMenuItem();
			this.txtCOM1 = new System.Windows.Forms.ToolStripTextBox();
			this.lblBaud1 = new System.Windows.Forms.ToolStripMenuItem();
			this.txtBaud1 = new System.Windows.Forms.ToolStripTextBox();
			this.mnuSep2 = new System.Windows.Forms.ToolStripSeparator();
			this.lblCOM2 = new System.Windows.Forms.ToolStripMenuItem();
			this.txtCOM2 = new System.Windows.Forms.ToolStripTextBox();
			this.lblBaud2 = new System.Windows.Forms.ToolStripMenuItem();
			this.txtBaud2 = new System.Windows.Forms.ToolStripTextBox();
			this.mnuSep3 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// notifyIcon
			// 
			this.notifyIcon.Visible = true;
			this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
			// 
			// contextMenuStrip
			// 
			this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStart,
            this.mnuStop,
            this.mnuSep,
            this.lblCOM1,
            this.txtCOM1,
            this.lblBaud1,
            this.txtBaud1,
            this.mnuSep2,
            this.lblCOM2,
            this.txtCOM2,
            this.lblBaud2,
            this.txtBaud2,
            this.mnuSep3,
            this.mnuExit});
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Size = new System.Drawing.Size(161, 276);
			this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
			// 
			// mnuStart
			// 
			this.mnuStart.Image = global::ArduinoToBluetooth.Properties.Resources.play16png;
			this.mnuStart.Name = "mnuStart";
			this.mnuStart.Size = new System.Drawing.Size(160, 22);
			this.mnuStart.Click += new System.EventHandler(this.mnuStart_Click);
			// 
			// mnuStop
			// 
			this.mnuStop.Image = global::ArduinoToBluetooth.Properties.Resources.pause16png;
			this.mnuStop.Name = "mnuStop";
			this.mnuStop.Size = new System.Drawing.Size(160, 22);
			this.mnuStop.Click += new System.EventHandler(this.mnuStop_Click);
			// 
			// mnuSep
			// 
			this.mnuSep.Name = "mnuSep";
			this.mnuSep.Size = new System.Drawing.Size(157, 6);
			// 
			// lblCOM1
			// 
			this.lblCOM1.Enabled = false;
			this.lblCOM1.Name = "lblCOM1";
			this.lblCOM1.Size = new System.Drawing.Size(160, 22);
			// 
			// txtCOM1
			// 
			this.txtCOM1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtCOM1.Name = "txtCOM1";
			this.txtCOM1.Size = new System.Drawing.Size(100, 23);
			// 
			// lblBaud1
			// 
			this.lblBaud1.Enabled = false;
			this.lblBaud1.Name = "lblBaud1";
			this.lblBaud1.Size = new System.Drawing.Size(160, 22);
			// 
			// txtBaud1
			// 
			this.txtBaud1.Name = "txtBaud1";
			this.txtBaud1.Size = new System.Drawing.Size(100, 23);
			// 
			// mnuSep2
			// 
			this.mnuSep2.Name = "mnuSep2";
			this.mnuSep2.Size = new System.Drawing.Size(157, 6);
			// 
			// lblCOM2
			// 
			this.lblCOM2.Enabled = false;
			this.lblCOM2.Name = "lblCOM2";
			this.lblCOM2.Size = new System.Drawing.Size(160, 22);
			// 
			// txtCOM2
			// 
			this.txtCOM2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtCOM2.Name = "txtCOM2";
			this.txtCOM2.Size = new System.Drawing.Size(100, 23);
			// 
			// lblBaud2
			// 
			this.lblBaud2.Enabled = false;
			this.lblBaud2.Name = "lblBaud2";
			this.lblBaud2.Size = new System.Drawing.Size(160, 22);
			// 
			// txtBaud2
			// 
			this.txtBaud2.Name = "txtBaud2";
			this.txtBaud2.Size = new System.Drawing.Size(100, 23);
			// 
			// mnuSep3
			// 
			this.mnuSep3.Name = "mnuSep3";
			this.mnuSep3.Size = new System.Drawing.Size(157, 6);
			// 
			// mnuExit
			// 
			this.mnuExit.Name = "mnuExit";
			this.mnuExit.Size = new System.Drawing.Size(160, 22);
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Name = "FormMain";
			this.Text = "ArduinoToBluetooth";
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
			this.contextMenuStrip.ResumeLayout(false);
			this.contextMenuStrip.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem mnuStart;
		private System.Windows.Forms.ToolStripMenuItem mnuStop;
		private System.Windows.Forms.ToolStripSeparator mnuSep;
		private System.Windows.Forms.ToolStripMenuItem lblCOM1;
		private System.Windows.Forms.ToolStripSeparator mnuSep2;
		private System.Windows.Forms.ToolStripMenuItem lblCOM2;
		private System.Windows.Forms.ToolStripSeparator mnuSep3;
		private System.Windows.Forms.ToolStripMenuItem mnuExit;
		private System.Windows.Forms.ToolStripTextBox txtCOM1;
		private System.Windows.Forms.ToolStripTextBox txtCOM2;
		private System.Windows.Forms.ToolStripMenuItem lblBaud1;
		private System.Windows.Forms.ToolStripTextBox txtBaud1;
		private System.Windows.Forms.ToolStripMenuItem lblBaud2;
		private System.Windows.Forms.ToolStripTextBox txtBaud2;
	}
}

