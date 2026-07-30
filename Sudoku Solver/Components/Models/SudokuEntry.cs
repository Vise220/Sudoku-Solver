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

    public int row;
    public int col;

    public SudokuEntry(int size , int row, int col)
    {
        AlignedValues = new bool[size];
        this.row = row;
        this.col = col;
    }
    
    public SudokuEntry(int size, int currentValue, int row, int col)
    {
        CurrentValue = currentValue;
        AlignedValues = new bool[size];
        Solvable = null;
        this.row = row;
        this.col = col;
    }

    public void UpdateAlignedValue(int insertedValue) // when inserting into puzzle updates correspoinding aligned values
    {
        if(AlignedValues is not null){
            AlignedValues[insertedValue] = true;
            Solvable = AlignedValues.Count(x => !x) == 1;
        }
    }

    public int Solve()
    {
        if (Solvable == true)
        {
            for (int i = 0; i < AlignedValues.Length; i++)
            {
                if (AlignedValues[i] == false)
                {
                    return i + 1;
                }
            }
        }
        return -1;
    }
}