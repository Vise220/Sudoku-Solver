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
    public void AddValue(){}
    
    
    
}