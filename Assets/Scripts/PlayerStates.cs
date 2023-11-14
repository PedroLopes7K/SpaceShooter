using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStates : MonoBehaviour
{

    private float maxHealth = 10;
    private float health;
    [SerializeField] private Animator animator;
    [SerializeField] private Image healthFill;
    [SerializeField] private GameObject explosion;
    [SerializeField] private Shield shield;
    [SerializeField] private float bulletSpeed = 10.0f;
    [SerializeField] private float bulletDamage = 1.0f;


    private bool canRunAnimation = true;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthFill.fillAmount = health / maxHealth;
        EndGameManager.endGameManager.gameOver = false;

    }

    // Update is called once per frame
    void Update()
    {

    }


    public float getSpeedBullet()
    {
        return bulletSpeed;
    }

    public float getBulletDamage()
    {
        return bulletDamage;
    }
 
    public void PlayerTakeDamage(float damage)
    {
        if (shield.protection) return;
        health -= damage;
        healthFill.fillAmount = health / maxHealth;
        if (canRunAnimation)
        {
            animator.SetTrigger("TakeDamage");
            StartCoroutine(controlAnimation());
        }

        if (health <= 0)
        {
            EndGameManager.endGameManager.gameOver = true;
            EndGameManager.endGameManager.StartResolveSequence();
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);

        }

    }
    public void AddHealth(int healAmount)
    {
        health += healAmount;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
        // update health bar
        healthFill.fillAmount = health / maxHealth;
    }

    private IEnumerator controlAnimation()
    {
        canRunAnimation = false;
        yield return new WaitForSeconds(0.15f);

        canRunAnimation = true;


    }

}
