using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zapoved : MonoBehaviour
{
    public float speed = 15f;
    Rigidbody2D rb;
    public float jumpower = 15f;
    public Transform groundCheck;
    bool isGrounded;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);


    }

    void Jump()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(transform.up * jumpower, ForceMode2D.Impulse);
        }
        print(isGrounded);

    }

    void Flip()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);

        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

    }

    private void Update()
    {
        Jump();
        GroundCheck();
        Stay();
    }
    void GroundCheck()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f);
        isGrounded = colliders.Length > 1;
        if (!isGrounded)
        {
            animator.SetInteger("State", 2);
        }

    }
    void Stay()
    {
        print(1);
        if (Input.GetAxis("Horizontal") == 0 && isGrounded)
        {
           animator.SetInteger("State", 1);
            print(2);
        }
        else
        {
            Flip();
            if(isGrounded)
            {
                animator.SetInteger("State", 3);
            }
            print(3);

        }

    }








}