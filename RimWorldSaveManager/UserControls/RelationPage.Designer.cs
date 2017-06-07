namespace RimWorldSaveManager.UserControls
{
    partial class RelationPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RelationPage));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxRelations = new System.Windows.Forms.ComboBox();
            this.btnRemoveRealtion = new System.Windows.Forms.Button();
            this.btnAddRelation = new System.Windows.Forms.Button();
            this.listBoxRelations = new System.Windows.Forms.ListBox();
            this.comboBoxFaction = new System.Windows.Forms.ComboBox();
            this.groupBoxRelation = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownStartTime = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxRelationDefs = new System.Windows.Forms.ComboBox();
            this.comboBoxPawns = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.DescriptionText = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBoxRelation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartTime)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 26);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(181, 745);
            this.listBox1.TabIndex = 15;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Pawns";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxRelations);
            this.groupBox2.Controls.Add(this.btnRemoveRealtion);
            this.groupBox2.Controls.Add(this.btnAddRelation);
            this.groupBox2.Controls.Add(this.listBoxRelations);
            this.groupBox2.Location = new System.Drawing.Point(187, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(356, 393);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Relations";
            // 
            // comboBoxRelations
            // 
            this.comboBoxRelations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxRelations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRelations.FormattingEnabled = true;
            this.comboBoxRelations.Location = new System.Drawing.Point(7, 363);
            this.comboBoxRelations.Name = "comboBoxRelations";
            this.comboBoxRelations.Size = new System.Drawing.Size(211, 21);
            this.comboBoxRelations.TabIndex = 3;
            this.comboBoxRelations.SelectedIndexChanged += new System.EventHandler(this.comboBoxRelations_SelectedIndexChanged);
            // 
            // btnRemoveRealtion
            // 
            this.btnRemoveRealtion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveRealtion.Location = new System.Drawing.Point(290, 362);
            this.btnRemoveRealtion.Name = "btnRemoveRealtion";
            this.btnRemoveRealtion.Size = new System.Drawing.Size(60, 23);
            this.btnRemoveRealtion.TabIndex = 2;
            this.btnRemoveRealtion.Text = "Remove";
            this.btnRemoveRealtion.UseVisualStyleBackColor = true;
            this.btnRemoveRealtion.Click += new System.EventHandler(this.btnRemoveRealtion_Click);
            // 
            // btnAddRelation
            // 
            this.btnAddRelation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRelation.Location = new System.Drawing.Point(224, 362);
            this.btnAddRelation.Name = "btnAddRelation";
            this.btnAddRelation.Size = new System.Drawing.Size(60, 23);
            this.btnAddRelation.TabIndex = 1;
            this.btnAddRelation.Text = "Add";
            this.btnAddRelation.UseVisualStyleBackColor = true;
            this.btnAddRelation.Click += new System.EventHandler(this.btnAddRelation_Click);
            // 
            // listBoxRelations
            // 
            this.listBoxRelations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxRelations.FormattingEnabled = true;
            this.listBoxRelations.Location = new System.Drawing.Point(6, 14);
            this.listBoxRelations.Name = "listBoxRelations";
            this.listBoxRelations.Size = new System.Drawing.Size(350, 329);
            this.listBoxRelations.TabIndex = 0;
            this.listBoxRelations.Click += new System.EventHandler(this.listBoxRelations_Click);
            // 
            // comboBoxFaction
            // 
            this.comboBoxFaction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxFaction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFaction.FormattingEnabled = true;
            this.comboBoxFaction.Location = new System.Drawing.Point(86, 78);
            this.comboBoxFaction.Name = "comboBoxFaction";
            this.comboBoxFaction.Size = new System.Drawing.Size(155, 21);
            this.comboBoxFaction.TabIndex = 4;
            this.comboBoxFaction.SelectedIndexChanged += new System.EventHandler(this.comboBoxFaction_SelectedIndexChanged);
            // 
            // groupBoxRelation
            // 
            this.groupBoxRelation.Controls.Add(this.label6);
            this.groupBoxRelation.Controls.Add(this.numericUpDownStartTime);
            this.groupBoxRelation.Controls.Add(this.label5);
            this.groupBoxRelation.Controls.Add(this.label4);
            this.groupBoxRelation.Controls.Add(this.label3);
            this.groupBoxRelation.Controls.Add(this.label2);
            this.groupBoxRelation.Controls.Add(this.comboBoxRelationDefs);
            this.groupBoxRelation.Controls.Add(this.comboBoxPawns);
            this.groupBoxRelation.Controls.Add(this.comboBoxFaction);
            this.groupBoxRelation.Location = new System.Drawing.Point(546, 26);
            this.groupBoxRelation.Name = "groupBoxRelation";
            this.groupBoxRelation.Size = new System.Drawing.Size(300, 393);
            this.groupBoxRelation.TabIndex = 18;
            this.groupBoxRelation.TabStop = false;
            this.groupBoxRelation.Text = "Relation";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Starttime";
            // 
            // numericUpDownStartTime
            // 
            this.numericUpDownStartTime.Location = new System.Drawing.Point(86, 132);
            this.numericUpDownStartTime.Name = "numericUpDownStartTime";
            this.numericUpDownStartTime.Size = new System.Drawing.Size(152, 20);
            this.numericUpDownStartTime.TabIndex = 11;
            this.numericUpDownStartTime.ValueChanged += new System.EventHandler(this.numericUpDownStartTime_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Pawn";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Faction";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "With:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Definition";
            // 
            // comboBoxRelationDefs
            // 
            this.comboBoxRelationDefs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxRelationDefs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRelationDefs.FormattingEnabled = true;
            this.comboBoxRelationDefs.Location = new System.Drawing.Point(86, 19);
            this.comboBoxRelationDefs.Name = "comboBoxRelationDefs";
            this.comboBoxRelationDefs.Size = new System.Drawing.Size(155, 21);
            this.comboBoxRelationDefs.TabIndex = 6;
            this.comboBoxRelationDefs.SelectedIndexChanged += new System.EventHandler(this.comboBoxRelationDefs_SelectedIndexChanged);
            // 
            // comboBoxPawns
            // 
            this.comboBoxPawns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPawns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPawns.FormattingEnabled = true;
            this.comboBoxPawns.Location = new System.Drawing.Point(86, 105);
            this.comboBoxPawns.Name = "comboBoxPawns";
            this.comboBoxPawns.Size = new System.Drawing.Size(155, 21);
            this.comboBoxPawns.TabIndex = 5;
            this.comboBoxPawns.SelectedIndexChanged += new System.EventHandler(this.comboBoxPawns_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.DescriptionText);
            this.groupBox5.Location = new System.Drawing.Point(849, 26);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox5.Size = new System.Drawing.Size(420, 152);
            this.groupBox5.TabIndex = 19;
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
            this.DescriptionText.Size = new System.Drawing.Size(407, 126);
            this.DescriptionText.TabIndex = 0;
            this.DescriptionText.Text = resources.GetString("DescriptionText.Text");
            // 
            // RelationShips
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBoxRelation);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Name = "RelationShips";
            this.Size = new System.Drawing.Size(1542, 787);
            this.groupBox2.ResumeLayout(false);
            this.groupBoxRelation.ResumeLayout(false);
            this.groupBoxRelation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartTime)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxRelations;
        private System.Windows.Forms.Button btnRemoveRealtion;
        private System.Windows.Forms.Button btnAddRelation;
        public System.Windows.Forms.ListBox listBoxRelations;
        private System.Windows.Forms.ComboBox comboBoxFaction;
        private System.Windows.Forms.GroupBox groupBoxRelation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownStartTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxRelationDefs;
        private System.Windows.Forms.ComboBox comboBoxPawns;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox DescriptionText;
    }
}
