namespace SudokuSolverForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tableGrid.RowStyles.Clear();
            tableGrid.ColumnStyles.Clear();

            tableGrid.RowCount = 9;
            tableGrid.ColumnCount = 9;

            // Distribute the cells evenly.
            for (int i = 0; i < 9; i++)
            {
                tableGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / 9f));
                tableGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 9f));
            }

            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    TextBox txt = new()
                    {
                        MaxLength = 1,
                        Font = new System.Drawing.Font("Segoe UI", 24),
                        Text = "",
                        Dock = DockStyle.Fill,
                        TextAlign = HorizontalAlignment.Center,
                        AutoSize = false,
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    // Checkboard pattern to visualize the 3x3 boxes.
                    if ((x / 3 + y / 3) % 2 == 0)
                        txt.BackColor = Color.LightGray;
                    tableGrid.Controls.Add(txt);
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableGrid.Controls)
            {
                c.Text = "";
                c.ForeColor = Color.Black;
            }
        }

        private void buttonSolve_Click(object sender, EventArgs e)
        {
            string inputPuzzle = "";
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    TextBox? t = tableGrid.GetControlFromPosition(x, y) as TextBox;
                    // Only sigle digits allowed with MaxLength = 1.
                    if (int.TryParse(t.Text, out int number))
                    {
                        inputPuzzle += number;
                        t.ForeColor = Color.DarkGray;
                    }
                    else
                    {
                        inputPuzzle += "0";
                    }
                }
            }

            SudokuEngine solver = new(inputPuzzle);
            if (solver.SolveWithDepthFirstSearch())
            {
                string result = solver.GridAsString;
                for (int i = 0; i < 81; i++)
                {
                    int col = i % 9;
                    int row = i / 9;
                    TextBox? t = tableGrid.GetControlFromPosition(row, col) as TextBox;
                    t.Text = result.Substring(i, 1);
                }
            }
            else
            {
                MessageBox.Show(
                    "Invalid puzzle",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}