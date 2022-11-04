using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float distance;
    private float distanceCounter;
    public bool goingLeft;

    private float speed;
    public float maxSpeed;
    private float dazedTime;
    public float startDazedTime;

    private Animator anim;
    public GameObject bloodEffect;

    public Transform attackPos;
    public LayerMask whatIsPlayer;
    public float attackRange;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", true);
        speed = maxSpeed;
    }

    private void FixedUpdate()
    {
        float disp = speed * Time.deltaTime;
        distanceCounter += disp;
        if (goingLeft)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (distanceCounter >= distance)
        {
            distanceCounter = 0;
            goingLeft = !goingLeft;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(dazedTime <= 0)
        {
            speed = maxSpeed;
        }
        else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        Collider2D[] playerToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsPlayer);
        if (playerToDamage.Length > 0)
        {
            playerToDamage[0].GetComponent<PlayerController>().TakeDamage(damage);
        }
    }

    public void TakeDamage(int damage)
    {
        dazedTime = startDazedTime;
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        health -= damage;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
