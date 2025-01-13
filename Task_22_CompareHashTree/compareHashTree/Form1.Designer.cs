namespace compareHashTree
{
    partial class Graphic
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
            this.components = new System.ComponentModel.Container();
            this.Graph = new ZedGraph.ZedGraphControl();
            this.start = new System.Windows.Forms.Button();
            this.choose_operation = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Graph
            // 
            this.Graph.Location = new System.Drawing.Point(231, 12);
            this.Graph.Name = "Graph";
            this.Graph.ScrollGrace = 0D;
            this.Graph.ScrollMaxX = 0D;
            this.Graph.ScrollMaxY = 0D;
            this.Graph.ScrollMaxY2 = 0D;
            this.Graph.ScrollMinX = 0D;
            this.Graph.ScrollMinY = 0D;
            this.Graph.ScrollMinY2 = 0D;
            this.Graph.Size = new System.Drawing.Size(811, 501);
            this.Graph.TabIndex = 0;
            this.Graph.UseExtendedPrintDialog = true;
            // 
            // start
            // 
            this.start.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.start.Location = new System.Drawing.Point(64, 343);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(119, 59);
            this.start.TabIndex = 1;
            this.start.Text = "start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // choose_operation
            // 
            this.choose_operation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.choose_operation.FormattingEnabled = true;
            this.choose_operation.Items.AddRange(new object[] {
            "Get",
            "Put",
            "Remove"});
            this.choose_operation.Location = new System.Drawing.Point(12, 171);
            this.choose_operation.Name = "choose_operation";
            this.choose_operation.Size = new System.Drawing.Size(201, 26);
            this.choose_operation.TabIndex = 2;
            this.choose_operation.Text = "Выберите операцию";
            // 
            // Graphic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 545);
            this.Controls.Add(this.choose_operation);
            this.Controls.Add(this.start);
            this.Controls.Add(this.Graph);
            this.Name = "Graphic";
            this.Text = "Graph";
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl Graph;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.ComboBox choose_operation;
    }
}

