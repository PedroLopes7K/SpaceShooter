using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStates : MonoBehaviour
{

    private float maxHealth = 3;
    private float health;
    [SerializeField] private Animator animator;
    [SerializeField] private Image healthFill;
    [SerializeField] protected GameObject explosion;


    private bool canRunAnimation = true;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthFill.fillAmount = health / maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void PlayerTakeDamage(float damage)
    {
        health -= damage;
        healthFill.fillAmount = health / maxHealth;
        if (canRunAnimation)
        {
            animator.SetTrigger("TakeDamage");
            StartCoroutine(controlAnimation());
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);

        }

    }

    private IEnumerator controlAnimation()
    {
        canRunAnimation = false;
        yield return new WaitForSeconds(0.15f);

        canRunAnimation = true;


    }

}
