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
            this.ucCard1 = new TestTowerConcept.ucCard();
            this.ucCard2 = new TestTowerConcept.ucCard();
            this.ucCard3 = new TestTowerConcept.ucCard();
            this.ucCard4 = new TestTowerConcept.ucCard();
            this.ucCard5 = new TestTowerConcept.ucCard();
            this.SuspendLayout();
            // 
            // ucFieldView1
            // 
            this.ucFieldView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucFieldView1.Location = new System.Drawing.Point(12, 46);
            this.ucFieldView1.Name = "ucFieldView1";
            this.ucFieldView1.Size = new System.Drawing.Size(458, 110);
            this.ucFieldView1.TabIndex = 0;
            // 
            // ucCard1
            // 
            this.ucCard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucCard1.Location = new System.Drawing.Point(12, 162);
            this.ucCard1.Name = "ucCard1";
            this.ucCard1.Size = new System.Drawing.Size(68, 100);
            this.ucCard1.TabIndex = 1;
            // 
            // ucCard2
            // 
            this.ucCard2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucCard2.Location = new System.Drawing.Point(107, 162);
            this.ucCard2.Name = "ucCard2";
            this.ucCard2.Size = new System.Drawing.Size(68, 100);
            this.ucCard2.TabIndex = 1;
            // 
            // ucCard3
            // 
            this.ucCard3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucCard3.Location = new System.Drawing.Point(202, 162);
            this.ucCard3.Name = "ucCard3";
            this.ucCard3.Size = new System.Drawing.Size(68, 100);
            this.ucCard3.TabIndex = 1;
            // 
            // ucCard4
            // 
            this.ucCard4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucCard4.Location = new System.Drawing.Point(302, 162);
            this.ucCard4.Name = "ucCard4";
            this.ucCard4.Size = new System.Drawing.Size(68, 100);
            this.ucCard4.TabIndex = 1;
            // 
            // ucCard5
            // 
            this.ucCard5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucCard5.Location = new System.Drawing.Point(400, 162);
            this.ucCard5.Name = "ucCard5";
            this.ucCard5.Size = new System.Drawing.Size(68, 100);
            this.ucCard5.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 275);
            this.Controls.Add(this.ucCard5);
            this.Controls.Add(this.ucCard4);
            this.Controls.Add(this.ucCard3);
            this.Controls.Add(this.ucCard2);
            this.Controls.Add(this.ucCard1);
            this.Controls.Add(this.ucFieldView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ucFieldView ucFieldView1;
        private ucCard ucCard1;
        private ucCard ucCard2;
        private ucCard ucCard3;
        private ucCard ucCard4;
        private ucCard ucCard5;
    }
}

