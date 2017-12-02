using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {
    Transform player;
    NavMeshAgent nav;
    EnemyHealth enemyHealth;
    PlayerHealth playerHealth;
    bool playerAtGoal;
	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        playerAtGoal = player.GetComponent<PlayerMovement>().playerAtGoal;
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();

    }
	
	// Update is called once per frame
	void Update () {
        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && !playerAtGoal)
        {
            nav.SetDestination(player.position);
        }
        else
        {
          nav.enabled = false;
        }
	}
}
