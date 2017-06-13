namespace ViewGame
{
    partial class FieldViewControl
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
            this.pView = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pView
            // 
            this.pView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pView.Location = new System.Drawing.Point(0, 0);
            this.pView.Name = "pView";
            this.pView.Size = new System.Drawing.Size(148, 251);
            this.pView.TabIndex = 0;
            // 
            // FieldViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pView);
            this.Name = "FieldViewControl";
            this.Size = new System.Drawing.Size(148, 251);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pView;
    }
}
