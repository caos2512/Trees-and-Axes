using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    [Header("VidaEnemigo parametres")]
    public int maxHp = 5;
    public int hp = 5;


    protected bool invencible;
    protected float tiempoInvencible = 0.2f;
    protected float blinkTime = 0.1f;

    public float knockbackStrength = 0.2f;
    float knockbackTime = 0.3f;


    protected Rigidbody2D rigidBody;
    protected SpriteRenderer spriteRenderer;
    protected MuerteEnemigo muerteEnemigo;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Espada") && !invencible)
        {
            hp--;
            if (hp <= 0)
            {
                muerteEnemigo.Defeat();
            }

            StopBehaviour();
            StartCoroutine(Invencibility());
            StartCoroutine(Knockback(collision.transform.position));
        }
    }

    // Start is called before the first frame update
    public virtual void Start()
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
            auxTime -= blinkTime;
            spriteRenderer.enabled = !spriteRenderer.enabled;
        }
        spriteRenderer.enabled = true;
        invencible = false;
    }

    IEnumerator Knockback(Vector3 hitPosition) 
    {
        if (knockbackStrength <= 0) 
        {
            if (hp > 0) ContinueBehaviour();
            yield break;
        } 

        rigidBody.velocity = (transform.position - hitPosition).normalized * knockbackStrength;
        yield return new WaitForSeconds(knockbackTime);
        rigidBody.velocity = Vector2.zero;
        yield return new WaitForSeconds(knockbackTime);
        if (hp > 0) ContinueBehaviour();

    }

    public virtual void HideEnemy() 
    {
        StopAllCoroutines();
        rigidBody.velocity = Vector3.zero;
        spriteRenderer.enabled = false;
    }

    public virtual void StopBehaviour() { }

    public virtual void ContinueBehaviour() { }
}
