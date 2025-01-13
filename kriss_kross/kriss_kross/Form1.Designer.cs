namespace kriss_kross
{
    partial class CrissCrossFrame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrissCrossFrame));
            this.gamePicture = new System.Windows.Forms.PictureBox();
            this.listWords = new System.Windows.Forms.RichTextBox();
            this.start = new System.Windows.Forms.Button();
            this.show_solve = new System.Windows.Forms.Button();
            this.WMP = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.gamePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WMP)).BeginInit();
            this.SuspendLayout();
            // 
            // gamePicture
            // 
            this.gamePicture.Location = new System.Drawing.Point(12, 12);
            this.gamePicture.Name = "gamePicture";
            this.gamePicture.Size = new System.Drawing.Size(577, 530);
            this.gamePicture.TabIndex = 0;
            this.gamePicture.TabStop = false;
            // 
            // listWords
            // 
            this.listWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.listWords.Location = new System.Drawing.Point(599, 28);
            this.listWords.Name = "listWords";
            this.listWords.Size = new System.Drawing.Size(267, 330);
            this.listWords.TabIndex = 1;
            this.listWords.Text = "";
            // 
            // start
            // 
            this.start.Font = new System.Drawing.Font("MingLiU-ExtB", 12F, System.Drawing.FontStyle.Bold);
            this.start.Location = new System.Drawing.Point(671, 441);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(141, 86);
            this.start.TabIndex = 2;
            this.start.Text = "запускаем игру!";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // show_solve
            // 
            this.show_solve.Font = new System.Drawing.Font("MingLiU-ExtB", 11F);
            this.show_solve.Location = new System.Drawing.Point(671, 364);
            this.show_solve.Name = "show_solve";
            this.show_solve.Size = new System.Drawing.Size(141, 59);
            this.show_solve.TabIndex = 3;
            this.show_solve.Text = "показать решение";
            this.show_solve.UseVisualStyleBackColor = true;
            this.show_solve.Visible = false;
            this.show_solve.Click += new System.EventHandler(this.show_solve_Click);
            // 
            // WMP
            // 
            this.WMP.Enabled = true;
            this.WMP.Location = new System.Drawing.Point(29, 494);
            this.WMP.Name = "WMP";
            this.WMP.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("WMP.OcxState")));
            this.WMP.Size = new System.Drawing.Size(226, 32);
            this.WMP.TabIndex = 4;
            this.WMP.Visible = false;
            // 
            // CrissCrossFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 554);
            this.Controls.Add(this.WMP);
            this.Controls.Add(this.show_solve);
            this.Controls.Add(this.start);
            this.Controls.Add(this.listWords);
            this.Controls.Add(this.gamePicture);
            this.Name = "CrissCrossFrame";
            this.Text = "Крисс-Кросс";
            ((System.ComponentModel.ISupportInitialize)(this.gamePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WMP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox gamePicture;
        private System.Windows.Forms.RichTextBox listWords;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button show_solve;
        private AxWMPLib.AxWindowsMediaPlayer WMP;
    }
}

