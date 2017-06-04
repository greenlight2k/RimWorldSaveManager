using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RimWorldSaveManager.Data.DataStructure;

namespace RimWorldSaveManager.UserControls
{
    public partial class ColonistPage : UserControl
    {
        private BindingList<Pawn> _pawnBindingList;

        private Pawn _pawn;

        public Dictionary<string, TextBox> Skills;
        public Dictionary<string, ComboBox> Passions;

        public ColonistPage(List<Pawn> pawns)
        {
            InitializeComponent();

            _pawnBindingList = new BindingList<Pawn>(pawns);

            listBox1.DataSource = _pawnBindingList;
            listBox1.DisplayMember = "FullName";

            comboBoxGender.Items.AddRange(DataLoader.Genders.ToArray());
            foreach (var trait in DataLoader.Traits)
            {
                traitComboBox.Items.Add(trait.Value);
            }

            setPawn(_pawnBindingList[0]);
        }

        private void listBox1_Click(object sender, EventArgs e)
        {

            Pawn pawn = (Pawn)listBox1.SelectedItems[0];
            setPawn(pawn);

        }
        private void setPawn(Pawn pawn)
        {
            _pawn = pawn;

            bioAgeField.Value = (decimal)(pawn.AgeBiologicalTicks / 3600000f);
            chronoAgeField.Value = -(decimal)(pawn.AgeChronoligicalTicks / 3600000f);
            numericUpDownMelanin.Value = _pawn.Melanin;

            labelDefinition.Text = _pawn.Def;


            traitComboBox.SelectedIndex = 0;

            Skills = new Dictionary<string, TextBox>();
            Passions = new Dictionary<string, ComboBox>();

            skillsGroupBox.Controls.Clear();
            listBoxTraits.Items.Clear();
            listBoxInjuries.Items.Clear();
            comboBoxBodyType.Items.Clear();
            comboBoxHeadType.Items.Clear();

            colorDialogHair.Color = _pawn.HairColor;
            panelHairColor.BackColor = colorDialogHair.Color;
            colorDialogHair.CustomColors = new int[]
            {
                ColorTranslator.ToOle(colorDialogHair.Color)
            };
            fillHairComboBox();
            textBoxFirstname.Text = _pawn.Firstname;
            textBoxNickname.Text = _pawn.Nickname;
            textBoxLastname.Text = _pawn.Lastname;


            comboBoxBodyType.Items.AddRange(_pawn.Race.BodyType.ToArray());
            comboBoxHeadType.Items.AddRange(_pawn.Race.HeadType.ToArray());

            comboBoxGender.SelectedItem = _pawn.Gender;
            comboBoxBodyType.SelectedItem = _pawn.BodyType;

            CrownType pawnCrownType = _pawn.CrownType;
            foreach(var crownType in _pawn.Race.HeadType)
            {
                if (pawnCrownType.CombinedCrownDef.Equals(crownType.CombinedCrownDef)){
                    comboBoxHeadType.SelectedItem = crownType;
                    break;
                }
            }

            var skillPos = new Size(skillsGroupBox.Margin.Left + skillsGroupBox.Padding.Left, skillsGroupBox.Margin.Top + skillsGroupBox.Padding.Top + 10);
            skillsGroupBox.Height = pawn.Skills.Count * 25 + skillsGroupBox.Margin.Bottom + skillsGroupBox.Padding.Bottom + 15;

            if (skillsGroupBox.Height > Height + 5)
                Height = skillsGroupBox.Height + 5;

            foreach (var skill in pawn.Skills)
            {
                var label = new Label();
                label.Text = skill.Name;
                label.SetBounds(skillPos.Width, skillPos.Height + 3, TextRenderer.MeasureText(skill.Name, label.Font).Width, 13);

                var textBox = new TextBox();
                textBox.Text = skill.Level == null ? "-" : skill.Level.ToString();
                textBox.SetBounds(skillPos.Width + 100, skillPos.Height, 20, 20);
                textBox.TextChanged += (obj, a) =>
                {
                    skill.Level = int.Parse(textBox.Text);
                };

                var comboBox = new ComboBox();
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox.Items.Add("None");
                comboBox.Items.Add("Minor");
                comboBox.Items.Add("Major");
                comboBox.SelectedItem = string.IsNullOrEmpty(skill.Passion) ? "None" : skill.Passion;
                comboBox.Left = textBox.Right + 5;
                comboBox.Top = skillPos.Height;
                comboBox.SelectionChangeCommitted += (obj, a) =>
                {
                    skill.Passion = comboBox.SelectedItem.ToString();
                };

                Skills.Add(skill.Name, textBox);
                Passions.Add(skill.Name, comboBox);

                skillsGroupBox.Controls.Add(label);
                skillsGroupBox.Controls.Add(textBox);
                skillsGroupBox.Controls.Add(comboBox);

                skillPos.Height += 25;
            }

            foreach (var trait in pawn.Traits)
            {
                listBoxTraits.Items.Add(trait);
            }

            childhoodComboBox.Items.AddRange(ResourceLoader.ChildhoodStories.ToArray());
            adulthoodComboBox.Items.AddRange(ResourceLoader.AdulthoodStories.ToArray());

            Action<ComboBox, string> setBackstory = (comboBox, storyKey) =>
            {
                if (string.IsNullOrEmpty(storyKey))
                {
                    comboBox.SelectedItem = ResourceLoader.Backstories["None"];
                    return;
                }

                Backstory backstory;
                if (!ResourceLoader.Backstories.TryGetValue(storyKey, out backstory))
                {
                    Logger.Err($"Failed to get backstory for key: {storyKey}");
                    return;
                }

                comboBox.SelectedItem = backstory;
                //comboBox.SelectedIndex = comboBox.FindStringExact(backstory.DisplayTitle);
            };

            setBackstory(childhoodComboBox, pawn.Childhood);
            setBackstory(adulthoodComboBox, pawn.Adulthood);

            foreach (var pawnHediff in pawn.Hediffs)
            {
                if (pawnHediff.ParentClass == "Hediff_AddedPart") continue;
                HediffDef hediffDef = null;
                Hediff hediffClass = null;

                if (pawnHediff.ParentClass != null)
                {
                    if (DataLoader.Hediffs.TryGetValue(pawnHediff.ParentClass, out hediffClass))
                    {
                        if (hediffClass.SubDiffs.TryGetValue(pawnHediff.Def, out hediffDef))
                        {
                            pawnHediff.Label = hediffDef.Label;
                        }
                    }
                }

                listBoxInjuries.Items.Add(pawnHediff);
            }
        }

        private void fillHairComboBox()
        {
            List<Hair> hairList;
            if (!_pawn.Race.HairsByGender.TryGetValue(_pawn.Gender, out hairList))
            {
                hairList = new List<Hair>();
            }
            comboBoxHairDef.Items.Clear();
            comboBoxHairDef.Items.AddRange(hairList.ToArray());
            string pawnHairDef = _pawn.HairDef;
            Hair pawnHair = null;
            foreach (var hair in hairList)
            {
                if (hair.Def.Equals(pawnHairDef))
                {
                    pawnHair = hair;
                    break;
                }
            }
            if (pawnHair != null)
            {
                comboBoxHairDef.SelectedItem = pawnHair;
            }
            else
            {
                if (comboBoxHairDef.Items.Count > 0)
                {
                    comboBoxHairDef.SelectedIndex = 0;
                }
            }

        }

        private void btnAddTrait_Click(object sender, EventArgs e)
        {
            var selected = (TraitDef)traitComboBox.SelectedItem;
            foreach (var item in listBoxTraits.Items)
            {
                if (((PawnTrait)item).Def == selected.Def)
                {
                    MessageBox.Show("Can not add identical traits");
                    return;
                }
            }

            listBoxTraits.Items.Add(_pawn.AddTrait((TraitDef)traitComboBox.SelectedItem));
        }

        private void btnRemoveTrait_Click(object sender, EventArgs e)
        {
            if (listBoxTraits.SelectedIndex == -1)
            {
                MessageBox.Show("Can not remove an unselected trait");
                return;
            }

            //var trait = (PawnTrait) listBoxTraits.SelectedItem;
            Console.WriteLine($"Selected index: {listBoxTraits.SelectedIndex}");
            _pawn.RemoveTrait(listBoxTraits.SelectedIndex);
            listBoxTraits.Items.RemoveAt(listBoxTraits.SelectedIndex);
        }

        private void btnRemoveInjury_Click(object sender, EventArgs e)
        {
            if (listBoxInjuries.SelectedIndex == -1)
            {
                MessageBox.Show("Can not remove an unselected injury");
                return;
            }

            var item = (PawnHealth)listBoxInjuries.SelectedItem;
            item.Element.Remove();

            listBoxInjuries.Items.RemoveAt(listBoxInjuries.SelectedIndex);
        }

        private void backstoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var backstory = (Backstory)comboBox.SelectedItem;

            if (comboBox == childhoodComboBox)
            {
                _pawn.Childhood = backstory.Id == "None" ? null : backstory.Id;
            }
            else
            {
                _pawn.Adulthood = backstory.Id == "None" ? null : backstory.Id;
            }
        }

        private void Backstory_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            var comboBox = (ComboBox)sender;
            var backstory = (Backstory)comboBox.SelectedItem;

            if (e.Bounds.Y < 0 || e.Bounds.Y > comboBox.DropDownHeight)
            {
                return;
            }

            e.DrawBackground();

            using (SolidBrush br = new SolidBrush(e.ForeColor))
            {
                e.Graphics.DrawString(comboBox.GetItemText(comboBox.Items[e.Index]), e.Font, br, e.Bounds);
            }

            if (e.State.HasFlag(DrawItemState.Selected) && comboBox.DroppedDown)
            {
                DescriptionText.Lines = GenerateDetailedInformation(backstory).Split('\n');
            }

            e.DrawFocusRectangle();
        }

        private bool InBound(Control control, Rectangle bound, Point pt)
        {
            pt = control.PointToClient(pt);
            Console.WriteLine($"{bound}|{pt}");
            return pt.X > bound.Left && pt.X < bound.Right;
        }

        private string GenerateDetailedInformation(Backstory backstory)
        {
            var detailedBackstory = $"{backstory.Title}\n\n{backstory.Description}\n";

            if (backstory.SkillGains != null && backstory.SkillGains.Count > 0)
            {
                detailedBackstory += "\nSkill Gains:\n";

                foreach (var skillGain in backstory.SkillGains)
                    detailedBackstory += $"{skillGain.Key}: {skillGain.Value}\n";
            }

            if (backstory.WorkDisables != null && backstory.WorkDisables.Count > 0)
            {
                detailedBackstory += "\nIncapable of:\n";

                if (DataLoader.WorkTypes.Count == 0)
                    foreach (var workTag in backstory.WorkDisables)
                        detailedBackstory += workTag + "\n";
                else
                    foreach (var workTag in backstory.WorkDisables)
                    {
                        var allWorkTypes = DataLoader.WorkTypes.Where(wt => wt.WorkTags.Contains(workTag));

                        var workTypes = allWorkTypes as WorkType[] ?? allWorkTypes.ToArray();
                        if (!workTypes.Any())
                            detailedBackstory += workTag + "\n";
                        else
                            foreach (var workType in workTypes)
                                detailedBackstory += workType.FullName + "\n";
                    }
            }

            return
                detailedBackstory.Replace("NAME", _pawn.Nickname)
                    .Replace("HECAP", _pawn.HeCap)
                    .Replace("HISCAP", _pawn.HisCap)
                    .Replace("HE", _pawn.He)
                    .Replace("HIS", _pawn.His);
        }

        private void DropDownClosed(object sender, EventArgs e)
        {
            DescriptionText.Text = "";
        }

        private void textBoxFirstname_TextChanged(object sender, EventArgs e)
        {
            _pawn.Firstname = textBoxFirstname.Text;
            _pawnBindingList.ResetItem(_pawnBindingList.IndexOf(_pawn));
        }

        private void textBoxNickname_TextChanged(object sender, EventArgs e)
        {
            _pawn.Nickname = textBoxNickname.Text;
            _pawnBindingList.ResetItem(_pawnBindingList.IndexOf(_pawn));
        }

        private void textBoxLastname_TextChanged(object sender, EventArgs e)
        {
            _pawn.Lastname = textBoxLastname.Text;
            _pawnBindingList.ResetItem(_pawnBindingList.IndexOf(_pawn));
        }

        private void bioAgeField_ValueChanged(object sender, EventArgs e)
        {
            _pawn.AgeBiologicalTicks = Decimal.ToInt64(Decimal.Multiply(bioAgeField.Value, 3600000));
        }

        private void chronoAgeField_ValueChanged(object sender, EventArgs e)
        {
            _pawn.AgeChronoligicalTicks = -Decimal.ToInt64(Decimal.Multiply(chronoAgeField.Value, 3600000));
        }

        private void comboBoxGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            _pawn.Gender = (string)comboBoxGender.SelectedItem;
            fillHairComboBox();
        }

        private void comboBoxBodyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _pawn.BodyType = (string)comboBoxBodyType.SelectedItem;
        }

        private void comboBoxHeadType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _pawn.CrownType = (CrownType)comboBoxHeadType.SelectedItem;
        }

        private void comboBoxHairDef_SelectedIndexChanged(object sender, EventArgs e)
        {
            _pawn.HairDef = ((Hair)comboBoxHairDef.SelectedItem).Def;

        }

        private void buttonHairColor_Click(object sender, EventArgs e)
        {
            if (colorDialogHair.ShowDialog() == DialogResult.OK)
            {
                panelHairColor.BackColor = colorDialogHair.Color;
                _pawn.HairColor = colorDialogHair.Color;
            }
        }

        private void numericUpDownMelanin_ValueChanged(object sender, EventArgs e)
        {
            _pawn.Melanin = numericUpDownMelanin.Value;
        }
    }
}
