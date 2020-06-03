using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;

    [SerializeField]
    private float movementInX = 2f;

    [SerializeField]
    private float movementInY = 2f;

    private Vector3 originalPosition;
    private Vector3 targetPosition;

    void Start()
    {
        originalPosition = transform.position;
        targetPosition = transform.position;
    }

    void Update()
    {
        if (AreWeAtTargetPosition()) AssignNewPoint();

        MoveToTargetPosition();

    }

    private bool AreWeAtTargetPosition()
    {
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f) return true;

        return false;
    }

    private void AssignNewPoint()
    {
        targetPosition = originalPosition + new Vector3(Random.Range(-movementInX, movementInX), Random.Range(-movementInY, movementInY));
    }

    private void MoveToTargetPosition()
    {
        Vector2 newPosition = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        transform.position = newPosition;
    }
}
