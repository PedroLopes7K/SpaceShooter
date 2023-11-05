using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]protected float health = 1;
    [SerializeField]protected Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage(float damage)
    {
        health -= damage;
        HurtSequence();

        if(health <= 0 )
        {
            DeathSequence();
        }

    }


    public virtual void HurtSequence()
    {

    }
    public virtual void DeathSequence()
    {
        Destroy(gameObject);
    }
}
