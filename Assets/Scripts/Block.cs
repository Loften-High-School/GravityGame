using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
   //[SerializeField] GameOver gameOver;
    [SerializeField] GameObject Shield;
    [SerializeField] GameObject player;
    [SerializeField] Vector3 playerTransform;
    [SerializeField] Vector3 vector3Player;
    // Start is called before the first frame update
    void Start()
 {
//glitch in code this work?
   

 }     

    // Update is called once per frame
    void Update()
    {
        
            if (Input.GetKeyDown(KeyCode.F))
            {
                  vector3Player = transform.position;
                  Debug.Log("This is the position of the player" + vector3Player.x + " " +vector3Player.y +" " +vector3Player.z);
                  Debug.Log("Blocking");
                  GenerateShield();
            }
            else
            {
                 DestroyImmediate (Shield, true);
            }
    }
     void GenerateShield()
     {
          Vector3 nextToPlayer; //creates the Vector 3
          Vector3 offSet = new Vector3(0.3f, 0f,0f); //creates vector 3 of the offset so we can add it to the player vector 3
          nextToPlayer = transform.localPosition + offSet;
          
       
         Instantiate(Shield, nextToPlayer, Quaternion.identity, player.transform ); //player.transform makes it a child of player
     }
}

//public static Object Instantiate(Object original, Vector3 position, Quaternion rotation, Transform parent);
