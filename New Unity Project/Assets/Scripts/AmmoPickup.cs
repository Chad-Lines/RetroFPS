using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{

    // The amount of ammo that this container represents
    public int ammoAmount = 25;

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
            PlayerController.instance.currentAmmo += ammoAmount;

            // Update the UI to show the new ammo amount
            PlayerController.instance.UpdateAmmoUI();

            // Play the associated sound
            AudioController.instance.PlayAmmoPickup();

            // Destroy the ammo container 
            Destroy(gameObject);
        }

    }
}
