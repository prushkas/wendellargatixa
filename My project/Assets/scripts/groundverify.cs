using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundverify : MonoBehaviour
{
    public Samurai player;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 6)
        {
            player.isJump = false;
            player.anim.SetBool("isJump", false);
        }
    }

}
