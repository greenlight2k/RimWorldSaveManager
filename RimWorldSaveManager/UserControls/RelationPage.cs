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
    public partial class RelationPage : UserControl
    {

        private BindingList<Pawn> _pawnBindingList;
        private BindingList<Relation> _pawnRelations;

        private Pawn _pawn;
        private Relation _relation;

        private string unknownPawn = "Unknown Pawn";

        public RelationPage()
        {
            InitializeComponent();

            _pawnBindingList = new BindingList<Pawn>(DataLoader.PawnsByFactions[DataLoader.PlayerFaction]);
            listBox1.DataSource = _pawnBindingList;
            listBox1.DisplayMember = "FullNameAndDef";

            _pawnRelations = new BindingList<Relation>();
            listBoxRelations.DataSource = _pawnRelations;
            listBoxRelations.DisplayMember = "Def";

            comboBoxRelations.Items.AddRange(DataLoader.PawnRelationDefs.ToArray());
            comboBoxRelationDefs.Items.AddRange(DataLoader.PawnRelationDefs.ToArray());
            comboBoxFaction.Items.AddRange(DataLoader.Factions.Values.ToArray());

            numericUpDownStartTime.Maximum = DataLoader.CurrentGameTick;

            if(_pawnBindingList.Count > 0)
            {
                setPawn(_pawnBindingList[0]);
            }
        }

        private void setPawn(Pawn pawn)
        {
            _pawn = pawn;

            _pawnRelations.Clear();
            foreach(var relation in _pawn.Relations)
            {
                _pawnRelations.Add(relation);
            }
            listBoxRelations.Refresh();

            if(_pawnRelations.Count > 0)
            {
                setRelation(_pawnRelations[0]);
            }
            else
            {
                groupBoxRelation.Visible = false;
            }
        }

        private void setRelation(Relation relation)
        {
            _relation = relation;
            groupBoxRelation.Visible = true;
            string otherPawnID = _relation.OtherPawn;
            Pawn otherPawn;
            DataLoader.PawnsById.TryGetValue(otherPawnID, out otherPawn);
            Faction faction = DataLoader.PlayerFaction;
            if (otherPawn != null)
            {
                faction = DataLoader.Factions[otherPawn.Faction];
                comboBoxFaction.SelectedItem = faction;
                comboBoxPawns.SelectedItem = otherPawn;
            }
            else
            {
                comboBoxFaction.SelectedItem = faction;
                if(comboBoxPawns.Items.Count > 0)
                {
                    comboBoxPawns.SelectedIndex = 0;
                }
            }

            numericUpDownStartTime.Value = _relation.StartTicks;

            foreach(var def in DataLoader.PawnRelationDefs)
            {
                if (def.DefName.Equals(_relation.Def))
                {
                    comboBoxRelationDefs.SelectedItem = def;
                    break;
                }
            }

            numericUpDownStartTime.Value = _relation.StartTicks;
        }

        private void comboBoxRelations_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxRelationDefs_SelectedIndexChanged(object sender, EventArgs e)
        {
            _relation.Def = ((PawnRelationDef)comboBoxRelationDefs.SelectedItem).DefName;
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem != null)
            {
                setPawn((Pawn)listBox1.SelectedItem);
            }
        }

        private void listBoxRelations_Click(object sender, EventArgs e)
        {
            if (listBoxRelations.SelectedItem != null)
            {
                setRelation((Relation)listBoxRelations.SelectedItem);
            }
        }

        private void comboBoxFaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxFaction.SelectedItem != null)
            {
                comboBoxPawns.Items.Clear();
                Faction faction = (Faction)comboBoxFaction.SelectedItem;
                comboBoxPawns.Items.AddRange(DataLoader.PawnsByFactions[faction].ToArray());
                if(comboBoxPawns.Items.Count > 0)
                {
                    comboBoxPawns.SelectedIndex = 0;
                }
            }
        }

        private void btnAddRelation_Click(object sender, EventArgs e)
        {
            PawnRelationDef def = (PawnRelationDef)comboBoxRelations.SelectedItem;
            if(def != null)
            {
                Relation relation = _pawn.AddRelation(def);
                _pawnRelations.Add(relation);
                listBoxRelations.Refresh();
                listBoxRelations.SelectedItem = relation;
                setRelation(relation);
            }
        }

        private void btnRemoveRealtion_Click(object sender, EventArgs e)
        {
            Relation relation = (Relation)listBoxRelations.SelectedItem;
            if(relation != null)
            {
                _pawnRelations.Remove(relation);
                listBoxRelations.Refresh();
                if(_pawnRelations.Count > 0)
                {
                    listBoxRelations.SelectedIndex = 0;
                }
                _pawn.RemoveRelation(relation);
            }
        }

        private void comboBoxPawns_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_relation != null)
            {
                try
                {
                    Pawn pawn = (Pawn)comboBoxPawns.SelectedItem;
                    _relation.OtherPawn = pawn.PawnId;
                }
                catch (InvalidCastException)
                {
                    string pawnId = (string)comboBoxPawns.SelectedItem;
                    _relation.OtherPawn = pawnId;
                }
            }
        }

        private void numericUpDownStartTime_ValueChanged(object sender, EventArgs e)
        {
            if (_relation != null)
            {
                _relation.StartTicks = (long)numericUpDownStartTime.Value;
            }
        }
    }
}
