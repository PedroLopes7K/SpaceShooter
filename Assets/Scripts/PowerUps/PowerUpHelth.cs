using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHelth : MonoBehaviour
{
    [SerializeField] private int healAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerStates player = collision.GetComponent<PlayerStates>();
            player.AddHealth(healAmount);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
