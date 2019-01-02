using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RimWorldSaveManager.UserControls
{
    public partial class GameDataPage : UserControl
    {

        private Boolean initiated = false;

        public GameDataPage()
        {
            InitializeComponent();
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
            long gameTime = ((long)numericUpDownTicks.Value -1);
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
    }
}
