using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Horizontal Movement")]
    [SerializeField]
    private float movementSpeed = 10f;

    [Header("Physics")]
    [SerializeField]
    private float jumpForce = 4f;
    [SerializeField]
    private float passiveGravity = 17f;
    [SerializeField]
    private float fallingGravity = 5f;

    [Header("Components")]
    [SerializeField]
    private GameObject lightReference;

    [Header("Attributes")]
    [SerializeField]
    private int layTimes = 10;

    private Rigidbody2D playerRGB;

    private float movementDir;
    private float lastMovementInput;
    private bool isJumping;
    public bool isFalling;
    public bool isDead;
    private bool isGrounded;


    void Start()
    {
        playerRGB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead) return;

        movementDir = Input.GetAxisRaw("Horizontal");

        ListenForJumpInput();

        ListenForThrowLightInput();
    }

    private void FixedUpdate()
    {
        Jump();

        Movement();

        Fall();

        if (playerRGB.velocity.y < -17f) playerRGB.velocity = new Vector2(playerRGB.velocity.x, -17f);
    }

    private void Jump()
    {
        if (isJumping && isGrounded) ActivateJump();
    }

    private void Fall()
    {
        if (playerRGB.velocity.y < -0.1f) ActivateFall();
    }

    private void Movement()
    {
        if (isDead) return;

        if (movementDir != 0) lastMovementInput = movementDir;

        playerRGB.velocity = new Vector2(movementDir * movementSpeed, playerRGB.velocity.y);
    }

    private void ThrowLight()
    {
        Vector2 velocity = new Vector2(-5f, 5f);

        if (lastMovementInput == 1) velocity = new Vector2(5f, 5f);

        GameObject throwLight = Instantiate(lightReference, transform.position, Quaternion.Euler(0f, 0f, 0f));

        throwLight.GetComponent<Rigidbody2D>().velocity = velocity;
    }

    private void ListenForThrowLightInput()
    {
        if (layTimes <= 0) return;

        if (Input.GetKeyDown(KeyCode.E) && !isDead) ThrowLight(); ;
    }

    private void ListenForJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded && !isDead) isJumping = true;
    }

    private void ActivateJump()
    {
        playerRGB.gravityScale = passiveGravity;
        isGrounded = false;
        isFalling = false;
        playerRGB.velocity = Vector2.up * jumpForce;
    }

    public void ActivateFall()
    {
        isGrounded = false;
        isJumping = false;
        isFalling = true;
        playerRGB.gravityScale = fallingGravity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor") {
            isGrounded = true;
            isJumping = false;
            isFalling = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            isGrounded = false;
        }
    }
}
