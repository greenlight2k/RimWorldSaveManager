namespace RimWorldSaveManager.UserControls
{
    partial class ItemsPage
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
            this.listBoxItems = new System.Windows.Forms.ListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.numericUpDownHealth = new System.Windows.Forms.NumericUpDown();
            this.comboBoxQuality = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelMap = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labelPosition = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelMaxStackSize = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelMaxHealth = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.labelID1 = new System.Windows.Forms.Label();
            this.labelDefinition = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxWornByCorpse = new System.Windows.Forms.CheckBox();
            this.comboBoxMaterial = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownStackCount = new System.Windows.Forms.NumericUpDown();
            this.groupBoxMinifiedStats = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBoxMinifiedMaterial = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxMinifiedQuality = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownMinifiedHealth = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.labelMinifiedMaxStackCount = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.labelMinifiedMaxHealth = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.labelMinifiedID = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.labelMinifiedDef = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHealth)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStackCount)).BeginInit();
            this.groupBoxMinifiedStats.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinifiedHealth)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxItems
            // 
            this.listBoxItems.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBoxItems.FormattingEnabled = true;
            this.listBoxItems.Location = new System.Drawing.Point(0, 0);
            this.listBoxItems.Name = "listBoxItems";
            this.listBoxItems.Size = new System.Drawing.Size(240, 591);
            this.listBoxItems.TabIndex = 16;
            this.listBoxItems.SelectedIndexChanged += new System.EventHandler(this.listBoxItems_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 46);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 13);
            this.label15.TabIndex = 20;
            this.label15.Text = "Health";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 13);
            this.label14.TabIndex = 19;
            this.label14.Text = "Quality";
            // 
            // numericUpDownHealth
            // 
            this.numericUpDownHealth.Location = new System.Drawing.Point(84, 44);
            this.numericUpDownHealth.Name = "numericUpDownHealth";
            this.numericUpDownHealth.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownHealth.TabIndex = 18;
            this.numericUpDownHealth.ValueChanged += new System.EventHandler(this.numericUpDownHealth_ValueChanged);
            // 
            // comboBoxQuality
            // 
            this.comboBoxQuality.FormattingEnabled = true;
            this.comboBoxQuality.Location = new System.Drawing.Point(85, 13);
            this.comboBoxQuality.Name = "comboBoxQuality";
            this.comboBoxQuality.Size = new System.Drawing.Size(119, 21);
            this.comboBoxQuality.TabIndex = 17;
            this.comboBoxQuality.SelectedIndexChanged += new System.EventHandler(this.comboBoxQuality_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelMap);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.labelPosition);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.labelMaxStackSize);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.labelMaxHealth);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.labelID);
            this.groupBox1.Controls.Add(this.labelID1);
            this.groupBox1.Controls.Add(this.labelDefinition);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(249, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 187);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Infos";
            // 
            // labelMap
            // 
            this.labelMap.AutoSize = true;
            this.labelMap.Location = new System.Drawing.Point(91, 65);
            this.labelMap.Name = "labelMap";
            this.labelMap.Size = new System.Drawing.Size(35, 13);
            this.labelMap.TabIndex = 11;
            this.labelMap.Text = "label9";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Map:";
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.Location = new System.Drawing.Point(91, 89);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(35, 13);
            this.labelPosition.TabIndex = 9;
            this.labelPosition.Text = "label8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Position:";
            // 
            // labelMaxStackSize
            // 
            this.labelMaxStackSize.AutoSize = true;
            this.labelMaxStackSize.Location = new System.Drawing.Point(91, 135);
            this.labelMaxStackSize.Name = "labelMaxStackSize";
            this.labelMaxStackSize.Size = new System.Drawing.Size(77, 13);
            this.labelMaxStackSize.TabIndex = 7;
            this.labelMaxStackSize.Text = "labelStackSize";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Max stack count:";
            // 
            // labelMaxHealth
            // 
            this.labelMaxHealth.AutoSize = true;
            this.labelMaxHealth.Location = new System.Drawing.Point(91, 112);
            this.labelMaxHealth.Name = "labelMaxHealth";
            this.labelMaxHealth.Size = new System.Drawing.Size(35, 13);
            this.labelMaxHealth.TabIndex = 5;
            this.labelMaxHealth.Text = "label8";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Max health:";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(91, 43);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(35, 13);
            this.labelID.TabIndex = 3;
            this.labelID.Text = "label8";
            // 
            // labelID1
            // 
            this.labelID1.AutoSize = true;
            this.labelID1.Location = new System.Drawing.Point(7, 43);
            this.labelID1.Name = "labelID1";
            this.labelID1.Size = new System.Drawing.Size(21, 13);
            this.labelID1.TabIndex = 2;
            this.labelID1.Text = "ID:";
            // 
            // labelDefinition
            // 
            this.labelDefinition.AutoSize = true;
            this.labelDefinition.Location = new System.Drawing.Point(91, 21);
            this.labelDefinition.Name = "labelDefinition";
            this.labelDefinition.Size = new System.Drawing.Size(35, 13);
            this.labelDefinition.TabIndex = 1;
            this.labelDefinition.Text = "label8";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Definition:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxWornByCorpse);
            this.groupBox2.Controls.Add(this.comboBoxMaterial);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.numericUpDownStackCount);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.comboBoxQuality);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.numericUpDownHealth);
            this.groupBox2.Location = new System.Drawing.Point(249, 196);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(313, 153);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // checkBoxWornByCorpse
            // 
            this.checkBoxWornByCorpse.AutoSize = true;
            this.checkBoxWornByCorpse.Location = new System.Drawing.Point(84, 124);
            this.checkBoxWornByCorpse.Name = "checkBoxWornByCorpse";
            this.checkBoxWornByCorpse.Size = new System.Drawing.Size(110, 17);
            this.checkBoxWornByCorpse.TabIndex = 25;
            this.checkBoxWornByCorpse.Text = "Worn by a corpse";
            this.checkBoxWornByCorpse.UseVisualStyleBackColor = true;
            this.checkBoxWornByCorpse.CheckedChanged += new System.EventHandler(this.checkBoxWornByCorpse_CheckedChanged);
            // 
            // comboBoxMaterial
            // 
            this.comboBoxMaterial.FormattingEnabled = true;
            this.comboBoxMaterial.Location = new System.Drawing.Point(84, 97);
            this.comboBoxMaterial.Name = "comboBoxMaterial";
            this.comboBoxMaterial.Size = new System.Drawing.Size(119, 21);
            this.comboBoxMaterial.TabIndex = 24;
            this.comboBoxMaterial.SelectedIndexChanged += new System.EventHandler(this.comboBoxMaterial_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 100);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 13);
            this.label16.TabIndex = 23;
            this.label16.Text = "Material";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "StackCount";
            // 
            // numericUpDownStackCount
            // 
            this.numericUpDownStackCount.Location = new System.Drawing.Point(85, 71);
            this.numericUpDownStackCount.Name = "numericUpDownStackCount";
            this.numericUpDownStackCount.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownStackCount.TabIndex = 21;
            this.numericUpDownStackCount.ValueChanged += new System.EventHandler(this.numericUpDownStackCount_ValueChanged);
            // 
            // groupBoxMinifiedStats
            // 
            this.groupBoxMinifiedStats.Controls.Add(this.groupBox4);
            this.groupBoxMinifiedStats.Controls.Add(this.groupBox5);
            this.groupBoxMinifiedStats.Location = new System.Drawing.Point(568, 3);
            this.groupBoxMinifiedStats.Name = "groupBoxMinifiedStats";
            this.groupBoxMinifiedStats.Size = new System.Drawing.Size(268, 293);
            this.groupBoxMinifiedStats.TabIndex = 23;
            this.groupBoxMinifiedStats.TabStop = false;
            this.groupBoxMinifiedStats.Text = "Minified stats";
            this.groupBoxMinifiedStats.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBoxMinifiedMaterial);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.comboBoxMinifiedQuality);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.numericUpDownMinifiedHealth);
            this.groupBox4.Location = new System.Drawing.Point(6, 155);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(256, 127);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Options";
            // 
            // comboBoxMinifiedMaterial
            // 
            this.comboBoxMinifiedMaterial.FormattingEnabled = true;
            this.comboBoxMinifiedMaterial.Location = new System.Drawing.Point(85, 76);
            this.comboBoxMinifiedMaterial.Name = "comboBoxMinifiedMaterial";
            this.comboBoxMinifiedMaterial.Size = new System.Drawing.Size(119, 21);
            this.comboBoxMinifiedMaterial.TabIndex = 24;
            this.comboBoxMinifiedMaterial.SelectedIndexChanged += new System.EventHandler(this.comboBoxMinifiedMaterial_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Material";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Quality";
            // 
            // comboBoxMinifiedQuality
            // 
            this.comboBoxMinifiedQuality.FormattingEnabled = true;
            this.comboBoxMinifiedQuality.Location = new System.Drawing.Point(85, 13);
            this.comboBoxMinifiedQuality.Name = "comboBoxMinifiedQuality";
            this.comboBoxMinifiedQuality.Size = new System.Drawing.Size(119, 21);
            this.comboBoxMinifiedQuality.TabIndex = 17;
            this.comboBoxMinifiedQuality.SelectedIndexChanged += new System.EventHandler(this.comboBoxMinifiedQuality_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Health";
            // 
            // numericUpDownMinifiedHealth
            // 
            this.numericUpDownMinifiedHealth.Location = new System.Drawing.Point(84, 44);
            this.numericUpDownMinifiedHealth.Name = "numericUpDownMinifiedHealth";
            this.numericUpDownMinifiedHealth.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownMinifiedHealth.TabIndex = 18;
            this.numericUpDownMinifiedHealth.ValueChanged += new System.EventHandler(this.numericUpDownMinifiedHealth_ValueChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.labelMinifiedMaxStackCount);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.labelMinifiedMaxHealth);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.labelMinifiedID);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.labelMinifiedDef);
            this.groupBox5.Controls.Add(this.label25);
            this.groupBox5.Location = new System.Drawing.Point(6, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(256, 130);
            this.groupBox5.TabIndex = 23;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Infos";
            // 
            // labelMinifiedMaxStackCount
            // 
            this.labelMinifiedMaxStackCount.AutoSize = true;
            this.labelMinifiedMaxStackCount.Location = new System.Drawing.Point(92, 94);
            this.labelMinifiedMaxStackCount.Name = "labelMinifiedMaxStackCount";
            this.labelMinifiedMaxStackCount.Size = new System.Drawing.Size(77, 13);
            this.labelMinifiedMaxStackCount.TabIndex = 7;
            this.labelMinifiedMaxStackCount.Text = "labelStackSize";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(8, 94);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(89, 13);
            this.label19.TabIndex = 6;
            this.label19.Text = "Max stack count:";
            // 
            // labelMinifiedMaxHealth
            // 
            this.labelMinifiedMaxHealth.AutoSize = true;
            this.labelMinifiedMaxHealth.Location = new System.Drawing.Point(92, 71);
            this.labelMinifiedMaxHealth.Name = "labelMinifiedMaxHealth";
            this.labelMinifiedMaxHealth.Size = new System.Drawing.Size(35, 13);
            this.labelMinifiedMaxHealth.TabIndex = 5;
            this.labelMinifiedMaxHealth.Text = "label8";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(8, 71);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(62, 13);
            this.label21.TabIndex = 4;
            this.label21.Text = "Max health:";
            // 
            // labelMinifiedID
            // 
            this.labelMinifiedID.AutoSize = true;
            this.labelMinifiedID.Location = new System.Drawing.Point(91, 43);
            this.labelMinifiedID.Name = "labelMinifiedID";
            this.labelMinifiedID.Size = new System.Drawing.Size(35, 13);
            this.labelMinifiedID.TabIndex = 3;
            this.labelMinifiedID.Text = "label8";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(7, 43);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(21, 13);
            this.label23.TabIndex = 2;
            this.label23.Text = "ID:";
            // 
            // labelMinifiedDef
            // 
            this.labelMinifiedDef.AutoSize = true;
            this.labelMinifiedDef.Location = new System.Drawing.Point(91, 21);
            this.labelMinifiedDef.Name = "labelMinifiedDef";
            this.labelMinifiedDef.Size = new System.Drawing.Size(35, 13);
            this.labelMinifiedDef.TabIndex = 1;
            this.labelMinifiedDef.Text = "label8";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(7, 21);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(54, 13);
            this.label25.TabIndex = 0;
            this.label25.Text = "Definition:";
            // 
            // ItemsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxMinifiedStats);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBoxItems);
            this.Name = "ItemsPage";
            this.Size = new System.Drawing.Size(1184, 591);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHealth)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStackCount)).EndInit();
            this.groupBoxMinifiedStats.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinifiedHealth)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxItems;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numericUpDownHealth;
        private System.Windows.Forms.ComboBox comboBoxQuality;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelMap;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelMaxStackSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelMaxHealth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelID1;
        private System.Windows.Forms.Label labelDefinition;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownStackCount;
        private System.Windows.Forms.ComboBox comboBoxMaterial;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox checkBoxWornByCorpse;
        private System.Windows.Forms.GroupBox groupBoxMinifiedStats;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBoxMinifiedMaterial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxMinifiedQuality;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownMinifiedHealth;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label labelMinifiedMaxStackCount;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label labelMinifiedMaxHealth;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label labelMinifiedID;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label labelMinifiedDef;
        private System.Windows.Forms.Label label25;
    }
}
