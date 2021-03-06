﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RimWorldSaveManager.Data.DataStructure;
using RimWorldSaveManager.Data.DataStructure.PawnInfo;
using RimWorldSaveManager.Data.DataStructure.SaveThings;

namespace RimWorldSaveManager.UserControls
{
    public partial class GeneralPage : UserControl
    {

        private Boolean initiated = false;
        List<Pawn> pawnList = null;
        public GeneralPage()
        {
            InitializeComponent();
            pawnList = DataLoader.PawnsByFactions[DataLoader.PlayerFaction].Where(p => p.Skills.Count != 0).ToList();
            comboBoxItemQuality.DataSource = new List<string>(DataLoader.Quality);
            comboBoxGroundItemQuality.DataSource = new List<string>(DataLoader.Quality);
            comboBoxBuildingQuality.DataSource = new List<string>(DataLoader.Quality);

            numericUpDownMaxHitMult.Value = DataLoader.MaxHitPointsMultiplikator;
            numericUpDownMaxStackCountMult.Value = DataLoader.MaxStackCountMultiplikator;

            setFields();
            initiated = true;
        }

        private void setFields()
        {
            long gameTime = DataLoader.GameData.GameTime;
            gameTime += DataLoader.GameData.GameStartAbsTick;
            gameTime += DataLoader.GameData.StartYear * 3600000;

            numericUpDownTicks.Value = gameTime % 2500 + 1;
            numericUpDownHour.Value = (gameTime % 60000) / 2500 + 1;
            numericUpDownDay.Value = gameTime % 900000 / 60000 + 1;
            numericUpDownSeason.Value = gameTime % 3600000 / 900000 + 1;
            numericUpDownYear.Value = gameTime / 3600000;
        }

        private void convertFields()
        {
            long gameTime = ((long)numericUpDownTicks.Value - 1);
            gameTime += ((long)numericUpDownHour.Value - 1) * 2500;
            gameTime += ((long)numericUpDownDay.Value - 1) * 60000;
            gameTime += ((long)numericUpDownSeason.Value - 1) * 900000;
            gameTime += ((long)numericUpDownYear.Value - DataLoader.GameData.StartYear) * 3600000;
            gameTime -= DataLoader.GameData.GameStartAbsTick;
            DataLoader.GameData.GameTime = gameTime;
        }

        private void numericUpDownTicks_ValueChanged(object sender, EventArgs e)
        {
            if (initiated)
            {
                convertFields();
                setFields();
            }
        }

        private void numericUpDownHour_ValueChanged(object sender, EventArgs e)
        {
            if (initiated)
            {
                convertFields();
                setFields();
            }
        }

        private void numericUpDownDay_ValueChanged(object sender, EventArgs e)
        {
            if (initiated)
            {
                convertFields();
                setFields();
            }
        }

        private void numericUpDownSeason_ValueChanged(object sender, EventArgs e)
        {
            if (initiated)
            {
                convertFields();
                setFields();
            }
        }

        private void numericUpDownYear_ValueChanged(object sender, EventArgs e)
        {
            if (initiated)
            {
                convertFields();
                setFields();
            }
        }

        private void buttonItemHP_Click(object sender, EventArgs e)
        {

            foreach (Pawn pawn in pawnList)
            {
                foreach (SaveThing apparel in pawn.Apparel)
                {
                    if (apparel.MaxHealth != null)
                    {
                        apparel.Health = (int)apparel.MaxHealth;
                    }
                }
            }
        }

        private void buttonItemQuality_Click(object sender, EventArgs e)
        {
            foreach (Pawn pawn in pawnList)
            {
                foreach (SaveThing apparel in pawn.Apparel)
                {
                    apparel.Quality = comboBoxItemQuality.SelectedItem.ToString();
                }
            }
        }

        private List<SaveThing> loadAllEditableItems()
        {
            List<SaveThing> editableItems = new List<SaveThing>();
            if (DataLoader.SaveThingsByClass.TryGetValue("ThingWithComps", out var value))
            {
                editableItems.AddRange(value);
            }
            if (DataLoader.SaveThingsByClass.TryGetValue("Apparel", out value))
            {
                editableItems.AddRange(value);
            }
            if (DataLoader.SaveThingsByClass.TryGetValue("Medicine", out value))
            {
                editableItems.AddRange(value);
            }
            if (DataLoader.SaveThingsByClass.TryGetValue("MinifiedThing", out value))
            {
                editableItems.AddRange(value);
                foreach(var minifiedThing in value)
                {
                    editableItems.Add(minifiedThing.MinifiedThing);
                }
            }
            if (DataLoader.SaveThingsByClass.TryGetValue("ShieldBelt", out value))
            {
                editableItems.AddRange(value);
            }
            return editableItems;
        }

        private void buttonGroundItemHP_Click(object sender, EventArgs e)
        {

            foreach (SaveThing saveThing in loadAllEditableItems())
            {
                if (saveThing.Health != null && saveThing.MaxHealth != null)
                {
                    saveThing.Health = (int)saveThing.MaxHealth;
                }
            }
        }

        private void buttonGroundItemQuality_Click(object sender, EventArgs e)
        {
            foreach (SaveThing saveThing in loadAllEditableItems())
            {
                saveThing.Quality = comboBoxGroundItemQuality.SelectedItem.ToString();
            }
        }

        private void buttonRemoveAllFilth_Click(object sender, EventArgs e)
        {
            if (DataLoader.SaveThingsByClass.TryGetValue("Filth", out var filthList))
            {
                while (filthList.Count > 0)
                {
                    filthList[0].Delete();
                    filthList.RemoveAt(0);
                }
            }
        }

        private void buttonGrowPlants_Click(object sender, EventArgs e)
        {
            if (DataLoader.SaveThingsByClass.TryGetValue("Plant", out var plantList))
            {
                foreach (var plant in plantList)
                {
                    plant.Growth = 1;
                }
            }
        }

        private void buttonRemoveWornByCorpse_Click(object sender, EventArgs e)
        {
            foreach (SaveThing saveThing in loadAllEditableItems())
            {
                saveThing.WornByCorpse = false;
            }
            DataLoader.itemsPage.Items.ResetBindings();
            foreach (Pawn pawn in pawnList)
            {
                foreach (SaveThing apparel in pawn.Apparel)
                {
                    if (apparel.MaxHealth != null)
                    {
                        apparel.WornByCorpse = false;
                    }
                }
            }
        }

        private void buttonBuildingHP_Click(object sender, EventArgs e)
        {
            if (DataLoader.SaveThingsByClass.TryGetValue("BuildingBase", out var buildingList))
            {
                foreach (var building in buildingList)
                {
                    building.Health = building.MaxHealth;
                }
            }
        }

        private void buttonBuildingQuality_Click(object sender, EventArgs e)
        {
            if (DataLoader.SaveThingsByClass.TryGetValue("BuildingBase", out var buildingList))
            {
                foreach (var building in buildingList)
                {
                    building.Quality = comboBoxBuildingQuality.SelectedItem.ToString();
                }
            }
        }

        private void buttonSetStacks_Click(object sender, EventArgs e)
        {
            foreach (SaveThing saveThing in loadAllEditableItems())
            {
                saveThing.StackCount = saveThing.StackLimit;
            }
        }

        private void numericUpDownMaxHitMult_ValueChanged(object sender, EventArgs e)
        {
            DataLoader.MaxHitPointsMultiplikator = numericUpDownMaxHitMult.Value;
        }

        private void numericUpDownMaxStackCountMult_ValueChanged(object sender, EventArgs e)
        {
            DataLoader.MaxStackCountMultiplikator = numericUpDownMaxStackCountMult.Value;
        }
    }
}
