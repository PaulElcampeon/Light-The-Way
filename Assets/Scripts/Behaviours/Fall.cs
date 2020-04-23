using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField]
    private float delay;
    private bool playerPresent;

    void Update()
    {
        if (playerPresent)
        {
            delay -= Time.deltaTime;

            if (delay <= 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, -100f), 8f * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerPresent = true;
        }
    }
}
