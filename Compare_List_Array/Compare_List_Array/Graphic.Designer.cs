namespace Compare_List_Array
{
    partial class Graphic
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
            this.components = new System.ComponentModel.Container();
            this.choose_structure = new System.Windows.Forms.ComboBox();
            this.choose_operation = new System.Windows.Forms.ComboBox();
            this.start = new System.Windows.Forms.Button();
            this.Graph = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // choose_structure
            // 
            this.choose_structure.FormattingEnabled = true;
            this.choose_structure.Items.AddRange(new object[] {
            "int",
            "string"});
            this.choose_structure.Location = new System.Drawing.Point(12, 92);
            this.choose_structure.Name = "choose_structure";
            this.choose_structure.Size = new System.Drawing.Size(168, 21);
            this.choose_structure.TabIndex = 0;
            this.choose_structure.Text = "Выберите структуру";
            // 
            // choose_operation
            // 
            this.choose_operation.FormattingEnabled = true;
            this.choose_operation.Items.AddRange(new object[] {
            "get",
            "set",
            "add(index, val)"});
            this.choose_operation.Location = new System.Drawing.Point(12, 210);
            this.choose_operation.Name = "choose_operation";
            this.choose_operation.Size = new System.Drawing.Size(168, 21);
            this.choose_operation.TabIndex = 1;
            this.choose_operation.Text = "Выберите операцию";
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(21, 312);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(158, 71);
            this.start.TabIndex = 2;
            this.start.Text = "Запустить тесты";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // Graph
            // 
            this.Graph.Location = new System.Drawing.Point(201, 22);
            this.Graph.Name = "Graph";
            this.Graph.ScrollGrace = 0D;
            this.Graph.ScrollMaxX = 0D;
            this.Graph.ScrollMaxY = 0D;
            this.Graph.ScrollMaxY2 = 0D;
            this.Graph.ScrollMinX = 0D;
            this.Graph.ScrollMinY = 0D;
            this.Graph.ScrollMinY2 = 0D;
            this.Graph.Size = new System.Drawing.Size(728, 484);
            this.Graph.TabIndex = 3;
            this.Graph.UseExtendedPrintDialog = true;
            // 
            // Graphic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 537);
            this.Controls.Add(this.Graph);
            this.Controls.Add(this.start);
            this.Controls.Add(this.choose_operation);
            this.Controls.Add(this.choose_structure);
            this.Name = "Graphic";
            this.Text = "Graphic";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox choose_structure;
        private System.Windows.Forms.ComboBox choose_operation;
        private System.Windows.Forms.Button start;        
        private ZedGraph.ZedGraphControl Graph;
    }
}

