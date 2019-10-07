using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public int damageAmount;
    public float bulletSpeed = 3f;
    public Rigidbody2D theRB;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        // Set the direction to be towards the player's current position
        direction = PlayerController.instance.transform.position - transform.position;
        // Normalize the direction
        direction.Normalize();
        // Move the direction at the rate of bulletSpeed
        direction = direction * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = direction * bulletSpeed;
    }

    // If the bullet hits the player, the player takes damage
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerController.instance.TakeDamage(damageAmount);

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Wall(Clone)" || col.gameObject.name == "Collider" )
        {
            Destroy(gameObject);
        }else
        {
            Debug.Log("collision name = " + col.gameObject.name);
        }
        
    }
}
