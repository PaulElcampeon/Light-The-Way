using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class Light : MonoBehaviour
{
    [SerializeField]
    private float timeToExhaust = 6f;

    private Light2D light2D;

    void Start()
    {
        light2D = GetComponentInChildren<Light2D>();
    }

    void Update()
    {
        timeToExhaust -= Time.deltaTime;

        if (timeToExhaust <= 0f)
        {
            float innerRadius = light2D.pointLightInnerRadius;
            float outerRadius = light2D.pointLightOuterRadius;

            light2D.pointLightInnerRadius = Mathf.MoveTowards(innerRadius, 0f, 0.5f * Time.deltaTime);
            light2D.pointLightOuterRadius = Mathf.MoveTowards(outerRadius, 0f, 0.5f * Time.deltaTime);

            if (innerRadius <= 0f && outerRadius <= 0f) DestroyLight();
        }
    }

    private void DestroyLight()
    {
        Destroy(gameObject);
    }
}
