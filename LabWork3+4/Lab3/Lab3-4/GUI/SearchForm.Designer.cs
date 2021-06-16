
namespace GUI
{
    partial class SearchForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.FuelBox = new System.Windows.Forms.TextBox();
            this.CheckFuelLessBox = new System.Windows.Forms.CheckBox();
            this.CheckHelicopterBox = new System.Windows.Forms.CheckBox();
            this.CheckHybridCarBox = new System.Windows.Forms.CheckBox();
            this.CheckCarBox = new System.Windows.Forms.CheckBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.CheckFuelGroupBox = new System.Windows.Forms.GroupBox();
            this.CheckFuelMoreBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.CheckFuelGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SearchButton);
            this.groupBox1.Controls.Add(this.CheckFuelGroupBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.FuelBox);
            this.groupBox1.Controls.Add(this.CheckHelicopterBox);
            this.groupBox1.Controls.Add(this.CheckHybridCarBox);
            this.groupBox1.Controls.Add(this.CheckCarBox);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(229, 147);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Найти транспорт";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 88);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "л";
            // 
            // FuelBox
            // 
            this.FuelBox.Location = new System.Drawing.Point(149, 85);
            this.FuelBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FuelBox.Name = "FuelBox";
            this.FuelBox.Size = new System.Drawing.Size(50, 20);
            this.FuelBox.TabIndex = 1;
            this.FuelBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberBox_KeyPress);
            // 
            // CheckFuelLessBox
            // 
            this.CheckFuelLessBox.AutoSize = true;
            this.CheckFuelLessBox.Location = new System.Drawing.Point(5, 18);
            this.CheckFuelLessBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CheckFuelLessBox.Name = "CheckFuelLessBox";
            this.CheckFuelLessBox.Size = new System.Drawing.Size(67, 17);
            this.CheckFuelLessBox.TabIndex = 2;
            this.CheckFuelLessBox.Text = "Меньше";
            this.CheckFuelLessBox.UseVisualStyleBackColor = true;
            // 
            // CheckHelicopterBox
            // 
            this.CheckHelicopterBox.AutoSize = true;
            this.CheckHelicopterBox.Location = new System.Drawing.Point(10, 59);
            this.CheckHelicopterBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CheckHelicopterBox.Name = "CheckHelicopterBox";
            this.CheckHelicopterBox.Size = new System.Drawing.Size(73, 17);
            this.CheckHelicopterBox.TabIndex = 2;
            this.CheckHelicopterBox.Text = "Вертолет";
            this.CheckHelicopterBox.UseVisualStyleBackColor = true;
            // 
            // CheckHybridCarBox
            // 
            this.CheckHybridCarBox.AutoSize = true;
            this.CheckHybridCarBox.Location = new System.Drawing.Point(10, 38);
            this.CheckHybridCarBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CheckHybridCarBox.Name = "CheckHybridCarBox";
            this.CheckHybridCarBox.Size = new System.Drawing.Size(105, 17);
            this.CheckHybridCarBox.TabIndex = 2;
            this.CheckHybridCarBox.Text = "Машина-гибрид";
            this.CheckHybridCarBox.UseVisualStyleBackColor = true;
            // 
            // CheckCarBox
            // 
            this.CheckCarBox.AutoSize = true;
            this.CheckCarBox.Location = new System.Drawing.Point(10, 17);
            this.CheckCarBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CheckCarBox.Name = "CheckCarBox";
            this.CheckCarBox.Size = new System.Drawing.Size(67, 17);
            this.CheckCarBox.TabIndex = 1;
            this.CheckCarBox.Text = "Машина";
            this.CheckCarBox.UseVisualStyleBackColor = true;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(149, 120);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(67, 20);
            this.SearchButton.TabIndex = 2;
            this.SearchButton.Text = "Найти";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // CheckFuelGroupBox
            // 
            this.CheckFuelGroupBox.Controls.Add(this.CheckFuelMoreBox);
            this.CheckFuelGroupBox.Controls.Add(this.CheckFuelLessBox);
            this.CheckFuelGroupBox.Location = new System.Drawing.Point(5, 81);
            this.CheckFuelGroupBox.Name = "CheckFuelGroupBox";
            this.CheckFuelGroupBox.Size = new System.Drawing.Size(136, 59);
            this.CheckFuelGroupBox.TabIndex = 3;
            this.CheckFuelGroupBox.TabStop = false;
            this.CheckFuelGroupBox.Text = "Затраченное топливо";
            // 
            // CheckFuelMoreBox
            // 
            this.CheckFuelMoreBox.AutoSize = true;
            this.CheckFuelMoreBox.Location = new System.Drawing.Point(5, 39);
            this.CheckFuelMoreBox.Margin = new System.Windows.Forms.Padding(2);
            this.CheckFuelMoreBox.Name = "CheckFuelMoreBox";
            this.CheckFuelMoreBox.Size = new System.Drawing.Size(65, 17);
            this.CheckFuelMoreBox.TabIndex = 2;
            this.CheckFuelMoreBox.Text = "Больше";
            this.CheckFuelMoreBox.UseVisualStyleBackColor = true;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 161);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchForm";
            this.Text = "Поиск";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.CheckFuelGroupBox.ResumeLayout(false);
            this.CheckFuelGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FuelBox;
        private System.Windows.Forms.CheckBox CheckFuelLessBox;
        private System.Windows.Forms.CheckBox CheckHelicopterBox;
        private System.Windows.Forms.CheckBox CheckHybridCarBox;
        private System.Windows.Forms.CheckBox CheckCarBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.GroupBox CheckFuelGroupBox;
        private System.Windows.Forms.CheckBox CheckFuelMoreBox;
    }
}