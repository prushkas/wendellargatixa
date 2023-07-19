using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreValue;
    public AudioSource sound;

    public void Awake()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            sound.Play();
            GameController.instance.UptadeScore(scoreValue);
            Destroy(gameObject, 0.1f);
        }
    }
}
