using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [Header("Atributes")]
    [SerializeField]
    private float minAngle = -45f;
    [SerializeField]
    private float maxAngle = 45f;

    private float targetAngle;
    private float counter;

    void Start()
    {
        AssignTargetAngle();
    }

    void Update()
    {
        RotateToTargetAngle();

        if (counter == targetAngle) AssignTargetAngle();
    }

    private void RotateToTargetAngle()
    {
        if (targetAngle < counter) counter -= 0.5f;
        if (targetAngle > counter) counter += 0.5f;

        transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.z + counter);
    }

    private void AssignTargetAngle()
    {
        float randomAngle = Mathf.Ceil(Random.Range(-45f, 45f));

        targetAngle = randomAngle;
    }
}
