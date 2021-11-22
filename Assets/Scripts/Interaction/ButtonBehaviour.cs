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

    public void Show(bool player)
    {
        if (!player)
        {
            for (int i = 0; i < 12; i++)
            {
                if (buttonController[i].IsPressed() && i >= 6)
                    buttonController[i].RemoveButton(true);
                else if (!buttonController[i].IsPressed() && i >= 6)
                    buttonController[i].RemoveButton(false);
                else if (i < 6)
                {
                    buttonController[i].RemoveButton(true);
                }
            }
        }
        else
        {
            for (int i = 0; i < 12; i++)
            {
                if (buttonController[i].IsPressed() && i < 6)
                    buttonController[i].RemoveButton(true);
                else if (!buttonController[i].IsPressed() && i < 6)
                    buttonController[i].RemoveButton(false);
                else if (i >= 6)
                {
                    buttonController[i].RemoveButton(true);
                }
            }
        }
    }
    
    public void RemoveButton(int index)
    {
        buttonController[index].RemoveButton(true);
    }
}
