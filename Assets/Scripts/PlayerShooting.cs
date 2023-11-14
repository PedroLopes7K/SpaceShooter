using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform basicShootPoint;
    [SerializeField] private Transform basicShootPoint1;
    [SerializeField] private Transform basicShootPoint2;

    private float shootInterval = 0.7f;
    private float intervalReset;
    public bool multipleShoots  = false;
    public int countPowerUpShoot  = 0;

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
    public void SetMultipleShoot()
    {
        if(multipleShoots == false)
        {
            countPowerUpShoot = 0;
            multipleShoots = true;
            StartCoroutine(ModifyMultipleShoot());

        }


    }

    public void UpdateSpeedAndDamage(float value)
    {
        if (intervalReset > 0.1f)
        {
            StartCoroutine(ModifyShoot(value));
            countPowerUpShoot += 1;
            if(countPowerUpShoot == 2)
            {
                SetMultipleShoot();

            }

            //ModifyShoot(value);

        }
    }

    IEnumerator ModifyShoot(float value)
    {

        intervalReset -= value;

        yield return new WaitForSeconds(10);

        intervalReset += value;


    }
    IEnumerator ModifyMultipleShoot()
    {


        yield return new WaitForSeconds(6);

        multipleShoots = false;



    }

    private void Shoot()
    {
        if(multipleShoots == false)
        {
            Instantiate(bullet, basicShootPoint.position, Quaternion.identity);

        } else
        {
            Instantiate(bullet, basicShootPoint.position, Quaternion.identity);
            Instantiate(bullet, basicShootPoint1.position, Quaternion.identity);
            Instantiate(bullet, basicShootPoint2.position, Quaternion.identity);

        }

    }
}
