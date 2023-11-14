using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeedShot : MonoBehaviour
{
    private float shootImprove = 0.1f ;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerShooting player = collision.GetComponent<PlayerShooting>();
            player.UpdateSpeedAndDamage(shootImprove);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
