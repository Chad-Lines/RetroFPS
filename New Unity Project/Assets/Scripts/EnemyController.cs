using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    // The enemy's health
    public int health = 3;

    // How close the player needs to be before the enemy
    // takes notice
    public float playerRange = 10f;

    // Assigning a rigidbody2d so the enemy has to abide physics
    public Rigidbody2D theRB;

    // how fast the enemy can move
    public float moveSpeed;

    public GameObject explosion;

    public bool shouldShoot;
    public float fireRate = 0.5f;
    private float shotCounter;
    public GameObject bullet;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the player is within range...
        if(Vector3.Distance(transform.position, PlayerController.instance.transform.position) < playerRange)
        {
            // Get the direction of the player
            Vector3 playerDirection = PlayerController.instance.transform.position - transform.position;

            // Move towards the player. We normailze the diirection so that the max is 1 ... otherwise
            // the enemy might inadvertently move very fast
            theRB.velocity = playerDirection.normalized * moveSpeed;

            // If the enemy is the type that shoots...
            if(shouldShoot)
            {
                // We start the count down
                shotCounter -= Time.deltaTime;
                // When it hits zero...
                if(shotCounter <= 0)
                {
                    // We fire a bullet...
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                    // and reset the timer
                    shotCounter = fireRate;
                }
            }

        }
        else
        {
            theRB.velocity = Vector2.zero;
        }
    }

    public void takeDamage()
    {
        // This facilitates taking damage and is called in the PlayerController script
        // when the player shoots (assuming it hits the enemy)
        health--;

        if(health <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
