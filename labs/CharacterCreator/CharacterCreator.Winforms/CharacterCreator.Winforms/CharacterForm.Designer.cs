namespace CharacterCreator.Winforms
{
    partial class CharacterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ddlProfession = new System.Windows.Forms.ComboBox();
            this.ddlRace = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.numericStrength = new System.Windows.Forms.NumericUpDown();
            this.numericIntelligience = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numericAgility = new System.Windows.Forms.NumericUpDown();
            this.numericConstitution = new System.Windows.Forms.NumericUpDown();
            this.numericCharisma = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this._errorName = new System.Windows.Forms.ErrorProvider(this.components);
            this._errorAttribute = new System.Windows.Forms.ErrorProvider(this.components);
            this._errorComboBox = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericStrength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIntelligience)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAgility)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericConstitution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCharisma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._errorName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._errorAttribute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._errorComboBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Profession";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Race";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Strength";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Intelligence";
            // 
            // ddlProfession
            // 
            this.ddlProfession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlProfession.FormattingEnabled = true;
            this.ddlProfession.Location = new System.Drawing.Point(127, 95);
            this.ddlProfession.Name = "ddlProfession";
            this.ddlProfession.Size = new System.Drawing.Size(121, 21);
            this.ddlProfession.TabIndex = 1;
            this.ddlProfession.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateProfession);
            // 
            // ddlRace
            // 
            this.ddlRace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlRace.FormattingEnabled = true;
            this.ddlRace.Location = new System.Drawing.Point(127, 130);
            this.ddlRace.Name = "ddlRace";
            this.ddlRace.Size = new System.Drawing.Size(121, 21);
            this.ddlRace.TabIndex = 2;
            this.ddlRace.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateRace);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._errorName.SetError(this.txtName, "Name is required");
            this.txtName.Location = new System.Drawing.Point(127, 64);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(121, 20);
            this.txtName.TabIndex = 0;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateName);
            // 
            // numericStrength
            // 
            this.numericStrength.Location = new System.Drawing.Point(128, 170);
            this.numericStrength.Name = "numericStrength";
            this.numericStrength.Size = new System.Drawing.Size(40, 20);
            this.numericStrength.TabIndex = 3;
            this.numericStrength.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericStrength.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateAttribute);
            // 
            // numericIntelligience
            // 
            this.numericIntelligience.Location = new System.Drawing.Point(127, 196);
            this.numericIntelligience.Name = "numericIntelligience";
            this.numericIntelligience.Size = new System.Drawing.Size(41, 20);
            this.numericIntelligience.TabIndex = 4;
            this.numericIntelligience.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericIntelligience.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateAttribute);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(86, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Agility";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(57, 250);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Constitution";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(68, 276);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Charisma";
            // 
            // numericAgility
            // 
            this.numericAgility.Location = new System.Drawing.Point(128, 222);
            this.numericAgility.Name = "numericAgility";
            this.numericAgility.Size = new System.Drawing.Size(39, 20);
            this.numericAgility.TabIndex = 5;
            this.numericAgility.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericAgility.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateAttribute);
            // 
            // numericConstitution
            // 
            this.numericConstitution.Location = new System.Drawing.Point(128, 248);
            this.numericConstitution.Name = "numericConstitution";
            this.numericConstitution.Size = new System.Drawing.Size(40, 20);
            this.numericConstitution.TabIndex = 6;
            this.numericConstitution.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericConstitution.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateAttribute);
            // 
            // numericCharisma
            // 
            this.numericCharisma.Location = new System.Drawing.Point(128, 274);
            this.numericCharisma.Name = "numericCharisma";
            this.numericCharisma.Size = new System.Drawing.Size(40, 20);
            this.numericCharisma.TabIndex = 7;
            this.numericCharisma.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericCharisma.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateAttribute);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(335, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(415, 61);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(334, 231);
            this.txtDescription.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(570, 403);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnSave);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(651, 402);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OnCancel);
            // 
            // _errorName
            // 
            this._errorName.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorName.ContainerControl = this;
            // 
            // _errorAttribute
            // 
            this._errorAttribute.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorAttribute.ContainerControl = this;
            // 
            // _errorComboBox
            // 
            this._errorComboBox.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorComboBox.ContainerControl = this;
            // 
            // CharacterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numericCharisma);
            this.Controls.Add(this.numericConstitution);
            this.Controls.Add(this.numericAgility);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericIntelligience);
            this.Controls.Add(this.numericStrength);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.ddlRace);
            this.Controls.Add(this.ddlProfession);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CharacterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Character Form";
            ((System.ComponentModel.ISupportInitialize)(this.numericStrength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIntelligience)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAgility)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericConstitution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCharisma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._errorName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._errorAttribute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._errorComboBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ddlProfession;
        private System.Windows.Forms.ComboBox ddlRace;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.NumericUpDown numericStrength;
        private System.Windows.Forms.NumericUpDown numericIntelligience;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericAgility;
        private System.Windows.Forms.NumericUpDown numericConstitution;
        private System.Windows.Forms.NumericUpDown numericCharisma;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ErrorProvider _errorName;
        private System.Windows.Forms.ErrorProvider _errorAttribute;
        private System.Windows.Forms.ErrorProvider _errorComboBox;
    }
}