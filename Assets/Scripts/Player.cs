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

    private int noOfLights = 6;

    [Header("Layer masks")]
    [SerializeField]
    private LayerMask groundLayerMask;

    public Joystick joystick;

    private Rigidbody2D playerRGB;

    private Animator playerAnimator;

    public float movementDir;
    private float lastMovementInput;
    public bool isJumping;
    public bool isMoving;
    public bool isDead;
    public bool isGrounded;
    private bool canJump = true;
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
        if (isDead || GameManager.instance.isMenuOpen) return;

        //movementDir = joystick.Horizontal;

        //if (joystick.Horizontal >= 0.2f)
        //{
        //    movementDir = 1;
        //} else if (joystick.Horizontal <= -0.2f)
        //{
        //    movementDir = -1;
        //}

        //ListenForJumpInput();

        ListenForThrowLightInput();

        CheckIfGrounded();
    }

    private void FixedUpdate()
    {
        Jump();

        Movement();

        Fall();

        if (playerRGB.velocity.y < -13f) playerRGB.velocity = new Vector2(playerRGB.velocity.x, -13f);
    }

    public void Dead()
    {
        if (isDead) return;

        isDead = true;

        SoundManager.instance.PlaySFX(2);

        StopMovement();

        playerAnimator.SetTrigger("Dead");

        GameManager.instance.isGameOver = true;
    }

    private void Jump()
    {
        if (isJumping && isGrounded && canJump) ActivateJump();
    }

    private void Fall()
    {
        if (playerRGB.velocity.y < -0.1f) ActivateFall();
    }

    private void Movement()
    {
        if (isDead) return;

        if (movementDir != 0) lastMovementInput = movementDir;
        if (movementDir == 0) isMoving = false;
        if (movementDir != 0) isMoving = true;

        if (!canMove)
        {
            playerRGB.velocity = new Vector2(0, 0);
        }
        else
        {
            playerRGB.velocity = new Vector2(movementDir * movementSpeed, playerRGB.velocity.y);
        }
    }

    public void StopMovement()
    {
        canMove = false;
        playerRGB.velocity = new Vector2(0f, 0f);
    }

    public void MergeWithRefuge(Vector2 refugePosition)
    {
        canMove = false;
        playerRGB.gravityScale = 0;
        transform.position = Vector2.MoveTowards(transform.position, refugePosition, 2f * Time.deltaTime);
    }

    private void ThrowLight()
    {
        noOfLights--;

        Vector2 velocity = new Vector2(-5f, 5f);

        if (lastMovementInput == 1) velocity = new Vector2(5f, 5f);

        GameObject throwLight = Instantiate(lightReference, transform.position, Quaternion.Euler(0f, 0f, 0f));

        throwLight.GetComponent<Rigidbody2D>().velocity = velocity;

        GameManager.instance.UpdateLightsHud(noOfLights);
    }

    private void ListenForThrowLightInput()
    {
        if (noOfLights <= 0) return;

        if (Input.GetKeyDown(KeyCode.E) && !isDead) ThrowLight(); ;
    }

    //private void ListenForJumpInput()
    //{
    //    if (joystick.Vertical >= 0.5f && isGrounded && !isDead) isJumping = true;
    //}

    private void ActivateJump()
    {
        canJump = false;
        playerRGB.gravityScale = passiveGravity;
        isGrounded = false;
        StartCoroutine(ResetJump());
        playerRGB.velocity = Vector2.up * jumpForce;

        SoundManager.instance.PlaySFX(4);
    }

    public void ActivateFall()
    {
        isJumping = false;
        playerRGB.gravityScale = fallingGravity;
    }

    private void CheckIfGrounded()
    {
        RaycastHit2D hit;
        RaycastHit2D hitLeft;
        RaycastHit2D hitRight;

        float rayDistance = 0.05f;

        hit = Physics2D.Raycast(transform.position - Vector3.up/2, Vector2.down, rayDistance, groundLayerMask);
        hitLeft = Physics2D.Raycast(transform.position - Vector3.up/2 + Vector3.left/4, Vector2.down, rayDistance, groundLayerMask);
        hitRight = Physics2D.Raycast(transform.position - Vector3.up/2 + Vector3.right/4, Vector2.down, rayDistance, groundLayerMask);

        Debug.DrawRay(transform.position - Vector3.up / 2, Vector2.down * rayDistance, Color.red);
        Debug.DrawRay(transform.position - Vector3.up / 2 + Vector3.left / 4, Vector2.down * rayDistance, Color.red);
        Debug.DrawRay(transform.position - Vector3.up / 2 + Vector3.right / 4, Vector2.down * rayDistance, Color.red);

        if (hit.collider != null || hitLeft.collider != null || hitRight.collider != null)
        {
            isGrounded = true;
        } 
    }

    private IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(0.4f);
        canJump = true;
    }
}
