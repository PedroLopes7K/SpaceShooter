using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{

   [SerializeField] private GameObject[] meteor;
   [SerializeField] private float spawTime;
    private float timer;
    private int i;

    private Camera mainCam;
    private float maxRight;
    private float maxLeft;
    private float yPosition;

    // Start is called before the first frame update
    void Start()
    {

        mainCam = Camera.main;

        StartCoroutine(SetBoundaries());
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if(timer >  spawTime) {

            i = Random.Range(0, meteor.Length);
            Instantiate(meteor[i], new Vector3(Random.Range(maxLeft, maxRight), yPosition, -5), Quaternion.Euler(0, 0, Random.Range(0, 360)));
            timer = 0;
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
