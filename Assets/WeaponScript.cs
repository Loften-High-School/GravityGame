using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GunSystem : MonoBehaviour
{
  public UnityEvent OnGunShoot;
  public float FireCooldown;
  public bool Automatic;
  private float CurrentCooldown;
  void Start()
  {
    CurrentCooldown = FireCooldown;
  }
  void Update()
  {
    if (Automatic)
    {
      if (Input.GetMouseButton(0))
      {
        if (CurrentCooldown <= 0f)
        {
          OnGunShoot?.Invoke();
          CurrentCooldown = FireCooldown;
          Debug.Log("Shots Fired");
        }
      }
    }
    else
    {
      if (Input.GetMouseButtonDown(0))
      {
        if (CurrentCooldown <= 0f)
        {
          OnGunShoot?.Invoke();
          CurrentCooldown = FireCooldown;
          Debug.Log("Shots Fired");
        }
      }
    }
    CurrentCooldown -= Time.deltaTime;
  }
}