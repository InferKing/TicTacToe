using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private string text;
    public int index;
    [SerializeField] private Text textField;
    private bool isPressed = false;
    public void SetText()
    {
        text = textField.text;
        isPressed = true;
    }
    public string GetText()
    {
        return text != null ? text : "ERROR";
    }
    
    public void RemoveButton(bool b)
    {
        gameObject.SetActive(!b);
    }

    public bool IsActivated()
    {
        return gameObject.activeInHierarchy;
    }
    public bool IsPressed()
    {
        return isPressed;
    }
}
