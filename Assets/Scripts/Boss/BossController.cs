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
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void ChangeStatus(BossStates state)
    {
        switch(state)
        {
            case BossStates.enter:
                Debug.Log("entert");
                break;
            case BossStates.fire:
                Debug.Log("entert");
                break;
            case BossStates.special:
                Debug.Log("entert");
                break;
            case BossStates.death:
                Debug.Log("entert");
                break;
        }
    }

}
