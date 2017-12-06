using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeScore : MonoBehaviour {

    public Victory victory;
    public GameObject player;
    PlayerMovement playerMovement;
    Text text;
    // Use this for initialization
    void Awake()
    {
        text = GetComponent<Text>();
        playerMovement = player.GetComponent<PlayerMovement>();

    }
    // Update is called once per frame
    void Update () {
        if (playerMovement.playerAtGoal)
        {
            text.text = "in " + victory.overallTime.ToString("#.##") + "s."; 
        }
	}
}
