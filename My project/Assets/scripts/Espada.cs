using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Espada : MonoBehaviour
{
    public float timeUntilDestruction;
    


    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, timeUntilDestruction);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 3)
        {
            Destroy(col.gameObject);
        }
    }
}
