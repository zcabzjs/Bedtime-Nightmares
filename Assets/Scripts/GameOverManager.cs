using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour {

    Animator anim;
    public PlayerHealth playerHealth;
    public GameObject GameOverUI;
	// Use this for initialization
	void Awake () {
        
		anim = GameOverUI.GetComponent<Animator>(); // Get animator
        
	}
	
	// Update is called once per frame
	void Update () {
		if(playerHealth.currentHealth <= 0)
        {
            GameOverUI.SetActive(true);
            anim.SetTrigger("GameOver");
        }
	}
}
