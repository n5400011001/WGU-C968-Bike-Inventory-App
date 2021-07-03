
namespace C968
{
    partial class modifyPart
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.modifyPartInHouseRadio = new System.Windows.Forms.RadioButton();
            this.modifyPartOutsourcedRadio = new System.Windows.Forms.RadioButton();
            this.modifyPartCancelButton = new System.Windows.Forms.Button();
            this.modifyPartSaveButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.modifyPartSourceLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.modifyPartMinField = new System.Windows.Forms.TextBox();
            this.modifyPartSourceField = new System.Windows.Forms.TextBox();
            this.modifyPartMaxField = new System.Windows.Forms.TextBox();
            this.modifyPartPriceField = new System.Windows.Forms.TextBox();
            this.modifyPartQuantityField = new System.Windows.Forms.TextBox();
            this.modifyPartNameField = new System.Windows.Forms.TextBox();
            this.modifyPartIdField = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.modifyPartErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modifyPartErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.modifyPartInHouseRadio);
            this.groupBox1.Controls.Add(this.modifyPartOutsourcedRadio);
            this.groupBox1.Location = new System.Drawing.Point(114, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 55);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source";
            // 
            // modifyPartInHouseRadio
            // 
            this.modifyPartInHouseRadio.AutoSize = true;
            this.modifyPartInHouseRadio.Location = new System.Drawing.Point(27, 22);
            this.modifyPartInHouseRadio.Name = "modifyPartInHouseRadio";
            this.modifyPartInHouseRadio.Size = new System.Drawing.Size(80, 19);
            this.modifyPartInHouseRadio.TabIndex = 1;
            this.modifyPartInHouseRadio.Text = "IN-HOUSE";
            this.modifyPartInHouseRadio.UseVisualStyleBackColor = true;
            this.modifyPartInHouseRadio.CheckedChanged += new System.EventHandler(this.modifyPartInHouseRadio_CheckedChanged_1);
            // 
            // modifyPartOutsourcedRadio
            // 
            this.modifyPartOutsourcedRadio.AutoSize = true;
            this.modifyPartOutsourcedRadio.Location = new System.Drawing.Point(128, 22);
            this.modifyPartOutsourcedRadio.Name = "modifyPartOutsourcedRadio";
            this.modifyPartOutsourcedRadio.Size = new System.Drawing.Size(100, 19);
            this.modifyPartOutsourcedRadio.TabIndex = 2;
            this.modifyPartOutsourcedRadio.Text = "OUTSOURCED";
            this.modifyPartOutsourcedRadio.UseVisualStyleBackColor = true;
            this.modifyPartOutsourcedRadio.CheckedChanged += new System.EventHandler(this.modifyPartOutsourcedRadio_CheckedChanged);
            // 
            // modifyPartCancelButton
            // 
            this.modifyPartCancelButton.Location = new System.Drawing.Point(273, 368);
            this.modifyPartCancelButton.Name = "modifyPartCancelButton";
            this.modifyPartCancelButton.Size = new System.Drawing.Size(75, 23);
            this.modifyPartCancelButton.TabIndex = 36;
            this.modifyPartCancelButton.Text = "CANCEL";
            this.modifyPartCancelButton.UseVisualStyleBackColor = true;
            this.modifyPartCancelButton.Click += new System.EventHandler(this.modifyPartCancelButton_Click);
            // 
            // modifyPartSaveButton
            // 
            this.modifyPartSaveButton.Location = new System.Drawing.Point(192, 368);
            this.modifyPartSaveButton.Name = "modifyPartSaveButton";
            this.modifyPartSaveButton.Size = new System.Drawing.Size(75, 23);
            this.modifyPartSaveButton.TabIndex = 35;
            this.modifyPartSaveButton.Text = "SAVE";
            this.modifyPartSaveButton.UseVisualStyleBackColor = true;
            this.modifyPartSaveButton.Click += new System.EventHandler(this.modifyPartSaveButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(239, 257);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 15);
            this.label8.TabIndex = 34;
            this.label8.Text = "Min";
            // 
            // modifyPartSourceLabel
            // 
            this.modifyPartSourceLabel.AutoSize = true;
            this.modifyPartSourceLabel.Location = new System.Drawing.Point(48, 302);
            this.modifyPartSourceLabel.Name = "modifyPartSourceLabel";
            this.modifyPartSourceLabel.Size = new System.Drawing.Size(67, 15);
            this.modifyPartSourceLabel.TabIndex = 33;
            this.modifyPartSourceLabel.Text = "Machine ID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(85, 257);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 15);
            this.label7.TabIndex = 32;
            this.label7.Text = "Max";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 31;
            this.label4.Text = "Price/Cost";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 15);
            this.label5.TabIndex = 30;
            this.label5.Text = "Quantity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 29;
            this.label3.Text = "Name";
            // 
            // modifyPartMinField
            // 
            this.modifyPartMinField.Location = new System.Drawing.Point(277, 254);
            this.modifyPartMinField.Name = "modifyPartMinField";
            this.modifyPartMinField.Size = new System.Drawing.Size(71, 23);
            this.modifyPartMinField.TabIndex = 28;
            // 
            // modifyPartSourceField
            // 
            this.modifyPartSourceField.Location = new System.Drawing.Point(146, 299);
            this.modifyPartSourceField.Name = "modifyPartSourceField";
            this.modifyPartSourceField.Size = new System.Drawing.Size(202, 23);
            this.modifyPartSourceField.TabIndex = 27;
            // 
            // modifyPartMaxField
            // 
            this.modifyPartMaxField.Location = new System.Drawing.Point(146, 254);
            this.modifyPartMaxField.Name = "modifyPartMaxField";
            this.modifyPartMaxField.Size = new System.Drawing.Size(71, 23);
            this.modifyPartMaxField.TabIndex = 26;
            // 
            // modifyPartPriceField
            // 
            this.modifyPartPriceField.Location = new System.Drawing.Point(146, 209);
            this.modifyPartPriceField.Name = "modifyPartPriceField";
            this.modifyPartPriceField.Size = new System.Drawing.Size(202, 23);
            this.modifyPartPriceField.TabIndex = 25;
            // 
            // modifyPartQuantityField
            // 
            this.modifyPartQuantityField.Location = new System.Drawing.Point(146, 164);
            this.modifyPartQuantityField.Name = "modifyPartQuantityField";
            this.modifyPartQuantityField.Size = new System.Drawing.Size(202, 23);
            this.modifyPartQuantityField.TabIndex = 24;
            // 
            // modifyPartNameField
            // 
            this.modifyPartNameField.Location = new System.Drawing.Point(146, 118);
            this.modifyPartNameField.Name = "modifyPartNameField";
            this.modifyPartNameField.Size = new System.Drawing.Size(202, 23);
            this.modifyPartNameField.TabIndex = 23;
            // 
            // modifyPartIdField
            // 
            this.modifyPartIdField.Location = new System.Drawing.Point(146, 73);
            this.modifyPartIdField.Name = "modifyPartIdField";
            this.modifyPartIdField.ReadOnly = true;
            this.modifyPartIdField.Size = new System.Drawing.Size(202, 23);
            this.modifyPartIdField.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 21;
            this.label2.Text = "Part ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "MODIFY PART";
            // 
            // modifyPartErrorProvider
            // 
            this.modifyPartErrorProvider.ContainerControl = this;
            // 
            // modifyPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 410);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.modifyPartCancelButton);
            this.Controls.Add(this.modifyPartSaveButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.modifyPartSourceLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.modifyPartMinField);
            this.Controls.Add(this.modifyPartSourceField);
            this.Controls.Add(this.modifyPartMaxField);
            this.Controls.Add(this.modifyPartPriceField);
            this.Controls.Add(this.modifyPartQuantityField);
            this.Controls.Add(this.modifyPartNameField);
            this.Controls.Add(this.modifyPartIdField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "modifyPart";
            this.Text = "modifyPart";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modifyPartErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button modifyPartCancelButton;
        private System.Windows.Forms.Button modifyPartSaveButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label modifyPartSourceLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox modifyPartMinField;
        public System.Windows.Forms.TextBox modifyPartSourceField;
        public System.Windows.Forms.TextBox modifyPartMaxField;
        public System.Windows.Forms.TextBox modifyPartPriceField;
        public System.Windows.Forms.TextBox modifyPartQuantityField;
        public System.Windows.Forms.TextBox modifyPartNameField;
        public System.Windows.Forms.TextBox modifyPartIdField;
        public System.Windows.Forms.RadioButton modifyPartInHouseRadio;
        public System.Windows.Forms.RadioButton modifyPartOutsourcedRadio;
        private System.Windows.Forms.ErrorProvider modifyPartErrorProvider;
        private System.Windows.Forms.Label test;
    }
}