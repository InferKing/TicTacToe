using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager {

    private GameField gameField;
    private bool whoIsNext;
    public event System.Action<int, int, CellType> onCellUpdated; 

    public GameManager() {
        gameField = new GameField();
        whoIsNext = true;
    }

    public void NextAction (GameAction action, int value) {
        if (gameField.IsEmpty(action.col, action.row) || gameField.IsHigher(action.col, action.row, (CellType)value)) { 
            var type = (CellType)value;
            gameField.Put(action.col, action.row, type, whoIsNext);
            onCellUpdated?.Invoke(action.col, action.row, type);
            whoIsNext = !whoIsNext; 
        }
    }

    public bool Znach(int col, int row, int value)
    {
        return gameField.IsHigher(col, row, (CellType)value);
    }

    public bool IsOver() {
        return gameField.Has3InLine() || !gameField.HasPossibleAction();
    }

    public bool GetTurn()
    {
        return whoIsNext;
    }
}