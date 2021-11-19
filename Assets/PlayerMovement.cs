using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool facingRight = true;

    public Animator animator;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
       
        if (movement.x ==0 && movement.y ==0)
        {
            animator.SetBool("isrunning", false);
        }
        else
        {
            animator.SetBool("isrunning", true);
        }
    }

    void FixedUpdate()
    {
        moveCharacter(movement);
        if (facingRight == false && movement.x > 0)
        {
            Flip();
        }
        else if (facingRight == true && movement.x < 0)
        {
            Flip();
        }
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position +(speed * direction * Time.deltaTime));
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}



