using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RimWorldSaveManager.Data.DataStructure.SaveThings;
using RimWorldSaveManager.Data.DataStructure.Defs;

namespace RimWorldSaveManager.UserControls
{
    public partial class BuildingsPage : UserControl
    {

        private BindingList<SaveThing> buildings = null;
        private SaveThing currentSaveThing = null;

        public BuildingsPage()
        {
            InitializeComponent();


            labelDefinition.Text = "";
            labelID.Text = "";
            labelMap.Text = "";
            labelMaxHealth.Text = "";
            labelPosition.Text = "";

            numericUpDownHealth.Maximum = int.MaxValue;
            numericUpDownHealth.Minimum = 0;

            comboBoxQuality.DataSource = new List<string>(DataLoader.Quality);
            List<SaveThing> saveThingsToShow = new List<SaveThing>();

            List<String> classesToLoad = new List<string>();


            if (DataLoader.SaveThingsByClass.TryGetValue("BuildingBase", out var value))
            {
                saveThingsToShow.AddRange(value);
            }

            if (saveThingsToShow.Count > 0)
            {
                saveThingsToShow.Sort(Comparer<SaveThing>.Create((x, y) => string.Compare(x.ToString(), y.ToString())));
                buildings = new BindingList<SaveThing>(saveThingsToShow);
                listBoxBuildings.DataSource = buildings;
                listBoxBuildings.DisplayMember = "ToString";

                updatePage(buildings[0]);
            }
        }

        private void updatePage(SaveThing thing)
        {
            currentSaveThing = thing;
            labelDefinition.Text = thing.Def;
            labelID.Text = thing.Id;
            labelMap.Text = thing.Map;
            labelMaxHealth.Text = "" + thing.MaxHealth;
            labelPosition.Text = thing.Pos;

            if (thing.Quality != null)
            {
                comboBoxQuality.Enabled = true;
                comboBoxQuality.SelectedItem = thing.Quality;
            }
            else
            {
                comboBoxQuality.Enabled = false;
            }

            if (thing.Health != null)
            {
                decimal currentHealth = (decimal)thing.Health;
                int? maxHealth = thing.MaxHealth;
                if (maxHealth == null || currentHealth > maxHealth)
                {
                    maxHealth = int.MaxValue;
                }
                numericUpDownHealth.Enabled = true;
                numericUpDownHealth.Maximum = (int)maxHealth;
                numericUpDownHealth.Value = currentHealth;
            }
            else
            {
                numericUpDownHealth.Enabled = false;
            }

            List<ThingDef> availableMaterials = new List<ThingDef>();
            if (thing.BaseThing != null)
            {
                foreach (var thingCategories in thing.BaseThing.ReciepStuffCategories)
                {
                    if (DataLoader.ThingDefsByStuffCategory.TryGetValue(thingCategories, out var thingDefList))
                    {
                        availableMaterials.AddRange(thingDefList);
                    }
                }
            }

            comboBoxMaterial.Items.Clear();
            comboBoxMaterial.Items.AddRange(availableMaterials.ToArray());
            if (availableMaterials.Count == 0)
            {
                comboBoxMaterial.SelectedItem = null;
                comboBoxMaterial.Enabled = false;
            }
            else
            {
                comboBoxMaterial.Enabled = true;
                comboBoxMaterial.SelectedItem = thing.StuffBaseThing;
            }
        }

        private void comboBoxQuality_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(currentSaveThing != null)
            {
                currentSaveThing.Quality = comboBoxQuality.SelectedItem.ToString();
            }
        }

        private void numericUpDownHealth_ValueChanged(object sender, EventArgs e)
        {
            if (currentSaveThing != null)
            {
                currentSaveThing.Health = (int)numericUpDownHealth.Value;
            }
        }

        private void comboBoxMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThingDef stuffDef = (ThingDef)comboBoxMaterial.SelectedItem;

            if (currentSaveThing != null && stuffDef != null)
            {
                currentSaveThing.Stuff = stuffDef.DefName;
                currentSaveThing.StuffBaseThing = stuffDef;
            }
        }

        private void listBoxBuildings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxBuildings.SelectedIndex > 0)
            {
                updatePage(buildings[listBoxBuildings.SelectedIndex]);
            }
        }
    }
}
