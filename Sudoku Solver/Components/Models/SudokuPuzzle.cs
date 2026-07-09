namespace Sudoku_Solver.Components.Models;

public class SudokuPuzzle
{
    public SudokuEntry[,] Puzzle { get; }

    public SudokuPuzzle(int size)
    {
        Puzzle = new SudokuEntry[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Puzzle[i, j] = new SudokuEntry();
            }
        }
    }
    
    // adds sudoku value into puzzle and updates all aligned values
    public void AddValue(int row, int col, int value)
    {
        if (Puzzle[row, col].CurrentValue != null)
        {
            //dont override value
            return; 
        }
        Puzzle[row, col].CurrentValue = value;
    }

    private void UpdateAlignedRow(int row, int col, int value)
    {
        
    }
    
    private void UpdateAlignedCol(int row, int col, int value){}

    private void UpdateAligned3x3(int row, int col, int value){}



}