using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private int hitsToDestroy = 3;
    public bool protection = false;
    [SerializeField] private GameObject[] shields;

    private void OnEnable()
    {
        hitsToDestroy = 3;
        for(int i = 0; i < shields.Length; i++)
        {
            shields[i].SetActive(true);
        }
        protection = true;
    }

    private void UpdateUI()

    {
        switch(hitsToDestroy)
        {
            case 0:
                for (int i = 0; i < shields.Length; i++)
                {
                    shields[i].SetActive(false);
                }
                break;
            case 1:
                shields[0].SetActive(true);
                shields[1].SetActive(false);
                shields[2].SetActive(false);
                break;
            case 2:
                shields[0].SetActive(true);
                shields[1].SetActive(true);
                shields[2].SetActive(false);
                break;
            case 3:
                shields[0].SetActive(true);
                shields[1].SetActive(true);
                shields[2].SetActive(true);
                break;
            default:
                Debug.Log("Error in Update UI Function");
                break;
        }
    }
    private void DamageShield()
    {
        hitsToDestroy -= 1;
        if(hitsToDestroy <= 0)
        {
            hitsToDestroy = 0;
            protection = false;
            gameObject.SetActive(false);
        }

        UpdateUI();
    }

    public void RepairShield()
    {
        hitsToDestroy = 3;
        UpdateUI();


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Enemy enemy))
        {
            if(collision.CompareTag("Boss"))
            {
                hitsToDestroy = 0;
                DamageShield();
                return;
            }
            enemy.TakeDamage(10000);
            DamageShield();
        } else
        {
            Destroy(collision.gameObject);
            DamageShield();
        }
    }
}
