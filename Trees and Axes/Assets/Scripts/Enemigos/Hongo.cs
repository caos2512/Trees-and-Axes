using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Hongo : MonoBehaviour
{
    public int Vida = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Espada")
        {
            Vida--;
            if (Vida < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
