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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
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
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.listBox1);
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(211, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Remove";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(145, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(7, 20);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(264, 43);
            this.listBox1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(211, 69);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Remove";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(7, 20);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(264, 43);
            this.listBox2.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.listBox2);
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
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox comboBox1;
		public System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button button3;
		public System.Windows.Forms.ListBox listBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ComboBox adulthoodComboBox;
		private System.Windows.Forms.ComboBox childhoodComboBox;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.NumericUpDown BiologicalAgeBox;
	}
}
