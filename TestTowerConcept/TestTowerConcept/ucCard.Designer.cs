namespace TestTowerConcept
{
    partial class ucCard
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbPic = new System.Windows.Forms.PictureBox();
            this.lInfo = new System.Windows.Forms.Label();
            this.lCri = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPic)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPic
            // 
            this.pbPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPic.Enabled = false;
            this.pbPic.Location = new System.Drawing.Point(3, 3);
            this.pbPic.Margin = new System.Windows.Forms.Padding(0);
            this.pbPic.Name = "pbPic";
            this.pbPic.Size = new System.Drawing.Size(35, 36);
            this.pbPic.TabIndex = 0;
            this.pbPic.TabStop = false;
            // 
            // lInfo
            // 
            this.lInfo.AutoSize = true;
            this.lInfo.Location = new System.Drawing.Point(3, 81);
            this.lInfo.Name = "lInfo";
            this.lInfo.Size = new System.Drawing.Size(35, 13);
            this.lInfo.TabIndex = 1;
            this.lInfo.Text = "label1";
            // 
            // lCri
            // 
            this.lCri.AutoSize = true;
            this.lCri.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lCri.Location = new System.Drawing.Point(41, 3);
            this.lCri.Name = "lCri";
            this.lCri.Size = new System.Drawing.Size(24, 17);
            this.lCri.TabIndex = 1;
            this.lCri.Text = "10";
            // 
            // ucCard
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lCri);
            this.Controls.Add(this.lInfo);
            this.Controls.Add(this.pbPic);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucCard";
            this.Size = new System.Drawing.Size(71, 100);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ucCard_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.ucCard_DragEnter);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ucCard_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ucCard_MouseDown_1);
            this.MouseEnter += new System.EventHandler(this.ucCard_MouseEnter);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ucCard_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ucCard_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPic;
        private System.Windows.Forms.Label lInfo;
        private System.Windows.Forms.Label lCri;
    }
}
