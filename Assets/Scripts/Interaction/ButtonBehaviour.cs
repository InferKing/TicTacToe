using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField] private List<ButtonController> buttonController;
    private string answer;
    public (string, string) GetText()
    {
        for (int i = 0; i < 12; i++)
        {
            answer = buttonController[i].GetText();
            if (answer != "ERROR" && buttonController[i].IsActivated())
            {
                return (answer, i.ToString());
            }
        }
        return ("-1","-1");
    }
    
    public void RemoveButton(int index)
    {
        buttonController[index].RemoveButton();
    }
}
