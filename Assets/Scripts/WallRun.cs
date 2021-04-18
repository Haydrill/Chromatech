using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRun : MonoBehaviour
{
    public InputAndMovement jumps;

    // Orientaiton for rotation
    public Transform orientation;

    // Needed for wall run
    public Rigidbody rb;

    // Wall run variables
    public float wallDist = 0.5f;
    public float minJumpHeight = 1.5f;
    public float wallRunGrav = 1f;
    public float wallJumpForce = 6f;

    public bool wallLeft = false;
    public bool wallRight = false;
    RaycastHit leftWallRaycast; // raycasts used for wall detection
    RaycastHit rightWallRaycast;

    // Camera adjustments
    public Camera cam;
    public float cameraTilt;
    public float cameraTiltTime;
    public float currentTilt;

    // Update is called once per frame
    void Update()
    {

        CheckWall();

        if (CanWallRun())
        {
            if (wallLeft)
            {
                StartWallRun();
                Debug.Log("Wall run left");
            }
            else if (wallRight)
            {
                StartWallRun();
                Debug.Log("Wall run right");
            }
            else
                EndWallRun();
        }
        else
            EndWallRun();
    }

    void CheckWall()
    {
        wallLeft = Physics.Raycast(transform.position, -orientation.right, out leftWallRaycast, wallDist);
        wallRight = Physics.Raycast(transform.position, orientation.right, out rightWallRaycast, wallDist);
    }
    bool CanWallRun()
    {
        return !Physics.Raycast(transform.position, Vector3.down, minJumpHeight); // check if the player is at least min jump height off ground
    }

    void StartWallRun()
    {
        jumps.jumpsLeft = 1;
        rb.useGravity = false;

        // use our wall run grav instead of regular during the wall run
        rb.AddForce(Vector3.down * wallRunGrav, ForceMode.Force);

        if(wallLeft)
            currentTilt = Mathf.Lerp(currentTilt, -cameraTilt, cameraTiltTime * Time.deltaTime);
        else if (wallRight)
            currentTilt = Mathf.Lerp(currentTilt, cameraTilt, cameraTiltTime * Time.deltaTime);

        // jump from wall if player hits space
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            if (wallLeft)
            {
                Vector3 jumpDirection = transform.up + leftWallRaycast.normal;
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddForce(jumpDirection * wallJumpForce * 100, ForceMode.Force);
                jumps.jumpsLeft = 1;
            }
            else if (wallRight)
            {
                Vector3 jumpDirection = transform.up + rightWallRaycast.normal;
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddForce(jumpDirection * wallJumpForce * 100, ForceMode.Force);
                jumps.jumpsLeft = 1;
            }
        }
    }
    void EndWallRun()
    {
        rb.useGravity = true;
        currentTilt = Mathf.Lerp(currentTilt, 0, cameraTiltTime * Time.deltaTime);
    }
}
