using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Enemy
{
    [SerializeField] protected float minSpeed;
    [SerializeField] protected float maxSpeed;

    private float speed;

    private float rotateSpeed = 109.0f ;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        rb.velocity = Vector2.down * speed;

        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        
    }

    public override void HurtSequence()
    {
        //base.HurtSequence();

    }

    public override void DeathSequence()
    {
        //base.DeathSequence();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
