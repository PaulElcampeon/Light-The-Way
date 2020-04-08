using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandCollider : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField]
    private float radiusLimit = 20f;

    private bool flipSwitch;
    private CircleCollider2D circleCollider2D;

    void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();    
    }

    void Update()
    {
        if (!flipSwitch) return;
        if (circleCollider2D.radius > radiusLimit) return;

        circleCollider2D.radius += 10f * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") flipSwitch = true;

        if (other.gameObject.tag == "Enemy") Debug.Log("Yipeee");
    }
}
