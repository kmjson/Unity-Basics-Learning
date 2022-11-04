using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private Collider2D[] spikes;
    public Collider2D Player;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        spikes = GetComponents<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < spikes.Length; i++)
        if (Player != null && Physics2D.IsTouching(spikes[i], Player))
        {
            Player.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }
}
