using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MuerteEnemigo : MonoBehaviour
{
    VidaEnemigo VidaEnemigo;
    Animator animator;

    protected void Start()
    {
        VidaEnemigo = GetComponent<VidaEnemigo>();
        animator = GetComponent<Animator>();
    }

    public void Defeat() 
    {
        animator.Play("MuerteHongo");
    }

    public void Hide() 
    {
        VidaEnemigo.HideEnemy();
    }

    public void Destroy()
    {
       Destroy(VidaEnemigo.gameObject);
    }
}
