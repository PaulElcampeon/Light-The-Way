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

    [Header("Layer masks")]
    [SerializeField]
    private LayerMask groundLayerMask;

    private Rigidbody2D playerRGB;

    private Animator playerAnimator;

    private float movementDir;
    private float lastMovementInput;
    private bool isJumping;
    public bool isDead;
    private bool isGrounded;
    private bool canMove = true;

    public static Player instance;

    void Start()
    {
        instance = this;
        playerRGB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (isDead || GameManager.instance.isMenuOpen || !canMove) return;

        movementDir = Input.GetAxisRaw("Horizontal");

        ListenForJumpInput();

        ListenForThrowLightInput();

        CheckIfGrounded();
    }

    private void FixedUpdate()
    {
        Jump();

        Movement();

        Fall();

        if (playerRGB.velocity.y < -16f) playerRGB.velocity = new Vector2(playerRGB.velocity.x, -16f);
    }

    public void Dead()
    {
        isDead = true;

        StopMovement();

        playerAnimator.SetTrigger("Dead");

        GameManager.instance.isGameOver = true;
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
        if (isDead || !canMove) return;

        if (movementDir != 0) lastMovementInput = movementDir;

        playerRGB.velocity = new Vector2(movementDir * movementSpeed, playerRGB.velocity.y);
    }

    public void StopMovement()
    {
        canMove = false;
        playerRGB.velocity = new Vector2(0f, 0f);
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
        playerRGB.velocity = Vector2.up * jumpForce;
    }

    public void ActivateFall()
    {
        isGrounded = false;
        isJumping = false;
        playerRGB.gravityScale = fallingGravity;
    }

    private void CheckIfGrounded()
    {
        RaycastHit2D hit;

        float rayDistance = 0.05f;

        hit = Physics2D.Raycast(transform.position - Vector3.up/2, Vector2.down, rayDistance, groundLayerMask);
        Debug.DrawRay(transform.position - Vector3.up/2, Vector2.down * rayDistance, Color.red);

        if (hit.collider != null)
        {
            isGrounded = true;
        } 
    }
}
