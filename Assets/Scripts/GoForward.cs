using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoForward : MonoBehaviour
{
    [SerializeField] Raycast raycast;
        public Rigidbody RB;
    // Start is called before the first frame update
    void Start()
    {
    RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
     RB.AddForce(Vector3.RaycastDirection);
    }
}
