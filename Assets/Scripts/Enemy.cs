using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("External Objects")]
    [SerializeField]
    private GameObject target;

    [Header("Attributes")]
    [SerializeField]
    private float movementSpeed = 0.6f;

    void Update()
    {
        MoveTowardsTarget();
    }

    private void MoveTowardsTarget()
    {
       transform.position =  Vector2.MoveTowards(transform.position, target.transform.position, movementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") Time.timeScale = 0;
    }
}
