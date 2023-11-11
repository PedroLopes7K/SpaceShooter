using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleEnemy : Enemy
{

    [SerializeField] private float speed;
    [SerializeField] private float shootInterval;
    [SerializeField] private Transform leftShoot;
    [SerializeField] private Transform rightShoot;
    [SerializeField] private GameObject bullet;
    private float shootTimer = 0;
    private float damage = 1.0f;



    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = Vector2.down * speed;
    }

    // Update is called once per frame
    void Update()
    {

        shootTimer += Time.deltaTime;
        if(shootTimer >= shootInterval)
        {
            Instantiate(bullet, leftShoot.transform.position, Quaternion.identity);
            Instantiate(bullet, rightShoot.transform.position, Quaternion.identity);
            shootTimer = 0;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStates>().PlayerTakeDamage(damage);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    public override void HurtSequence()
    {

        anim.SetTrigger("damage");

    }
    public override void DeathSequence()
    {
        base.DeathSequence();
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
