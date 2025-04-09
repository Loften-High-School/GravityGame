using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyGenerator : MonoBehaviour
{
   //[SerializeField] GameOver gameOver;
    [SerializeField] GameObject platform3;
    [SerializeField] Vector3 vector3;
    // Start is called before the first frame update
    void Start()
 {
//glitch in code this work?
 }     

    // Update is called once per frame
    void Update()
    {
        
    }

private void OnTriggerEnter(Collider collision)
      { 
        //if (gameOver.isAlive != false);
         {
            if (collision.gameObject.CompareTag("Generator"));
            {
                  Debug.Log("Enemy is being created");
                  GenerateNextPlatform();
            }
         }
      }




     void GeneratePlatform()
     {
         Vector3 randomPlace = new Vector3(Random.Range(9.01f, 11.01f), Random.Range(-2f, 3f), 0);
         Instantiate(platform3, randomPlace, Quaternion.identity); 
     }

     
     void GenerateNextPlatform()
     {
      float randomWait = Random.Range(0.75f, 1.5f);
      Invoke ("GeneratePlatform", randomWait);
     }
}

