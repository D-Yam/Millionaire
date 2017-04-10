using System;
using System.ServiceModel;
using System.Windows.Forms;
using Interface;
using InterfaceDefine;

namespace MillionaireHost
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// Hostボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, EventArgs e)
		{
			//指定されなきゃ何もしない
			if (textBox1.Text == "")
			{
				return;
			}
			var baseAddress = textBox1.Text;
			var endPointAddress = "IPC";

			ServiceHost serviceHost = new ServiceHost(
				typeof(InterfaceDefine.InterfaceDefine),
				new Uri(baseAddress)
				);
			serviceHost.AddServiceEndpoint(
				typeof(IWcfInterface),
				new NetNamedPipeBinding(NetNamedPipeSecurityMode.None),
				endPointAddress
			);

			serviceHost.Open();
		}
	}
}
