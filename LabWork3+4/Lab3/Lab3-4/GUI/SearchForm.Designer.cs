
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
            this.CheckFuelBox = new System.Windows.Forms.CheckBox();
            this.CheckHelicopterBox = new System.Windows.Forms.CheckBox();
            this.CheckHybridCarBox = new System.Windows.Forms.CheckBox();
            this.CheckCarBox = new System.Windows.Forms.CheckBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.FuelBox);
            this.groupBox1.Controls.Add(this.CheckFuelBox);
            this.groupBox1.Controls.Add(this.CheckHelicopterBox);
            this.groupBox1.Controls.Add(this.CheckHybridCarBox);
            this.groupBox1.Controls.Add(this.CheckCarBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 133);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Найти транспорт";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(251, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "л";
            // 
            // FuelBox
            // 
            this.FuelBox.Location = new System.Drawing.Point(188, 102);
            this.FuelBox.Name = "FuelBox";
            this.FuelBox.Size = new System.Drawing.Size(57, 22);
            this.FuelBox.TabIndex = 1;
            this.FuelBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberBox_KeyPress);
            // 
            // CheckFuelBox
            // 
            this.CheckFuelBox.AutoSize = true;
            this.CheckFuelBox.Location = new System.Drawing.Point(6, 104);
            this.CheckFuelBox.Name = "CheckFuelBox";
            this.CheckFuelBox.Size = new System.Drawing.Size(176, 21);
            this.CheckFuelBox.TabIndex = 2;
            this.CheckFuelBox.Text = "Затраченное топливо";
            this.CheckFuelBox.UseVisualStyleBackColor = true;
            // 
            // CheckHelicopterBox
            // 
            this.CheckHelicopterBox.AutoSize = true;
            this.CheckHelicopterBox.Location = new System.Drawing.Point(6, 77);
            this.CheckHelicopterBox.Name = "CheckHelicopterBox";
            this.CheckHelicopterBox.Size = new System.Drawing.Size(93, 21);
            this.CheckHelicopterBox.TabIndex = 2;
            this.CheckHelicopterBox.Text = "Вертолет";
            this.CheckHelicopterBox.UseVisualStyleBackColor = true;
            // 
            // CheckHybridCarBox
            // 
            this.CheckHybridCarBox.AutoSize = true;
            this.CheckHybridCarBox.Location = new System.Drawing.Point(6, 50);
            this.CheckHybridCarBox.Name = "CheckHybridCarBox";
            this.CheckHybridCarBox.Size = new System.Drawing.Size(134, 21);
            this.CheckHybridCarBox.TabIndex = 2;
            this.CheckHybridCarBox.Text = "Машина-гибрид";
            this.CheckHybridCarBox.UseVisualStyleBackColor = true;
            // 
            // CheckCarBox
            // 
            this.CheckCarBox.AutoSize = true;
            this.CheckCarBox.Location = new System.Drawing.Point(6, 23);
            this.CheckCarBox.Name = "CheckCarBox";
            this.CheckCarBox.Size = new System.Drawing.Size(84, 21);
            this.CheckCarBox.TabIndex = 1;
            this.CheckCarBox.Text = "Машина";
            this.CheckCarBox.UseVisualStyleBackColor = true;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(209, 151);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 25);
            this.SearchButton.TabIndex = 2;
            this.SearchButton.Text = "Найти";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 184);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchForm";
            this.Text = "Поиск";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FuelBox;
        private System.Windows.Forms.CheckBox CheckFuelBox;
        private System.Windows.Forms.CheckBox CheckHelicopterBox;
        private System.Windows.Forms.CheckBox CheckHybridCarBox;
        private System.Windows.Forms.CheckBox CheckCarBox;
        private System.Windows.Forms.Button SearchButton;
    }
}