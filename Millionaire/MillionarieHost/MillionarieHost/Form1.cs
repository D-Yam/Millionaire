using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading;
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

			try
			{
				//サービスホストを作成
				ServiceHost serviceHost = new ServiceHost(
					typeof(InterfaceDefine.InterfaceDefine),
					new Uri(baseAddress)
				);

				var smb = serviceHost.Description.Behaviors.Find<ServiceMetadataBehavior>();

				if (smb == null)
				{
					smb = new ServiceMetadataBehavior();
				}

				//smb.HttpGetEnabled = true;

				smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;

				serviceHost.Description.Behaviors.Add(smb);

				serviceHost.AddServiceEndpoint(
					ServiceMetadataBehavior.MexContractName,
					MetadataExchangeBindings.CreateMexNamedPipeBinding(),
					"Mex"
				);

				///*
				//エンドポイントを追加
				serviceHost.AddServiceEndpoint(
					typeof(IWcfInterface),
					new NetNamedPipeBinding(NetNamedPipeSecurityMode.None),
					endPointAddress
				);
				//*/
				  
				serviceHost.Open();
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception);
				throw;
			}
		}
	}
}
