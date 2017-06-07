namespace ViewGame
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.bRewrite = new System.Windows.Forms.Button();
            this.cbDeletesLine = new System.Windows.Forms.CheckBox();
            this.moveCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 420);
            this.panel1.TabIndex = 0;
            // 
            // bRewrite
            // 
            this.bRewrite.Location = new System.Drawing.Point(232, 1);
            this.bRewrite.Name = "bRewrite";
            this.bRewrite.Size = new System.Drawing.Size(102, 33);
            this.bRewrite.TabIndex = 1;
            this.bRewrite.Text = "Переписываем";
            this.bRewrite.UseVisualStyleBackColor = true;
            this.bRewrite.Click += new System.EventHandler(this.bRewrite_Click);
            // 
            // cbDeletesLine
            // 
            this.cbDeletesLine.AutoSize = true;
            this.cbDeletesLine.Location = new System.Drawing.Point(236, 394);
            this.cbDeletesLine.Name = "cbDeletesLine";
            this.cbDeletesLine.Size = new System.Drawing.Size(102, 17);
            this.cbDeletesLine.TabIndex = 2;
            this.cbDeletesLine.Text = "Удалять линии";
            this.cbDeletesLine.UseVisualStyleBackColor = true;
            // 
            // moveCancel
            // 
            this.moveCancel.Location = new System.Drawing.Point(232, 40);
            this.moveCancel.Name = "moveCancel";
            this.moveCancel.Size = new System.Drawing.Size(102, 35);
            this.moveCancel.TabIndex = 3;
            this.moveCancel.Text = "Ход назад";
            this.moveCancel.UseVisualStyleBackColor = true;
            this.moveCancel.Click += new System.EventHandler(this.moveCancel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 423);
            this.Controls.Add(this.moveCancel);
            this.Controls.Add(this.cbDeletesLine);
            this.Controls.Add(this.bRewrite);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bRewrite;
        private System.Windows.Forms.CheckBox cbDeletesLine;
        private System.Windows.Forms.Button moveCancel;
    }
}

