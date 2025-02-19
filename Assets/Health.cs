using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
private float health = 3f;

public void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.CompareTag("laser"))
        {
          if (health = 3)
          {
            health = 2;
          }
          if (health = 2)
           {
           health = 1;
           }
           if (health = 1)
           {
            health = 0;
           }
        }
    }
public float Health
{
  get
  {
    return health;
  }
  set
  {
    health = value;
    Debug.Log(health);
    if (health <= 0f)
    {
      Destroy(gameObject);
    }
  }
}
}
