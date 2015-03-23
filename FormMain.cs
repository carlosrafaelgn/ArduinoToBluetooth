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
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ArduinoToBluetooth
{
	public partial class FormMain : Form
	{
		[DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
		private static extern void SetForegroundWindow(IntPtr hWnd);

		//https://msdn.microsoft.com/en-us/library/system.configuration.configurationmanager%28v=vs.110%29.aspx
		public static string ReadSetting(string key, string defaultValue)
		{
			try
			{
				return (ConfigurationManager.AppSettings[key] ?? defaultValue);
			}
			catch
			{
				return defaultValue;
			}
		}

		public static void SaveSetting(string key, string value)
		{
			try
			{
				Configuration configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				if (configFile.AppSettings.Settings[key] == null)
					configFile.AppSettings.Settings.Add(key, value);
				else
					configFile.AppSettings.Settings[key].Value = value;
				configFile.Save(ConfigurationSaveMode.Modified);
				ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
			}
			catch
			{
			}
		}
		private bool preparing, running, closePending;
		private Action threadReadyDelegate, threadDeathDelegate, threadData1SentDelegate, threadData2SentDelegate;
		private Action<string> threadErrDelegate;
		private AutoResetEvent threadWakeUpEvent;
		private bool notResponding1, notResponding2;
		private string com1, com2;
		private int baud1, baud2, count1, count2;
		private byte[] sendBuffer1, sendBuffer2;
		private FormData frmData;

		public FormMain()
		{
			InitializeComponent();
			Icon = global::ArduinoToBluetooth.Properties.Resources.main;
			Visible = false;
			notifyIcon.Text = Program.str("clickToStart");
			notifyIcon.Icon = global::ArduinoToBluetooth.Properties.Resources.pause16;

			mnuStart.Text = Program.str("start");
			mnuStop.Text = Program.str("stop");
			lblCOM1.Text = Program.str("arduinoPort");
			lblBaud1.Text = Program.str("speedBps");
			lblCOM2.Text = Program.str("bluetoothPort");
			lblBaud2.Text = Program.str("speedBps");
			mnuExit.Text = Program.str("exit");
			txtCOM1.Text = ReadSetting("com1", "COM1");
			txtCOM2.Text = ReadSetting("com2", "COM2");
			txtBaud1.Text = ReadSetting("baud1", "9600");
			txtBaud2.Text = ReadSetting("baud2", "9600");

			threadReadyDelegate = new Action(ThreadReadyHandler);
			threadDeathDelegate = new Action(ThreadDeathHandler);
			threadData1SentDelegate = new Action(ThreadData1SentHandler);
			threadData2SentDelegate = new Action(ThreadData2SentHandler);
			threadErrDelegate = new Action<string>(ThreadErrHandler);
			threadWakeUpEvent = new AutoResetEvent(false);
		}

		public string COM1
		{
			get
			{
				return com1;
			}
		}

		public string COM2
		{
			get
			{
				return com2;
			}
		}

		public int Count1
		{
			get
			{
				return count1;
			}
		}

		public int Count2
		{
			get
			{
				return count2;
			}
		}

		public bool NotResponding1
		{
			get
			{
				return notResponding1;
			}
		}

		public bool NotResponding2
		{
			get
			{
				return notResponding2;
			}
		}

		private void ThreadReadyHandler()
		{
			if (running)
			{
				notifyIcon.Text = Program.str("clickToStop");
				notifyIcon.Icon = global::ArduinoToBluetooth.Properties.Resources.play16;
				preparing = false;
				frmData = new FormData(this);
				frmData.Data1SendRequested += frmData_Data1SendRequested;
				frmData.Data2SendRequested += frmData_Data2SendRequested;
				frmData.FormClosed += frmData_FormClosed;
				frmData.Show();
			}
		}

		private void ThreadDeathHandler()
		{
			notifyIcon.Text = Program.str("clickToStart");
			notifyIcon.Icon = global::ArduinoToBluetooth.Properties.Resources.pause16;
			preparing = false;
			running = false;
			Stop();
			if (closePending)
			{
				closePending = false;
				Close();
			}
		}

		private void ThreadData1SentHandler()
		{
			if (running && frmData != null)
				frmData.Data1Sent();
		}

		private void ThreadData2SentHandler()
		{
			if (running && frmData != null)
				frmData.Data2Sent();
		}

		private void ThreadErrHandler(string msg)
		{
			Err(msg);
			ThreadDeathHandler();
		}

		private void Err(string msg)
		{
			if (InvokeRequired)
			{
				BeginInvoke(threadErrDelegate, msg);
				return;
			}
			MessageBox.Show(msg, "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
		}

		private void ThreadProc()
		{
			//localization debug and testing...
			//Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("pt-BR");
			//Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

			SerialPort port1 = null, port2 = null;
			string serialErr = null;
			bool firstPort1Error = true, firstPort2Error = true;
			try
			{
				try
				{
					port1 = new SerialPort(com1, baud1, Parity.None, 8, StopBits.One);
					port1.DiscardNull = false;
					port1.DtrEnable = false;
					port1.Handshake = Handshake.None;
					port1.ReadBufferSize = 8192;
					port1.ReadTimeout = 2000;
					port1.ReceivedBytesThreshold = 8192;
					port1.RtsEnable = false;
					port1.WriteBufferSize = 8192;
					port1.WriteTimeout = 2000;
				}
				catch (Exception ex)
				{
					Err(Program.str("errorCreatingArduino") + ex.Message);
					return;
				}

				if (!running)
					return;

				try
				{
					port2 = new SerialPort(com2, baud2, Parity.None, 8, StopBits.One);
					port2.DiscardNull = false;
					port2.DtrEnable = false;
					port2.Handshake = Handshake.None;
					port2.ReadBufferSize = 8192;
					port2.ReadTimeout = 2000;
					port2.ReceivedBytesThreshold = 8192;
					port2.RtsEnable = false;
					port2.WriteBufferSize = 8192;
					port2.WriteTimeout = 2000;
				}
				catch (Exception ex)
				{
					Err(Program.str("errorCreatingBluetooth") + ex.Message);
					return;
				}

				if (!running)
					return;

				try
				{
					port1.Open();
				}
				catch (Exception ex)
				{
					Err(Program.str("errorOpeningArduino") + ex.Message);
					return;
				}

				try
				{
					port2.Open();
				}
				catch (Exception ex)
				{
					Err(Program.str("errorOpeningBluetooth") + ex.Message);
					return;
				}

				try
				{
					port1.DiscardInBuffer();
				}
				catch
				{
				}
				try
				{
					port1.DiscardOutBuffer();
				}
				catch
				{
				}

				try
				{
					port2.DiscardInBuffer();
				}
				catch
				{
				}
				try
				{
					port2.DiscardOutBuffer();
				}
				catch
				{
				}

				if (!running)
					return;

				Thread t1 = new Thread(() =>
				{
					byte[] buffer1 = new byte[8192];

					while (running && serialErr == null)
					{
						int s = 0;
						try
						{
							s = port1.Read(buffer1, 0, 8192);
						}
						catch (TimeoutException)
						{
							//just ignore these timeouts as they will happen quite often here!
						}
						catch (Exception ex)
						{
							//the system is being shut down
							if (!running || !port1.IsOpen || !port2.IsOpen)
								return;
							serialErr = Program.str("errorArduino") + ex.Message;
							threadWakeUpEvent.Set();
							return;
						}
						if (s > 0)
						{
							count1 += s; //won't do any harm... ;)
							try
							{
								port2.Write(buffer1, 0, s);
								notResponding2 = false;
							}
							catch (TimeoutException)
							{
								notResponding2 = true;
							}
							catch (Exception ex)
							{
								//the system is being shut down
								if (!running || !port1.IsOpen || !port2.IsOpen)
									return;
								serialErr = Program.str("errorSendingBluetooth") + ex.Message;
								threadWakeUpEvent.Set();
								return;
							}
						}
					}
				});

				Thread t2 = new Thread(() =>
				{
					byte[] buffer2 = new byte[8192];

					while (running && serialErr == null)
					{
						int s = 0;
						try
						{
							s = port2.Read(buffer2, 0, 8192);
						}
						catch (TimeoutException)
						{
							//just ignore these timeouts as they will happen quite often here!
						}
						catch (Exception ex)
						{
							//the system is being shut down
							if (!running || !port1.IsOpen || !port2.IsOpen)
								return;
							serialErr = Program.str("errorBluetooth") + ex.Message;
							threadWakeUpEvent.Set();
							return;
						}
						if (s > 0 && running)
						{
							count2 += s; //won't do any harm... ;)
							try
							{
								port1.Write(buffer2, 0, s);
								notResponding1 = false;
							}
							catch (TimeoutException)
							{
								notResponding1 = true;
							}
							catch (Exception ex)
							{
								//the system is being shut down
								if (!running || !port1.IsOpen || !port2.IsOpen)
									return;
								serialErr = Program.str("errorSendingArduino") + ex.Message;
								threadWakeUpEvent.Set();
								return;
							}
						}
					}
				});

				t1.Start();
				t2.Start();

				port1.ErrorReceived += (sender, e) =>
				{
					//the system is being shut down
					if (!running || !port1.IsOpen || !port2.IsOpen)
						return;
					//a few drivers indicate overrun if the port had been receiving
					//too many bytes before it was open (which could easily happen if
					//either the Arduino or the Bluetooth had been sending data before
					//this application was started)
					if (firstPort1Error && e.EventType == SerialError.Overrun)
					{
						firstPort1Error = false;
						return;
					}
					firstPort1Error = false;
					//this is executed in another worker thread
					serialErr = Program.str("errorArduino") + e.EventType;
					threadWakeUpEvent.Set();
				};

				port2.ErrorReceived += (sender, e) =>
				{
					//the system is being shut down
					if (!running || !port1.IsOpen || !port2.IsOpen)
						return;
					//a few drivers indicate overrun if the port had been receiving
					//too many bytes before it was open (which could easily happen if
					//either the Arduino or the Bluetooth had been sending data before
					//this application was started)
					if (firstPort2Error && e.EventType == SerialError.Overrun)
					{
						firstPort2Error = false;
						return;
					}
					firstPort2Error = false;
					//this is executed in another worker thread
					serialErr = Program.str("errorBluetooth") + e.EventType;
					threadWakeUpEvent.Set();
				};

				BeginInvoke(threadReadyDelegate);

				while (running && serialErr == null)
				{
					if (sendBuffer1 != null)
					{
						try
						{
							port1.Write(sendBuffer1, 0, sendBuffer1.Length);
							notResponding1 = false;
							BeginInvoke(threadData1SentDelegate);
						}
						catch (TimeoutException)
						{
							notResponding1 = true;
						}
						catch (Exception ex)
						{
							//the system is being shut down
							if (running && port1.IsOpen && port2.IsOpen)
								serialErr = Program.str("errorSendingArduino") + ex.Message;
							break;
						}
						finally
						{
							sendBuffer1 = null;
						}
					}
					if (sendBuffer2 != null)
					{
						try
						{
							port2.Write(sendBuffer2, 0, sendBuffer2.Length);
							notResponding2 = false;
							BeginInvoke(threadData2SentDelegate);
						}
						catch (TimeoutException)
						{
							notResponding2 = true;
						}
						catch (Exception ex)
						{
							//the system is being shut down
							if (running && port1.IsOpen && port2.IsOpen)
								serialErr = Program.str("errorSendingBluetooth") + ex.Message;
							break;
						}
						finally
						{
							sendBuffer2 = null;
						}
					}
					if (serialErr == null)
						threadWakeUpEvent.WaitOne();
				}
				running = false;

				t1.Join();
				t2.Join();
			}
			finally
			{
				try
				{
					if (port1 != null)
						port1.Close();
				}
				catch
				{
				}
				try
				{
					if (port2 != null)
						port2.Close();
				}
				catch
				{
				}
				try
				{
					if (port1 != null)
						port1.Dispose();
				}
				catch
				{
				}
				try
				{
					if (port2 != null)
						port2.Dispose();
				}
				catch
				{
				}
				if (serialErr != null)
					Err(serialErr);
				else
					BeginInvoke(threadDeathDelegate);
			}
		}

		private void Start()
		{
			if (running)
				return;
			if ((com1 = txtCOM1.Text.Trim()).Length < 3)
			{
				Err(Program.str("invalidArduinoPort"));
				return;
			}
			if ((com2 = txtCOM2.Text.Trim()).Length < 3)
			{
				Err(Program.str("invalidBluetoothPort"));
				return;
			}
			if (!int.TryParse(txtBaud1.Text, out baud1) || baud1 <= 0)
			{
				Err(Program.str("invalidArduinoBaud"));
				return;
			}
			if (!int.TryParse(txtBaud2.Text, out baud2) || baud2 <= 0)
			{
				Err(Program.str("invalidBluetoothBaud"));
				return;
			}
			notifyIcon.Text = Program.str("pleaseWait");
			notifyIcon.Icon = global::ArduinoToBluetooth.Properties.Resources.loading16;
			preparing = true;
			running = true;
			notResponding1 = false;
			notResponding2 = false;
			count1 = 0;
			count2 = 0;
			sendBuffer1 = null;
			sendBuffer2 = null;
			threadWakeUpEvent.Reset();
			Thread thread = new Thread(ThreadProc);
			thread.Name = "Serial Processing Thread";
			thread.Start();
		}

		private void Stop()
		{
			if (frmData != null)
			{
				frmData.Close();
				frmData = null;
			}
			if (!running)
				return;
			notifyIcon.Text = Program.str("pleaseWait");
			notifyIcon.Icon = global::ArduinoToBluetooth.Properties.Resources.loading16;
			preparing = true;
			running = false;
			threadWakeUpEvent.Set();
		}

		protected override void OnLoad(EventArgs e)
		{
			Visible = false;
			base.OnLoad(e);
			Visible = false;
		}

		protected override void OnShown(EventArgs e)
		{
			Visible = false;
			base.OnShown(e);
			Visible = false;
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			base.OnFormClosing(e);
			if (running || preparing)
			{
				closePending = true;
				e.Cancel = true;
				Stop();
				return;
			}

			notifyIcon.Visible = false;

			SaveSetting("com1", txtCOM1.Text);
			SaveSetting("com2", txtCOM2.Text);
			SaveSetting("baud1", txtBaud1.Text);
			SaveSetting("baud2", txtBaud2.Text);
		}

		private void frmData_Data1SendRequested(byte[] buffer)
		{
			if (!preparing && running)
			{
				sendBuffer1 = buffer;
				threadWakeUpEvent.Set();
			}
		}

		private void frmData_Data2SendRequested(byte[] buffer)
		{
			if (!preparing && running)
			{
				sendBuffer2 = buffer;
				threadWakeUpEvent.Set();
			}
		}

		private void frmData_FormClosed(object sender, FormClosedEventArgs e)
		{
			frmData = null;
			Stop();
		}

		private void notifyIcon_Click(object sender, EventArgs e)
		{
			SetForegroundWindow(Handle); //win32... good old win32 days! :)
			contextMenuStrip.Show(MousePosition.X, MousePosition.Y);
		}

		private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
		{
			bool start = (!preparing && !running);
			mnuStart.Enabled = start;
			mnuStop.Enabled = (!preparing && running);
			txtCOM1.Enabled = start;
			txtBaud1.Enabled = start;
			txtCOM2.Enabled = start;
			txtBaud2.Enabled = start;
		}

		private void mnuStart_Click(object sender, EventArgs e)
		{
			if (!preparing)
				Start();
		}

		private void mnuStop_Click(object sender, EventArgs e)
		{
			if (!preparing)
				Stop();
		}

		private void mnuExit_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
