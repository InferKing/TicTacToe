using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private string text;
    public int index;
    [SerializeField] private Text textField;
    public void SetText()
    {
        text = textField.text;
    }
    public string GetText()
    {
        return text != null ? text : "ERROR";
    }
    
    public void RemoveButton()
    {
        gameObject.SetActive(false);
    }

    public bool IsActivated()
    {
        return gameObject.activeInHierarchy;
    }
}
