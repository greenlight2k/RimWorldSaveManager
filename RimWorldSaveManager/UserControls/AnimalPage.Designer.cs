namespace RimWorldSaveManager.UserControls
{
    partial class AnimalPage
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.nameGroupBox = new System.Windows.Forms.GroupBox();
            this.textBoxNickname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ageGroupBox = new System.Windows.Forms.GroupBox();
            this.chronoAgeField = new System.Windows.Forms.NumericUpDown();
            this.bioAgeField = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRemoveInjury = new System.Windows.Forms.Button();
            this.listBoxInjuries = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDownTameness = new System.Windows.Forms.NumericUpDown();
            this.checkBoxTameness = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDownRescue = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHaul = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRelease = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownObedience = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBoxHaul = new System.Windows.Forms.CheckBox();
            this.checkBoxRescue = new System.Windows.Forms.CheckBox();
            this.checkBoxRelease = new System.Windows.Forms.CheckBox();
            this.checkBoxObedience = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelDefinition = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonCopyPawn = new System.Windows.Forms.Button();
            this.nameGroupBox.SuspendLayout();
            this.ageGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chronoAgeField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bioAgeField)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTameness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRescue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHaul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRelease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownObedience)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 35);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(240, 498);
            this.listBox1.TabIndex = 15;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            // 
            // nameGroupBox
            // 
            this.nameGroupBox.Controls.Add(this.textBoxNickname);
            this.nameGroupBox.Controls.Add(this.label5);
            this.nameGroupBox.Location = new System.Drawing.Point(246, 63);
            this.nameGroupBox.Name = "nameGroupBox";
            this.nameGroupBox.Size = new System.Drawing.Size(327, 59);
            this.nameGroupBox.TabIndex = 16;
            this.nameGroupBox.TabStop = false;
            this.nameGroupBox.Text = "Name";
            // 
            // textBoxNickname
            // 
            this.textBoxNickname.Location = new System.Drawing.Point(65, 22);
            this.textBoxNickname.Name = "textBoxNickname";
            this.textBoxNickname.Size = new System.Drawing.Size(100, 20);
            this.textBoxNickname.TabIndex = 4;
            this.textBoxNickname.TextChanged += new System.EventHandler(this.textBoxNickname_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Nickname";
            // 
            // ageGroupBox
            // 
            this.ageGroupBox.Controls.Add(this.chronoAgeField);
            this.ageGroupBox.Controls.Add(this.bioAgeField);
            this.ageGroupBox.Controls.Add(this.label2);
            this.ageGroupBox.Controls.Add(this.label1);
            this.ageGroupBox.Location = new System.Drawing.Point(246, 128);
            this.ageGroupBox.Name = "ageGroupBox";
            this.ageGroupBox.Size = new System.Drawing.Size(327, 79);
            this.ageGroupBox.TabIndex = 17;
            this.ageGroupBox.TabStop = false;
            this.ageGroupBox.Text = "Age";
            // 
            // chronoAgeField
            // 
            this.chronoAgeField.DecimalPlaces = 2;
            this.chronoAgeField.Location = new System.Drawing.Point(83, 42);
            this.chronoAgeField.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.chronoAgeField.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.chronoAgeField.Name = "chronoAgeField";
            this.chronoAgeField.Size = new System.Drawing.Size(65, 20);
            this.chronoAgeField.TabIndex = 3;
            this.chronoAgeField.ValueChanged += new System.EventHandler(this.chronoAgeField_ValueChanged);
            // 
            // bioAgeField
            // 
            this.bioAgeField.DecimalPlaces = 2;
            this.bioAgeField.Location = new System.Drawing.Point(83, 16);
            this.bioAgeField.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.bioAgeField.Name = "bioAgeField";
            this.bioAgeField.Size = new System.Drawing.Size(66, 20);
            this.bioAgeField.TabIndex = 2;
            this.bioAgeField.ValueChanged += new System.EventHandler(this.bioAgeField_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chronological";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Biological";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnRemoveInjury);
            this.groupBox3.Controls.Add(this.listBoxInjuries);
            this.groupBox3.Location = new System.Drawing.Point(573, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(275, 547);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Injuries";
            // 
            // btnRemoveInjury
            // 
            this.btnRemoveInjury.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveInjury.Location = new System.Drawing.Point(209, 516);
            this.btnRemoveInjury.Name = "btnRemoveInjury";
            this.btnRemoveInjury.Size = new System.Drawing.Size(60, 23);
            this.btnRemoveInjury.TabIndex = 2;
            this.btnRemoveInjury.Text = "Remove";
            this.btnRemoveInjury.UseVisualStyleBackColor = true;
            this.btnRemoveInjury.Click += new System.EventHandler(this.btnRemoveInjury_Click);
            // 
            // listBoxInjuries
            // 
            this.listBoxInjuries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxInjuries.FormattingEnabled = true;
            this.listBoxInjuries.Location = new System.Drawing.Point(6, 20);
            this.listBoxInjuries.Name = "listBoxInjuries";
            this.listBoxInjuries.Size = new System.Drawing.Size(263, 485);
            this.listBoxInjuries.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDownTameness);
            this.groupBox1.Controls.Add(this.checkBoxTameness);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.numericUpDownRescue);
            this.groupBox1.Controls.Add(this.numericUpDownHaul);
            this.groupBox1.Controls.Add(this.numericUpDownRelease);
            this.groupBox1.Controls.Add(this.numericUpDownObedience);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.checkBoxHaul);
            this.groupBox1.Controls.Add(this.checkBoxRescue);
            this.groupBox1.Controls.Add(this.checkBoxRelease);
            this.groupBox1.Controls.Add(this.checkBoxObedience);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(246, 213);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 178);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Training";
            // 
            // numericUpDownTameness
            // 
            this.numericUpDownTameness.Location = new System.Drawing.Point(124, 48);
            this.numericUpDownTameness.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownTameness.Name = "numericUpDownTameness";
            this.numericUpDownTameness.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownTameness.TabIndex = 16;
            this.numericUpDownTameness.ValueChanged += new System.EventHandler(this.numericUpDownTameness_ValueChanged);
            // 
            // checkBoxTameness
            // 
            this.checkBoxTameness.AutoSize = true;
            this.checkBoxTameness.Location = new System.Drawing.Point(83, 50);
            this.checkBoxTameness.Name = "checkBoxTameness";
            this.checkBoxTameness.Size = new System.Drawing.Size(15, 14);
            this.checkBoxTameness.TabIndex = 15;
            this.checkBoxTameness.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Tameness";
            // 
            // numericUpDownRescue
            // 
            this.numericUpDownRescue.Location = new System.Drawing.Point(124, 127);
            this.numericUpDownRescue.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownRescue.Name = "numericUpDownRescue";
            this.numericUpDownRescue.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownRescue.TabIndex = 13;
            this.numericUpDownRescue.ValueChanged += new System.EventHandler(this.numericUpDownRescue_ValueChanged);
            // 
            // numericUpDownHaul
            // 
            this.numericUpDownHaul.Location = new System.Drawing.Point(124, 153);
            this.numericUpDownHaul.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericUpDownHaul.Name = "numericUpDownHaul";
            this.numericUpDownHaul.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownHaul.TabIndex = 12;
            this.numericUpDownHaul.ValueChanged += new System.EventHandler(this.numericUpDownHaul_ValueChanged);
            // 
            // numericUpDownRelease
            // 
            this.numericUpDownRelease.Location = new System.Drawing.Point(124, 101);
            this.numericUpDownRelease.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownRelease.Name = "numericUpDownRelease";
            this.numericUpDownRelease.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownRelease.TabIndex = 11;
            this.numericUpDownRelease.ValueChanged += new System.EventHandler(this.numericUpDownRelease_ValueChanged);
            // 
            // numericUpDownObedience
            // 
            this.numericUpDownObedience.Location = new System.Drawing.Point(124, 75);
            this.numericUpDownObedience.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownObedience.Name = "numericUpDownObedience";
            this.numericUpDownObedience.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownObedience.TabIndex = 10;
            this.numericUpDownObedience.ValueChanged += new System.EventHandler(this.numericUpDownObedience_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(70, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Activated";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(130, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Steps";
            // 
            // checkBoxHaul
            // 
            this.checkBoxHaul.AutoSize = true;
            this.checkBoxHaul.Location = new System.Drawing.Point(83, 155);
            this.checkBoxHaul.Name = "checkBoxHaul";
            this.checkBoxHaul.Size = new System.Drawing.Size(15, 14);
            this.checkBoxHaul.TabIndex = 7;
            this.checkBoxHaul.UseVisualStyleBackColor = true;
            this.checkBoxHaul.CheckedChanged += new System.EventHandler(this.checkBoxHaul_CheckedChanged);
            // 
            // checkBoxRescue
            // 
            this.checkBoxRescue.AutoSize = true;
            this.checkBoxRescue.Location = new System.Drawing.Point(83, 129);
            this.checkBoxRescue.Name = "checkBoxRescue";
            this.checkBoxRescue.Size = new System.Drawing.Size(15, 14);
            this.checkBoxRescue.TabIndex = 6;
            this.checkBoxRescue.UseVisualStyleBackColor = true;
            this.checkBoxRescue.CheckedChanged += new System.EventHandler(this.checkBoxRescue_CheckedChanged);
            // 
            // checkBoxRelease
            // 
            this.checkBoxRelease.AutoSize = true;
            this.checkBoxRelease.Location = new System.Drawing.Point(83, 103);
            this.checkBoxRelease.Name = "checkBoxRelease";
            this.checkBoxRelease.Size = new System.Drawing.Size(15, 14);
            this.checkBoxRelease.TabIndex = 5;
            this.checkBoxRelease.UseVisualStyleBackColor = true;
            this.checkBoxRelease.CheckedChanged += new System.EventHandler(this.checkBoxRelease_CheckedChanged);
            // 
            // checkBoxObedience
            // 
            this.checkBoxObedience.AutoSize = true;
            this.checkBoxObedience.Location = new System.Drawing.Point(83, 77);
            this.checkBoxObedience.Name = "checkBoxObedience";
            this.checkBoxObedience.Size = new System.Drawing.Size(15, 14);
            this.checkBoxObedience.TabIndex = 4;
            this.checkBoxObedience.UseVisualStyleBackColor = true;
            this.checkBoxObedience.CheckedChanged += new System.EventHandler(this.checkBoxObedience_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Haul";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Rescue";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Release";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Obedience";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelDefinition);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(248, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(319, 54);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Infos";
            // 
            // labelDefinition
            // 
            this.labelDefinition.AutoSize = true;
            this.labelDefinition.Location = new System.Drawing.Point(68, 21);
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
            // buttonCopyPawn
            // 
            this.buttonCopyPawn.Location = new System.Drawing.Point(3, 6);
            this.buttonCopyPawn.Name = "buttonCopyPawn";
            this.buttonCopyPawn.Size = new System.Drawing.Size(239, 23);
            this.buttonCopyPawn.TabIndex = 21;
            this.buttonCopyPawn.Text = "Copy selected animal";
            this.buttonCopyPawn.UseVisualStyleBackColor = true;
            this.buttonCopyPawn.Click += new System.EventHandler(this.buttonCopyPawn_Click);
            // 
            // AnimalPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonCopyPawn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.ageGroupBox);
            this.Controls.Add(this.nameGroupBox);
            this.Controls.Add(this.listBox1);
            this.Name = "AnimalPage";
            this.Size = new System.Drawing.Size(848, 547);
            this.nameGroupBox.ResumeLayout(false);
            this.nameGroupBox.PerformLayout();
            this.ageGroupBox.ResumeLayout(false);
            this.ageGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chronoAgeField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bioAgeField)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTameness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRescue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHaul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRelease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownObedience)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox nameGroupBox;
        private System.Windows.Forms.TextBox textBoxNickname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox ageGroupBox;
        private System.Windows.Forms.NumericUpDown chronoAgeField;
        private System.Windows.Forms.NumericUpDown bioAgeField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnRemoveInjury;
        public System.Windows.Forms.ListBox listBoxInjuries;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownRescue;
        private System.Windows.Forms.NumericUpDown numericUpDownHaul;
        private System.Windows.Forms.NumericUpDown numericUpDownRelease;
        private System.Windows.Forms.NumericUpDown numericUpDownObedience;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBoxHaul;
        private System.Windows.Forms.CheckBox checkBoxRescue;
        private System.Windows.Forms.CheckBox checkBoxRelease;
        private System.Windows.Forms.CheckBox checkBoxObedience;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelDefinition;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDownTameness;
        private System.Windows.Forms.CheckBox checkBoxTameness;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonCopyPawn;
    }
}
