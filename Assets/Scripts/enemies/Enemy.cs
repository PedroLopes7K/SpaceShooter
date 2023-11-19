using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]protected float health = 1;
    [SerializeField]protected Rigidbody2D rb;
    [SerializeField]protected GameObject explosion;

    [SerializeField] protected Animator anim;
    [Header("Score"), SerializeField]
    protected int scoreValue;
    protected bool canTakeDamage;

    // Start is called before the first frame update
    void Awake()
    {
        canTakeDamage = false;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage(float damage)
    {
        if (canTakeDamage == false)
        {
            return;
        }
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

        EndGameManager.endGameManager.updateScore(scoreValue);
        Destroy(gameObject);
    }
    private void OnBecameVisible()
    {
        canTakeDamage = true;
    }
}
