using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGreen : Enemy
{

    [SerializeField] private float speed;
    private float damage = 1.0f;

    void Start()
    {
        rb.velocity = Vector2.down * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStates>().PlayerTakeDamage(damage);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    public override void HurtSequence()
    {

        anim.SetTrigger("EnemyGreenDamage");

    }
    public override void DeathSequence()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
