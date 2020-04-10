using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandCollider : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField]
    private float radiusLimit = 20f;

    private CircleCollider2D circleCollider2D;

    void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();    
    }

    void Update()
    {
        if (circleCollider2D.radius > radiusLimit) return;

        circleCollider2D.radius += 10f * Time.deltaTime;
    }
}
