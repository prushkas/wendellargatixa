using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHeart : MonoBehaviour
{
    public int healthValue;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Samurai>().IncreaseLife(healthValue);
            Destroy(gameObject);
        }
    }
}
