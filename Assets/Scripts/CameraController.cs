using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float smoothing = 6f;
    public GameObject player;
    Vector3 offset;
    float distanceOffset;
    int terrainMask;
	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
      
	}


    // Update is called once per frame
    void LateUpdate () {
        Vector3 cameraToPlayer = player.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, cameraToPlayer, smoothing);
	}
}
