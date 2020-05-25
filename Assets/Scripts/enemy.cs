using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float health = 4f;
    public GameObject deatheffect;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.relativeVelocity.magnitude > health)
        {
            Die();
        }
        
    }

    void Die()
    {
        Instantiate(deatheffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
