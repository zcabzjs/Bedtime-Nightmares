using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausingGame : MonoBehaviour {

    // Use this for initialization
    public GameObject PauseUI;
    // Use this for initialization
    public bool isPaused;
    public GameObject player;
    PlayerMovement playerMovement;
    PlayerHealth playerHealth;
    public AudioSource backgroundAudio;
    void Awake()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        playerHealth = player.GetComponent<PlayerHealth>();
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerMovement.playerAtGoal && playerHealth.currentHealth > 0)
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
        
    }

    void Pause()
    {
        Time.timeScale = 0f;
        backgroundAudio.Pause();
        PauseUI.SetActive(true);
        isPaused = true;
    }

    public void Resume()
    {
        PauseUI.SetActive(false);
        backgroundAudio.Play();
        Time.timeScale = 1f;
        isPaused = false;
    }
}
