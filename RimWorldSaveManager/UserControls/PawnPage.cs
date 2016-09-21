using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RimWorldSaveManager
{
	public partial class PawnPage : UserControl
	{
		private Pawn PawnClass;
		private ToolTip BackstoryDescription;

		public PawnPage(Pawn pawn)
		{
			InitializeComponent();

			BackstoryDescription = new ToolTip();

			PawnClass = pawn;

			foreach (var trait in DataLoader.Traits)
				comboBox1.Items.Add(trait.Value.Label);

			BiologicalAgeBox.Value = (decimal)(pawn.ageBiologicalTicks / 3600000f);

			comboBox1.SelectedIndex = 0;

			Skills = new Dictionary<string, TextBox>();
			Passions = new Dictionary<string, ComboBox>();

			var skillPos = new Size(groupBox1.Margin.Left + groupBox1.Padding.Left, groupBox1.Margin.Top + groupBox1.Padding.Top + 10);
			groupBox1.Height = pawn.skills.Count * 25 + groupBox1.Margin.Bottom + groupBox1.Padding.Bottom + 15;

			if (groupBox1.Height > Height + 5)
				Height = groupBox1.Height + 5;

			foreach (var skill in pawn.skills)
			{
				var label = new Label();
				var textBox = new TextBox();
				var comboBox = new ComboBox();
				label.Text = skill.Name;
				label.SetBounds(skillPos.Width, skillPos.Height + 3, TextRenderer.MeasureText(skill.Name, label.Font).Width, 13);
				textBox.Text = skill.Level == -1 ? "-" : skill.Level.ToString();
				textBox.SetBounds(skillPos.Width + 100, skillPos.Height, 20, 20);
				comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
				comboBox.Items.Add("None");
				comboBox.Items.Add("Minor");
				comboBox.Items.Add("Major");
				comboBox.SelectedItem = string.IsNullOrEmpty(skill.Passion) ? "None" : skill.Passion;
				comboBox.Left = textBox.Right + 5;
				comboBox.Top = skillPos.Height;
				Skills.Add(skill.Name, textBox);
				Passions.Add(skill.Name, comboBox);
				groupBox1.Controls.Add(label);
				groupBox1.Controls.Add(textBox);
				groupBox1.Controls.Add(comboBox);
				skillPos.Height += 25;
			}

			foreach (var trait in pawn.traits)
			{
				var traitKey = trait.Def + trait.Degree;
				listBox1.Items.Add(DataLoader.Traits.ContainsKey(traitKey) ? DataLoader.Traits[traitKey].Label : trait.Def);
			}

			foreach (var backstory in DataLoader.Backstories)
			{
				((backstory.Value.Slot == "Childhood") ? childhoodComboBox : adulthoodComboBox)
					.Items.Add(backstory.Value);
			}

			/*Action<ComboBox, string> setBackstory = (comboBox, trimString) =>
			{
				var trimIndex = trimString.IndexOf('-');

				if (trimIndex == -1)
					trimIndex = trimString.IndexOfAny(new char[]
						{ '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });

				var stageString = trimString.Substring(0, trimIndex);
				stageString = string.Concat(stageString.Select(x => char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');

				comboBox.SelectedIndex = comboBox.FindStringExact(stageString);
			};*/

			Action<ComboBox, string> setBackstory = (comboBox, storyKey) =>
			{
				PawnBackstory backstory = null;

				if (DataLoader.Backstories.TryGetValue(storyKey, out backstory) == false)
					return;

				comboBox.SelectedIndex = comboBox
				.FindStringExact(backstory.DisplayTitle);
			};

			setBackstory(childhoodComboBox, pawn.childhood);
			setBackstory(adulthoodComboBox, pawn.adulthood);

			foreach (var hediff in pawn.hediffs)
			{
				if (hediff.ParentClass == "Hediff_AddedPart") continue;
				PawnHealth pawnHealth = null;
				Hediff hediffClass = null;

				bool labelExists = false;

				if (DataLoader.Hediffs.TryGetValue(hediff.ParentClass, out hediffClass))
					labelExists = hediffClass.SubDiffs.TryGetValue(hediff.Def, out pawnHealth);

				listBox2.Items.Add(labelExists ? pawnHealth.Label : hediff.Def);
			}
		}

		public Dictionary<string, TextBox> Skills;
		public Dictionary<string, ComboBox> Passions;

		private void button1_Click(object sender, System.EventArgs e)
		{
			if (listBox1.Items.Count >= 3)
			{
				MessageBox.Show("Can not add more than 3 traits");
				return;
			}

			if (listBox1.Items.Contains(comboBox1.SelectedItem))
			{
				MessageBox.Show("Can not add identical traits");
				return;
			}

			listBox1.Items.Add(comboBox1.SelectedItem);
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			if (listBox1.SelectedIndex == -1)
			{
				MessageBox.Show("Can not remove an unselected trait");
				return;
			}

			listBox1.Items.RemoveAt(listBox1.SelectedIndex);
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			if (listBox2.SelectedIndex == -1)
			{
				MessageBox.Show("Can not remove an unselected injury");
				return;
			}

			PawnClass.hediffs.RemoveAt(listBox2.SelectedIndex);

			listBox2.Items.RemoveAt(listBox2.SelectedIndex);
		}

		private void backstoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			var comboBox = (ComboBox)sender;

			var backstory = (PawnBackstory)comboBox.SelectedItem;

			if (comboBox == childhoodComboBox)
				PawnClass.childhood = backstory.DescriptionKey;
			else
				PawnClass.adulthood = backstory.DescriptionKey;
		}

		private void Backstory_DrawItem(object sender, DrawItemEventArgs e)
		{
			if (e.Index < 0)
				return;

			var comboBox = (ComboBox)sender;
			var backstory = (PawnBackstory)comboBox.SelectedItem;

			e.DrawBackground();

			using (SolidBrush br = new SolidBrush(e.ForeColor))
			{
				e.Graphics.DrawString(comboBox.GetItemText(comboBox.Items[e.Index]), e.Font, br, e.Bounds);
			}

			if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
				BackstoryDescription.Show(
					GenerateDetailedInformation(backstory),
					comboBox,
					e.Bounds.Right,
					e.Bounds.Bottom);

			e.DrawFocusRectangle();
		}

		private string GenerateDetailedInformation(PawnBackstory backstory)
		{
			var detailedBackstory = backstory.Description + "\n";

			if (backstory.SkillGains != null)
			{
				detailedBackstory += "\nSkill Gains:\n";

				foreach (var skillGain in backstory.SkillGains)
					detailedBackstory += string.Format("{0}: {1}\n", skillGain.Key, skillGain.Value);
			}

			if (backstory.WorkDisables != null &&
				backstory.WorkDisables.Length != 0)
			{
				detailedBackstory += "\nIncapable of:\n";

				if (DataLoader.WorkTypes.Count == 0)
					foreach (var workTag in backstory.WorkDisables)
						detailedBackstory += workTag + "\n";
				else
					foreach (var workTag in backstory.WorkDisables)
					{
						var workTypes = DataLoader.WorkTypes.Where(wt => wt.WorkTags.Contains(workTag));

						if (workTypes.Count() == 0)
							detailedBackstory += workTag + "\n";
						else
							foreach (var workType in workTypes)
								detailedBackstory += workType.FullName + "\n";
					}
			}

			return detailedBackstory;
		}

		private void DropDownClosed(object sender, EventArgs e)
		{
			BackstoryDescription.Hide((IWin32Window)sender);
		}
	}
}
