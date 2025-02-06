using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
  [SerializeField] private float StartingHealth;
private float health;
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
