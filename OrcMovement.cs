using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcMovement : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    DetectionZone detectionZone;
    Animator animator;

    public float speed = 5;
    public float knockbackForce;
    public float attackPower;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        detectionZone = GetComponent<DetectionZone>();
    }
    private void FixedUpdate()
    {
        if (detectionZone.detectedObjs != null)
        {
            Vector2 direction = (detectionZone.detectedObjs.transform.position - transform.position);
            if (direction.magnitude <= detectionZone.viewRadius)
            {
                rb.AddForce(direction.normalized * speed);
                if(direction.x > 0 )
                {
                    spriteRenderer.flipX = false;
                }
                if(direction.x < 0 )
                {
                    spriteRenderer.flipX = true;
                }
                OnWalk();
            }
            else
            {
                OnWalkStop();
            }
        }       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        IDamageable damageable = collider.GetComponent<IDamageable>();

        if (damageable != null && collider.tag == "Player")
        {
            Vector2 direction = collider.transform.position - transform.position; //player position - orc postion
            Vector2 force = direction.normalized * knockbackForce;

            damageable.OnHit(attackPower, force);
        }
    }
    private void OnWalk()
    {
        animator.SetBool("isWalking", true);
    }
    private void OnWalkStop()
    {
        animator.SetBool("isWalking", false);
    }
    private void OnDamage()
    {
        animator.SetTrigger("isDamage");
    }
    private void OnDie()
    {
        animator.SetTrigger("isDead");
    }
}
