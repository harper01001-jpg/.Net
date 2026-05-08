namespace Lab5
{
    partial class Form1
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
            this.btnDraw = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rtbReflection = new System.Windows.Forms.RichTextBox();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.btnSaveXML = new System.Windows.Forms.Button();
            this.btnLoadXML = new System.Windows.Forms.Button();
            this.btnSaveBinary = new System.Windows.Forms.Button();
            this.btnLoadBinary = new System.Windows.Forms.Button();
            this.btnReflection = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(40, 82);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(125, 20);
            this.btnDraw.TabIndex = 0;
            this.btnDraw.Text = "Намалювати";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(242, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(292, 205);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // rtbReflection
            // 
            this.rtbReflection.Location = new System.Drawing.Point(242, 246);
            this.rtbReflection.Name = "rtbReflection";
            this.rtbReflection.Size = new System.Drawing.Size(292, 249);
            this.rtbReflection.TabIndex = 2;
            this.rtbReflection.Text = "";
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(40, 16);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(100, 20);
            this.txtA.TabIndex = 3;
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(40, 45);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(100, 20);
            this.txtB.TabIndex = 4;
            // 
            // btnSaveXML
            // 
            this.btnSaveXML.Location = new System.Drawing.Point(40, 111);
            this.btnSaveXML.Name = "btnSaveXML";
            this.btnSaveXML.Size = new System.Drawing.Size(125, 20);
            this.btnSaveXML.TabIndex = 6;
            this.btnSaveXML.Text = "Зберегти (XML)";
            this.btnSaveXML.UseVisualStyleBackColor = true;
            this.btnSaveXML.Click += new System.EventHandler(this.btnSaveXml_Click);
            // 
            // btnLoadXML
            // 
            this.btnLoadXML.Location = new System.Drawing.Point(40, 140);
            this.btnLoadXML.Name = "btnLoadXML";
            this.btnLoadXML.Size = new System.Drawing.Size(125, 20);
            this.btnLoadXML.TabIndex = 7;
            this.btnLoadXML.Text = "Завантажити (XML)";
            this.btnLoadXML.UseVisualStyleBackColor = true;
            this.btnLoadXML.Click += new System.EventHandler(this.btnLoadXml_Click);
            // 
            // btnSaveBinary
            // 
            this.btnSaveBinary.Location = new System.Drawing.Point(40, 169);
            this.btnSaveBinary.Name = "btnSaveBinary";
            this.btnSaveBinary.Size = new System.Drawing.Size(125, 20);
            this.btnSaveBinary.TabIndex = 8;
            this.btnSaveBinary.Text = "Зберегти (Вin)";
            this.btnSaveBinary.UseVisualStyleBackColor = true;
            this.btnSaveBinary.Click += new System.EventHandler(this.btnSaveBin_Click);
            // 
            // btnLoadBinary
            // 
            this.btnLoadBinary.Location = new System.Drawing.Point(40, 198);
            this.btnLoadBinary.Name = "btnLoadBinary";
            this.btnLoadBinary.Size = new System.Drawing.Size(125, 20);
            this.btnLoadBinary.TabIndex = 9;
            this.btnLoadBinary.Text = "Завантажити (Bin)";
            this.btnLoadBinary.UseVisualStyleBackColor = true;
            this.btnLoadBinary.Click += new System.EventHandler(this.btnLoadBin_Click);
            // 
            // btnReflection
            // 
            this.btnReflection.Location = new System.Drawing.Point(40, 227);
            this.btnReflection.Name = "btnReflection";
            this.btnReflection.Size = new System.Drawing.Size(125, 20);
            this.btnReflection.TabIndex = 10;
            this.btnReflection.Text = "Рефлексія";
            this.btnReflection.UseVisualStyleBackColor = true;
            this.btnReflection.Click += new System.EventHandler(this.btnReflection_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "а:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "b:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 532);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReflection);
            this.Controls.Add(this.btnLoadBinary);
            this.Controls.Add(this.btnSaveBinary);
            this.Controls.Add(this.btnLoadXML);
            this.Controls.Add(this.btnSaveXML);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.rtbReflection);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnDraw);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox rtbReflection;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Button btnSaveXML;
        private System.Windows.Forms.Button btnLoadXML;
        private System.Windows.Forms.Button btnSaveBinary;
        private System.Windows.Forms.Button btnLoadBinary;
        private System.Windows.Forms.Button btnReflection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

