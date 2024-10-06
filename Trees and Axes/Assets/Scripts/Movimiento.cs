using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocid = 5f;
    Vector2 direccion;

    Rigidbody2D rigidbody;
    Animator Animator;

    bool Ataque;

   private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = direccion * velocid;
    }

    // Update is called once per frame
    private void Update()
    {
        Movement();
        Animations();
        
    }

    private void Movement() 
    {
        if (Ataque) return;

        direccion = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (Input.GetKeyDown(KeyCode.I)) 
        {
            Animator.Play("Atacar");
            Ataque = true;
            direccion = Vector2.zero;
        }
    }

    private void Animations() 
    {

        if (Ataque) return;
        
        if (direccion.magnitude != 0)
        {
            Animator.SetFloat("Horizontal", direccion.x);
            Animator.SetFloat("Vertical", direccion.y);
            Animator.Play("Movimiento");
        }
        else Animator.Play("idle");

    }

    private void Ataques() 
    {
        Ataque = false;
    }
}
