
namespace GUI
{
    partial class AddVehicleForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TypeOfTransportBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ConsumptionLabelUnits = new System.Windows.Forms.Label();
            this.DistanceLabelUnits = new System.Windows.Forms.Label();
            this.ConsumptionTextBox = new System.Windows.Forms.TextBox();
            this.ConsumptionLabel = new System.Windows.Forms.Label();
            this.DistanceTextBox = new System.Windows.Forms.TextBox();
            this.DistanceLabel = new System.Windows.Forms.Label();
            this.PowerLabelUnits = new System.Windows.Forms.Label();
            this.PowerLabel = new System.Windows.Forms.Label();
            this.PowerBox = new System.Windows.Forms.TextBox();
            this.WeightLabelUnits = new System.Windows.Forms.Label();
            this.WeightLabel = new System.Windows.Forms.Label();
            this.WeightBox = new System.Windows.Forms.TextBox();
            this.WasteLabelUnits = new System.Windows.Forms.Label();
            this.WasteBox = new System.Windows.Forms.TextBox();
            this.WasteLabel = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.GetRandomData = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TypeOfFuelBox = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TypeOfTransportBox);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(223, 43);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип транспорта";
            // 
            // TypeOfTransportBox
            // 
            this.TypeOfTransportBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeOfTransportBox.Location = new System.Drawing.Point(4, 17);
            this.TypeOfTransportBox.Margin = new System.Windows.Forms.Padding(2);
            this.TypeOfTransportBox.Name = "TypeOfTransportBox";
            this.TypeOfTransportBox.Size = new System.Drawing.Size(213, 21);
            this.TypeOfTransportBox.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ConsumptionLabelUnits);
            this.groupBox2.Controls.Add(this.DistanceLabelUnits);
            this.groupBox2.Controls.Add(this.ConsumptionTextBox);
            this.groupBox2.Controls.Add(this.ConsumptionLabel);
            this.groupBox2.Controls.Add(this.DistanceTextBox);
            this.groupBox2.Controls.Add(this.DistanceLabel);
            this.groupBox2.Controls.Add(this.PowerLabelUnits);
            this.groupBox2.Controls.Add(this.PowerLabel);
            this.groupBox2.Controls.Add(this.PowerBox);
            this.groupBox2.Controls.Add(this.WeightLabelUnits);
            this.groupBox2.Controls.Add(this.WeightLabel);
            this.groupBox2.Controls.Add(this.WeightBox);
            this.groupBox2.Controls.Add(this.WasteLabelUnits);
            this.groupBox2.Controls.Add(this.WasteBox);
            this.groupBox2.Controls.Add(this.WasteLabel);
            this.groupBox2.Controls.Add(this.NameBox);
            this.groupBox2.Controls.Add(this.NameLabel);
            this.groupBox2.Location = new System.Drawing.Point(9, 102);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(223, 185);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры транспорта";
            // 
            // ConsumptionLabelUnits
            // 
            this.ConsumptionLabelUnits.AutoSize = true;
            this.ConsumptionLabelUnits.Location = new System.Drawing.Point(187, 159);
            this.ConsumptionLabelUnits.Name = "ConsumptionLabelUnits";
            this.ConsumptionLabelUnits.Size = new System.Drawing.Size(13, 13);
            this.ConsumptionLabelUnits.TabIndex = 10;
            this.ConsumptionLabelUnits.Text = "л";
            // 
            // DistanceLabelUnits
            // 
            this.DistanceLabelUnits.AutoSize = true;
            this.DistanceLabelUnits.Location = new System.Drawing.Point(187, 135);
            this.DistanceLabelUnits.Name = "DistanceLabelUnits";
            this.DistanceLabelUnits.Size = new System.Drawing.Size(21, 13);
            this.DistanceLabelUnits.TabIndex = 10;
            this.DistanceLabelUnits.Text = "км";
            // 
            // ConsumptionTextBox
            // 
            this.ConsumptionTextBox.Enabled = false;
            this.ConsumptionTextBox.Location = new System.Drawing.Point(132, 156);
            this.ConsumptionTextBox.Name = "ConsumptionTextBox";
            this.ConsumptionTextBox.ReadOnly = true;
            this.ConsumptionTextBox.Size = new System.Drawing.Size(51, 20);
            this.ConsumptionTextBox.TabIndex = 9;
            // 
            // ConsumptionLabel
            // 
            this.ConsumptionLabel.AutoSize = true;
            this.ConsumptionLabel.Location = new System.Drawing.Point(7, 159);
            this.ConsumptionLabel.Name = "ConsumptionLabel";
            this.ConsumptionLabel.Size = new System.Drawing.Size(121, 13);
            this.ConsumptionLabel.TabIndex = 8;
            this.ConsumptionLabel.Text = "Потребление топлива:";
            // 
            // DistanceTextBox
            // 
            this.DistanceTextBox.Location = new System.Drawing.Point(132, 130);
            this.DistanceTextBox.Name = "DistanceTextBox";
            this.DistanceTextBox.Size = new System.Drawing.Size(51, 20);
            this.DistanceTextBox.TabIndex = 7;
            this.DistanceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberBox_KeyPress);
            this.DistanceTextBox.TextChanged += new System.EventHandler(this.DistanceTextBox_TextChanged);
            // 
            // DistanceLabel
            // 
            this.DistanceLabel.AutoSize = true;
            this.DistanceLabel.Location = new System.Drawing.Point(5, 135);
            this.DistanceLabel.Name = "DistanceLabel";
            this.DistanceLabel.Size = new System.Drawing.Size(66, 13);
            this.DistanceLabel.TabIndex = 6;
            this.DistanceLabel.Text = "Дистанция:";
            // 
            // PowerLabelUnits
            // 
            this.PowerLabelUnits.AutoSize = true;
            this.PowerLabelUnits.Location = new System.Drawing.Point(187, 109);
            this.PowerLabelUnits.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PowerLabelUnits.Name = "PowerLabelUnits";
            this.PowerLabelUnits.Size = new System.Drawing.Size(28, 13);
            this.PowerLabelUnits.TabIndex = 2;
            this.PowerLabelUnits.Text = "л. с.";
            // 
            // PowerLabel
            // 
            this.PowerLabel.AutoSize = true;
            this.PowerLabel.Location = new System.Drawing.Point(4, 109);
            this.PowerLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PowerLabel.Name = "PowerLabel";
            this.PowerLabel.Size = new System.Drawing.Size(124, 13);
            this.PowerLabel.TabIndex = 2;
            this.PowerLabel.Text = "Мощность транспорта:";
            // 
            // PowerBox
            // 
            this.PowerBox.Location = new System.Drawing.Point(132, 105);
            this.PowerBox.Margin = new System.Windows.Forms.Padding(2);
            this.PowerBox.Name = "PowerBox";
            this.PowerBox.Size = new System.Drawing.Size(51, 20);
            this.PowerBox.TabIndex = 5;
            this.PowerBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberBox_KeyPress);
            // 
            // WeightLabelUnits
            // 
            this.WeightLabelUnits.AutoSize = true;
            this.WeightLabelUnits.Location = new System.Drawing.Point(187, 82);
            this.WeightLabelUnits.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.WeightLabelUnits.Name = "WeightLabelUnits";
            this.WeightLabelUnits.Size = new System.Drawing.Size(12, 13);
            this.WeightLabelUnits.TabIndex = 2;
            this.WeightLabelUnits.Text = "т";
            // 
            // WeightLabel
            // 
            this.WeightLabel.AutoSize = true;
            this.WeightLabel.Location = new System.Drawing.Point(4, 82);
            this.WeightLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.WeightLabel.Name = "WeightLabel";
            this.WeightLabel.Size = new System.Drawing.Size(90, 13);
            this.WeightLabel.TabIndex = 2;
            this.WeightLabel.Text = "Вес транспорта:";
            // 
            // WeightBox
            // 
            this.WeightBox.Location = new System.Drawing.Point(132, 79);
            this.WeightBox.Margin = new System.Windows.Forms.Padding(2);
            this.WeightBox.Name = "WeightBox";
            this.WeightBox.Size = new System.Drawing.Size(51, 20);
            this.WeightBox.TabIndex = 4;
            this.WeightBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberBox_KeyPress);
            // 
            // WasteLabelUnits
            // 
            this.WasteLabelUnits.AutoSize = true;
            this.WasteLabelUnits.Location = new System.Drawing.Point(187, 54);
            this.WasteLabelUnits.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.WasteLabelUnits.Name = "WasteLabelUnits";
            this.WasteLabelUnits.Size = new System.Drawing.Size(32, 13);
            this.WasteLabelUnits.TabIndex = 2;
            this.WasteLabelUnits.Text = "л/км";
            // 
            // WasteBox
            // 
            this.WasteBox.Location = new System.Drawing.Point(132, 51);
            this.WasteBox.Margin = new System.Windows.Forms.Padding(2);
            this.WasteBox.Name = "WasteBox";
            this.WasteBox.Size = new System.Drawing.Size(51, 20);
            this.WasteBox.TabIndex = 3;
            this.WasteBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberBox_KeyPress);
            // 
            // WasteLabel
            // 
            this.WasteLabel.AutoSize = true;
            this.WasteLabel.Location = new System.Drawing.Point(4, 54);
            this.WasteLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.WasteLabel.Name = "WasteLabel";
            this.WasteLabel.Size = new System.Drawing.Size(90, 13);
            this.WasteLabel.TabIndex = 2;
            this.WasteLabel.Text = "Расход топлива:";
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(98, 22);
            this.NameBox.Margin = new System.Windows.Forms.Padding(2);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(112, 20);
            this.NameBox.TabIndex = 2;
            this.NameBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NameBox_KeyPress);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(4, 25);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(86, 13);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.Text = "Наименование:";
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(128, 291);
            this.ButtonAdd.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(104, 20);
            this.ButtonAdd.TabIndex = 2;
            this.ButtonAdd.Text = "Добавить";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.Add_Click);
            // 
            // GetRandomData
            // 
            this.GetRandomData.Location = new System.Drawing.Point(9, 291);
            this.GetRandomData.Margin = new System.Windows.Forms.Padding(2);
            this.GetRandomData.Name = "GetRandomData";
            this.GetRandomData.Size = new System.Drawing.Size(115, 20);
            this.GetRandomData.TabIndex = 6;
            this.GetRandomData.Text = "Случайные данные";
            this.GetRandomData.UseVisualStyleBackColor = true;
            this.GetRandomData.Click += new System.EventHandler(this.GetRandomData_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TypeOfFuelBox);
            this.groupBox3.Location = new System.Drawing.Point(9, 53);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(223, 44);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Тип топлива";
            // 
            // TypeOfFuelBox
            // 
            this.TypeOfFuelBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeOfFuelBox.Enabled = false;
            this.TypeOfFuelBox.FormattingEnabled = true;
            this.TypeOfFuelBox.Location = new System.Drawing.Point(4, 17);
            this.TypeOfFuelBox.Name = "TypeOfFuelBox";
            this.TypeOfFuelBox.Size = new System.Drawing.Size(213, 21);
            this.TypeOfFuelBox.TabIndex = 0;
            this.TypeOfFuelBox.SelectedIndexChanged += new System.EventHandler(this.TypeOfFuelBox_SelectedIndexChanged);
            // 
            // AddVehicleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 315);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.GetRandomData);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddVehicleForm";
            this.Text = "Добавить транспорт";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox TypeOfTransportBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label PowerLabel;
        private System.Windows.Forms.TextBox PowerBox;
        private System.Windows.Forms.Label WeightLabelUnits;
        private System.Windows.Forms.Label WeightLabel;
        private System.Windows.Forms.TextBox WeightBox;
        private System.Windows.Forms.Label WasteLabelUnits;
        private System.Windows.Forms.TextBox WasteBox;
        private System.Windows.Forms.Label WasteLabel;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label PowerLabelUnits;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Button GetRandomData;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox TypeOfFuelBox;
        private System.Windows.Forms.Label ConsumptionLabelUnits;
        private System.Windows.Forms.Label DistanceLabelUnits;
        private System.Windows.Forms.TextBox ConsumptionTextBox;
        private System.Windows.Forms.Label ConsumptionLabel;
        private System.Windows.Forms.Label DistanceLabel;
        private System.Windows.Forms.TextBox DistanceTextBox;
    }
}