using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor.Animations;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public float speed;
    public Transform groundCheckPoint;
    public LayerMask groundMask;

    private Rigidbody2D rigid;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        if(!IsGroundExist())
        {
            Trun();
        }
    }
    
    public void Trun()
    {
        transform.Rotate(Vector3.up, 180);
    }
    public void Move()
    {
        rigid.velocity = new Vector2(transform.right.x * -speed, rigid.velocity.y);
    }

    private bool IsGroundExist()
    {
        return Physics2D.Raycast(groundCheckPoint.position, Vector2.down, 1f, groundMask);
    }
}
