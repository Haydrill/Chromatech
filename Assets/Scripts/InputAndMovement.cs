using System;
using UnityEngine;

public class InputAndMovement : MonoBehaviour
{
    // Variables
    public float moveSpeed = 6f;
    public float movementMultiplier = 10f;
    public float airMovementMultiplier = 0.5f;
    public float groundDrag = 6;
    public float airDrag = 2;
    public float jumpForce = 10f;
    public float jumpsLeft = 1;

    public float runSpeed = 6f;
    public float walkSpeed = 4f;
    public float crouchSpeed = 1.5f;
    public float acceleration = 10f;

    public LayerMask groundLayer;
    public Transform orientation;

    // Not assignable
    float playerHeight = 2f;
    Rigidbody rb;

    Vector3 movementDirection;
    float horizontalMovement;
    float verticalMovement;

    // only public for viewing purposes
    public bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // prevents rotation of the player object for movement
    }

    // using Unity physics on rb so need fixed update
    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void Update()
    {
        // Use a raycast to detect if ground is directly below player
        isGrounded = Physics.CheckSphere(transform.position - new Vector3(0,1,0), 0.4f, groundLayer);
        //Debug.Log(isGrounded);

        getMovement();
        ControlDrag();
        Sprint();
        Crouch();
        // If player presses space and is also on the ground
        Jump();
        Shoot();
        Reload();
    }

    void getMovement()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        verticalMovement = Input.GetAxisRaw("Vertical") * Time.deltaTime;

        // this moves the player relative to where they are looking
        movementDirection = orientation.forward * verticalMovement + orientation.right * horizontalMovement;
    }
    void MovePlayer()
    {
        if(isGrounded)
        {
            rb.AddForce(movementDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
            jumpsLeft = 1;
        }
        else
            rb.AddForce(movementDirection.normalized * moveSpeed * movementMultiplier * airMovementMultiplier, ForceMode.Acceleration);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) && (jumpsLeft != 0))
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            jumpsLeft -= 1;
        }

    }

    void ControlDrag()
    {
        rb.drag = isGrounded ? groundDrag : airDrag;
    }

    void Sprint()
    {
        if ( Input.GetKey(KeyCode.LeftShift) && isGrounded )
        {
            moveSpeed = Mathf.Lerp(moveSpeed, runSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            moveSpeed = Mathf.Lerp(moveSpeed, walkSpeed, acceleration * Time.deltaTime);
        }
    }

    void Crouch()
    {
        if (Input.GetKey(KeyCode.C) && isGrounded)
        {
            transform.localScale = new Vector3(1f, .5f, 1f);
            moveSpeed = Mathf.Lerp(moveSpeed, crouchSpeed, acceleration * Time.deltaTime);
        }
        else if (Input.GetKeyDown(KeyCode.C) && isGrounded) // move them slightly up when uncrouching to prevent clipping
        {
            Vector3 uncrouch = new Vector3(0, 1, 0);
            transform.localPosition += uncrouch;
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            moveSpeed = Mathf.Lerp(moveSpeed, walkSpeed, acceleration * Time.deltaTime);
        }
    }

    public GameObject gun;
    public Gun gunObject;
    public LineRenderer trail;
    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(gunObject.ammoInMagazine != 0)
            {
                RaycastHit shoot;
                Physics.Raycast(gun.transform.position, gun.transform.forward, out shoot);
                trail.enabled = true;
                trail.SetPosition(0, gun.transform.position);
                trail.SetPosition(1, shoot.point);
                gunObject.GunShot();
            }
            else
            {
                gunObject.GunEmpty();
            }
        }
        else
        {
            trail.enabled = false;
        }

        
    }

    void Reload()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            gunObject.Reload();
        }
    }
}