using UnityEngine;

public class BigLaser : MonoBehaviour
{
    public float speed = 10f;               // Speed at which the rocket moves forward
    public float explosionRadius = 5f;      // Radius of the explosion
    public float explosionForce = 100f;     // Knock-back force
    public float playerLaunchForce = 500f;  // Force to launch the player upon explosion
    public GameObject explosionEffect;     // Explosion effect prefab (e.g., a particle system)
    public float destructionDelay = 2f;    // Delay before destroying the rocket after explosion
    public Vector3 moveDirection = Vector3.forward; // Direction in which the rocket will move (modifiable in the Inspector)

    private Transform player;              // Reference to the player object
    private bool isRiding = false;         // Is the player riding the rocket?
    private Rigidbody rb;                  // Rigidbody of the rocket

    private void Start()
    {
        // Ensure that the rocket starts moving immediately in the specified direction
        moveDirection.Normalize(); // Ensure the move direction is a unit vector
        rb = GetComponent<Rigidbody>();

        // Disable gravity for the rocket
        if (rb != null)
        {
            rb.useGravity = false; // Disable gravity on the rocket
        }
    }

    private void FixedUpdate()
    {
        if (!isRiding)
        {
            // If the player is not riding the rocket, move the rocket forward
            rb.velocity = moveDirection * speed; // Directly apply velocity to the rocket
        }
        else if (player != null)
        {
            // If the player is riding the rocket, move the rocket without affecting the player's position
            transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If the rocket collides with the player, allow them to ride the rocket
        if (collision.gameObject.CompareTag("Player") && !isRiding)
        {
            player = collision.transform;
            isRiding = true;

            // Make the player a child of the rocket to ride with it
            player.SetParent(transform);
            Rigidbody playerRb = player.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                playerRb.isKinematic = true;  // Disable physics for the player while riding
                playerRb.useGravity = false;  // Disable gravity for the player while riding
            }
        }

        // Handle the explosion when the rocket hits anything (including the player)
        Explode();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && isRiding)
        {
            // If the player leaves the rocket, unparent and enable physics again
            player.SetParent(null);
            Rigidbody playerRb = player.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                playerRb.isKinematic = false;
                playerRb.useGravity = true;  // Re-enable gravity for the player when they leave the rocket
            }
            isRiding = false;
        }
    }

    private void Explode()
    {
        // Instantiate the explosion effect (if any)
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // If the player is riding the rocket, eject them when the explosion occurs
        if (isRiding && player != null)
        {
            // Launch the player away from the rocket (apply force to eject them)
            Rigidbody playerRb = player.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                playerRb.isKinematic = false; // Re-enable physics
                playerRb.useGravity = true;   // Re-enable gravity for the player when they are ejected
                Vector3 launchDirection = (player.position - transform.position).normalized;
                playerRb.AddForce(launchDirection * playerLaunchForce, ForceMode.Impulse);
            }

            // Detach the player from the rocket
            player.SetParent(null);
            isRiding = false;
        }

        // Apply explosion effects to nearby objects
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Calculate the direction of the explosion force
                Vector3 explosionDirection = nearbyObject.transform.position - transform.position;
                float distance = explosionDirection.magnitude;
                float force = Mathf.Lerp(explosionForce, 0, distance / explosionRadius); // Reduce force with distance

                // Apply the explosion force to the nearby object
                rb.AddForce(explosionDirection.normalized * force, ForceMode.Impulse);
            }
        }

        // Delay the destruction of the rocket
        Destroy(gameObject, destructionDelay); // The rocket will be destroyed after 'destructionDelay' seconds
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a radius gizmo to show the explosion range in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}