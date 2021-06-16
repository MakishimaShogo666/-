
namespace GUI
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGridVehicle = new System.Windows.Forms.DataGridView();
            this.AddTransport = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RemoveTransport = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.Loadbutton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridVehicle)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGridVehicle
            // 
            this.DataGridVehicle.AllowUserToAddRows = false;
            this.DataGridVehicle.AllowUserToDeleteRows = false;
            this.DataGridVehicle.AllowUserToResizeColumns = false;
            this.DataGridVehicle.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Format = "N3";
            dataGridViewCellStyle4.NullValue = null;
            this.DataGridVehicle.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DataGridVehicle.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.DataGridVehicle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.Format = "N3";
            dataGridViewCellStyle5.NullValue = null;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridVehicle.DefaultCellStyle = dataGridViewCellStyle5;
            this.DataGridVehicle.Location = new System.Drawing.Point(4, 17);
            this.DataGridVehicle.Margin = new System.Windows.Forms.Padding(2);
            this.DataGridVehicle.Name = "DataGridVehicle";
            this.DataGridVehicle.ReadOnly = true;
            this.DataGridVehicle.RowHeadersVisible = false;
            this.DataGridVehicle.RowHeadersWidth = 51;
            dataGridViewCellStyle6.Format = "N3";
            dataGridViewCellStyle6.NullValue = null;
            this.DataGridVehicle.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DataGridVehicle.RowTemplate.Height = 24;
            this.DataGridVehicle.Size = new System.Drawing.Size(267, 125);
            this.DataGridVehicle.TabIndex = 0;
            // 
            // AddTransport
            // 
            this.AddTransport.Location = new System.Drawing.Point(290, 49);
            this.AddTransport.Margin = new System.Windows.Forms.Padding(2);
            this.AddTransport.Name = "AddTransport";
            this.AddTransport.Size = new System.Drawing.Size(126, 20);
            this.AddTransport.TabIndex = 1;
            this.AddTransport.Text = "Добавить";
            this.AddTransport.UseVisualStyleBackColor = true;
            this.AddTransport.Click += new System.EventHandler(this.AddTransport_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DataGridVehicle);
            this.groupBox1.Location = new System.Drawing.Point(9, 32);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(276, 147);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация о затраченном топливе";
            // 
            // RemoveTransport
            // 
            this.RemoveTransport.Location = new System.Drawing.Point(289, 73);
            this.RemoveTransport.Margin = new System.Windows.Forms.Padding(2);
            this.RemoveTransport.Name = "RemoveTransport";
            this.RemoveTransport.Size = new System.Drawing.Size(126, 20);
            this.RemoveTransport.TabIndex = 4;
            this.RemoveTransport.Text = "Удалить";
            this.RemoveTransport.UseVisualStyleBackColor = true;
            this.RemoveTransport.Click += new System.EventHandler(this.RemoveTransport_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(290, 97);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(2);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(126, 20);
            this.SearchButton.TabIndex = 6;
            this.SearchButton.Text = "Найти";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(290, 121);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(2);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(126, 20);
            this.ClearButton.TabIndex = 7;
            this.ClearButton.Text = "Очистить";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // Loadbutton
            // 
            this.Loadbutton.Location = new System.Drawing.Point(9, 6);
            this.Loadbutton.Margin = new System.Windows.Forms.Padding(2);
            this.Loadbutton.Name = "Loadbutton";
            this.Loadbutton.Size = new System.Drawing.Size(93, 20);
            this.Loadbutton.TabIndex = 8;
            this.Loadbutton.Text = "Загрузить";
            this.Loadbutton.UseVisualStyleBackColor = true;
            this.Loadbutton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(106, 6);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(101, 20);
            this.SaveButton.TabIndex = 9;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 182);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.Loadbutton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.RemoveTransport);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.AddTransport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Вычисление затраченного транспортом топлива";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridVehicle)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridVehicle;
        private System.Windows.Forms.Button AddTransport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button RemoveTransport;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button Loadbutton;
        private System.Windows.Forms.Button SaveButton;
    }
}

