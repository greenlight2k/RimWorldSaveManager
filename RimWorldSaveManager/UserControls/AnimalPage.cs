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
    public partial class AnimalPage : UserControl
    {

        private BindingList<Pawn> _pawnBindingList;

        private Pawn _pawn;

        public AnimalPage(List<Pawn> pawnList)
        {
            InitializeComponent();
            _pawnBindingList = new BindingList<Pawn>(pawnList);

            listBox1.DataSource = _pawnBindingList;
            listBox1.DisplayMember = "FullName";

            if (_pawnBindingList.Count > 0)
            {
                setPawn(_pawnBindingList[0]);
            }
        }
        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                Pawn pawn = (Pawn)listBox1.SelectedItems[0];
                setPawn(pawn);
            }
        }

        private void setPawn(Pawn pawn)
        {
            _pawn = pawn;

            bioAgeField.Value = (decimal)(pawn.AgeBiologicalTicks / 3600000f);
            chronoAgeField.Value = -(decimal)(pawn.AgeChronoligicalTicks / 3600000f);

            labelDefinition.Text = _pawn.Def;
            textBoxNickname.Text = _pawn.Nickname;

            checkBoxObedience.Checked = _pawn.Training.ObedienceTraining;
            checkBoxRelease.Checked = _pawn.Training.ReleaseTraining;
            checkBoxRescue.Checked = _pawn.Training.RescueTraining;
            checkBoxHaul.Checked = _pawn.Training.HaulTraining;

            numericUpDownObedience.Value = _pawn.Training.ObedienceStep;
            numericUpDownRelease.Value = _pawn.Training.ReleaseStep;
            numericUpDownRescue.Value = _pawn.Training.RescueStep;
            numericUpDownHaul.Value = _pawn.Training.HaulStep;

            listBoxInjuries.Items.Clear();

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
        private void btnRemoveInjury_Click(object sender, EventArgs e)
        {
            if (listBoxInjuries.SelectedIndex == -1)
            {
                MessageBox.Show("Can not remove an unselected injury");
                return;
            }

            var item = (PawnHealth)listBoxInjuries.SelectedItem;
            item.Element.Remove();
            _pawn.Hediffs.Remove(item);

            listBoxInjuries.Items.RemoveAt(listBoxInjuries.SelectedIndex);
        }

        private void textBoxNickname_TextChanged(object sender, EventArgs e)
        {
            _pawn.Nickname = textBoxNickname.Text;
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

        private void checkBoxObedience_CheckedChanged(object sender, EventArgs e)
        {
            _pawn.Training.ObedienceTraining = checkBoxObedience.Checked;
        }

        private void checkBoxRelease_CheckedChanged(object sender, EventArgs e)
        {
            _pawn.Training.ReleaseTraining = checkBoxRelease.Checked;

        }

        private void checkBoxRescue_CheckedChanged(object sender, EventArgs e)
        {
            _pawn.Training.RescueTraining = checkBoxRelease.Checked;

        }

        private void checkBoxHaul_CheckedChanged(object sender, EventArgs e)
        {
            _pawn.Training.HaulTraining = checkBoxHaul.Checked;

        }

        private void numericUpDownObedience_ValueChanged(object sender, EventArgs e)
        {
            _pawn.Training.ObedienceStep = (int)numericUpDownObedience.Value;
        }

        private void numericUpDownRelease_ValueChanged(object sender, EventArgs e)
        {
            _pawn.Training.ReleaseStep = (int)numericUpDownRelease.Value;
        }

        private void numericUpDownRescue_ValueChanged(object sender, EventArgs e)
        {
            _pawn.Training.RescueStep = (int)numericUpDownRescue.Value;
        }

        private void numericUpDownHaul_ValueChanged(object sender, EventArgs e)
        {
            _pawn.Training.HaulStep = (int)numericUpDownHaul.Value;
        }
    }
}
