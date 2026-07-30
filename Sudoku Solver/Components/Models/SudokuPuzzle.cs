namespace Sudoku_Solver.Components.Models;

public class SudokuPuzzle
{
    public SudokuEntry[,] Puzzle { get; }
    public int Size { get; }
    public Queue<SudokuEntry> SolvableEntries { get;}

    public SudokuPuzzle(int size) // size x size ex Size = 9, sudokuPuzzle = 9x9
    {
        Size = size;
        Puzzle = new SudokuEntry[size, size];
        SolvableEntries = new Queue<SudokuEntry>();
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Puzzle[i, j] = new SudokuEntry(size,i,j);
            }
        }
    }
    
    // adds sudoku value into puzzle and updates all aligned values
    public void AddValue(int row, int col, int value)
    {
        if (Puzzle[row, col].CurrentValue != null)//dont override value
        {
            return; 
        }
        Puzzle[row, col].CurrentValue = value;
        UpdateAlignedRow(row , col, value);
        UpdateAlignedCol(row , col, value);
        UpdateAligned3X3(row , col, value);
    }

    public void SolveNextEntry()
    {
        SudokuEntry Entry = SolvableEntries.Dequeue();
        AddValue(Entry.row,Entry.col,Entry.Solve());
    }

    private void UpdateAlignedRow(int row, int col, int value)
    {
        for (int i = 0; i < Size; i++)
        {
            Puzzle[row,i].UpdateAlignedValue(value - 1);// - 1 so 0 indexed
            if (Puzzle[row, i].Solvable == true)
            {
                if (!SolvableEntries.Contains(Puzzle[row, i]))
                {
                    SolvableEntries.Enqueue(Puzzle[row, i]);
                }
            }
        }
    }

    private void UpdateAlignedCol(int row, int col, int value)
    {
        for (int i = 0; i < Size; i++)
        {
            Puzzle[i,col].UpdateAlignedValue(value - 1);// - 1 so 0 indexed
            if (Puzzle[i, col].Solvable == true)
            {
                if (!SolvableEntries.Contains(Puzzle[i, col]))
                {
                    SolvableEntries.Enqueue(Puzzle[i, col]);
                }
            }
        }
    }

    private void UpdateAligned3X3(int row, int col, int value)
    {
        int startingRow = (row/3)*3;
        int startingCol =  (col/3)*3;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Puzzle[startingRow+i,startingCol+j].UpdateAlignedValue(value - 1);
                if (Puzzle[startingRow+i, startingCol+j].Solvable == true)
                {
                    if (!SolvableEntries.Contains(Puzzle[startingRow+i, startingCol+j]))
                    {
                        SolvableEntries.Enqueue(Puzzle[startingRow+i, startingCol+j]);
                    }
                }
            }
        }
    }



}