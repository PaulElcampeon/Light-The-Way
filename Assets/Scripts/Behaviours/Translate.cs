using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField]
    private float distanceToMove;
    [SerializeField]
    private bool shouldMoveVeritcal;

    [Header("Speed should be between 0.1 and 1f")]
    [SerializeField]
    private float speed = 1f;

    private Vector3 startingPosition;
    private Vector3 endPosition;
    private Vector3 targetPosition;

    private Rigidbody2D rgb;

    void Start()
    {

        AdjustSpeedIfNeeded();
        rgb = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;

        if (shouldMoveVeritcal)
        {
            endPosition = new Vector3(0f, distanceToMove, 0f);
        } else
        {
            endPosition = new Vector3(distanceToMove, 0f, 0f);
        }
        targetPosition = endPosition;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, startingPosition + targetPosition) <= 0.5f)
        {
            startingPosition = transform.position;

            targetPosition *= -1;
        }
    }

    private void FixedUpdate()
    {
        rgb.MovePosition(transform.position + targetPosition * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (shouldMoveVeritcal) return;

        if (other.gameObject.tag == "Player")
        {
            if (!other.gameObject.GetComponent<Player>().isJumping && !other.gameObject.GetComponent<Player>().isMoving) other.gameObject.GetComponent<Rigidbody2D>().MovePosition(other.gameObject.transform.position + targetPosition * speed * Time.fixedDeltaTime);
        }
    }

    private void AdjustSpeedIfNeeded()
    {
        if (speed > 1f) speed = 1f;
        if (speed <= 0f) speed = 0.1f;
    }
}
