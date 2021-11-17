using System.Collections;
using System.Collections.Generic;
public enum CellType {
    Empty,
    One,
    Two,
    Three
}

public struct Cells
{
    public CellType cell;
    public int player;
}

public class GameField {
    private Cells[,] field;
    public GameField() {
        field = new Cells[3, 3];
        for (var i = 0; i < field.GetLength(0); i++) {
            for (var j = 0; j < field.GetLength(1); j++) {
                field[i, j].cell = CellType.Empty;
            }
        }
    }

    public void Put(int col, int row, CellType cell, bool player) {
        field[col, row].cell = cell;
        if (player)
        {
            field[col, row].player = 1; // игрок 1
        }
        else
        {
            field[col, row].player = 2; // игрок 2
        }
    }

    public bool IsEmpty (int col, int row) {
        return field[col, row].cell == CellType.Empty;
    }

    public bool IsHigher(int col, int row, CellType cell)
    {
        return cell > field[col, row].cell;
    }

    public bool HasPossibleAction() { 
        for (var i = 0; i < field.GetLength(0); i++) {
            for (var j = 0; j < field.GetLength(1); j++) {
                if (field[i, j].cell == CellType.Empty) {
                    return true;
                }
            }
        }
        return false;
    }

    public bool Has3InLine()
    {
        var case1 = field[0, 0].player == field[0, 1].player && field[0, 0].player == field[0, 2].player && field[0, 0].cell != CellType.Empty;
        var case2 = field[1, 0].player == field[1, 1].player && field[1, 0].player == field[1, 2].player && field[1, 0].cell != CellType.Empty;
        var case3 = field[2, 0].player == field[2, 1].player && field[2, 0].player == field[2, 2].player && field[2, 0].cell != CellType.Empty;

        var case4 = field[0, 0].player == field[1, 0].player && field[0, 0].player == field[2, 0].player && field[0, 0].cell != CellType.Empty;
        var case5 = field[0, 1].player == field[1, 1].player && field[0, 1].player == field[2, 1].player && field[0, 1].cell != CellType.Empty;
        var case6 = field[0, 2].player == field[1, 2].player && field[0, 2].player == field[2, 2].player && field[0, 2].cell != CellType.Empty;

        var case7 = field[0, 0].player == field[1, 1].player && field[0, 0].player == field[2, 2].player && field[0, 0].cell != CellType.Empty;
        var case8 = field[0, 2].player == field[1, 1].player && field[0, 2].player == field[2, 0].player && field[0, 2].cell != CellType.Empty;

        return case1 || case2 || case3 || case4 || case5 || case6 || case7 || case8; 
    }
    // я как индус - увеличиваю количество строк кода, чтобы больше денег получить
}