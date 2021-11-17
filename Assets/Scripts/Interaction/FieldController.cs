using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FieldController : MonoBehaviour
{
    const int FILED_WIDTH = 3;
    [SerializeField]
    private SpriteRenderer[] cells;
    [SerializeField]
    private Sprite[] cellSprites;
    void Start() {
        for (var i = 0; i < cells.Length; i++ ) {
            cells[i].sprite = GetSpriteByType(CellType.Empty);
        }
    }

    public void SetCell(int col, int row, CellType type, bool isPlayer) {
        var cell = cells[col + row * FILED_WIDTH];
        cell.sprite = GetSpriteByType(type);
        if (isPlayer) cell.color = new Color(0, 255, 0);
        else cell.color = new Color(255, 0, 0);
    }

    private Sprite GetSpriteByType(CellType type) {
        switch (type) {
            case CellType.One: return cellSprites[1]; 
            case CellType.Two: return cellSprites[2];
            case CellType.Three: return cellSprites[3];
            default: return cellSprites[0];
        }
    }
    public (int col, int row) GetCellByCoord(float x, float y) {
        var col = Mathf.FloorToInt(x - transform.position.x);
        var row = Mathf.FloorToInt(transform.position.y - y);
        return (col, row);
    }
}
