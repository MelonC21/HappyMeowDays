using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementUniversal : MonoBehaviour
{
    //reference call to the scriptable object for the players
    public PlayerMovementScriptable PlyrMovSts;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    private float currentMoveSpeed;
    private float currentJumpForce;

    Vector3 moveDirection;

    bool readyToJump;

    Rigidbody rb;

    private void Start()
    {
        currentMoveSpeed = PlyrMovSts.moveSpeed;
        currentJumpForce = PlyrMovSts.jumpForce;

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        resetJump();

    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();

        if (grounded)
        {
            rb.drag = PlyrMovSts.groundDrag;

        }
        else
        {
            rb.drag = 0f;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw(PlyrMovSts.Horizontal);
        verticalInput = Input.GetAxisRaw(PlyrMovSts.Vertical);

        if (Input.GetKey(PlyrMovSts.jumpButton) && readyToJump && grounded)
        {
            readyToJump = false;

            smallJump();

            Invoke(nameof(resetJump), PlyrMovSts.jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (grounded)
            rb.AddForce(moveDirection.normalized * PlyrMovSts.moveSpeed * 10f, ForceMode.Force);

        else if (!grounded)
            rb.AddForce(moveDirection.normalized * PlyrMovSts.moveSpeed * 10f * PlyrMovSts.airMultiplyer, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > PlyrMovSts.moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * PlyrMovSts.moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void smallJump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * PlyrMovSts.jumpForce, ForceMode.Impulse);


    }

    private void resetJump()
    {
        readyToJump = true;
    }

}
