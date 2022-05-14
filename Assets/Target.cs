using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Animator animator;
    public float health = 100f;     

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void TakeDamage (float amount)
    {
        Debug.Log("Hit");
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        var destroyTime = 2; 
        animator.SetBool("isDead", true);
        Destroy(gameObject, destroyTime);

    }
}
