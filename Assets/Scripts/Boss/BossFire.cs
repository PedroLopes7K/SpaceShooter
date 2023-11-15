using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFire : BossBaseState
{

    [SerializeField] private float speed;
    [SerializeField] private float shootRate;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform[] shootPoints;

    public override void RunState()
    {
        StartCoroutine(RunFireState());
    }
    public override void StopState()
    {
        base.StopState();
    }
    IEnumerator RunFireState()
    {
        float shootTimer = 0f;
        float fireStateTimer = 0f;
        float fireStateExitTimer = Random.Range(5f, 10f);
        Vector2 targetPosition = new Vector2(Random.Range(maxLeft, maxRight), Random.Range(maxDown, maxUp));

        while(fireStateTimer <= fireStateExitTimer)
        {
            if(Vector2.Distance(transform.position, targetPosition) > 0.01f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            } else
            {
                targetPosition = new Vector2(Random.Range(maxLeft, maxRight), Random.Range(maxDown, maxUp));
            }
            shootTimer += Time.deltaTime;
            if(shootTimer >= shootRate)
            {
                for(int i = 0; i < shootPoints.Length; i++)
                {
                    Instantiate(bulletPrefab, shootPoints[i].position, Quaternion.identity);

                }
                shootTimer = 0;
            }
            yield return new WaitForEndOfFrame();
            fireStateTimer += Time.deltaTime;
        }

        int randomPick = Random.Range(0, 2);
        if(randomPick == 0) {
            bossController.ChangeStatus(BossStates.fire);
        } else
        {
            bossController.ChangeStatus(BossStates.special);

        }
    }
}
