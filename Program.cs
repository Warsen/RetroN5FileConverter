using System;
using System.Windows.Forms;

namespace RetroN5FileConverter
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(defaultValue: false);
			Application.Run(new MainForm());
		}
	}
}
