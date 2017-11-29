using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour {
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public AudioClip deathClip;

    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;
	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (isSinking)
        {
            transform.Translate(-Vector3.up * Time.deltaTime * sinkSpeed);
        }
	}

    public void TakeDamage(int damageCount, Vector3 hitPosition)
    {
        if (isDead)
        {
            return;
        }

        enemyAudio.Play();
        currentHealth -= damageCount;
        hitParticles.transform.position = hitPosition;
        hitParticles.Play();
        if(currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        capsuleCollider.isTrigger = true;
        anim.SetTrigger("IsDead");
        enemyAudio.clip = deathClip;
        enemyAudio.Play();
    }

    public void StartSinking()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        Destroy(gameObject, 2f);
    }
}
