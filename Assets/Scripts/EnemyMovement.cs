using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {
    GameObject player;
    NavMeshAgent nav;
	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        //if(enemyHealth.currentHealth > 0 && playerHealth > 0)
        //{
        nav.SetDestination(player.transform.position);
        //}
        //{
        //  nav.enabled = false;
        //}
	}
}
