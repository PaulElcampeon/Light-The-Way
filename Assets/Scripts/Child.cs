using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : MonoBehaviour
{
    private float stamina = 10f;
    private Rigidbody2D rgb;
    private float jumpForce;
    private bool isGrounded;
    private Vector2 targetPosition;

    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        if (!isGrounded) stamina -= 2f * Time.deltaTime;
        if (isGrounded) stamina += 1f * Time.deltaTime;
        if (stamina > 10f) stamina = 10f;
        if (stamina < 0f) stamina = 0f;
    }

    private void FixedUpdate()
    {
        if (stamina <= 0f && !isGrounded) return;

        if (!isGrounded) rgb.velocity = new Vector2(0f, 1f);


        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }
}
