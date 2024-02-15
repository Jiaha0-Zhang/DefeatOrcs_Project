using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 100f;
    Rigidbody2D rb;
    Vector2 moveInput;
    Animator animator;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        if(moveInput == Vector2.zero)
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", true);
            if(moveInput.x > 0)
            {
                spriteRenderer.flipX = false;
                gameObject.BroadcastMessage("IsFacingRight", true);
            }
            if(moveInput.x < 0)
            {
                spriteRenderer.flipX = true;
                gameObject.BroadcastMessage("IsFacingRight", false);
            }
        }
    }
    private void FixedUpdate()
    {
        rb.AddForce(moveInput * moveSpeed);
    }
    private void OnFire()
    {
        animator.SetTrigger("swordAttack");
    }
    private void OnDamage()
    {

    }
    private void OnDie()
    {
        animator.SetTrigger("isDead");
    }
    private void OnDestroy()
    {
        Destroy(gameObject);
        GameAssets.Instance.RestartGame();
    }
}
