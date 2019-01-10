namespace RimWorldSaveManager.UserControls
{
    partial class GeneralPage
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.startingYearLabel = new System.Windows.Forms.Label();
            this.numericUpDownYear = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTicks = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownHour = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDay = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownSeason = new System.Windows.Forms.NumericUpDown();
            this.checkBoxIgnoreMaxHitPoints = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Actions = new System.Windows.Forms.GroupBox();
            this.buttonRemoveWornByCorpse = new System.Windows.Forms.Button();
            this.buttonGrowPlants = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBoxGroundItemQuality = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonGroundItemHP = new System.Windows.Forms.Button();
            this.buttonGroundItemQuality = new System.Windows.Forms.Button();
            this.buttonRemoveAllFilth = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBoxItemQuality = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonItemHP = new System.Windows.Forms.Button();
            this.buttonItemQuality = new System.Windows.Forms.Button();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.comboBoxBuildingQuality = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonBuildingHP = new System.Windows.Forms.Button();
            this.buttonBuildingQuality = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTicks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeason)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.Actions.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.startingYearLabel);
            this.groupBox1.Controls.Add(this.numericUpDownYear);
            this.groupBox1.Controls.Add(this.numericUpDownTicks);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.numericUpDownHour);
            this.groupBox1.Controls.Add(this.numericUpDownDay);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numericUpDownSeason);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 99);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gametime";
            // 
            // startingYearLabel
            // 
            this.startingYearLabel.AutoSize = true;
            this.startingYearLabel.Location = new System.Drawing.Point(80, 29);
            this.startingYearLabel.Name = "startingYearLabel";
            this.startingYearLabel.Size = new System.Drawing.Size(173, 13);
            this.startingYearLabel.TabIndex = 12;
            this.startingYearLabel.Text = "You can not go below starting time!";
            // 
            // numericUpDownYear
            // 
            this.numericUpDownYear.Location = new System.Drawing.Point(202, 69);
            this.numericUpDownYear.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownYear.Name = "numericUpDownYear";
            this.numericUpDownYear.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownYear.TabIndex = 11;
            this.numericUpDownYear.ValueChanged += new System.EventHandler(this.numericUpDownYear_ValueChanged);
            // 
            // numericUpDownTicks
            // 
            this.numericUpDownTicks.Location = new System.Drawing.Point(9, 69);
            this.numericUpDownTicks.Maximum = new decimal(new int[] {
            2501,
            0,
            0,
            0});
            this.numericUpDownTicks.Name = "numericUpDownTicks";
            this.numericUpDownTicks.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownTicks.TabIndex = 10;
            this.numericUpDownTicks.ValueChanged += new System.EventHandler(this.numericUpDownTicks_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(201, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Year";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Ticks";
            // 
            // numericUpDownHour
            // 
            this.numericUpDownHour.Location = new System.Drawing.Point(64, 69);
            this.numericUpDownHour.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDownHour.Name = "numericUpDownHour";
            this.numericUpDownHour.Size = new System.Drawing.Size(40, 20);
            this.numericUpDownHour.TabIndex = 7;
            this.numericUpDownHour.ValueChanged += new System.EventHandler(this.numericUpDownHour_ValueChanged);
            // 
            // numericUpDownDay
            // 
            this.numericUpDownDay.Location = new System.Drawing.Point(110, 69);
            this.numericUpDownDay.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDownDay.Name = "numericUpDownDay";
            this.numericUpDownDay.Size = new System.Drawing.Size(40, 20);
            this.numericUpDownDay.TabIndex = 6;
            this.numericUpDownDay.ValueChanged += new System.EventHandler(this.numericUpDownDay_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Hour";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(110, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Day";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Season";
            // 
            // numericUpDownSeason
            // 
            this.numericUpDownSeason.Location = new System.Drawing.Point(156, 69);
            this.numericUpDownSeason.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownSeason.Name = "numericUpDownSeason";
            this.numericUpDownSeason.Size = new System.Drawing.Size(40, 20);
            this.numericUpDownSeason.TabIndex = 0;
            this.numericUpDownSeason.ValueChanged += new System.EventHandler(this.numericUpDownSeason_ValueChanged);
            // 
            // checkBoxIgnoreMaxHitPoints
            // 
            this.checkBoxIgnoreMaxHitPoints.AutoSize = true;
            this.checkBoxIgnoreMaxHitPoints.Location = new System.Drawing.Point(9, 19);
            this.checkBoxIgnoreMaxHitPoints.Name = "checkBoxIgnoreMaxHitPoints";
            this.checkBoxIgnoreMaxHitPoints.Size = new System.Drawing.Size(175, 17);
            this.checkBoxIgnoreMaxHitPoints.TabIndex = 1;
            this.checkBoxIgnoreMaxHitPoints.Text = "Ignore max hitpoints for all items";
            this.checkBoxIgnoreMaxHitPoints.UseVisualStyleBackColor = true;
            this.checkBoxIgnoreMaxHitPoints.CheckedChanged += new System.EventHandler(this.checkBoxIgnoreMaxHitPoints_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxIgnoreMaxHitPoints);
            this.groupBox2.Location = new System.Drawing.Point(3, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 54);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Settings";
            // 
            // Actions
            // 
            this.Actions.Controls.Add(this.groupBox5);
            this.Actions.Controls.Add(this.buttonRemoveWornByCorpse);
            this.Actions.Controls.Add(this.buttonGrowPlants);
            this.Actions.Controls.Add(this.groupBox4);
            this.Actions.Controls.Add(this.buttonRemoveAllFilth);
            this.Actions.Controls.Add(this.groupBox3);
            this.Actions.Location = new System.Drawing.Point(3, 168);
            this.Actions.Name = "Actions";
            this.Actions.Size = new System.Drawing.Size(275, 419);
            this.Actions.TabIndex = 3;
            this.Actions.TabStop = false;
            this.Actions.Text = "Actions";
            // 
            // buttonRemoveWornByCorpse
            // 
            this.buttonRemoveWornByCorpse.Location = new System.Drawing.Point(9, 354);
            this.buttonRemoveWornByCorpse.Name = "buttonRemoveWornByCorpse";
            this.buttonRemoveWornByCorpse.Size = new System.Drawing.Size(237, 23);
            this.buttonRemoveWornByCorpse.TabIndex = 6;
            this.buttonRemoveWornByCorpse.Text = "Remove  \"Worn by corpse\"-Flag from all items";
            this.buttonRemoveWornByCorpse.UseVisualStyleBackColor = true;
            this.buttonRemoveWornByCorpse.Click += new System.EventHandler(this.buttonRemoveWornByCorpse_Click);
            // 
            // buttonGrowPlants
            // 
            this.buttonGrowPlants.Location = new System.Drawing.Point(9, 325);
            this.buttonGrowPlants.Name = "buttonGrowPlants";
            this.buttonGrowPlants.Size = new System.Drawing.Size(237, 23);
            this.buttonGrowPlants.TabIndex = 5;
            this.buttonGrowPlants.Text = "Full grow all plants";
            this.buttonGrowPlants.UseVisualStyleBackColor = true;
            this.buttonGrowPlants.Click += new System.EventHandler(this.buttonGrowPlants_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBoxGroundItemQuality);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.buttonGroundItemHP);
            this.groupBox4.Controls.Add(this.buttonGroundItemQuality);
            this.groupBox4.Location = new System.Drawing.Point(9, 121);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(249, 96);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ground Items";
            // 
            // comboBoxGroundItemQuality
            // 
            this.comboBoxGroundItemQuality.FormattingEnabled = true;
            this.comboBoxGroundItemQuality.Location = new System.Drawing.Point(10, 66);
            this.comboBoxGroundItemQuality.Name = "comboBoxGroundItemQuality";
            this.comboBoxGroundItemQuality.Size = new System.Drawing.Size(121, 21);
            this.comboBoxGroundItemQuality.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(174, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Set quality of all items on ground to:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Repair every item on ground";
            // 
            // buttonGroundItemHP
            // 
            this.buttonGroundItemHP.Location = new System.Drawing.Point(162, 19);
            this.buttonGroundItemHP.Name = "buttonGroundItemHP";
            this.buttonGroundItemHP.Size = new System.Drawing.Size(75, 23);
            this.buttonGroundItemHP.TabIndex = 0;
            this.buttonGroundItemHP.Text = "Set Hitpoints";
            this.buttonGroundItemHP.UseVisualStyleBackColor = true;
            this.buttonGroundItemHP.Click += new System.EventHandler(this.buttonGroundItemHP_Click);
            // 
            // buttonGroundItemQuality
            // 
            this.buttonGroundItemQuality.Location = new System.Drawing.Point(162, 66);
            this.buttonGroundItemQuality.Name = "buttonGroundItemQuality";
            this.buttonGroundItemQuality.Size = new System.Drawing.Size(75, 23);
            this.buttonGroundItemQuality.TabIndex = 1;
            this.buttonGroundItemQuality.Text = "Set Quality";
            this.buttonGroundItemQuality.UseVisualStyleBackColor = true;
            this.buttonGroundItemQuality.Click += new System.EventHandler(this.buttonGroundItemQuality_Click);
            // 
            // buttonRemoveAllFilth
            // 
            this.buttonRemoveAllFilth.Location = new System.Drawing.Point(9, 383);
            this.buttonRemoveAllFilth.Name = "buttonRemoveAllFilth";
            this.buttonRemoveAllFilth.Size = new System.Drawing.Size(237, 23);
            this.buttonRemoveAllFilth.TabIndex = 3;
            this.buttonRemoveAllFilth.Text = "Remove all filth";
            this.buttonRemoveAllFilth.UseVisualStyleBackColor = true;
            this.buttonRemoveAllFilth.Click += new System.EventHandler(this.buttonRemoveAllFilth_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBoxItemQuality);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.buttonItemHP);
            this.groupBox3.Controls.Add(this.buttonItemQuality);
            this.groupBox3.Location = new System.Drawing.Point(9, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(249, 96);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pawn Apparel/Equipment";
            // 
            // comboBoxItemQuality
            // 
            this.comboBoxItemQuality.FormattingEnabled = true;
            this.comboBoxItemQuality.Location = new System.Drawing.Point(10, 66);
            this.comboBoxItemQuality.Name = "comboBoxItemQuality";
            this.comboBoxItemQuality.Size = new System.Drawing.Size(121, 21);
            this.comboBoxItemQuality.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Set quality of all equiped items to:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Repair every equiped item";
            // 
            // buttonItemHP
            // 
            this.buttonItemHP.Location = new System.Drawing.Point(162, 19);
            this.buttonItemHP.Name = "buttonItemHP";
            this.buttonItemHP.Size = new System.Drawing.Size(75, 23);
            this.buttonItemHP.TabIndex = 0;
            this.buttonItemHP.Text = "Set Hitpoints";
            this.buttonItemHP.UseVisualStyleBackColor = true;
            this.buttonItemHP.Click += new System.EventHandler(this.buttonItemHP_Click);
            // 
            // buttonItemQuality
            // 
            this.buttonItemQuality.Location = new System.Drawing.Point(162, 66);
            this.buttonItemQuality.Name = "buttonItemQuality";
            this.buttonItemQuality.Size = new System.Drawing.Size(75, 23);
            this.buttonItemQuality.TabIndex = 1;
            this.buttonItemQuality.Text = "Set Quality";
            this.buttonItemQuality.UseVisualStyleBackColor = true;
            this.buttonItemQuality.Click += new System.EventHandler(this.buttonItemQuality_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.comboBoxBuildingQuality);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.buttonBuildingHP);
            this.groupBox5.Controls.Add(this.buttonBuildingQuality);
            this.groupBox5.Location = new System.Drawing.Point(9, 223);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(249, 96);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Buildings";
            // 
            // comboBoxBuildingQuality
            // 
            this.comboBoxBuildingQuality.FormattingEnabled = true;
            this.comboBoxBuildingQuality.Location = new System.Drawing.Point(10, 66);
            this.comboBoxBuildingQuality.Name = "comboBoxBuildingQuality";
            this.comboBoxBuildingQuality.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBuildingQuality.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Set quality of buildings";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Repair every building";
            // 
            // buttonBuildingHP
            // 
            this.buttonBuildingHP.Location = new System.Drawing.Point(162, 19);
            this.buttonBuildingHP.Name = "buttonBuildingHP";
            this.buttonBuildingHP.Size = new System.Drawing.Size(75, 23);
            this.buttonBuildingHP.TabIndex = 0;
            this.buttonBuildingHP.Text = "Set Hitpoints";
            this.buttonBuildingHP.UseVisualStyleBackColor = true;
            this.buttonBuildingHP.Click += new System.EventHandler(this.buttonBuildingHP_Click);
            // 
            // buttonBuildingQuality
            // 
            this.buttonBuildingQuality.Location = new System.Drawing.Point(162, 66);
            this.buttonBuildingQuality.Name = "buttonBuildingQuality";
            this.buttonBuildingQuality.Size = new System.Drawing.Size(75, 23);
            this.buttonBuildingQuality.TabIndex = 1;
            this.buttonBuildingQuality.Text = "Set Quality";
            this.buttonBuildingQuality.UseVisualStyleBackColor = true;
            this.buttonBuildingQuality.Click += new System.EventHandler(this.buttonBuildingQuality_Click);
            // 
            // GeneralPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Actions);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "GeneralPage";
            this.Size = new System.Drawing.Size(1235, 709);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTicks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeason)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.Actions.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDownYear;
        private System.Windows.Forms.NumericUpDown numericUpDownTicks;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownHour;
        private System.Windows.Forms.NumericUpDown numericUpDownDay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownSeason;
        private System.Windows.Forms.Label startingYearLabel;
        private System.Windows.Forms.CheckBox checkBoxIgnoreMaxHitPoints;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox Actions;
        private System.Windows.Forms.Button buttonItemQuality;
        private System.Windows.Forms.Button buttonItemHP;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBoxItemQuality;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRemoveAllFilth;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBoxGroundItemQuality;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonGroundItemHP;
        private System.Windows.Forms.Button buttonGroundItemQuality;
        private System.Windows.Forms.Button buttonGrowPlants;
        private System.Windows.Forms.Button buttonRemoveWornByCorpse;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox comboBoxBuildingQuality;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonBuildingHP;
        private System.Windows.Forms.Button buttonBuildingQuality;
    }
}
