using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    private List<int> playerValues = new List<int> {1,1,2,2,3,3}, enemyValues = new List<int> { 1, 1, 2, 2, 3, 3 };
    public void RemoveItem(int item, bool isPlayer)
    {
        if (isPlayer) playerValues.Remove(item);
        else enemyValues.Remove(item);
    }
    public string GetItems(bool isPlayer)
    {
        
        if (isPlayer)
        {
            string temp = "Player 1: ";
            foreach (var item in playerValues)
            {
                temp += (item.ToString() + " ");
            }
            return temp;
        }
        else
        {
            string temp = "Player 2: ";
            foreach (var item in enemyValues)
            {
                temp += (item.ToString() + " "); 
            }
            return temp;
        }
    }

    public bool IsEmpty(bool isPlayer)
    {
        if (isPlayer)
        {
            if (playerValues.Count == 0)
                return true;
            else
                return false;
        }
        else
        {
            if (enemyValues.Count == 0)
                return true;
            else
                return false;
        }

    }
}
