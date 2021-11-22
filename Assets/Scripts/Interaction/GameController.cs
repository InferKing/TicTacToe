using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private FieldController fieldController;
    [SerializeField]
    private GameObject gameOverObject;
    [SerializeField]
    private Text text;
    private GameManager manager;
    private int value;
    [SerializeField] private ButtonBehaviour but;
    private (string, string) s;

    void Start()
    {
        manager = new GameManager();
        manager.onCellUpdated += UpdateField;
        but.Show(manager.GetTurn());
        StartCoroutine(GameLoop());
    }
    private void UpdateField (int col, int row, CellType type) {
        fieldController.SetCell (col, row, type, manager.GetTurn());
    }
    private IEnumerator GameLoop() {
        while (!manager.IsOver()) { 
            yield return StartCoroutine(playerController.NextTurn());
            var lastAction = playerController.GetLastAction();
            s = but.GetText();
            value = int.Parse(s.Item1);
            var cell = fieldController.GetCellByCoord(lastAction.x, lastAction.y);
            if (s.Item1 == "-1" || !manager.Znach(cell.col,cell.row,value)) continue;
            but.RemoveButton(int.Parse(s.Item2));
            manager.NextAction(new GameAction(cell.col, cell.row), value);
            but.Show(manager.GetTurn());
            yield return null;
        }
        gameOverObject.SetActive(true);
        
        yield return new WaitForSeconds(2.0f);
        SceneLoader.GetInstance().LoadScene("MenuScene");
    }
}
