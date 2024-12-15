namespace _13_task
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.repeated_el = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.type_for_sort = new System.Windows.Forms.ComboBox();
            this.Graph = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Массив случайных чисел по модулю 1000",
            "С отсортированными подмассивами разного размера",
            "Отсортированные с перестановками пар элементов",
            "Отсортированные с большим числом повторов элементов"});
            this.comboBox1.Location = new System.Drawing.Point(728, 210);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(233, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "Выберите группу тестовых массивов";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(821, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 82);
            this.button1.TabIndex = 1;
            this.button1.Text = "Сгенерировать массивы";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "пузырьком, вставками, выбором, шейкерная, гномья",
            "битонная, Шелла, деревом",
            "расчёской, пирамидальная, быстрая, слиянием, подсчётом, поразрядная"});
            this.comboBox2.Location = new System.Drawing.Point(728, 321);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(233, 21);
            this.comboBox2.TabIndex = 2;
            this.comboBox2.Text = "Выберите группу сортировок";
            // 
            // repeated_el
            // 
            this.repeated_el.FormattingEnabled = true;
            this.repeated_el.Items.AddRange(new object[] {
            "10",
            "25",
            "50",
            "75",
            "90"});
            this.repeated_el.Location = new System.Drawing.Point(821, 264);
            this.repeated_el.Name = "repeated_el";
            this.repeated_el.Size = new System.Drawing.Size(140, 21);
            this.repeated_el.TabIndex = 3;
            this.repeated_el.Text = "% повторов элемента";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(840, 422);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 55);
            this.button2.TabIndex = 4;
            this.button2.Text = "Сохранить результаты";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // type_for_sort
            // 
            this.type_for_sort.FormattingEnabled = true;
            this.type_for_sort.Items.AddRange(new object[] {
            "string",
            "char",
            "pair (int, int)"});
            this.type_for_sort.Location = new System.Drawing.Point(728, 377);
            this.type_for_sort.Name = "type_for_sort";
            this.type_for_sort.Size = new System.Drawing.Size(233, 21);
            this.type_for_sort.TabIndex = 5;
            this.type_for_sort.Text = "Выберите тип сортируемых объектов";
            // 
            // Graph
            // 
            this.Graph.Location = new System.Drawing.Point(12, 12);
            this.Graph.Name = "Graph";
            this.Graph.ScrollGrace = 0D;
            this.Graph.ScrollMaxX = 0D;
            this.Graph.ScrollMaxY = 0D;
            this.Graph.ScrollMaxY2 = 0D;
            this.Graph.ScrollMinX = 0D;
            this.Graph.ScrollMinY = 0D;
            this.Graph.ScrollMinY2 = 0D;
            this.Graph.Size = new System.Drawing.Size(667, 465);
            this.Graph.TabIndex = 6;
            this.Graph.UseExtendedPrintDialog = true;
            // 
            // Graphic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 489);
            this.Controls.Add(this.Graph);
            this.Controls.Add(this.type_for_sort);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.repeated_el);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Graphic";
            this.Text = "Graphic";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox repeated_el;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox type_for_sort;
        private ZedGraph.ZedGraphControl Graph;
    }
}

