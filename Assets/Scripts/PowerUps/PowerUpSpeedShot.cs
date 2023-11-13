using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeedShot : MonoBehaviour
{
    private float shootImprove = 0.5f ;
   [SerializeField] private Bullet bullet;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //PlayerStates player = collision.GetComponent<PlayerStates>();
            bullet.UpdateSpeedAndDamage(shootImprove);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
