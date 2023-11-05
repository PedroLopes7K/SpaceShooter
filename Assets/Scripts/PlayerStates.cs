using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStates : MonoBehaviour
{

    private float maxHealth = 3;
    private float health;
    [SerializeField] private Image healthFill;
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

        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }

}
