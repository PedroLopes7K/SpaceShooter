using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform basicShootPoint;

    private float shootInterval = 0.7f;
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

    public void UpdateSpeedAndDamage(float value)
    {
        Debug.Log("VALOR ATUAL DO SHOOT " + shootInterval);
        if (intervalReset > 0.1f)
        {
            StartCoroutine(ModifyShoot(value));
            //ModifyShoot(value);

        }
    }

    IEnumerator ModifyShoot(float value)
    {

        intervalReset -= value;

        yield return new WaitForSeconds(10);

        intervalReset += value;


    }

    private void Shoot()
    {
        Instantiate(bullet, basicShootPoint.position, Quaternion.identity);

    }
}
