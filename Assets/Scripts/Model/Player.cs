using System.Collections;
using System.Collections.Generic;

public  struct GameAction {
    public int col;
    public int row;

    public GameAction(int col, int row) {
        this.col = col;
        this.row = row;
    }
}
public interface Player {
    public IEnumerator NextTurn(GameField field);
    public GameAction? GetLastAction();
}