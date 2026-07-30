namespace SudokuTests;

using Sudoku_Solver.Components.Models;
[TestClass]
public sealed class Test1
{
    [TestMethod]
    public void SudokuPuzzleConstructor()
    {
        SudokuPuzzle puzzle = new SudokuPuzzle(9);
        puzzle.Puzzle[3, 3].CurrentValue = null;
        bool[] ExpectedAlignedValues = new bool[9];
        Assert.IsNull(puzzle.Puzzle[3, 3].CurrentValue);
        CollectionAssert.AreEqual(ExpectedAlignedValues,puzzle.Puzzle[3, 3].AlignedValues);
        Assert.IsNull(puzzle.Puzzle[3, 3].Solvable);
    }

    [TestMethod]
    public void SudokuPuzzleAddValue()
    {
        SudokuPuzzle puzzle = new SudokuPuzzle(9);
        puzzle.AddValue(0,0, 8);
        Assert.AreEqual(8, puzzle.Puzzle[0, 0].CurrentValue);
        Assert.IsTrue(puzzle.Puzzle[0, 1].AlignedValues[7]); // test UpdateAlignedRow
        Assert.IsTrue(puzzle.Puzzle[1, 0].AlignedValues[7]); // test UpdateAlignedCol
        Assert.IsTrue(puzzle.Puzzle[1, 1].AlignedValues[7]); // test UpdateAligned3X3


        
    }
}