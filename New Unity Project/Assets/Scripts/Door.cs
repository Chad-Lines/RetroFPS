using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Be able to get the location of the door
    public Transform doorModel;

    // Collider object
    public GameObject colObject;

    // The speed at which the door opens
    public float openSpeed;

    private bool shouldOpen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(shouldOpen && doorModel.position.z != 1f)
        {

            Debug.Log("Door should open");

            // If the door should open, we move the player to -1 on the z access (x, y, z)
            doorModel.position = Vector3.MoveTowards(doorModel.position, new Vector3(doorModel.position.x, doorModel.position.y, 1f), openSpeed * Time.deltaTime);

            // Once the door is out of the way, we disable the collider
            if(doorModel.position.z == 1f)
            {
                colObject.SetActive(false);
            }
        } else if(!shouldOpen && doorModel.position.z != 0f)
        {            
            // if the door should be shut, but is currently open...
            Debug.Log("Door should shut");
            
            // This is basically the opposite of the code above. We are shutting the door by moving it up and reactivating
            // the collider
            doorModel.position = Vector3.MoveTowards(doorModel.position, new Vector3(doorModel.position.x, doorModel.position.y, 0f), openSpeed * Time.deltaTime);
            
            if(doorModel.position.z == 0f)
            {
                colObject.SetActive(true);
            }
        }

    }

    // the trigger for when the door should open
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        // If the player collides with the collider (area2D basically)
        if(other.tag == "Player")
        {
            shouldOpen = true;
        }
    }      

    // the trigger for when the door should close
    private void OnTriggerExit2D(Collider2D other)
    {
        
        // If the player exits the collider (area2D basically)
        if(other.tag == "Player")
        {
            shouldOpen = false;
        }
    }
}
