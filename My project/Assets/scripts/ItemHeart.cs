using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHeart : MonoBehaviour
{
    public int healthValue;
    public AudioSource sound;

    private void Awake()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            sound.Play();
            col.gameObject.GetComponent<Samurai>().IncreaseLife(healthValue);
            Destroy(gameObject, 0.1f);
        }
    }
}
