using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableCharactor : MonoBehaviour,IDamageable
{
    public float health;
    Rigidbody2D rb;
    Collider2D physicsCollider;
    bool targetable;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        physicsCollider = GetComponent<Collider2D>();
    }
    public float Health
    {
        get 
        { 
            return health; 
        }
        set
        {
            health = value;
            if(health < 0)
            {
                gameObject.BroadcastMessage("OnDie");
                Targetable = false; 
            }
            else
            {
                gameObject.BroadcastMessage("OnDamage");
            }
        }
    }
    public bool Targetable
    {
        get
        {
            return targetable;
        }
        set
        {
            targetable = value;
            if(!targetable)
            {
                rb.simulated = false;
            }
        }
    }
    public void OnHit(float damage, Vector2 knockback)
    {
        Health -= damage;
        rb.AddForce(knockback);
    }
    public void OnObjectDestroyed()
    {
        Destroy(gameObject);
    }
}
