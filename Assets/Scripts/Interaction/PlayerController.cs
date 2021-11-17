using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float lastX;
    private float lastY;
    
    public IEnumerator NextTurn () {
        var done = false;
        while (!done) {
            if (Input.GetMouseButton(0)) {
                var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null) {
                    lastX = hit.transform.position.x;
                    lastY = hit.transform.position.y;
                    done = true;                    
                }
            }
            yield return null;
        }
    }
    public (float x, float y) GetLastAction() {
        return (lastX, lastY);
    }


}
