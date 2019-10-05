using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // This allows other scripts to access the PlayerController
    public static PlayerController instance;

    public Rigidbody2D theRB;

    public float moveSpeed = 5f;

    private Vector2 moveInput;
    private Vector2 mouseInput;

    public float mouseSensitivity = 1f;

    public Camera viewCam;

    // This is where the bullet will impact any object
    public GameObject bulletImpact;

    public int currentAmmo;

    public Animator gunAnim;

    private void Awake()
    {
        // This further facilitates making the PlayerController available to other scripts
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Capturing keyboard input
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // This code is to facilitate movement along the correct axis
        // despite the odd plane we're playing at.
        Vector3 moveHorizontal = transform.up * -moveInput.x;
        Vector3 moveVertical = transform.right * moveInput.y;
        theRB.velocity = (moveHorizontal + moveVertical) * moveSpeed;

        // Capturing mouse input for view control and apply mouse
        // sensitivity
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

        // This actually applies the mouse movement to the player for horizontal rotation
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x);

        // This applies the mouse movement to the *camera* for vertical rotation
        viewCam.transform.localRotation = Quaternion.Euler(viewCam.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f));

        // Shooting - shooting is done when the left mouse button (0) is pressed
        if(Input.GetMouseButtonDown(0))
        {
            if (currentAmmo > 0)
            {
                // We create a ray for raycasting that is in the middle of the screen and centered on
                // the player (x=0.5, y=0.5, z=0)
                Ray ray = viewCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
                RaycastHit hit;
                
                // This IF statement detects if the ray has collided with anything
                if(Physics.Raycast(ray, out hit))
                {
                    //Debug.Log("I'm looking at " + hit.transform.name);
                    // We create the bulletImpact (which we map to the bullet impact prefab in the 
                    // editor) at the hit.point (i.e. middle of the screen)
                    Instantiate(bulletImpact, hit.point, transform.rotation);

                    // We check to see if the bullet collided with an enemy. If so
                    // we call the enemy's takeDamage() function
                    if(hit.transform.tag == "Enemy")
                    {
                        hit.transform.parent.GetComponent<EnemyController>().takeDamage();
                    }
                } 
                else
                {
                    // Debug.Log("I'm looking at nothing");
                }

                currentAmmo--;
                gunAnim.SetTrigger("Shoot");
            }
        }


    }
}
