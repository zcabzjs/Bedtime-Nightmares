using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {
    public float jumpVelocity = 5f;
    public bool onGround;
    private Rigidbody rb;
	// Use this for initialization
	void Awake () {
        onGround = true;
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (onGround)
        {
            if (Input.GetKey("space"))
            {
                rb.velocity = new Vector3(0f, jumpVelocity, 0f);
                onGround = false;
            }
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            onGround = true;
        }    
    }
}
