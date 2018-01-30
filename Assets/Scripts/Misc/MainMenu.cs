using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public void LoadLevel(int level)
    {
        Debug.Log("Loading game...");
        Application.LoadLevel(level);
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game...");
        Application.Quit();
    }

}
