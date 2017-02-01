using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RimWorldSaveManager
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
		    //Console.BufferHeight = 2000;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
