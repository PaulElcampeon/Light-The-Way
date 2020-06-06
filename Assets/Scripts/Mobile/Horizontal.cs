using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horizontal : MonoBehaviour
{

    public void Move(int direction)
    {
        Player.instance.movementDir = direction;
    }
}
