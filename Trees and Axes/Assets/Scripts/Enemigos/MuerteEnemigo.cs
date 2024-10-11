using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MuerteEnemigo : MonoBehaviour
{
    VidaEnemigo VidaEnemigo;
    Animator animator;

    private void Start()
    {
        VidaEnemigo = GetComponent<VidaEnemigo>();
        animator = GetComponent<Animator>();
    }

    public void Defeat() 
    {
        animator.Play("MuerteHongo");
    }

    private void Hide() 
    {
        VidaEnemigo.HideEnemy();
    }

    private void Destroy()
    {
       Destroy(VidaEnemigo.gameObject);
    }
}
