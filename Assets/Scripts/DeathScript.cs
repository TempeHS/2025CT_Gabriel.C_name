using UnityEngine;

public class DeathScript : MonoBehaviour
{
    [SerializeField] private Transform startPoint; // Assign your respawn point in Inspector

private void OnCollisionEnter2D(Collision2D collision)
{
    Debug.Log("Collided with: " + collision.collider.name);
    if (collision.collider.CompareTag("Player"))
    {
        collision.collider.transform.position = startPoint.position;
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.velocity = Vector2.zero;
    }
}
}