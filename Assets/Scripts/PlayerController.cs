using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int health;
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float moveInput;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    private Animator anim;
    public GameObject bloodEffect;

    private float invincibleTimeCounter;
    public float invincibleTime;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    private void Update()
    {
        if (this.health <= 0)
        {
            SoundManagerScript.PlaySound("death");
            Instantiate(bloodEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        invincibleTimeCounter -= Time.deltaTime;
        if (invincibleTimeCounter > 0)
        {
            anim.SetBool("isInvincible", true);
        }
        else
        {
            anim.SetBool("isInvincible", false);
        }
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            SoundManagerScript.PlaySound("jump");
            anim.SetTrigger("takeOff");
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (isGrounded == true)
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if(jumpTimeCounter > 0 && isJumping == true) {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;

        }
        if (moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }
        if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0); // Flipped
        }
        else if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0); // Normal
        }
    }

    public void TakeDamage(int damage)
    {
        if (invincibleTimeCounter <= 0)
        {
            SoundManagerScript.PlaySound("hit");
            //Instantiate(bloodEffect, transform.position, Quaternion.identity);
            health -= damage;
            invincibleTimeCounter = invincibleTime;
        }
    }
}
