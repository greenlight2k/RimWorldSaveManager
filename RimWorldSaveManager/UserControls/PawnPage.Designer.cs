namespace RimWorldSaveManager
{
	partial class PawnPage
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnRemoveTrait = new System.Windows.Forms.Button();
            this.btnAddTrait = new System.Windows.Forms.Button();
            this.listBoxTraits = new System.Windows.Forms.ListBox();
            this.btnRemoveInjury = new System.Windows.Forms.Button();
            this.listBoxInjuries = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.adulthoodComboBox = new System.Windows.Forms.ComboBox();
            this.childhoodComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BiologicalAgeBox = new System.Windows.Forms.NumericUpDown();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BiologicalAgeBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 90);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Skills";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.btnRemoveTrait);
            this.groupBox2.Controls.Add(this.btnAddTrait);
            this.groupBox2.Controls.Add(this.listBoxTraits);
            this.groupBox2.Location = new System.Drawing.Point(269, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(277, 100);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Traits";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(7, 70);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(132, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // btnRemoveTrait
            // 
            this.btnRemoveTrait.Location = new System.Drawing.Point(211, 69);
            this.btnRemoveTrait.Name = "btnRemoveTrait";
            this.btnRemoveTrait.Size = new System.Drawing.Size(60, 23);
            this.btnRemoveTrait.TabIndex = 2;
            this.btnRemoveTrait.Text = "Remove";
            this.btnRemoveTrait.UseVisualStyleBackColor = true;
            this.btnRemoveTrait.Click += new System.EventHandler(this.btnRemoveTrait_Click);
            // 
            // btnAddTrait
            // 
            this.btnAddTrait.Location = new System.Drawing.Point(145, 69);
            this.btnAddTrait.Name = "btnAddTrait";
            this.btnAddTrait.Size = new System.Drawing.Size(60, 23);
            this.btnAddTrait.TabIndex = 1;
            this.btnAddTrait.Text = "Add";
            this.btnAddTrait.UseVisualStyleBackColor = true;
            this.btnAddTrait.Click += new System.EventHandler(this.btnAddTrait_Click);
            // 
            // listBoxTraits
            // 
            this.listBoxTraits.FormattingEnabled = true;
            this.listBoxTraits.Location = new System.Drawing.Point(7, 20);
            this.listBoxTraits.Name = "listBoxTraits";
            this.listBoxTraits.Size = new System.Drawing.Size(264, 43);
            this.listBoxTraits.TabIndex = 0;
            // 
            // btnRemoveInjury
            // 
            this.btnRemoveInjury.Location = new System.Drawing.Point(211, 69);
            this.btnRemoveInjury.Name = "btnRemoveInjury";
            this.btnRemoveInjury.Size = new System.Drawing.Size(60, 23);
            this.btnRemoveInjury.TabIndex = 2;
            this.btnRemoveInjury.Text = "Remove";
            this.btnRemoveInjury.UseVisualStyleBackColor = true;
            this.btnRemoveInjury.Click += new System.EventHandler(this.btnRemoveInjury_Click);
            // 
            // listBoxInjuries
            // 
            this.listBoxInjuries.FormattingEnabled = true;
            this.listBoxInjuries.Location = new System.Drawing.Point(7, 20);
            this.listBoxInjuries.Name = "listBoxInjuries";
            this.listBoxInjuries.Size = new System.Drawing.Size(264, 43);
            this.listBoxInjuries.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnRemoveInjury);
            this.groupBox3.Controls.Add(this.listBoxInjuries);
            this.groupBox3.Location = new System.Drawing.Point(269, 138);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(277, 100);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Injuries";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.adulthoodComboBox);
            this.groupBox4.Controls.Add(this.childhoodComboBox);
            this.groupBox4.Location = new System.Drawing.Point(269, 244);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(277, 42);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Backstory";
            // 
            // adulthoodComboBox
            // 
            this.adulthoodComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.adulthoodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.adulthoodComboBox.FormattingEnabled = true;
            this.adulthoodComboBox.Location = new System.Drawing.Point(150, 15);
            this.adulthoodComboBox.Name = "adulthoodComboBox";
            this.adulthoodComboBox.Size = new System.Drawing.Size(121, 21);
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
            this.childhoodComboBox.Location = new System.Drawing.Point(7, 15);
            this.childhoodComboBox.Name = "childhoodComboBox";
            this.childhoodComboBox.Size = new System.Drawing.Size(121, 21);
            this.childhoodComboBox.TabIndex = 0;
            this.childhoodComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Backstory_DrawItem);
            this.childhoodComboBox.SelectedIndexChanged += new System.EventHandler(this.backstoryComboBox_SelectedIndexChanged);
            this.childhoodComboBox.DropDownClosed += new System.EventHandler(this.DropDownClosed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(273, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Biological Age";
            // 
            // BiologicalAgeBox
            // 
            this.BiologicalAgeBox.DecimalPlaces = 2;
            this.BiologicalAgeBox.Location = new System.Drawing.Point(350, 5);
            this.BiologicalAgeBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.BiologicalAgeBox.Name = "BiologicalAgeBox";
            this.BiologicalAgeBox.Size = new System.Drawing.Size(58, 20);
            this.BiologicalAgeBox.TabIndex = 11;
            this.BiologicalAgeBox.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // PawnPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BiologicalAgeBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PawnPage";
            this.Size = new System.Drawing.Size(550, 344);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BiologicalAgeBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnRemoveTrait;
		private System.Windows.Forms.Button btnAddTrait;
		private System.Windows.Forms.ComboBox comboBox1;
		public System.Windows.Forms.ListBox listBoxTraits;
		private System.Windows.Forms.Button btnRemoveInjury;
		public System.Windows.Forms.ListBox listBoxInjuries;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ComboBox adulthoodComboBox;
		private System.Windows.Forms.ComboBox childhoodComboBox;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.NumericUpDown BiologicalAgeBox;
	}
}
