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
        private SaveThing currentMinifiedSaveThing = null;

        public BindingList<SaveThing> Items { get => items; }

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
            comboBoxMinifiedQuality.DataSource = new List<string>(DataLoader.Quality);
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
            if (DataLoader.SaveThingsByClass.TryGetValue("MinifiedThing", out value))
            {
                saveThingsToShow.AddRange(value);
            }
            if (DataLoader.SaveThingsByClass.TryGetValue("ShieldBelt", out value))
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
            if (currentSaveThing.Class == "Apparel")
            {
                checkBoxWornByCorpse.Enabled = true;
                checkBoxWornByCorpse.Checked = currentSaveThing.WornByCorpse;
            }
            else
            {
                checkBoxWornByCorpse.Enabled = false;
            }

            if (thing.Class == "MinifiedThing")
            {
                currentMinifiedSaveThing = thing.MinifiedThing;

                groupBoxMinifiedStats.Visible = true;

                labelMinifiedDef.Text = currentMinifiedSaveThing.Def;
                labelMinifiedID.Text = currentMinifiedSaveThing.Id;
                labelMinifiedMaxHealth.Text = "" + currentMinifiedSaveThing.MaxHealth;
                labelMinifiedMaxStackCount.Text = "" + currentMinifiedSaveThing.StackLimit;

                if (currentMinifiedSaveThing.Quality != null)
                {
                    comboBoxMinifiedQuality.Enabled = true;
                    comboBoxMinifiedQuality.SelectedItem = currentMinifiedSaveThing.Quality;
                }
                else
                {
                    comboBoxMinifiedQuality.Enabled = false;
                }

                if (currentMinifiedSaveThing.Health != null)
                {
                    decimal currentHealth = (decimal)currentMinifiedSaveThing.Health;
                    int maxHealth = (int)currentMinifiedSaveThing.MaxHealth;
                    if (currentHealth > maxHealth)
                    {
                        maxHealth = int.MaxValue;
                    }
                    numericUpDownMinifiedHealth.Enabled = true;
                    numericUpDownMinifiedHealth.Maximum = maxHealth;
                    numericUpDownMinifiedHealth.Value = currentHealth;
                }
                else
                {
                    numericUpDownMinifiedHealth.Enabled = false;
                }

                List<ThingDef> availableMaterialsMinified = new List<ThingDef>();
                if (currentMinifiedSaveThing.BaseThing != null)
                {
                    foreach (var thingCategories in currentMinifiedSaveThing.BaseThing.ReciepStuffCategories)
                    {
                        if (DataLoader.ThingDefsByStuffCategory.TryGetValue(thingCategories, out var thingDefList))
                        {
                            availableMaterialsMinified.AddRange(thingDefList);
                        }
                    }
                }

                comboBoxMinifiedMaterial.Items.Clear();
                comboBoxMinifiedMaterial.Items.AddRange(availableMaterialsMinified.ToArray());
                if (availableMaterialsMinified.Count == 0)
                {
                    comboBoxMinifiedMaterial.SelectedItem = null;
                    comboBoxMinifiedMaterial.Enabled = false;
                }
                else
                {
                    comboBoxMinifiedMaterial.Enabled = true;
                    comboBoxMinifiedMaterial.SelectedItem = currentMinifiedSaveThing.StuffBaseThing;
                }
            }
            else
            {
                groupBoxMinifiedStats.Visible = false;
            }
        }

        private void listBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxItems.SelectedIndex > 0)
            {
                updatePage(items[listBoxItems.SelectedIndex]);
            }
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
            ThingDef baseSaveThing = (ThingDef)comboBoxMaterial.SelectedItem;

            if (currentSaveThing != null && baseSaveThing != null)
            {
                currentSaveThing.StuffBaseThing = baseSaveThing;
                currentSaveThing.Stuff = baseSaveThing.DefName;
            }

        }

        private void checkBoxWornByCorpse_CheckedChanged(object sender, EventArgs e)
        {
            var currentThing = currentSaveThing;
            currentSaveThing.WornByCorpse = checkBoxWornByCorpse.Checked;
            items.ResetItem(items.IndexOf(currentThing));
        }

        private void comboBoxMinifiedQuality_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentMinifiedSaveThing != null)
            {
                currentMinifiedSaveThing.Quality = comboBoxMinifiedQuality.SelectedItem.ToString();
            }
        }

        private void numericUpDownMinifiedHealth_ValueChanged(object sender, EventArgs e)
        {
            if (currentMinifiedSaveThing != null)
            {
                currentMinifiedSaveThing.Health = (int)numericUpDownMinifiedHealth.Value;
            }
        }

        private void comboBoxMinifiedMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThingDef baseSaveThing = (ThingDef)comboBoxMinifiedMaterial.SelectedItem;
            if (currentMinifiedSaveThing != null && baseSaveThing != null)
            {
                currentMinifiedSaveThing.StuffBaseThing = baseSaveThing;
                currentMinifiedSaveThing.Stuff = baseSaveThing.DefName;
            }
        }

    }
}
