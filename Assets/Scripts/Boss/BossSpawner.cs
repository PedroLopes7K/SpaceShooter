using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    private Camera mainCam;
    private float maxRight;
    private float maxLeft;
    private float yPosition;

    [SerializeField] private GameObject boss;


    void Start()
    {

        mainCam = Camera.main;

        StartCoroutine(SetBoundaries());
    }

    private IEnumerator SetBoundaries()
    {
        yield return new WaitForSeconds(0.4f);


        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.15f, 0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.85f, 0)).x;
        yPosition = mainCam.ViewportToWorldPoint(new Vector2(0, 1.1f)).y;
        Instantiate(boss, new Vector3(Random.Range(maxLeft, maxRight), yPosition, 0), Quaternion.identity);


    }

}
