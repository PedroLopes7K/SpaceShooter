using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //[SerializeField] private float speed;
    //[SerializeField] private float damage = 1;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private PlayerStates playerState;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log( "MEU VALOR" + playerState.getSpeedBullet());
        //rb.velocity = transform.up * playerState.getSpeedBullet();
        rb.velocity = transform.up * 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        Enemy enemy = collision.GetComponent<Enemy>();
        enemy.TakeDamage(playerState.getBulletDamage());
        Destroy(gameObject);
        //if (collision.CompareTag("Enemy"))
        //{
        //    Destroy(gameObject);
        //    Destroy(collision.gameObject);
        //}
    }



    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
