using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public float movePower;
    public float jumpPower;
    public float maxSpeed;
    private SpriteRenderer sprite;
    private Rigidbody2D rigid;
    private Vector2 inputDir;
    private Animator animator;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        if(inputDir.x > 0 && rigid.velocity.x < maxSpeed)
            rigid.AddForce(Vector2.right * inputDir * movePower, ForceMode2D.Force);
        if(inputDir.x < 0 && rigid.velocity.x > -maxSpeed)
            rigid.AddForce(Vector2.right * inputDir * movePower, ForceMode2D.Force);
    }

    private void OnMove(InputValue value)
    {
        inputDir = value.Get<Vector2>();
        animator.SetFloat("MoveSpeed",Mathf.Abs(inputDir.x));
        if(inputDir.x < 0)
            sprite.flipX = true;
        else if(inputDir.x > 0)
            sprite.flipX = false;
    }
    public void Jump()
    {
        rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }
    private void OnJump(InputValue value)
    {
        Jump();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("Ground",true);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.SetBool("Ground", false);
    }
}
