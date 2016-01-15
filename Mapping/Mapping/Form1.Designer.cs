namespace Mapping
{
    partial class Form1
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
            this.newMapButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mainLabel = new System.Windows.Forms.Label();
            this.sizeWidthTextBox = new System.Windows.Forms.TextBox();
            this.sizeWidthLabel = new System.Windows.Forms.Label();
            this.sizeHeightLabel = new System.Windows.Forms.Label();
            this.sizeHeightTextBox = new System.Windows.Forms.TextBox();
            this.sizeOKButton = new System.Windows.Forms.Button();
            this.pointListBox = new System.Windows.Forms.ListBox();
            this.pointDeleteButton = new System.Windows.Forms.Button();
            this.pointConfirmButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.PiontLabel = new System.Windows.Forms.Label();
            this.PointLabel = new System.Windows.Forms.Label();
            this.btnLoadConf = new System.Windows.Forms.Button();
            this.labelBuildingName = new System.Windows.Forms.Label();
            this.buildingTextBox = new System.Windows.Forms.TextBox();
            this.labelFloorNo = new System.Windows.Forms.Label();
            this.floorTextBox = new System.Windows.Forms.TextBox();
            this.pointTypeComboBox = new System.Windows.Forms.ComboBox();
            this.pointTypeValueTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // newMapButton
            // 
            this.newMapButton.Location = new System.Drawing.Point(12, 11);
            this.newMapButton.Name = "newMapButton";
            this.newMapButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.newMapButton.Size = new System.Drawing.Size(90, 23);
            this.newMapButton.TabIndex = 0;
            this.newMapButton.Text = "Load Map";
            this.newMapButton.UseVisualStyleBackColor = true;
            this.newMapButton.Click += new System.EventHandler(this.newMapButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Image fles|*.jpg; *.jpeg; *.bmp; *.png";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(157, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(763, 513);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.SizeChanged += new System.EventHandler(this.pictureBox1_SizeChanged);
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // mainLabel
            // 
            this.mainLabel.AutoSize = true;
            this.mainLabel.Location = new System.Drawing.Point(220, 17);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(0, 13);
            this.mainLabel.TabIndex = 2;
            // 
            // sizeWidthTextBox
            // 
            this.sizeWidthTextBox.Location = new System.Drawing.Point(93, 98);
            this.sizeWidthTextBox.Name = "sizeWidthTextBox";
            this.sizeWidthTextBox.Size = new System.Drawing.Size(60, 20);
            this.sizeWidthTextBox.TabIndex = 3;
            this.sizeWidthTextBox.Visible = false;
            // 
            // sizeWidthLabel
            // 
            this.sizeWidthLabel.AutoSize = true;
            this.sizeWidthLabel.Location = new System.Drawing.Point(12, 100);
            this.sizeWidthLabel.Name = "sizeWidthLabel";
            this.sizeWidthLabel.Size = new System.Drawing.Size(38, 13);
            this.sizeWidthLabel.TabIndex = 4;
            this.sizeWidthLabel.Text = "Width:";
            this.sizeWidthLabel.Visible = false;
            // 
            // sizeHeightLabel
            // 
            this.sizeHeightLabel.AutoSize = true;
            this.sizeHeightLabel.Location = new System.Drawing.Point(12, 126);
            this.sizeHeightLabel.Name = "sizeHeightLabel";
            this.sizeHeightLabel.Size = new System.Drawing.Size(41, 13);
            this.sizeHeightLabel.TabIndex = 5;
            this.sizeHeightLabel.Text = "Height:";
            this.sizeHeightLabel.Visible = false;
            // 
            // sizeHeightTextBox
            // 
            this.sizeHeightTextBox.Location = new System.Drawing.Point(93, 124);
            this.sizeHeightTextBox.Name = "sizeHeightTextBox";
            this.sizeHeightTextBox.Size = new System.Drawing.Size(60, 20);
            this.sizeHeightTextBox.TabIndex = 6;
            this.sizeHeightTextBox.Visible = false;
            // 
            // sizeOKButton
            // 
            this.sizeOKButton.Location = new System.Drawing.Point(14, 152);
            this.sizeOKButton.Name = "sizeOKButton";
            this.sizeOKButton.Size = new System.Drawing.Size(89, 23);
            this.sizeOKButton.TabIndex = 7;
            this.sizeOKButton.Text = "OK";
            this.sizeOKButton.UseVisualStyleBackColor = true;
            this.sizeOKButton.Visible = false;
            this.sizeOKButton.Click += new System.EventHandler(this.sizeOKButton_Click);
            // 
            // pointListBox
            // 
            this.pointListBox.FormattingEnabled = true;
            this.pointListBox.Location = new System.Drawing.Point(12, 185);
            this.pointListBox.Name = "pointListBox";
            this.pointListBox.Size = new System.Drawing.Size(139, 264);
            this.pointListBox.TabIndex = 8;
            this.pointListBox.Visible = false;
            this.pointListBox.SelectedIndexChanged += new System.EventHandler(this.pointListBox_SelectedIndexChanged);
            // 
            // pointDeleteButton
            // 
            this.pointDeleteButton.Location = new System.Drawing.Point(13, 457);
            this.pointDeleteButton.Name = "pointDeleteButton";
            this.pointDeleteButton.Size = new System.Drawing.Size(92, 23);
            this.pointDeleteButton.TabIndex = 9;
            this.pointDeleteButton.Text = "Delete Point";
            this.pointDeleteButton.UseVisualStyleBackColor = true;
            this.pointDeleteButton.Visible = false;
            this.pointDeleteButton.Click += new System.EventHandler(this.pointDeleteButton_Click);
            // 
            // pointConfirmButton
            // 
            this.pointConfirmButton.Location = new System.Drawing.Point(13, 484);
            this.pointConfirmButton.Name = "pointConfirmButton";
            this.pointConfirmButton.Size = new System.Drawing.Size(92, 23);
            this.pointConfirmButton.TabIndex = 10;
            this.pointConfirmButton.Text = "Add Edge";
            this.pointConfirmButton.UseVisualStyleBackColor = true;
            this.pointConfirmButton.Visible = false;
            this.pointConfirmButton.Click += new System.EventHandler(this.pointConfirmButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(13, 536);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(92, 23);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Visible = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // PiontLabel
            // 
            this.PiontLabel.AutoSize = true;
            this.PiontLabel.Location = new System.Drawing.Point(361, 2);
            this.PiontLabel.Name = "PiontLabel";
            this.PiontLabel.Size = new System.Drawing.Size(0, 13);
            this.PiontLabel.TabIndex = 12;
            // 
            // PointLabel
            // 
            this.PointLabel.AutoSize = true;
            this.PointLabel.Location = new System.Drawing.Point(312, 13);
            this.PointLabel.Name = "PointLabel";
            this.PointLabel.Size = new System.Drawing.Size(0, 13);
            this.PointLabel.TabIndex = 13;
            // 
            // btnLoadConf
            // 
            this.btnLoadConf.Location = new System.Drawing.Point(115, 11);
            this.btnLoadConf.Name = "btnLoadConf";
            this.btnLoadConf.Size = new System.Drawing.Size(90, 23);
            this.btnLoadConf.TabIndex = 14;
            this.btnLoadConf.Text = "Load Conf";
            this.btnLoadConf.UseVisualStyleBackColor = true;
            this.btnLoadConf.Click += new System.EventHandler(this.btnLoadConf_Click);
            // 
            // labelBuildingName
            // 
            this.labelBuildingName.AutoSize = true;
            this.labelBuildingName.Location = new System.Drawing.Point(12, 49);
            this.labelBuildingName.Name = "labelBuildingName";
            this.labelBuildingName.Size = new System.Drawing.Size(81, 13);
            this.labelBuildingName.TabIndex = 16;
            this.labelBuildingName.Text = "Building Name: ";
            this.labelBuildingName.Visible = false;
            // 
            // buildingTextBox
            // 
            this.buildingTextBox.Location = new System.Drawing.Point(93, 47);
            this.buildingTextBox.Name = "buildingTextBox";
            this.buildingTextBox.Size = new System.Drawing.Size(60, 20);
            this.buildingTextBox.TabIndex = 15;
            this.buildingTextBox.Visible = false;
            // 
            // labelFloorNo
            // 
            this.labelFloorNo.AutoSize = true;
            this.labelFloorNo.Location = new System.Drawing.Point(12, 74);
            this.labelFloorNo.Name = "labelFloorNo";
            this.labelFloorNo.Size = new System.Drawing.Size(56, 13);
            this.labelFloorNo.TabIndex = 18;
            this.labelFloorNo.Text = "Floor No.: ";
            this.labelFloorNo.Visible = false;
            // 
            // floorTextBox
            // 
            this.floorTextBox.Location = new System.Drawing.Point(93, 72);
            this.floorTextBox.Name = "floorTextBox";
            this.floorTextBox.Size = new System.Drawing.Size(60, 20);
            this.floorTextBox.TabIndex = 17;
            this.floorTextBox.Visible = false;
            // 
            // pointTypeComboBox
            // 
            this.pointTypeComboBox.AllowDrop = true;
            this.pointTypeComboBox.FormattingEnabled = true;
            this.pointTypeComboBox.Items.AddRange(new object[] {
            "Normal (Default)",
            "Elevator",
            "Connector"});
            this.pointTypeComboBox.Location = new System.Drawing.Point(14, 511);
            this.pointTypeComboBox.Name = "pointTypeComboBox";
            this.pointTypeComboBox.Size = new System.Drawing.Size(91, 21);
            this.pointTypeComboBox.TabIndex = 20;
            this.pointTypeComboBox.Text = "Point Type";
            // 
            // pointTypeValueTextBox
            // 
            this.pointTypeValueTextBox.Location = new System.Drawing.Point(111, 512);
            this.pointTypeValueTextBox.Name = "pointTypeValueTextBox";
            this.pointTypeValueTextBox.Size = new System.Drawing.Size(40, 20);
            this.pointTypeValueTextBox.TabIndex = 21;
            this.pointTypeValueTextBox.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 566);
            this.Controls.Add(this.pointTypeValueTextBox);
            this.Controls.Add(this.pointTypeComboBox);
            this.Controls.Add(this.labelFloorNo);
            this.Controls.Add(this.floorTextBox);
            this.Controls.Add(this.labelBuildingName);
            this.Controls.Add(this.buildingTextBox);
            this.Controls.Add(this.btnLoadConf);
            this.Controls.Add(this.PointLabel);
            this.Controls.Add(this.PiontLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.pointConfirmButton);
            this.Controls.Add(this.pointDeleteButton);
            this.Controls.Add(this.pointListBox);
            this.Controls.Add(this.sizeOKButton);
            this.Controls.Add(this.sizeHeightTextBox);
            this.Controls.Add(this.sizeHeightLabel);
            this.Controls.Add(this.sizeWidthLabel);
            this.Controls.Add(this.sizeWidthTextBox);
            this.Controls.Add(this.mainLabel);
            this.Controls.Add(this.newMapButton);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button newMapButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label mainLabel;
        private System.Windows.Forms.TextBox sizeWidthTextBox;
        private System.Windows.Forms.Label sizeWidthLabel;
        private System.Windows.Forms.Label sizeHeightLabel;
        private System.Windows.Forms.TextBox sizeHeightTextBox;
        private System.Windows.Forms.Button sizeOKButton;
        private System.Windows.Forms.ListBox pointListBox;
        private System.Windows.Forms.Button pointDeleteButton;
        private System.Windows.Forms.Button pointConfirmButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label PiontLabel;
        private System.Windows.Forms.Label PointLabel;
        private System.Windows.Forms.Button btnLoadConf;
        private System.Windows.Forms.Label labelBuildingName;
        private System.Windows.Forms.TextBox buildingTextBox;
        private System.Windows.Forms.Label labelFloorNo;
        private System.Windows.Forms.TextBox floorTextBox;
        private System.Windows.Forms.ComboBox pointTypeComboBox;
        private System.Windows.Forms.TextBox pointTypeValueTextBox;
    }
}

