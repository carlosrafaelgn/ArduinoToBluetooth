//
// ArduinoToBluetooth is distributed under the FreeBSD License
//
// Copyright (c) 2015, Carlos Rafael Gimenes das Neves
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
//
// 1. Redistributions of source code must retain the above copyright notice, this
//    list of conditions and the following disclaimer.
// 2. Redistributions in binary form must reproduce the above copyright notice,
//    this list of conditions and the following disclaimer in the documentation
//    and/or other materials provided with the distribution.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
// ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
// (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
// The views and conclusions contained in the software and documentation are those
// of the authors and should not be interpreted as representing official policies,
// either expressed or implied, of the FreeBSD Project.
//
// https://github.com/BandTec/ArduinoToBluetooth
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ArduinoToBluetooth
{
	public partial class FormData : Form
	{
		public event Action<byte[]> Data1SendRequested, Data2SendRequested;

		private bool data1Pending, data2Pending;
		private StringBuilder timerSB;
		private FormMain parent;

		public FormData(FormMain parent)
		{
			InitializeComponent();
			Icon = global::ArduinoToBluetooth.Properties.Resources.main;
			timerSB = new StringBuilder(128);
			this.parent = parent;
			btnSend1.Text = Program.str("send");
			btnSend2.Text = Program.str("send");
			lblLineBreak1.Text = Program.str("lineBreak");
			lblLineBreak2.Text = Program.str("lineBreak");
			chkClear1.Text = Program.str("clearAfterSending");
			chkClear2.Text = Program.str("clearAfterSending");
			groupBox1.Text = "Arduino (" + parent.COM1 + ")";
			groupBox2.Text = "Bluetooth (" + parent.COM2 + ")";
			chkClear1.Checked = (FormMain.ReadSetting("clear1", "0") == "1");
			chkClear2.Checked = (FormMain.ReadSetting("clear2", "0") == "1");
			int i;
			int.TryParse(FormMain.ReadSetting("lineBreak1", "0"), out i);
			cbLineBreak1.SelectedIndex = ((i < 0 || i > 3) ? 0 : i);
			int.TryParse(FormMain.ReadSetting("lineBreak2", "0"), out i);
			cbLineBreak2.SelectedIndex = ((i < 0 || i > 3) ? 0 : i);
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			timer_Tick(timer, e);
			timer.Start();
		}

		protected override void OnFormClosed(FormClosedEventArgs e)
		{
			base.OnFormClosed(e);
			timer.Stop();
			FormMain.SaveSetting("clear1", chkClear1.Checked ? "1" : "0");
			FormMain.SaveSetting("clear2", chkClear2.Checked ? "1" : "0");
			FormMain.SaveSetting("lineBreak1", cbLineBreak1.SelectedIndex.ToString());
			FormMain.SaveSetting("lineBreak2", cbLineBreak2.SelectedIndex.ToString());
		}

		public void Data1Sent()
		{
			data1Pending = false;
			txtSend1.ReadOnly = false;
			if (chkClear1.Checked)
				txtSend1.Text = "";
		}

		public void Data2Sent()
		{
			data2Pending = false;
			txtSend2.ReadOnly = false;
			if (chkClear2.Checked)
				txtSend2.Text = "";
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			timerSB.Remove(0, timerSB.Length);
			timerSB.Append(Program.str("receivedBytes"));
			timerSB.Append(parent.Count1);
			lblStats1.Text = timerSB.ToString();
			timerSB.Remove(0, timerSB.Length);
			timerSB.Append(Program.str("receivedBytes"));
			timerSB.Append(parent.Count2);
			lblStats2.Text = timerSB.ToString();
		}

		private void btnSend1_Click(object sender, EventArgs e)
		{
			if (data1Pending || txtSend1.Text.Length == 0)
				return;
			if (Data1SendRequested != null)
			{
				data1Pending = true;
				//don't let neither the text nor the button loose the focus
				txtSend1.ReadOnly = true;
				string txt;
				switch (cbLineBreak1.SelectedIndex)
				{
					case 1:
						txt = txtSend1.Text + "\n";
						break;
					case 2:
						txt = txtSend1.Text + "\r";
						break;
					case 3:
						txt = txtSend1.Text + "\r\n";
						break;
					default:
						txt = txtSend1.Text;
						break;
				}
				Data1SendRequested(Encoding.Default.GetBytes(txt));
			}
		}

		private void txtSend1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				btnSend1.PerformClick();
		}

		private void btnSend2_Click(object sender, EventArgs e)
		{
			if (data2Pending || txtSend2.Text.Length == 0)
				return;
			if (Data2SendRequested != null)
			{
				data2Pending = true;
				//don't let neither the text nor the button loose the focus
				txtSend2.ReadOnly = true;
				string txt;
				switch (cbLineBreak2.SelectedIndex)
				{
					case 1:
						txt = txtSend2.Text + "\n";
						break;
					case 2:
						txt = txtSend2.Text + "\r";
						break;
					case 3:
						txt = txtSend2.Text + "\r\n";
						break;
					default:
						txt = txtSend2.Text;
						break;
				}
				Data2SendRequested(Encoding.Default.GetBytes(txt));
			}
		}

		private void txtSend2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				btnSend2.PerformClick();
		}
	}
}
