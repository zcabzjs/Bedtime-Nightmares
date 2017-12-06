using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {
    Transform player;
    NavMeshAgent nav;
    EnemyHealth enemyHealth;
    PlayerHealth playerHealth;
    PlayerMovement playerMovement;
    int difficulty;
	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        playerMovement = player.GetComponent<PlayerMovement>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
        difficulty = PlayerPrefs.GetInt("Difficulty", 0);
        nav.speed += difficulty;
        

    }
	
	// Update is called once per frame
	void Update () {
        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && !playerMovement.playerAtGoal)
        {   
            
            nav.SetDestination(player.position);
        }
        else
        {
            nav.enabled = false;
        }
	}
}
