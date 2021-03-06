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

    private void ActivateBehaviours()
    {
        shine.enabled = true;
        expandCollider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SoundManager.instance.PlaySFX(6);

            if (Timer.instance != null) Timer.instance.shouldStop = true;

            GameManager.instance.Save();

            ActivateBehaviours();

            GameManager.instance.isLevelCompleted = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") other.gameObject.GetComponent<Player>().MergeWithRefuge(transform.position);
    }
}
