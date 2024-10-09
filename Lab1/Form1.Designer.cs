namespace Lab1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button_NextStep = new System.Windows.Forms.Button();
            this.button_PrevStep = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCountNode = new System.Windows.Forms.Label();
            this.labelState = new System.Windows.Forms.Label();
            this.button_DFS = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelCountSteps = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.labelCountIteration = new System.Windows.Forms.Label();
            this.buttonLevel1 = new System.Windows.Forms.Button();
            this.buttonLevel2 = new System.Windows.Forms.Button();
            this.buttonBIS = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(827, 321);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Обновление";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(827, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 38);
            this.button2.TabIndex = 1;
            this.button2.Text = "Поиск в ширину";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_NextStep
            // 
            this.button_NextStep.Location = new System.Drawing.Point(927, 289);
            this.button_NextStep.Name = "button_NextStep";
            this.button_NextStep.Size = new System.Drawing.Size(94, 25);
            this.button_NextStep.TabIndex = 2;
            this.button_NextStep.Text = "След. шаг";
            this.button_NextStep.UseVisualStyleBackColor = true;
            this.button_NextStep.Click += new System.EventHandler(this.button_NextStep_Click);
            // 
            // button_PrevStep
            // 
            this.button_PrevStep.Location = new System.Drawing.Point(827, 289);
            this.button_PrevStep.Name = "button_PrevStep";
            this.button_PrevStep.Size = new System.Drawing.Size(94, 26);
            this.button_PrevStep.TabIndex = 3;
            this.button_PrevStep.Text = "Пред. шаг";
            this.button_PrevStep.UseVisualStyleBackColor = true;
            this.button_PrevStep.Click += new System.EventHandler(this.button_PrevStep_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(827, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Кол-во узлов:";
            // 
            // labelCountNode
            // 
            this.labelCountNode.AutoSize = true;
            this.labelCountNode.Location = new System.Drawing.Point(827, 197);
            this.labelCountNode.Name = "labelCountNode";
            this.labelCountNode.Size = new System.Drawing.Size(13, 13);
            this.labelCountNode.TabIndex = 5;
            this.labelCountNode.Text = "0";
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.Location = new System.Drawing.Point(830, 228);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(70, 13);
            this.labelState.TabIndex = 6;
            this.labelState.Text = "Номер хода:";
            // 
            // button_DFS
            // 
            this.button_DFS.Location = new System.Drawing.Point(927, 50);
            this.button_DFS.Name = "button_DFS";
            this.button_DFS.Size = new System.Drawing.Size(88, 41);
            this.button_DFS.TabIndex = 7;
            this.button_DFS.Text = "Поиск в глубину";
            this.button_DFS.UseVisualStyleBackColor = true;
            this.button_DFS.Click += new System.EventHandler(this.button_DFS_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(927, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Кол-во ходов";
            // 
            // labelCountSteps
            // 
            this.labelCountSteps.AutoSize = true;
            this.labelCountSteps.Location = new System.Drawing.Point(930, 260);
            this.labelCountSteps.Name = "labelCountSteps";
            this.labelCountSteps.Size = new System.Drawing.Size(13, 13);
            this.labelCountSteps.TabIndex = 9;
            this.labelCountSteps.Text = "0";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(927, 97);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 42);
            this.button3.TabIndex = 10;
            this.button3.Text = "В глубину с итерацией";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(927, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Кол-во итераций:";
            // 
            // labelCountIteration
            // 
            this.labelCountIteration.AutoSize = true;
            this.labelCountIteration.Location = new System.Drawing.Point(927, 197);
            this.labelCountIteration.Name = "labelCountIteration";
            this.labelCountIteration.Size = new System.Drawing.Size(13, 13);
            this.labelCountIteration.TabIndex = 12;
            this.labelCountIteration.Text = "0";
            // 
            // buttonLevel1
            // 
            this.buttonLevel1.Location = new System.Drawing.Point(830, 12);
            this.buttonLevel1.Name = "buttonLevel1";
            this.buttonLevel1.Size = new System.Drawing.Size(75, 23);
            this.buttonLevel1.TabIndex = 13;
            this.buttonLevel1.Text = "Уровень 1";
            this.buttonLevel1.UseVisualStyleBackColor = true;
            this.buttonLevel1.Click += new System.EventHandler(this.buttonLevel1_Click);
            // 
            // buttonLevel2
            // 
            this.buttonLevel2.Location = new System.Drawing.Point(911, 12);
            this.buttonLevel2.Name = "buttonLevel2";
            this.buttonLevel2.Size = new System.Drawing.Size(75, 23);
            this.buttonLevel2.TabIndex = 14;
            this.buttonLevel2.Text = "Уровень 2";
            this.buttonLevel2.UseVisualStyleBackColor = true;
            this.buttonLevel2.Click += new System.EventHandler(this.buttonLevel2_Click);
            // 
            // buttonBIS
            // 
            this.buttonBIS.Location = new System.Drawing.Point(827, 97);
            this.buttonBIS.Name = "buttonBIS";
            this.buttonBIS.Size = new System.Drawing.Size(94, 42);
            this.buttonBIS.TabIndex = 15;
            this.buttonBIS.Text = "Двунаправленный поиск";
            this.buttonBIS.UseVisualStyleBackColor = true;
            this.buttonBIS.Click += new System.EventHandler(this.buttonBIS_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 512);
            this.Controls.Add(this.buttonBIS);
            this.Controls.Add(this.buttonLevel2);
            this.Controls.Add(this.buttonLevel1);
            this.Controls.Add(this.labelCountIteration);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.labelCountSteps);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_DFS);
            this.Controls.Add(this.labelState);
            this.Controls.Add(this.labelCountNode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_PrevStep);
            this.Controls.Add(this.button_NextStep);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button_NextStep;
        private System.Windows.Forms.Button button_PrevStep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCountNode;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.Button button_DFS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelCountSteps;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelCountIteration;
        private System.Windows.Forms.Button buttonLevel1;
        private System.Windows.Forms.Button buttonLevel2;
        private System.Windows.Forms.Button buttonBIS;
    }
}

