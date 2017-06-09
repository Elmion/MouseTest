namespace ViewGame
{
    partial class AnalyseForm
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
            this.treeView = new System.Windows.Forms.TreeView();
            this.pView = new System.Windows.Forms.Panel();
            this.bCreatePosition = new System.Windows.Forms.Button();
            this.bPairCalc = new System.Windows.Forms.Button();
            this.bLoadTest = new System.Windows.Forms.Button();
            this.bRandom = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(290, 12);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(258, 252);
            this.treeView.TabIndex = 0;
            // 
            // pView
            // 
            this.pView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pView.Location = new System.Drawing.Point(137, 12);
            this.pView.Name = "pView";
            this.pView.Size = new System.Drawing.Size(147, 252);
            this.pView.TabIndex = 1;
            // 
            // bCreatePosition
            // 
            this.bCreatePosition.Location = new System.Drawing.Point(12, 70);
            this.bCreatePosition.Name = "bCreatePosition";
            this.bCreatePosition.Size = new System.Drawing.Size(110, 23);
            this.bCreatePosition.TabIndex = 2;
            this.bCreatePosition.Text = "Создать позицию";
            this.bCreatePosition.UseVisualStyleBackColor = true;
            // 
            // bPairCalc
            // 
            this.bPairCalc.Location = new System.Drawing.Point(554, 13);
            this.bPairCalc.Name = "bPairCalc";
            this.bPairCalc.Size = new System.Drawing.Size(108, 47);
            this.bPairCalc.TabIndex = 3;
            this.bPairCalc.Text = "Посчитать дерево пар текущей позиции";
            this.bPairCalc.UseVisualStyleBackColor = true;
            this.bPairCalc.Click += new System.EventHandler(this.bPairCalc_Click);
            // 
            // bLoadTest
            // 
            this.bLoadTest.Location = new System.Drawing.Point(12, 41);
            this.bLoadTest.Name = "bLoadTest";
            this.bLoadTest.Size = new System.Drawing.Size(110, 23);
            this.bLoadTest.TabIndex = 2;
            this.bLoadTest.Text = "Загрузить тест";
            this.bLoadTest.UseVisualStyleBackColor = true;
            this.bLoadTest.Click += new System.EventHandler(this.bLoadTest_Click);
            // 
            // bRandom
            // 
            this.bRandom.Location = new System.Drawing.Point(12, 12);
            this.bRandom.Name = "bRandom";
            this.bRandom.Size = new System.Drawing.Size(110, 23);
            this.bRandom.TabIndex = 2;
            this.bRandom.Text = "Рандом";
            this.bRandom.UseVisualStyleBackColor = true;
            this.bRandom.Click += new System.EventHandler(this.bRandom_Click);
            // 
            // AnalyseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 519);
            this.Controls.Add(this.bPairCalc);
            this.Controls.Add(this.bRandom);
            this.Controls.Add(this.bLoadTest);
            this.Controls.Add(this.bCreatePosition);
            this.Controls.Add(this.pView);
            this.Controls.Add(this.treeView);
            this.Name = "AnalyseForm";
            this.Text = "AnalyseForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Panel pView;
        private System.Windows.Forms.Button bCreatePosition;
        private System.Windows.Forms.Button bPairCalc;
        private System.Windows.Forms.Button bLoadTest;
        private System.Windows.Forms.Button bRandom;
    }
}