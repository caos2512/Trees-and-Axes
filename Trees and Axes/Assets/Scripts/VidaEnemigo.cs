using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public int maxHp = 5;
    public int hp = 5;

    bool invencible;
    float tiempoInvencible = 0.2f;
    float blinkTime = 0.1f;

    public float knockbackStrength = 2f;
    float knockbackTime = 0.3f;


    Rigidbody2D rigidBody;
    SpriteRenderer spriteRenderer;
    MuerteEnemigo muerteEnemigo;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Espada" && !invencible)
        {
            hp--;
            if (hp < 0)
            {
                muerteEnemigo.Defeat();
            }

            StartCoroutine(Invencibility());
            StartCoroutine(Knockback(collision.transform.position));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        muerteEnemigo = GetComponentInChildren<MuerteEnemigo>();
        hp = maxHp;


    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Invencibility()
    {
        invencible = true;
        float auxTime = tiempoInvencible;

        while (auxTime > 0) 
        {
            yield return new WaitForSeconds(blinkTime);
            tiempoInvencible -= blinkTime;
            spriteRenderer.enabled = !spriteRenderer.enabled;
        }
        spriteRenderer.enabled = true;
        invencible = false;
    }

    IEnumerator Knockback(Vector3 hitPosition) 
    {
        if (knockbackStrength <= 0) yield break;
        rigidBody.velocity = (transform.position - hitPosition).normalized * knockbackStrength;
        yield return new WaitForSeconds(knockbackTime);
        rigidBody.velocity = Vector3.zero;

    }

    public void HideEnemy() 
    {
        StopAllCoroutines();
        rigidBody.velocity = Vector3.zero;
        spriteRenderer.enabled = false;
    }

}
