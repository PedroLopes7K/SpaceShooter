using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    private Camera mainCam;
    private float maxRight;
    private float maxLeft;
    private float yPosition;
    private float enemyTimer;
    [SerializeField] private float enemySpawTime;

    [SerializeField] private GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {

        mainCam = Camera.main;

        StartCoroutine(SetBoundaries());
    }

    // Update is called once per frame
    void Update()
    {
        EnemySpawn();
    }

    private void EnemySpawn()
    {

        enemyTimer += Time.deltaTime;
        if(enemyTimer >= enemySpawTime)
        {
            int randomPick = Random.Range(0, enemies.Length);
            Instantiate(enemies[randomPick], new Vector3(Random.Range(maxLeft, maxRight) , yPosition, 0), Quaternion.identity);
            enemyTimer = 0;

        }

    }
     private IEnumerator SetBoundaries()
    {
        // do something or nothing
        yield return new WaitForSeconds(0.4f);


        // do something
        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.15f, 0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.85f, 0)).x;
        yPosition = mainCam.ViewportToWorldPoint(new Vector2(0, 1.1f)).y;

    }
}
