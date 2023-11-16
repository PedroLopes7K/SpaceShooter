using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpecial : BossBaseState
{
    [SerializeField] private GameObject specialBulletPrefab;
    //[SerializeField] private Transform boss;
    [SerializeField] private Transform transformBoss;
    //private float maxRight;
    //private float maxLeft;
    //private float yPosition;


    public override void RunState()
    {
        StartCoroutine(RunSpecialState());
    }
    public override void StopState()
    {
        base.StopState();
    }
    IEnumerator RunSpecialState()
    {
        yield return new WaitForSeconds(0.1F);


        //maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.15f, 0)).x;
        //maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.85f, 0)).x;
        //yPosition = mainCam.ViewportToWorldPoint(new Vector2(0, 1.1f)).y;
        Instantiate(specialBulletPrefab, new Vector3(transformBoss.position.x, transformBoss.position.y, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.4F);
        bossController.ChangeStatus(BossStates.fire);
    }
   
}
