using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform Jugador;
    public float Radio = 5.0f;
    public float speed = 2.0f;

    private Rigidbody2D rigidBody;
    private Vector2 movimiento;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector2.Distance(transform.position, Jugador.position);

        if (distancia < Radio)
        {
            Vector2 direccion = (Jugador.position - transform.position).normalized;
            movimiento = new Vector2(direccion.x, 0);
        }
        else 
        {
            movimiento = Vector2.zero;
        }

        rigidBody.MovePosition(rigidBody.position + movimiento * speed * Time.deltaTime);

    }
}
