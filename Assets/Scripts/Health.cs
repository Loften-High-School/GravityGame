using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float Count;

    void Start()
    {
        Count = 3f;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Checking if the object collided with a "Laser" tagged object
        if (other.gameObject.CompareTag("Laser"))
        {
            // Reducing health on laser hit
            if (Count == 3f)
            {
                Count = 2f;
            }
            else if (Count == 2f)
            {
                Count = 1f;
            }
            else if (Count == 1f)
            {
                Count = 0f;
            }
        }
    }

    void Update()
    {
        // Destroy the game object if health is 0
        if (Count == 0f)
        {
            Destroy(gameObject);
        }
    }
}
