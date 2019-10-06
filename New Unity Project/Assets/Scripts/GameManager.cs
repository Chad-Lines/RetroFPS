using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LockCursor();
    }

    // Update is called once per frame
    void Update()
    {
        // Unlock the cursor if the player presses the Escape button
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UnlockCursor();
        }

        // If the player clicks back on the screen after unlocking the
        // cursor, then we relock it
        if(Input.GetMouseButton(0)){
            LockCursor();
        }
    }

    private void LockCursor()
    {
        // This is how we lock and hide the mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void UnlockCursor()
    {
        // This is how we unlock and show the mouse cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
