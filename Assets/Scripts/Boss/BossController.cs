using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BossStates
{
    enter,
    fire,
    special,
    death
}
public class BossController : MonoBehaviour
{
    [SerializeField] private BossEnter bossEnter;
    [SerializeField] private BossFire bossFire;
    [SerializeField] private BossDeath bossDeath;
    [SerializeField] private BossStates testState;
    [SerializeField] private bool test;
    void Start()
    {
        ChangeStatus(BossStates.enter);
        if(test)
        {
            ChangeStatus(testState);
        }
        
    }


    public void ChangeStatus(BossStates state)
    {
        switch(state)
        {
            case BossStates.enter:
                bossEnter.RunState();
                break;
            case BossStates.fire:
                bossFire.RunState();
                break;
            case BossStates.special:
                Debug.Log("entert");
                break;
            case BossStates.death:
                bossEnter.StopState();
                bossFire.StopState();
                bossDeath.RunState();
                break;
        }
    }

}
