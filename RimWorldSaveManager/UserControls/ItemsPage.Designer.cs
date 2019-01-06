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
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownStackCount = new System.Windows.Forms.NumericUpDown();
            this.comboBoxMaterial = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHealth)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStackCount)).BeginInit();
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
            this.groupBox2.Size = new System.Drawing.Size(313, 308);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
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
            // ItemsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBoxItems);
            this.Name = "ItemsPage";
            this.Size = new System.Drawing.Size(823, 591);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHealth)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStackCount)).EndInit();
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
    }
}
