using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private static SceneLoader instance;
    public static SceneLoader GetInstance() {
        return instance;
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
        LoadScene("MenuScene");
    }

    public void LoadScene(string name) {
        SceneManager.LoadScene(name);
    }
}
