using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    // The purpose of this script is to rotate all sprites so that they are 
    // facing the player

    private SpriteRenderer theSR;
    // Start is called before the first frame update
    void Start()
    {
        // Getting the sprite-renderer component
        theSR = GetComponent<SpriteRenderer>();
        theSR.flipX = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Transform the object to face the player
        transform.LookAt(PlayerController.instance.transform.position, -Vector3.forward);
    }
}
