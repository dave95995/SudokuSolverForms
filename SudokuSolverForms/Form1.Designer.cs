namespace SudokuSolverForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableGrid = new TableLayoutPanel();
            buttonClear = new Button();
            buttonSolve = new Button();
            SuspendLayout();
            // 
            // tableGrid
            // 
            tableGrid.ColumnCount = 2;
            tableGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableGrid.Location = new Point(12, 12);
            tableGrid.Name = "tableGrid";
            tableGrid.RowCount = 2;
            tableGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableGrid.Size = new Size(550, 550);
            tableGrid.TabIndex = 0;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(12, 584);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(160, 57);
            buttonClear.TabIndex = 1;
            buttonClear.Text = "Clear";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // buttonSolve
            // 
            buttonSolve.Location = new Point(402, 584);
            buttonSolve.Name = "buttonSolve";
            buttonSolve.Size = new Size(160, 57);
            buttonSolve.TabIndex = 2;
            buttonSolve.Text = "Solve";
            buttonSolve.UseVisualStyleBackColor = true;
            buttonSolve.Click += buttonSolve_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(574, 669);
            Controls.Add(buttonSolve);
            Controls.Add(buttonClear);
            Controls.Add(tableGrid);
            Name = "Form1";
            Text = "Sudoku Solver";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableGrid;
        private Button buttonClear;
        private Button buttonSolve;
    }
}
