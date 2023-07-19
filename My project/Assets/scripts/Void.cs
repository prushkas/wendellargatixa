using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Void : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Samurai jogador = collision.gameObject.GetComponent<Samurai>();
            if (jogador != null)
            {
                jogador.Damage(jogador.health);
            }
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
