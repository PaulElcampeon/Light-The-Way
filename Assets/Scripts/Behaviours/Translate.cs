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

    private Vector3 startingPosition;
    private Vector3 endPosition;
    public Vector3 targetPosition;

    private Rigidbody2D rgb;

    void Start()
    {
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
        rgb.MovePosition(transform.position + targetPosition * Time.fixedDeltaTime);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!other.gameObject.GetComponent<Player>().isJumping && !other.gameObject.GetComponent<Player>().isMoving) other.gameObject.GetComponent<Rigidbody2D>().MovePosition(other.gameObject.transform.position + targetPosition * Time.fixedDeltaTime);
        }
    }
}
