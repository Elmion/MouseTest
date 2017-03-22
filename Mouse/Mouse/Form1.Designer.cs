namespace Mouse
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
            this.Wheel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lPulse = new System.Windows.Forms.Label();
            this.lPowerOUT = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lhangry = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lBlock = new System.Windows.Forms.Label();
            this.bEatCheese = new System.Windows.Forms.Button();
            this.bEquipHead = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lMousePowerOutput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Wheel
            // 
            this.Wheel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Wheel.Location = new System.Drawing.Point(12, 12);
            this.Wheel.Name = "Wheel";
            this.Wheel.Size = new System.Drawing.Size(279, 254);
            this.Wheel.TabIndex = 0;
            this.Wheel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Wheel_MouseDown);
            this.Wheel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Wheel_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(332, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Пульс";
            // 
            // lPulse
            // 
            this.lPulse.AutoSize = true;
            this.lPulse.Location = new System.Drawing.Point(383, 22);
            this.lPulse.Name = "lPulse";
            this.lPulse.Size = new System.Drawing.Size(35, 13);
            this.lPulse.TabIndex = 2;
            this.lPulse.Text = "label2";
            // 
            // lPowerOUT
            // 
            this.lPowerOUT.AutoSize = true;
            this.lPowerOUT.Location = new System.Drawing.Point(383, 51);
            this.lPowerOUT.Name = "lPowerOUT";
            this.lPowerOUT.Size = new System.Drawing.Size(35, 13);
            this.lPowerOUT.TabIndex = 4;
            this.lPowerOUT.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(332, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Выход";
            // 
            // lhangry
            // 
            this.lhangry.AutoSize = true;
            this.lhangry.Location = new System.Drawing.Point(383, 85);
            this.lhangry.Name = "lhangry";
            this.lhangry.Size = new System.Drawing.Size(35, 13);
            this.lhangry.TabIndex = 6;
            this.lhangry.Text = "label2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(332, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Голод";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(332, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Блок запитан";
            // 
            // lBlock
            // 
            this.lBlock.AutoSize = true;
            this.lBlock.Location = new System.Drawing.Point(414, 176);
            this.lBlock.Name = "lBlock";
            this.lBlock.Size = new System.Drawing.Size(35, 13);
            this.lBlock.TabIndex = 6;
            this.lBlock.Text = "label2";
            // 
            // bEatCheese
            // 
            this.bEatCheese.Location = new System.Drawing.Point(12, 288);
            this.bEatCheese.Name = "bEatCheese";
            this.bEatCheese.Size = new System.Drawing.Size(75, 23);
            this.bEatCheese.TabIndex = 7;
            this.bEatCheese.Text = "Съесть сыр";
            this.bEatCheese.UseVisualStyleBackColor = true;
            this.bEatCheese.Click += new System.EventHandler(this.bEatCheese_Click);
            // 
            // bEquipHead
            // 
            this.bEquipHead.Location = new System.Drawing.Point(109, 288);
            this.bEquipHead.Name = "bEquipHead";
            this.bEquipHead.Size = new System.Drawing.Size(86, 23);
            this.bEquipHead.TabIndex = 7;
            this.bEquipHead.Text = "Одеть шапку";
            this.bEquipHead.UseVisualStyleBackColor = true;
            this.bEquipHead.Click += new System.EventHandler(this.bEquipHead_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(332, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Выход мышки";
            // 
            // lMousePowerOutput
            // 
            this.lMousePowerOutput.AutoSize = true;
            this.lMousePowerOutput.Location = new System.Drawing.Point(414, 138);
            this.lMousePowerOutput.Name = "lMousePowerOutput";
            this.lMousePowerOutput.Size = new System.Drawing.Size(35, 13);
            this.lMousePowerOutput.TabIndex = 6;
            this.lMousePowerOutput.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 323);
            this.Controls.Add(this.bEquipHead);
            this.Controls.Add(this.bEatCheese);
            this.Controls.Add(this.lMousePowerOutput);
            this.Controls.Add(this.lBlock);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lhangry);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lPowerOUT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lPulse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Wheel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Wheel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lPulse;
        private System.Windows.Forms.Label lPowerOUT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lhangry;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lBlock;
        private System.Windows.Forms.Button bEatCheese;
        private System.Windows.Forms.Button bEquipHead;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lMousePowerOutput;
    }
}

