namespace CardioMonitor
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
            this.pPicHeart = new System.Windows.Forms.Panel();
            this.pHeart = new System.Windows.Forms.Panel();
            this.bAcceleration = new System.Windows.Forms.Button();
            this.bDeceleration = new System.Windows.Forms.Button();
            this.tBPM = new System.Windows.Forms.TextBox();
            this.tPblood = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pHeart.SuspendLayout();
            this.SuspendLayout();
            // 
            // pPicHeart
            // 
            this.pPicHeart.BackgroundImage = global::CardioMonitor.Properties.Resources.Heart;
            this.pPicHeart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pPicHeart.Location = new System.Drawing.Point(6, 6);
            this.pPicHeart.Name = "pPicHeart";
            this.pPicHeart.Size = new System.Drawing.Size(55, 52);
            this.pPicHeart.TabIndex = 0;
            // 
            // pHeart
            // 
            this.pHeart.Controls.Add(this.pPicHeart);
            this.pHeart.Location = new System.Drawing.Point(12, 12);
            this.pHeart.Name = "pHeart";
            this.pHeart.Size = new System.Drawing.Size(67, 66);
            this.pHeart.TabIndex = 1;
            // 
            // bAcceleration
            // 
            this.bAcceleration.Location = new System.Drawing.Point(249, 52);
            this.bAcceleration.Name = "bAcceleration";
            this.bAcceleration.Size = new System.Drawing.Size(75, 23);
            this.bAcceleration.TabIndex = 2;
            this.bAcceleration.Text = "Ускорить";
            this.bAcceleration.UseVisualStyleBackColor = true;
            this.bAcceleration.Click += new System.EventHandler(this.bAcceleration_Click);
            // 
            // bDeceleration
            // 
            this.bDeceleration.Location = new System.Drawing.Point(249, 10);
            this.bDeceleration.Name = "bDeceleration";
            this.bDeceleration.Size = new System.Drawing.Size(75, 23);
            this.bDeceleration.TabIndex = 3;
            this.bDeceleration.Text = "Замедлить";
            this.bDeceleration.UseVisualStyleBackColor = true;
            this.bDeceleration.Click += new System.EventHandler(this.bDeceleration_Click);
            // 
            // tBPM
            // 
            this.tBPM.Enabled = false;
            this.tBPM.Location = new System.Drawing.Point(134, 12);
            this.tBPM.Name = "tBPM";
            this.tBPM.Size = new System.Drawing.Size(51, 20);
            this.tBPM.TabIndex = 4;
            // 
            // tPblood
            // 
            this.tPblood.Enabled = false;
            this.tPblood.Location = new System.Drawing.Point(134, 54);
            this.tPblood.Name = "tPblood";
            this.tPblood.Size = new System.Drawing.Size(51, 20);
            this.tPblood.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "BPM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "P blood";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 320);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tPblood);
            this.Controls.Add(this.tBPM);
            this.Controls.Add(this.bDeceleration);
            this.Controls.Add(this.bAcceleration);
            this.Controls.Add(this.pHeart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.pHeart.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pPicHeart;
        private System.Windows.Forms.Panel pHeart;
        private System.Windows.Forms.Button bAcceleration;
        private System.Windows.Forms.Button bDeceleration;
        private System.Windows.Forms.TextBox tBPM;
        private System.Windows.Forms.TextBox tPblood;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

