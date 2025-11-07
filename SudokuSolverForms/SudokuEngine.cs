using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverForms
{
    internal class SudokuEngine
    {
        private readonly int[,] _grid;

        public SudokuEngine(string input) => _grid = ParseString(input);

        private int[,] ParseString(String input)
        {
            int[,] grid = new int[9, 9];

            if (input.Length != 81)
            {
                throw new ArgumentException($"Input string has to be 81 digits long, input = {input.Length} characters");
            }

            for (int i = 0; i < 81; i++)
            {
                int x = i % 9;
                int y = i / 9;

                char ch = input[i];
                if (char.IsDigit(ch))
                    grid[y, x] = ch - '0';
                else
                    throw new ArgumentException($"Only digits allowed, invalid character '{ch}' at index {i}.");
            }

            return grid;
        }

        public bool IsCellValid(Point position)
        {
            int x = position.X;
            int y = position.Y;
            int value = _grid[y, x];

            // Empty cell is always valid.
            if (value == 0)
            {
                return true;
            }

            // The upper left position of the 3x3 box for the position.
            Point topLeft = new((x / 3) * 3, (y / 3) * 3);

            // Check for box violations.
            for (int y0 = topLeft.Y; y0 < topLeft.Y + 3; y0++)
            {
                for (int x0 = topLeft.X; x0 < topLeft.X + 3; x0++)
                {
                    if ((x0 != x || y0 != y) && _grid[y0, x0] == value)
                        return false;
                }
            }

            // Check for vertical and horizonal violations.
            for (int i = 0; i < 9; i++)
            {
                // Check vertical line.
                if (i != y && _grid[i, x] == value) return false;

                // Check horizotnal line.
                if (i != x && _grid[y, i] == value) return false;
            }

            return true;
        }

        public List<Point> GetEmptyCells()
        {
            List<Point> cells = [];

            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    if (_grid[y, x] == 0)
                        cells.Add(new Point(x, y));
                }
            }
            return cells;
        }

        public void DisplayBoard()
        {
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    if (_grid[y, x] != 0)
                        Console.Write(_grid[y, x] + " ");
                    else
                        Console.Write("- ");

                    // Add extra horizonal separation between the boxes.
                    if ((x + 1) % 3 == 0 && x != 8)
                        Console.Write(" ");
                }
                Console.WriteLine();

                // Add extra vertical separation between the boxes.
                if ((y + 1) % 3 == 0 && y != 8)
                    Console.WriteLine();
            }
        }

        public String GridAsString
        {
            get
            {
                string result = "";
                for (int x = 0; x < 9; x++)
                {
                    for (int y = 0; y < 9; y++)
                    {
                        result += _grid[x, y];
                    }
                }
                return result;
            }
        }

        public bool SolveWithDepthFirstSearch()
        {
            List<Point> emptyCells = GetEmptyCells();

            int emptyIndex = 0;
            while (emptyIndex < emptyCells.Count)
            {
                // This will only be negative if the puzzle contains error.
                if (emptyIndex < 0)
                {
                    return false;
                }
                Point p = emptyCells[emptyIndex];
                bool isValid = false;

                // Keep adding util we find the first valid value.
                while (_grid[p.Y, p.X] < 9)
                {
                    _grid[p.Y, p.X]++;
                    if (IsCellValid(p))
                    {
                        isValid = true;
                        break;
                    }
                }

                // Move to next empty cell.
                if (isValid)
                {
                    emptyIndex++;
                }
                else
                {
                    // No valid numbers found, move back to previous cell.
                    _grid[p.Y, p.X] = 0;
                    emptyIndex--;
                }
            }
            return true;
        }
    }
}