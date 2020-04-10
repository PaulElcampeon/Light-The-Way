using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    void Update()
    {
        if (GameManager.instance.isLevelCompleted) gameObject.SetActive(false);
    }
}
