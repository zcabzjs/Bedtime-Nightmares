using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public Toggle NormalDifficulty;
    public Toggle HardDifficulty;
	// Use this for initialization
    public void ClickToStart()
    {
        SceneManager.LoadScene(1);
    }

    public void ClickToQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void SetDifficulty()
    {
        if (NormalDifficulty.isOn)
        {
            PlayerPrefs.SetInt("Difficulty", 0);
            Debug.Log("Normal");
        }
        else if (HardDifficulty.isOn)
        {
            PlayerPrefs.SetInt("Difficulty", 1);
            Debug.Log("Hardcore");
        }
    
    }

    public void ChooseDifficulty() // Turns on the toggle based on Loaded PlayerPrefs
    {
        int difficulty = PlayerPrefs.GetInt("Difficulty", 0);
        if(difficulty == 0) // Use switch case if theres more buttons coming up
        {
            NormalDifficulty.isOn = true;
        }
        else if(difficulty == 1)
        {
            HardDifficulty.isOn = true;
        }
    }
}
