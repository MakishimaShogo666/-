
namespace GUI
{
    partial class AddTransportForm
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
            this.PowerLabelUnits = new System.Windows.Forms.Label();
            this.PowerLabel = new System.Windows.Forms.Label();
            this.PowerBox = new System.Windows.Forms.TextBox();
            this.DistanceLabelUnits = new System.Windows.Forms.Label();
            this.DistanceLabel = new System.Windows.Forms.Label();
            this.DistanceBox = new System.Windows.Forms.TextBox();
            this.ConsumptionLabelUnits = new System.Windows.Forms.Label();
            this.ConsumptionBox = new System.Windows.Forms.TextBox();
            this.ConsumptionLabel = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.GetRandomData = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TypeOfTransportBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 53);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип транспорта";
            // 
            // TypeOfTransportBox
            // 
            this.TypeOfTransportBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeOfTransportBox.Location = new System.Drawing.Point(6, 21);
            this.TypeOfTransportBox.Name = "TypeOfTransportBox";
            this.TypeOfTransportBox.Size = new System.Drawing.Size(310, 24);
            this.TypeOfTransportBox.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PowerLabelUnits);
            this.groupBox2.Controls.Add(this.PowerLabel);
            this.groupBox2.Controls.Add(this.PowerBox);
            this.groupBox2.Controls.Add(this.DistanceLabelUnits);
            this.groupBox2.Controls.Add(this.DistanceLabel);
            this.groupBox2.Controls.Add(this.DistanceBox);
            this.groupBox2.Controls.Add(this.ConsumptionLabelUnits);
            this.groupBox2.Controls.Add(this.ConsumptionBox);
            this.groupBox2.Controls.Add(this.ConsumptionLabel);
            this.groupBox2.Controls.Add(this.NameBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(326, 153);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры транспорта";
            // 
            // PowerLabelUnits
            // 
            this.PowerLabelUnits.AutoSize = true;
            this.PowerLabelUnits.Location = new System.Drawing.Point(281, 118);
            this.PowerLabelUnits.Name = "PowerLabelUnits";
            this.PowerLabelUnits.Size = new System.Drawing.Size(35, 17);
            this.PowerLabelUnits.TabIndex = 2;
            this.PowerLabelUnits.Text = "кДж";
            // 
            // PowerLabel
            // 
            this.PowerLabel.AutoSize = true;
            this.PowerLabel.Location = new System.Drawing.Point(6, 118);
            this.PowerLabel.Name = "PowerLabel";
            this.PowerLabel.Size = new System.Drawing.Size(203, 17);
            this.PowerLabel.TabIndex = 2;
            this.PowerLabel.Text = "Мощность электродвигателя:";
            // 
            // PowerBox
            // 
            this.PowerBox.Location = new System.Drawing.Point(215, 115);
            this.PowerBox.Name = "PowerBox";
            this.PowerBox.Size = new System.Drawing.Size(60, 22);
            this.PowerBox.TabIndex = 5;
            this.PowerBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberBox_KeyPress);
            // 
            // DistanceLabelUnits
            // 
            this.DistanceLabelUnits.AutoSize = true;
            this.DistanceLabelUnits.Location = new System.Drawing.Point(200, 88);
            this.DistanceLabelUnits.Name = "DistanceLabelUnits";
            this.DistanceLabelUnits.Size = new System.Drawing.Size(24, 17);
            this.DistanceLabelUnits.TabIndex = 2;
            this.DistanceLabelUnits.Text = "км";
            // 
            // DistanceLabel
            // 
            this.DistanceLabel.AutoSize = true;
            this.DistanceLabel.Location = new System.Drawing.Point(6, 88);
            this.DistanceLabel.Name = "DistanceLabel";
            this.DistanceLabel.Size = new System.Drawing.Size(85, 17);
            this.DistanceLabel.TabIndex = 2;
            this.DistanceLabel.Text = "Дистанция:";
            // 
            // DistanceBox
            // 
            this.DistanceBox.Location = new System.Drawing.Point(134, 85);
            this.DistanceBox.Name = "DistanceBox";
            this.DistanceBox.Size = new System.Drawing.Size(60, 22);
            this.DistanceBox.TabIndex = 4;
            this.DistanceBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberBox_KeyPress);
            // 
            // ConsumptionLabelUnits
            // 
            this.ConsumptionLabelUnits.AutoSize = true;
            this.ConsumptionLabelUnits.Location = new System.Drawing.Point(200, 58);
            this.ConsumptionLabelUnits.Name = "ConsumptionLabelUnits";
            this.ConsumptionLabelUnits.Size = new System.Drawing.Size(60, 17);
            this.ConsumptionLabelUnits.TabIndex = 2;
            this.ConsumptionLabelUnits.Text = "л/100км";
            // 
            // ConsumptionBox
            // 
            this.ConsumptionBox.Location = new System.Drawing.Point(134, 55);
            this.ConsumptionBox.Name = "ConsumptionBox";
            this.ConsumptionBox.Size = new System.Drawing.Size(60, 22);
            this.ConsumptionBox.TabIndex = 3;
            this.ConsumptionBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberBox_KeyPress);
            // 
            // ConsumptionLabel
            // 
            this.ConsumptionLabel.AutoSize = true;
            this.ConsumptionLabel.Location = new System.Drawing.Point(6, 58);
            this.ConsumptionLabel.Name = "ConsumptionLabel";
            this.ConsumptionLabel.Size = new System.Drawing.Size(118, 17);
            this.ConsumptionLabel.TabIndex = 2;
            this.ConsumptionLabel.Text = "Средний расход:";
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(134, 24);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(182, 22);
            this.NameBox.TabIndex = 2;
            this.NameBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NameBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Наименование:";
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(258, 234);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(80, 25);
            this.ButtonAdd.TabIndex = 2;
            this.ButtonAdd.Text = "Добавить";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.Add_Click);
            // 
            // GetRandomData
            // 
            this.GetRandomData.Location = new System.Drawing.Point(84, 234);
            this.GetRandomData.Name = "GetRandomData";
            this.GetRandomData.Size = new System.Drawing.Size(168, 25);
            this.GetRandomData.TabIndex = 6;
            this.GetRandomData.Text = "Случайные данные";
            this.GetRandomData.UseVisualStyleBackColor = true;
            this.GetRandomData.Click += new System.EventHandler(this.GetRandomData_Click);
            // 
            // AddTransportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 269);
            this.Controls.Add(this.GetRandomData);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTransportForm";
            this.Text = "Добавить транспорт";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox TypeOfTransportBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label PowerLabel;
        private System.Windows.Forms.TextBox PowerBox;
        private System.Windows.Forms.Label DistanceLabelUnits;
        private System.Windows.Forms.Label DistanceLabel;
        private System.Windows.Forms.TextBox DistanceBox;
        private System.Windows.Forms.Label ConsumptionLabelUnits;
        private System.Windows.Forms.TextBox ConsumptionBox;
        private System.Windows.Forms.Label ConsumptionLabel;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label PowerLabelUnits;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Button GetRandomData;
    }
}