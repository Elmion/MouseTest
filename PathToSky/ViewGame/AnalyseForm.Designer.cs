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
            this.bCreatePosition = new System.Windows.Forms.Button();
            this.bPairCalc = new System.Windows.Forms.Button();
            this.bLoadTest = new System.Windows.Forms.Button();
            this.bRandom = new System.Windows.Forms.Button();
            this.fieldView = new ViewGame.FieldViewControl();
            this.bViewOrgin = new System.Windows.Forms.Button();
            this.bCalcNewAlgoritm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(290, 13);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(597, 271);
            this.treeView.TabIndex = 0;
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
            this.bPairCalc.Location = new System.Drawing.Point(893, 13);
            this.bPairCalc.Name = "bPairCalc";
            this.bPairCalc.Size = new System.Drawing.Size(108, 47);
            this.bPairCalc.TabIndex = 3;
            this.bPairCalc.Text = "Посчитать базовым агоритмом";
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
            // fieldView
            // 
            this.fieldView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fieldView.Location = new System.Drawing.Point(136, 13);
            this.fieldView.Name = "fieldView";
            this.fieldView.Size = new System.Drawing.Size(146, 240);
            this.fieldView.TabIndex = 4;
            // 
            // bViewOrgin
            // 
            this.bViewOrgin.Location = new System.Drawing.Point(136, 260);
            this.bViewOrgin.Name = "bViewOrgin";
            this.bViewOrgin.Size = new System.Drawing.Size(147, 24);
            this.bViewOrgin.TabIndex = 5;
            this.bViewOrgin.Text = "Показать начальное поле";
            this.bViewOrgin.UseVisualStyleBackColor = true;
            this.bViewOrgin.Click += new System.EventHandler(this.bViewOrgin_Click);
            // 
            // bCalcNewAlgoritm
            // 
            this.bCalcNewAlgoritm.Location = new System.Drawing.Point(893, 70);
            this.bCalcNewAlgoritm.Name = "bCalcNewAlgoritm";
            this.bCalcNewAlgoritm.Size = new System.Drawing.Size(108, 47);
            this.bCalcNewAlgoritm.TabIndex = 3;
            this.bCalcNewAlgoritm.Text = "Посчитать новым алгоритмом";
            this.bCalcNewAlgoritm.UseVisualStyleBackColor = true;
            this.bCalcNewAlgoritm.Click += new System.EventHandler(this.bCalcNewAlgoritm_Click);
            // 
            // AnalyseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 519);
            this.Controls.Add(this.bViewOrgin);
            this.Controls.Add(this.fieldView);
            this.Controls.Add(this.bCalcNewAlgoritm);
            this.Controls.Add(this.bPairCalc);
            this.Controls.Add(this.bRandom);
            this.Controls.Add(this.bLoadTest);
            this.Controls.Add(this.bCreatePosition);
            this.Controls.Add(this.treeView);
            this.Name = "AnalyseForm";
            this.Text = "AnalyseForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Button bCreatePosition;
        private System.Windows.Forms.Button bPairCalc;
        private System.Windows.Forms.Button bLoadTest;
        private System.Windows.Forms.Button bRandom;
        private FieldViewControl fieldView;
        private System.Windows.Forms.Button bViewOrgin;
        private System.Windows.Forms.Button bCalcNewAlgoritm;
    }
}