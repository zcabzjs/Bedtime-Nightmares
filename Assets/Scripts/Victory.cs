using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour {
    public GameObject player;
    public GameObject victoryUI;
    public float overallTime;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    PlayerJump playerJump;
    Rigidbody rb;
    Animator anim;
    void Awake()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        playerJump = player.GetComponent<PlayerJump>();
        playerShooting = player.GetComponentInChildren<PlayerShooting>();
        anim = victoryUI.GetComponent<Animator>();
        rb = player.GetComponent<Rigidbody>();
    }
    // Use this for initialization
    public void playerVictory()
    {

        rb.constraints = RigidbodyConstraints.FreezePositionY; // freeze character if he jumps towards portal
        playerShooting.DisableEffects();
        playerMovement.enabled = false;
        playerShooting.enabled = false;
        playerJump.enabled = false;
        Debug.Log("Won");
        overallTime = Time.timeSinceLevelLoad;
        anim.SetTrigger("PlayerVictory");
     


    }
}
