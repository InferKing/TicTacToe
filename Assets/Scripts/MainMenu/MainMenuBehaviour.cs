using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBehaviour : MonoBehaviour
{
    public void StartTheGame() {
        SceneLoader.GetInstance().LoadScene("GameScene");
    }
}
