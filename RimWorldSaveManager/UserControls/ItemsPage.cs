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
    public partial class ItemsPage : UserControl
    {

        private BindingList<SaveThing> items = null;
        private SaveThing currentSaveThing = null;

        public ItemsPage()
        {
            InitializeComponent();

            labelDefinition.Text = "";
            labelID.Text = "";
            labelMap.Text = "";
            labelMaxHealth.Text = "";
            labelMaxStackSize.Text = "";
            labelPosition.Text = "";

            numericUpDownHealth.Maximum = int.MaxValue;
            numericUpDownHealth.Minimum = 0;
            numericUpDownStackCount.Maximum = int.MaxValue;
            numericUpDownStackCount.Minimum = 0;

            comboBoxQuality.DataSource = new List<string>(DataLoader.Quality);
            List<SaveThing> saveThingsToShow = new List<SaveThing>();
            if (DataLoader.SaveThingsByClass.TryGetValue("ThingWithComps", out var value))
            {
                saveThingsToShow.AddRange(value);
            }
            if (DataLoader.SaveThingsByClass.TryGetValue("Apparel", out value))
            {
                saveThingsToShow.AddRange(value);
            }
            if (DataLoader.SaveThingsByClass.TryGetValue("Medicine", out value))
            {
                saveThingsToShow.AddRange(value);
            }

            if (saveThingsToShow.Count > 0)
            {
                saveThingsToShow.Sort(Comparer<SaveThing>.Create((x, y) => string.Compare(x.ToString(), y.ToString())));
                items = new BindingList<SaveThing>(saveThingsToShow);
                listBoxItems.DataSource = items;
                listBoxItems.DisplayMember = "ToString";

                updatePage(items[0]);
            }
        }

        private void updatePage(SaveThing thing)
        {
            currentSaveThing = thing;
            labelDefinition.Text = thing.Def;
            labelID.Text = thing.Id;
            labelMap.Text = thing.Map;
            labelMaxHealth.Text = "" + thing.MaxHealth;
            labelMaxStackSize.Text = "" + thing.StackLimit;
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
                int maxHealth = (int)thing.MaxHealth;
                if (currentHealth > maxHealth)
                {
                    maxHealth = int.MaxValue;
                }
                numericUpDownHealth.Enabled = true;
                numericUpDownHealth.Maximum = maxHealth;
                numericUpDownHealth.Value = currentHealth;
            }
            else
            {
                numericUpDownHealth.Enabled = false;
            }

            if (thing.StackCount != null)
            {
                numericUpDownStackCount.Enabled = true;
                numericUpDownStackCount.Value = (decimal)thing.StackCount;
                if (thing.StackLimit == 1)
                {
                    numericUpDownStackCount.Enabled = false;
                }
            }
            else
            {
                numericUpDownStackCount.Enabled = false;
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

        private void listBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatePage(items[listBoxItems.SelectedIndex]);
        }

        private void comboBoxQuality_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentSaveThing != null)
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

        private void numericUpDownStackCount_ValueChanged(object sender, EventArgs e)
        {
            if (currentSaveThing != null)
            {
                currentSaveThing.StackCount = (int)numericUpDownStackCount.Value;
            }
        }

        private void comboBoxMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
