namespace ViewGame
{
    partial class FullGameForm
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
            this.bRestart = new System.Windows.Forms.Button();
            this.moveCancel = new System.Windows.Forms.Button();
            this.cbDeletesLine = new System.Windows.Forms.CheckBox();
            this.bRewrite = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // bRestart
            // 
            this.bRestart.Location = new System.Drawing.Point(232, 364);
            this.bRestart.Name = "bRestart";
            this.bRestart.Size = new System.Drawing.Size(102, 24);
            this.bRestart.TabIndex = 7;
            this.bRestart.Text = "Рестарт";
            this.bRestart.UseVisualStyleBackColor = true;
            this.bRestart.Click += new System.EventHandler(this.bRestart_Click_1);
            // 
            // moveCancel
            // 
            this.moveCancel.Location = new System.Drawing.Point(232, 40);
            this.moveCancel.Name = "moveCancel";
            this.moveCancel.Size = new System.Drawing.Size(102, 35);
            this.moveCancel.TabIndex = 8;
            this.moveCancel.Text = "Ход назад";
            this.moveCancel.UseVisualStyleBackColor = true;
            // 
            // cbDeletesLine
            // 
            this.cbDeletesLine.AutoSize = true;
            this.cbDeletesLine.Location = new System.Drawing.Point(236, 394);
            this.cbDeletesLine.Name = "cbDeletesLine";
            this.cbDeletesLine.Size = new System.Drawing.Size(102, 17);
            this.cbDeletesLine.TabIndex = 6;
            this.cbDeletesLine.Text = "Удалять линии";
            this.cbDeletesLine.UseVisualStyleBackColor = true;
            // 
            // bRewrite
            // 
            this.bRewrite.Location = new System.Drawing.Point(232, 1);
            this.bRewrite.Name = "bRewrite";
            this.bRewrite.Size = new System.Drawing.Size(102, 33);
            this.bRewrite.TabIndex = 5;
            this.bRewrite.Text = "Переписываем";
            this.bRewrite.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 420);
            this.panel1.TabIndex = 4;
            // 
            // FullGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 423);
            this.Controls.Add(this.bRestart);
            this.Controls.Add(this.moveCancel);
            this.Controls.Add(this.cbDeletesLine);
            this.Controls.Add(this.bRewrite);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(353, 462);
            this.MinimumSize = new System.Drawing.Size(353, 462);
            this.Name = "FullGameForm";
            this.Text = "Полная игра";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bRestart;
        private System.Windows.Forms.Button moveCancel;
        private System.Windows.Forms.CheckBox cbDeletesLine;
        private System.Windows.Forms.Button bRewrite;
        private System.Windows.Forms.Panel panel1;
    }
}