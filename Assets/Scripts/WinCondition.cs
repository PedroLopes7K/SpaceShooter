using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private float timer;
   [SerializeField] private float possibleWinTime;
   [SerializeField] private bool bossExist;
    [SerializeField] private GameObject[] spawners;
    [SerializeField] private GameObject bossSpawner;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(EndGameManager.endGameManager.gameOver == true)
        {
            return;
        }
        timer += Time.deltaTime;
        if(timer >= possibleWinTime )
        {
            for(int i = 0; i< spawners.Length; i++) {
                spawners[i].SetActive(false);
            }

            if(bossExist == false)
            {
                EndGameManager.endGameManager.StartResolveSequence();
                gameObject.SetActive(false);

            }
            else
            {
                bossSpawner.SetActive(true);
            }
        }
        
    }
}
