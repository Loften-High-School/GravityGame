using UnityEngine;

public class RaycastDirection : MonoBehaviour
{
    public Vector3 raycastDirection; // To store the direction

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward); // Cast a ray from the object forward direction
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // If the ray hits something, we store the direction of the ray
            raycastDirection = ray.direction;
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red); // Visualize the ray in the scene
        }
        else
        {
            raycastDirection = transform.forward; // Use forward direction if no hit
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.green); // Visualize the ray in the scene
        }
    }
}