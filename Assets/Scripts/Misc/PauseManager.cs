using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class PauseManager : MonoBehaviour {

    public GameObject PauseCanvas;
    public KeyCode pauseKey = KeyCode.Escape;

    private Blur blur;
    public bool isPaused = false;

    private void Start()
    {
        blur = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Blur>();

        isPaused = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            isPaused = !isPaused;
        }
        if(isPaused == true)
        {
            Time.timeScale = 0.0f;
            PauseCanvas.SetActive(true);
            blur.enabled = true;
        }
        else if(isPaused == false)
        {
            Time.timeScale = 1.0f;
            PauseCanvas.SetActive(false);
            blur.enabled = false;
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
