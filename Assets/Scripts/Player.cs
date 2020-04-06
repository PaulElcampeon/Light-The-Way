using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Horizontal Movement")]
    [SerializeField]
    private float movementSpeed = 10f;

    private float movementDir;

    void Start()
    {
        
    }

    void Update()
    {
        movementDir = Input.GetAxisRaw("Horizontal");
    }


}
