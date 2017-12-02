using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class QuitGame : MonoBehaviour {

	// Use this for initialization
    public void QuitToMenu()
    {
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
        }
        SceneManager.LoadScene(0);
    }
}
