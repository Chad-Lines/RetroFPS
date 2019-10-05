using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    // This script simply allows us to destroy the game object after a period of
    // time which we'll define in the editor. This is handy for things like
    // temporary animations (hit animations, etc.) which need to play
    // and then disapear.
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifetime);
    }
}
