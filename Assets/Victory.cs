using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour {
    public GameObject player;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    PlayerJump playerJump;
    void Awake()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        playerJump = player.GetComponent<PlayerJump>();
        playerShooting = player.GetComponentInChildren<PlayerShooting>();
    }
    // Use this for initialization
    public void playerVictory()
    {
        playerShooting.DisableEffects();
        playerMovement.enabled = false;
        playerShooting.enabled = false;
        playerJump.enabled = false;
        Debug.Log("Won");
    }
}
