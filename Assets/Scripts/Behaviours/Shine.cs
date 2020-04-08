using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;


public class Shine : MonoBehaviour
{
    [SerializeField]
    private float maxRadius = 200f;

    private Light2D light2D;
    private bool flipSwitch;

    void Start()
    {
        light2D = GetComponentInChildren<Light2D>();
    }

    void Update()
    {
        if (!flipSwitch) return;

        float innerRadius = light2D.pointLightInnerRadius;
        float outerRadius = light2D.pointLightOuterRadius;

        light2D.pointLightInnerRadius = Mathf.MoveTowards(innerRadius, maxRadius, 10f * Time.deltaTime);
        light2D.pointLightOuterRadius = Mathf.MoveTowards(outerRadius, maxRadius, 10f * Time.deltaTime);
        //if (innerRadius >= 200f && outerRadius >= 200f) DestroyLight();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") flipSwitch = true;
    }
}
