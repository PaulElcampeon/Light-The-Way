using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jitter : MonoBehaviour
{
    [Header("Enter a value between 0.1 and 1")]
    [SerializeField]
    private float speed;
    private Vector2 targetPosition;
    private Vector2 startPosition;

    void Start()
    {
        AdjustSpeedIfNeeded();
        startPosition = transform.position;
        AssignTargetPositon();
    }

    void Update()
    {
       transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position == (Vector3)targetPosition) AssignTargetPositon();
    }

    private void AssignTargetPositon()
    {
        float xPosition = Random.Range(-0.25f, 0.25f);
        float yPosition = Random.Range(0, 0.25f);

        targetPosition = new Vector2(startPosition.x + xPosition, startPosition.y + yPosition);
    }

    private void AdjustSpeedIfNeeded()
    {
        if (speed > 1f) speed = 1f;
        if (speed <= 0f) speed = 0.1f;
    }
}
