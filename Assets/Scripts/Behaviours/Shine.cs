using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;


public class Shine : MonoBehaviour
{
    [SerializeField]
    private float maxRadius = 200f;

    private UnityEngine.Experimental.Rendering.Universal.Light2D light2D;

    void Start()
    {
        light2D = GetComponentInChildren<UnityEngine.Experimental.Rendering.Universal.Light2D>();
    }

    void Update()
    {
        float innerRadius = light2D.pointLightInnerRadius;
        float outerRadius = light2D.pointLightOuterRadius;

        light2D.pointLightInnerRadius = Mathf.MoveTowards(innerRadius, maxRadius, 10f * Time.deltaTime);
        light2D.pointLightOuterRadius = Mathf.MoveTowards(outerRadius, maxRadius, 10f * Time.deltaTime);
    }
}
