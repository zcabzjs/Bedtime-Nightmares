using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour {

    Animator anim;
    public PlayerHealth playerHealth;
    public GameObject MainUI;
    GameObject GameOverUI;
	// Use this for initialization
	void Awake () {
        
		anim = MainUI.GetComponent<Animator>(); // Get animator
        GameOverUI = GameObject.FindGameObjectWithTag("GameOverUI");

	}
	
	// Update is called once per frame
	void Update () {
		if(playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");
            Debug.Log("Game Over");
        }
	}
}
