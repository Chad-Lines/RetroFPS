using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{

    public GameObject p;
    public PlayerController pscript;

    public int healthAmount = 25;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // This checks to see if the player collides with the
        // ammo object
        if(other.tag == "Player")
        {
            // Add the ammount ammount to the player's ammo count
            PlayerController.instance.AddHealth(healthAmount);

            // Play sound effect
            AudioController.instance.PlayHealthPickup();

            // Destroy the ammo container 
            Destroy(gameObject);
        }

    }
}
