namespace ViewGame
{
    partial class LevelPlaner
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
            this.pView = new System.Windows.Forms.Panel();
            this.bSave = new System.Windows.Forms.Button();
            this.pPallete = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pView
            // 
            this.pView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pView.Location = new System.Drawing.Point(2, 3);
            this.pView.Name = "pView";
            this.pView.Size = new System.Drawing.Size(236, 425);
            this.pView.TabIndex = 0;
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(244, 386);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(171, 42);
            this.bSave.TabIndex = 2;
            this.bSave.Text = "Сохранить";
            this.bSave.UseVisualStyleBackColor = true;
            // 
            // pPallete
            // 
            this.pPallete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pPallete.Location = new System.Drawing.Point(245, 4);
            this.pPallete.Name = "pPallete";
            this.pPallete.Size = new System.Drawing.Size(170, 376);
            this.pPallete.TabIndex = 3;
            // 
            // LevelPlaner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 440);
            this.Controls.Add(this.pPallete);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.pView);
            this.Name = "LevelPlaner";
            this.Text = "LevelPlaner";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pView;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Panel pPallete;
    }
}