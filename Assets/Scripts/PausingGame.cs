using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausingGame : MonoBehaviour {

    // Use this for initialization
    public GameObject PauseUI;
    // Use this for initialization
    public bool isPaused;

    void Awake()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("escape"))
        {
            if (!isPaused)
            {
                Pause();
            }
            else Resume();
        }
    }

    void Pause()
    {
        Time.timeScale = 0f;
        PauseUI.SetActive(true);
        isPaused = true;
    }

    public void Resume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
