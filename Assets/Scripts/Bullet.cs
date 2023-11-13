using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage = 1;
    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        Enemy enemy = collision.GetComponent<Enemy>();
        enemy.TakeDamage(damage);
        Destroy(gameObject);
        //if (collision.CompareTag("Enemy"))
        //{
        //    Destroy(gameObject);
        //    Destroy(collision.gameObject);
        //}
    }

    public void UpdateSpeedAndDamage(float value)
    {
        StartCoroutine(ModifyShoot(value));
    }

    IEnumerator ModifyShoot(float value)
    {
        speed += value;
        damage += value;

        yield return new WaitForSeconds(2f);

        speed -= value;
        damage -= value;


    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
