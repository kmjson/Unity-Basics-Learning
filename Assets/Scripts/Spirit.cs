using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spirit : MonoBehaviour
{
    public Animator box;
    public Transform pos;
    public LayerMask whatIsPlayer;
    public float range;

    private bool first;
    private bool last = false;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] player = Physics2D.OverlapCircleAll(pos.position, range, whatIsPlayer);
        if (player.Length > 0)
        {
            if (first)
            {
                first = false;
                box.SetTrigger("Open");
                SoundManagerScript.PlaySound("point");
            }
            last = true;
        }
        else
        {
            if (last)
            {
                last = false;
                box.SetTrigger("Close");
            }
            first = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pos.position, range);
    }
}
