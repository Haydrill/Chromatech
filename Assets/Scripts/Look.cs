using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    public Transform playerCamera;
    public Transform orientation;

    public WallRun wallRun;

    // variables for mouse input and camera rotation
    float mouseX, mouseY;
    float xRot, yRot;
    public float mouseSensitivity = 30;

    public EndGameMgr gameStateCheck;
    public bool gameOver = false;

    private void Start()
    {
        // lock the cursor and hide it during playtime
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameOver = gameStateCheck.gameOver;
        if (!gameOver)
        {
            mouseX = Input.GetAxisRaw("Mouse X");
            mouseY = Input.GetAxisRaw("Mouse Y");

            // yrot because rotating on y axis is horizontal looking
            yRot += mouseX * mouseSensitivity * 0.5f;

            // vertical looking. clamping to prevent looking beyond 90 deg
            xRot -= mouseY * mouseSensitivity;
            xRot = Mathf.Clamp(xRot, -90, 90);

            // rotate the camera
            playerCamera.transform.localRotation = Quaternion.Euler(xRot, yRot, wallRun.currentTilt);
            orientation.transform.localRotation = Quaternion.Euler(0, yRot, 0);
        }
    }
}
