using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeSnail : MonoBehaviour
{
    public float speed;
    public LayerMask layer;
    public Transform groundCheck;


    Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        if(!IsGroundExist())
        {
            Turn();
        }
    }
    public void Turn()
    {
        transform.Rotate(Vector3.up, 180);
    }
    public void Move()
    {
        
        rigid.velocity = new Vector2(transform.right.x * -speed,rigid.velocity.y );
    }

    private bool IsGroundExist()
    {
        return Physics2D.Raycast(groundCheck.position, Vector2.down, 1f, layer);
    }
}
