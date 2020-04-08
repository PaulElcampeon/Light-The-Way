using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jitter : MonoBehaviour
{
    private Vector2 targetPosition;

    void Start()
    {
        AssignTargetPositon();
    }

    void Update()
    {
        Vector2.MoveTowards(transform.position, targetPosition, 1f * Time.deltaTime);

        if (transform.position == (Vector3)targetPosition) AssignTargetPositon();
    }

    private void AssignTargetPositon()
    {
        float xPosition = Random.Range(-0.25f, 0.25f);
        float yPosition = Random.Range(0, 1f);

        targetPosition = new Vector2(xPosition, yPosition);
    }
}
