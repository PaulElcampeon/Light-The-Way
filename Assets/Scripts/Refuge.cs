﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refuge : MonoBehaviour
{
    private Shine shine;
    private ExpandCollider expandCollider;

    public static Refuge instance;

    void Start()
    {
        instance = this;
        shine = GetComponent<Shine>();
        expandCollider = GetComponent<ExpandCollider>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().StopMovement();
            ActivateBehaviours();
            GameManager.instance.isLevelCompleted = true;
        }

        if (other.gameObject.tag == "Enemy") Debug.Log("Yipeee");
    }

    private void ActivateBehaviours()
    {
        shine.enabled = true;
        expandCollider.enabled = true;
    }
}
