using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour {

    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnRate = 3f;
    public float spawnTime = 0.2f;
    public Transform[] spawnPoints;
    public PlayerMovement playerMovement;
    int difficulty;
    
	// Use this for initialization
	void Start () {
        difficulty = PlayerPrefs.GetInt("Difficulty", 0);
        InvokeRepeating("Spawn", spawnTime, spawnRate - difficulty);
	}
	
    void Spawn()
    {
        if(playerHealth.currentHealth <= 0f || playerMovement.playerAtGoal)
        {
            return;
        }
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        NavMeshHit hit;
        NavMesh.SamplePosition(spawnPoints[spawnPointIndex].position, out hit, 1.0f, 1);

        Instantiate(enemy, hit.position, Quaternion.identity).GetComponent<NavMeshAgent>().Warp(hit.position);

    }


}
