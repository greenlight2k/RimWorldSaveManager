using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace RimWorldSaveManager
{
	public partial class MainForm : Form
	{
	    readonly DataLoader _dataLoader = new DataLoader();

		public MainForm()
		{
			InitializeComponent();

			var version = Assembly.GetExecutingAssembly().GetName();

			Text = $"{version.Name} v{version.Version} (1.0)";
		}

		private void toolStripLabel1_Click(object sender, EventArgs e)
		{
			var ofn = new OpenFileDialog();

			var platform = Environment.OSVersion.Platform;

			if (platform == PlatformID.MacOSX)
				ofn.InitialDirectory = Environment.ExpandEnvironmentVariables(@"%LOCALAPPDATA%Low\Ludeon Studios\RimWorld\Saves");
			else if (platform == PlatformID.Unix)
				ofn.InitialDirectory = string.Join(Path.DirectorySeparatorChar.ToString(),
					Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
					"unity3d",
					"Ludeon Studios",
					"RimWorld");
			else
				ofn.InitialDirectory = string.Join(Path.DirectorySeparatorChar.ToString(),
					Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
					"Library",
					"Application",
					"Support",
					"RimWorld",
					"Saves");

			ofn.Filter = @"RimWorld Save File|*.rws";
			ofn.FilterIndex = 1;

			if (ofn.ShowDialog() == DialogResult.OK)
			{
				_dataLoader.LoadData(ofn.FileName, tabControl1);
				toolStrip1.Items[2].Enabled = true;
			}
		}

		private void toolStripLabel2_Click(object sender, EventArgs e)
		{
			var sfn = new SaveFileDialog();

			var platform = Environment.OSVersion.Platform;

			if (platform == PlatformID.MacOSX)
				sfn.InitialDirectory = Environment.ExpandEnvironmentVariables(@"%LOCALAPPDATA%Low\Ludeon Studios\RimWorld\Saves");
			else if (platform == PlatformID.Unix)
				sfn.InitialDirectory = string.Join(Path.DirectorySeparatorChar.ToString(),
					Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
					"unity3d",
					"Ludeon Studios",
					"RimWorld");
			else
				sfn.InitialDirectory = string.Join(Path.DirectorySeparatorChar.ToString(),
					Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
					"Library",
					"Application Support",
					"RimWorld",
					"Saves");

			sfn.Filter = @"RimWorld Save File (.rws)|*.rws";
			sfn.FilterIndex = 1;

			if (sfn.ShowDialog() == DialogResult.OK)
			{
				_dataLoader.SaveData(sfn.FileName);
			}
		}
    }
}
