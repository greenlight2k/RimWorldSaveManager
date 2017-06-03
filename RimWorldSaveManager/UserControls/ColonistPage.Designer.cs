namespace RimWorldSaveManager.UserControls
{
    partial class ColonistPage
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
            this.skillsGroupBox = new System.Windows.Forms.GroupBox();
            this.ageGroupBox = new System.Windows.Forms.GroupBox();
            this.chronoAgeField = new System.Windows.Forms.NumericUpDown();
            this.bioAgeField = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.adulthoodComboBox = new System.Windows.Forms.ComboBox();
            this.childhoodComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.traitComboBox = new System.Windows.Forms.ComboBox();
            this.btnRemoveTrait = new System.Windows.Forms.Button();
            this.btnAddTrait = new System.Windows.Forms.Button();
            this.listBoxTraits = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRemoveInjury = new System.Windows.Forms.Button();
            this.listBoxInjuries = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.DescriptionText = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.nameGroupBox = new System.Windows.Forms.GroupBox();
            this.textBoxLastname = new System.Windows.Forms.TextBox();
            this.textBoxNickname = new System.Windows.Forms.TextBox();
            this.textBoxFirstname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.labelDefinition = new System.Windows.Forms.Label();
            this.ageGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chronoAgeField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bioAgeField)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.nameGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // skillsGroupBox
            // 
            this.skillsGroupBox.Location = new System.Drawing.Point(187, 66);
            this.skillsGroupBox.Name = "skillsGroupBox";
            this.skillsGroupBox.Size = new System.Drawing.Size(313, 549);
            this.skillsGroupBox.TabIndex = 1;
            this.skillsGroupBox.TabStop = false;
            this.skillsGroupBox.Text = "Skills";
            // 
            // ageGroupBox
            // 
            this.ageGroupBox.Controls.Add(this.chronoAgeField);
            this.ageGroupBox.Controls.Add(this.bioAgeField);
            this.ageGroupBox.Controls.Add(this.label2);
            this.ageGroupBox.Controls.Add(this.label1);
            this.ageGroupBox.Location = new System.Drawing.Point(509, 112);
            this.ageGroupBox.Name = "ageGroupBox";
            this.ageGroupBox.Size = new System.Drawing.Size(386, 76);
            this.ageGroupBox.TabIndex = 2;
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
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.adulthoodComboBox);
            this.groupBox4.Controls.Add(this.childhoodComboBox);
            this.groupBox4.Location = new System.Drawing.Point(509, 194);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(385, 91);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Backstory";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Adulthood";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Childhood";
            // 
            // adulthoodComboBox
            // 
            this.adulthoodComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.adulthoodComboBox.DropDownHeight = 400;
            this.adulthoodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.adulthoodComboBox.DropDownWidth = 200;
            this.adulthoodComboBox.FormattingEnabled = true;
            this.adulthoodComboBox.IntegralHeight = false;
            this.adulthoodComboBox.Location = new System.Drawing.Point(83, 46);
            this.adulthoodComboBox.Name = "adulthoodComboBox";
            this.adulthoodComboBox.Size = new System.Drawing.Size(296, 21);
            this.adulthoodComboBox.TabIndex = 1;
            this.adulthoodComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Backstory_DrawItem);
            this.adulthoodComboBox.SelectedIndexChanged += new System.EventHandler(this.backstoryComboBox_SelectedIndexChanged);
            this.adulthoodComboBox.DropDownClosed += new System.EventHandler(this.DropDownClosed);
            // 
            // childhoodComboBox
            // 
            this.childhoodComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.childhoodComboBox.DropDownHeight = 400;
            this.childhoodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.childhoodComboBox.DropDownWidth = 200;
            this.childhoodComboBox.FormattingEnabled = true;
            this.childhoodComboBox.IntegralHeight = false;
            this.childhoodComboBox.Location = new System.Drawing.Point(83, 19);
            this.childhoodComboBox.Name = "childhoodComboBox";
            this.childhoodComboBox.Size = new System.Drawing.Size(296, 21);
            this.childhoodComboBox.TabIndex = 0;
            this.childhoodComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Backstory_DrawItem);
            this.childhoodComboBox.SelectedIndexChanged += new System.EventHandler(this.backstoryComboBox_SelectedIndexChanged);
            this.childhoodComboBox.DropDownClosed += new System.EventHandler(this.DropDownClosed);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.traitComboBox);
            this.groupBox2.Controls.Add(this.btnRemoveTrait);
            this.groupBox2.Controls.Add(this.btnAddTrait);
            this.groupBox2.Controls.Add(this.listBoxTraits);
            this.groupBox2.Location = new System.Drawing.Point(902, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(353, 188);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Traits";
            // 
            // traitComboBox
            // 
            this.traitComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.traitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.traitComboBox.FormattingEnabled = true;
            this.traitComboBox.Location = new System.Drawing.Point(7, 158);
            this.traitComboBox.Name = "traitComboBox";
            this.traitComboBox.Size = new System.Drawing.Size(208, 21);
            this.traitComboBox.TabIndex = 3;
            // 
            // btnRemoveTrait
            // 
            this.btnRemoveTrait.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveTrait.Location = new System.Drawing.Point(287, 157);
            this.btnRemoveTrait.Name = "btnRemoveTrait";
            this.btnRemoveTrait.Size = new System.Drawing.Size(60, 23);
            this.btnRemoveTrait.TabIndex = 2;
            this.btnRemoveTrait.Text = "Remove";
            this.btnRemoveTrait.UseVisualStyleBackColor = true;
            this.btnRemoveTrait.Click += new System.EventHandler(this.btnRemoveTrait_Click);
            // 
            // btnAddTrait
            // 
            this.btnAddTrait.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTrait.Location = new System.Drawing.Point(221, 157);
            this.btnAddTrait.Name = "btnAddTrait";
            this.btnAddTrait.Size = new System.Drawing.Size(60, 23);
            this.btnAddTrait.TabIndex = 1;
            this.btnAddTrait.Text = "Add";
            this.btnAddTrait.UseVisualStyleBackColor = true;
            this.btnAddTrait.Click += new System.EventHandler(this.btnAddTrait_Click);
            // 
            // listBoxTraits
            // 
            this.listBoxTraits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxTraits.FormattingEnabled = true;
            this.listBoxTraits.Location = new System.Drawing.Point(6, 14);
            this.listBoxTraits.Name = "listBoxTraits";
            this.listBoxTraits.Size = new System.Drawing.Size(347, 134);
            this.listBoxTraits.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.btnRemoveInjury);
            this.groupBox3.Controls.Add(this.listBoxInjuries);
            this.groupBox3.Location = new System.Drawing.Point(509, 291);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(386, 499);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Injuries";
            // 
            // btnRemoveInjury
            // 
            this.btnRemoveInjury.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveInjury.Location = new System.Drawing.Point(320, 468);
            this.btnRemoveInjury.Name = "btnRemoveInjury";
            this.btnRemoveInjury.Size = new System.Drawing.Size(60, 23);
            this.btnRemoveInjury.TabIndex = 2;
            this.btnRemoveInjury.Text = "Remove";
            this.btnRemoveInjury.UseVisualStyleBackColor = true;
            this.btnRemoveInjury.Click += new System.EventHandler(this.btnRemoveInjury_Click);
            // 
            // listBoxInjuries
            // 
            this.listBoxInjuries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxInjuries.FormattingEnabled = true;
            this.listBoxInjuries.Location = new System.Drawing.Point(7, 20);
            this.listBoxInjuries.Name = "listBoxInjuries";
            this.listBoxInjuries.Size = new System.Drawing.Size(372, 446);
            this.listBoxInjuries.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.DescriptionText);
            this.groupBox5.Location = new System.Drawing.Point(902, 194);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox5.Size = new System.Drawing.Size(361, 596);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Description";
            // 
            // DescriptionText
            // 
            this.DescriptionText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionText.BackColor = System.Drawing.SystemColors.Window;
            this.DescriptionText.Location = new System.Drawing.Point(5, 18);
            this.DescriptionText.Multiline = true;
            this.DescriptionText.Name = "DescriptionText";
            this.DescriptionText.ReadOnly = true;
            this.DescriptionText.Size = new System.Drawing.Size(351, 570);
            this.DescriptionText.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(181, 784);
            this.listBox1.TabIndex = 14;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            // 
            // nameGroupBox
            // 
            this.nameGroupBox.Controls.Add(this.textBoxLastname);
            this.nameGroupBox.Controls.Add(this.textBoxNickname);
            this.nameGroupBox.Controls.Add(this.textBoxFirstname);
            this.nameGroupBox.Controls.Add(this.label5);
            this.nameGroupBox.Controls.Add(this.label4);
            this.nameGroupBox.Controls.Add(this.label3);
            this.nameGroupBox.Location = new System.Drawing.Point(509, 3);
            this.nameGroupBox.Name = "nameGroupBox";
            this.nameGroupBox.Size = new System.Drawing.Size(386, 100);
            this.nameGroupBox.TabIndex = 15;
            this.nameGroupBox.TabStop = false;
            this.nameGroupBox.Text = "Name";
            // 
            // textBoxLastname
            // 
            this.textBoxLastname.Location = new System.Drawing.Point(83, 70);
            this.textBoxLastname.Name = "textBoxLastname";
            this.textBoxLastname.Size = new System.Drawing.Size(141, 20);
            this.textBoxLastname.TabIndex = 5;
            this.textBoxLastname.TextChanged += new System.EventHandler(this.textBoxLastname_TextChanged);
            // 
            // textBoxNickname
            // 
            this.textBoxNickname.Location = new System.Drawing.Point(83, 44);
            this.textBoxNickname.Name = "textBoxNickname";
            this.textBoxNickname.Size = new System.Drawing.Size(141, 20);
            this.textBoxNickname.TabIndex = 4;
            this.textBoxNickname.TextChanged += new System.EventHandler(this.textBoxNickname_TextChanged);
            // 
            // textBoxFirstname
            // 
            this.textBoxFirstname.Location = new System.Drawing.Point(83, 18);
            this.textBoxFirstname.Name = "textBoxFirstname";
            this.textBoxFirstname.Size = new System.Drawing.Size(141, 20);
            this.textBoxFirstname.TabIndex = 3;
            this.textBoxFirstname.TextChanged += new System.EventHandler(this.textBoxFirstname_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Nickname";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Lastname";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Firstname";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelDefinition);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(187, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 54);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Infos";
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
            // labelDefinition
            // 
            this.labelDefinition.AutoSize = true;
            this.labelDefinition.Location = new System.Drawing.Point(68, 21);
            this.labelDefinition.Name = "labelDefinition";
            this.labelDefinition.Size = new System.Drawing.Size(35, 13);
            this.labelDefinition.TabIndex = 1;
            this.labelDefinition.Text = "label8";
            // 
            // ColonistPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.nameGroupBox);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.ageGroupBox);
            this.Controls.Add(this.skillsGroupBox);
            this.Name = "ColonistPage";
            this.Size = new System.Drawing.Size(1266, 793);
            this.ageGroupBox.ResumeLayout(false);
            this.ageGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chronoAgeField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bioAgeField)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.nameGroupBox.ResumeLayout(false);
            this.nameGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox skillsGroupBox;
        private System.Windows.Forms.GroupBox ageGroupBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox adulthoodComboBox;
        private System.Windows.Forms.ComboBox childhoodComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox traitComboBox;
        private System.Windows.Forms.Button btnRemoveTrait;
        private System.Windows.Forms.Button btnAddTrait;
        public System.Windows.Forms.ListBox listBoxTraits;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnRemoveInjury;
        public System.Windows.Forms.ListBox listBoxInjuries;
        private System.Windows.Forms.NumericUpDown chronoAgeField;
        private System.Windows.Forms.NumericUpDown bioAgeField;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox DescriptionText;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox nameGroupBox;
        private System.Windows.Forms.TextBox textBoxLastname;
        private System.Windows.Forms.TextBox textBoxNickname;
        private System.Windows.Forms.TextBox textBoxFirstname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelDefinition;
    }
}
