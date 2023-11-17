using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeath : BossBaseState
{

    public override void RunState()
    {
        Debug.Log("BOSS DEATH");

        EndGameManager.endGameManager.ResolveGame();
        gameObject.SetActive(false);

    }
}
