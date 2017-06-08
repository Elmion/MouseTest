namespace ViewGame
{
    partial class LevelsList
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.bCreate = new System.Windows.Forms.Button();
            this.bDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(101, 160);
            this.listBox1.TabIndex = 0;
            // 
            // bCreate
            // 
            this.bCreate.Location = new System.Drawing.Point(110, 3);
            this.bCreate.Name = "bCreate";
            this.bCreate.Size = new System.Drawing.Size(58, 23);
            this.bCreate.TabIndex = 1;
            this.bCreate.Text = "Новый";
            this.bCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bCreate.UseVisualStyleBackColor = true;
            this.bCreate.Click += new System.EventHandler(this.bCreate_Click);
            // 
            // bDelete
            // 
            this.bDelete.Location = new System.Drawing.Point(110, 32);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(58, 23);
            this.bDelete.TabIndex = 1;
            this.bDelete.Text = "Удалить";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // LevelsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.bCreate);
            this.Controls.Add(this.listBox1);
            this.Name = "LevelsList";
            this.Size = new System.Drawing.Size(170, 164);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button bCreate;
        private System.Windows.Forms.Button bDelete;
    }
}
