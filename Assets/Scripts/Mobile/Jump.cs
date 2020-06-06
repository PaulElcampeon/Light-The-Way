using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public void AttempJump()
    {
        if (Player.instance.isGrounded && !Player.instance.isDead) Player.instance.isJumping = true;
    }
}
