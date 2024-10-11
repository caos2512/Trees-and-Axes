using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : VidaEnemigo
{
    [Header("MovimientoEnemigo1 parameters")]
    public float speed;
    public float minPatrolTime;
    public float maxPatrolTime;
    public float mixWaitTime;
    public float maxMixWaitTime;

    Animator animator;

    Vector2 direccion;

    public override void Start()
    {
        base.Start();
         animator = GetComponent<Animator>();
        StartCoroutine(Patrol());
    }

    IEnumerator Patrol() 
    {
        direccion = RandomDirection();
        Animations();
        yield return new WaitForSeconds(Random.Range(minPatrolTime, maxMixWaitTime));

        direccion = Vector2.zero;
        Animations();
        yield return new WaitForSeconds(Random.Range(minPatrolTime, maxMixWaitTime));

        StartCoroutine(Patrol());
    }

    private Vector2 RandomDirection() 
    {
        int x = Random.Range(0, 5);

        return x switch
        {
            0 => Vector2.up,
            1 => Vector2.down,
            2 => Vector2.left,
            _ => Vector2.right,
            
        };
    }

    private void Animations() 
    {
        if (direccion.magnitude != 0)
        {
            animator.SetFloat("Horizontal", direccion.x);
            animator.SetFloat("Vertical", direccion.y);
            animator.Play("Correr");
        }

        else animator.Play("idle");

        rigidBody.velocity = direccion.normalized * speed;
    }

    public override void StopBehaviour()
    {
        StopAllCoroutines();
        direccion = Vector2.zero;
        Animations();
    }

    public override void ContinueBehaviour()
    {
        StartCoroutine(Patrol());
    }

}
