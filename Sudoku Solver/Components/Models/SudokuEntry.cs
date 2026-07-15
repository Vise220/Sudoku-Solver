namespace Sudoku_Solver.Components.Models;

/// <summary>
/// represents an entry in sudoku puzzle contains the current value (int), which numbers are aligned with it (bool array)
/// and if it is solvable (bool)
/// </summary>
public class SudokuEntry
{
    public int? CurrentValue { get; set; } //null means no value yet
    
    public bool[]? AlignedValues{ get; set; } // if CurrentValue not null should be empty to save space
    
    public bool? Solvable { get; set; }

    public SudokuEntry(int size)
    {
        AlignedValues = new bool[size];
    }
    
    public SudokuEntry(int size, int currentValue)
    {
        CurrentValue = currentValue;
        AlignedValues = new bool[size];
        Solvable = null;
    }

    public SudokuEntry(SudokuPuzzle sudokuPuzzle )
    {
        CurrentValue = null;
        // code to fill AlignedValues and set solvable
    }

    public void UpdateAlignedValue(int insertedValue) // when inserting into puzzle updates correspoinding aligned values
    {
        if(AlignedValues is not null){
            AlignedValues[insertedValue] = true;
        }
    }
}