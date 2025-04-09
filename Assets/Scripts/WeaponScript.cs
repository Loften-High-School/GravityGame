using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class WeaponScript : MonoBehaviour

{
  [SerializeField] GameObject LargeLaser;
  public UnityEvent OnGunShoot;
  public float FireCooldown;
  public bool Automatic;
  private float CurrentCooldown;
  private Vector3 PlayerLocation=  new Vector3 (1.2f, -49.2f, 18.4f);
  //PlayerLocation =
  void Start()
  {
    CurrentCooldown = FireCooldown;
  }
  void Update()
  {
    Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, fwd, Color.green);

    if (Automatic)
    {
      if (Input.GetMouseButton(0))
      {
        if (CurrentCooldown <= 0f)
        {
          
          OnGunShoot?.Invoke();
          CurrentCooldown = FireCooldown;
          Debug.Log("Shots Fired");
          Instantiate(LargeLaser, PlayerLocation, Quaternion.identity);
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