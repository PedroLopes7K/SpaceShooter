using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform basicShootPoint;

    [SerializeField] private float shootInterval;
    private float intervalReset;

    // Start is called before the first frame update
    void Start()
    {
        intervalReset = shootInterval;
    }

    // Update is called once per frame
    void Update()
    {
        shootInterval -= Time.deltaTime;
        if(shootInterval <= 0)
        {
            Shoot();
            shootInterval = intervalReset;
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, basicShootPoint.position, Quaternion.identity);

    }
}
