namespace TestTowerConcept
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
            this.ucFieldView1 = new TestTowerConcept.ucFieldView();
            this.ucCristalCollector1 = new TestTowerConcept.ucCristalCollector();
            this.SuspendLayout();
            // 
            // ucFieldView1
            // 
            this.ucFieldView1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ucFieldView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucFieldView1.Location = new System.Drawing.Point(12, 46);
            this.ucFieldView1.Name = "ucFieldView1";
            this.ucFieldView1.Size = new System.Drawing.Size(456, 103);
            this.ucFieldView1.TabIndex = 0;
            // 
            // ucCristalCollector1
            // 
            this.ucCristalCollector1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucCristalCollector1.Location = new System.Drawing.Point(13, 4);
            this.ucCristalCollector1.Name = "ucCristalCollector1";
            this.ucCristalCollector1.Size = new System.Drawing.Size(86, 40);
            this.ucCristalCollector1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 275);
            this.Controls.Add(this.ucCristalCollector1);
            this.Controls.Add(this.ucFieldView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ucFieldView ucFieldView1;
        private ucCristalCollector ucCristalCollector1;
    }
}

