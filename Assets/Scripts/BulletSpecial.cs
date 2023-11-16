using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpecial : MonoBehaviour
{
    public float moveDistance = 10.0f;  // Distância que o objeto deve percorrer
    public float moveSpeed = 1.5f;     // Velocidade de movimento

    private Vector3 originalPosition;
    private Vector3 targetPosition;
   [SerializeField] private Transform[] shootPoints;
    [SerializeField]private GameObject bullet;
    private bool shot = true;

    void Start()
    {
        originalPosition = transform.position;
        targetPosition = originalPosition - new Vector3(0, moveDistance, 0);
    }

    void Update()
    {
        //while (Vector2.Distance(transform.position, targetPosition) > 0.01f)
            // Interpolação linear para mover suavemente o objeto para baixo
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        transform.Rotate(0, 0, 3 * Time.deltaTime);
        //yield return new WaitForEndOfFrame();

        //for (int i = 0; i < shootPoints.Length; i++)
        //{
        //    Instantiate(bullet, shootPoints[i].position, Quaternion.identity);

        //}
        if(shot == true && Vector2.Distance(transform.position, targetPosition) <= 0.09f)
        {
            //Instantiate(bullet, transform.position, Quaternion.identity);
            for (int i = 0; i < shootPoints.Length; i++)
            {
                //Instantiate(bullet, shootPoints[i].position, Quaternion.identity);
                 //                                      needed be the rotation of shot point
                Instantiate(bullet, shootPoints[i].position, shootPoints[i].rotation);

            }
            shot = false;
            Destroy(gameObject);

        }
    }
}
