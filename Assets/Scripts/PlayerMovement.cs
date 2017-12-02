using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
	public float speed = 6f;
    GameObject goal;
    Vector3 movement;
    Animator anim;
    Rigidbody rb;
    PlayerJump playerJump;
    PlayerHealth playerHealth;
    int floorMask;
    float cameraRayLength = 100f;
    public bool walking;
    public bool playerAtGoal;
    public Victory victory;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        playerJump = GetComponent<PlayerJump>();
        playerHealth = GetComponent<PlayerHealth>();
        goal = GameObject.FindGameObjectWithTag("Goal");

    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Move(horizontal, vertical);
        Turn();
        Animate(horizontal, vertical);
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0, v);
        movement = movement.normalized * speed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }

    void Turn()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if(Physics.Raycast(cameraRay, out floorHit, cameraRayLength, floorMask))
        {
            Vector3 turnDirection = floorHit.point - transform.position;
            turnDirection.y = 0f;
            Quaternion rotation = Quaternion.LookRotation(turnDirection);
            rb.MoveRotation(rotation);
        }
    }

    void Animate(float h, float v)
    {
         walking = (h!=0f || v!=0f) && playerJump.onGround ;
         anim.SetBool("IsWalking", walking);       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == goal && playerHealth.currentHealth > 0)
        {
            playerAtGoal = true;
            victory.playerVictory();
        }    
    }

}
