
namespace Syvenir
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Friday = new System.Windows.Forms.CheckBox();
            this.Thursday = new System.Windows.Forms.CheckBox();
            this.Wednesday = new System.Windows.Forms.CheckBox();
            this.Tuesday = new System.Windows.Forms.CheckBox();
            this.Monday = new System.Windows.Forms.CheckBox();
            this.btn2 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnAddKalendar1 = new System.Windows.Forms.Button();
            this.btnAddKalendar2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bntScore = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb1Year = new System.Windows.Forms.CheckBox();
            this.btnLoadXLS = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(1234, 609);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(134, 23);
            this.btn1.TabIndex = 0;
            this.btn1.Text = "Сохранить файл";
            this.btn1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(26, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1200, 415);
            this.dataGridView1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Friday);
            this.groupBox1.Controls.Add(this.Thursday);
            this.groupBox1.Controls.Add(this.Wednesday);
            this.groupBox1.Controls.Add(this.Tuesday);
            this.groupBox1.Controls.Add(this.Monday);
            this.groupBox1.Location = new System.Drawing.Point(26, 506);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 99);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Дни учебы";
            // 
            // Friday
            // 
            this.Friday.AutoSize = true;
            this.Friday.Location = new System.Drawing.Point(107, 49);
            this.Friday.Name = "Friday";
            this.Friday.Size = new System.Drawing.Size(73, 19);
            this.Friday.TabIndex = 4;
            this.Friday.Text = "Пятница";
            this.Friday.UseVisualStyleBackColor = true;
            // 
            // Thursday
            // 
            this.Thursday.AutoSize = true;
            this.Thursday.Location = new System.Drawing.Point(107, 23);
            this.Thursday.Name = "Thursday";
            this.Thursday.Size = new System.Drawing.Size(69, 19);
            this.Thursday.TabIndex = 3;
            this.Thursday.Text = "Четверг";
            this.Thursday.UseVisualStyleBackColor = true;
            // 
            // Wednesday
            // 
            this.Wednesday.AutoSize = true;
            this.Wednesday.Location = new System.Drawing.Point(7, 75);
            this.Wednesday.Name = "Wednesday";
            this.Wednesday.Size = new System.Drawing.Size(59, 19);
            this.Wednesday.TabIndex = 2;
            this.Wednesday.Text = "Среда";
            this.Wednesday.UseVisualStyleBackColor = true;
            // 
            // Tuesday
            // 
            this.Tuesday.AutoSize = true;
            this.Tuesday.Location = new System.Drawing.Point(7, 49);
            this.Tuesday.Name = "Tuesday";
            this.Tuesday.Size = new System.Drawing.Size(72, 19);
            this.Tuesday.TabIndex = 1;
            this.Tuesday.Text = "Вторник";
            this.Tuesday.UseVisualStyleBackColor = true;
            // 
            // Monday
            // 
            this.Monday.AutoSize = true;
            this.Monday.Location = new System.Drawing.Point(7, 23);
            this.Monday.Name = "Monday";
            this.Monday.Size = new System.Drawing.Size(100, 19);
            this.Monday.TabIndex = 0;
            this.Monday.Text = "Понедельник";
            this.Monday.UseVisualStyleBackColor = true;
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(1285, 33);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(83, 41);
            this.btn2.TabIndex = 3;
            this.btn2.Text = "Расчитать результат";
            this.btn2.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(26, 460);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            2025,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            2021,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(45, 23);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.Value = new decimal(new int[] {
            2021,
            0,
            0,
            0});
            // 
            // btnAddKalendar1
            // 
            this.btnAddKalendar1.Location = new System.Drawing.Point(425, 506);
            this.btnAddKalendar1.Name = "btnAddKalendar1";
            this.btnAddKalendar1.Size = new System.Drawing.Size(156, 42);
            this.btnAddKalendar1.TabIndex = 7;
            this.btnAddKalendar1.Text = "Производственный календарь 1 полугодие";
            this.btnAddKalendar1.UseVisualStyleBackColor = true;
            // 
            // btnAddKalendar2
            // 
            this.btnAddKalendar2.Location = new System.Drawing.Point(425, 568);
            this.btnAddKalendar2.Name = "btnAddKalendar2";
            this.btnAddKalendar2.Size = new System.Drawing.Size(156, 42);
            this.btnAddKalendar2.TabIndex = 8;
            this.btnAddKalendar2.Text = "Производственный календарь 2 полугодие";
            this.btnAddKalendar2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(260, 506);
            this.label1.MaximumSize = new System.Drawing.Size(160, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 568);
            this.label2.MaximumSize = new System.Drawing.Size(160, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 15);
            this.label2.TabIndex = 10;
            // 
            // bntScore
            // 
            this.bntScore.Location = new System.Drawing.Point(1105, 480);
            this.bntScore.Name = "bntScore";
            this.bntScore.Size = new System.Drawing.Size(96, 41);
            this.bntScore.TabIndex = 11;
            this.bntScore.Text = "Пересчитать Итоги";
            this.bntScore.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1285, 193);
            this.label3.MaximumSize = new System.Drawing.Size(160, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 15);
            this.label4.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(1245, 348);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(173, 100);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Учебных часов по расчету";
            // 
            // cb1Year
            // 
            this.cb1Year.AutoSize = true;
            this.cb1Year.Location = new System.Drawing.Point(425, 464);
            this.cb1Year.Name = "cb1Year";
            this.cb1Year.Size = new System.Drawing.Size(147, 19);
            this.cb1Year.TabIndex = 15;
            this.cb1Year.Text = "Первый год обучения";
            this.cb1Year.UseVisualStyleBackColor = true;
            // 
            // btnLoadXLS
            // 
            this.btnLoadXLS.Location = new System.Drawing.Point(1234, 581);
            this.btnLoadXLS.Name = "btnLoadXLS";
            this.btnLoadXLS.Size = new System.Drawing.Size(134, 23);
            this.btnLoadXLS.TabIndex = 16;
            this.btnLoadXLS.Text = "Загрузить файл";
            this.btnLoadXLS.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1475, 674);
            this.Controls.Add(this.btnLoadXLS);
            this.Controls.Add(this.cb1Year);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bntScore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddKalendar2);
            this.Controls.Add(this.btnAddKalendar1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn1);
            this.Name = "Form1";
            this.Text = "Сувенир";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox Friday;
        private System.Windows.Forms.CheckBox Thursday;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox Monday;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.CheckBox Tuesday;
        private System.Windows.Forms.CheckBox Wednesday;
        private System.Windows.Forms.Button btnAddKalendar1;
        private System.Windows.Forms.Button btnAddKalendar2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bntScore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cb1Year;
        private System.Windows.Forms.Button btnLoadXLS;
    }
}

