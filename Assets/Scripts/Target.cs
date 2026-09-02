using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component attached to this GameObject
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (transform.position.y < -30)
        {
            Die();
        }
    }

    // Updated to take directional knockback data
    public void TakeDamage(float amount, Vector3 hitDirection, float knockbackForce = 10f)
    {
        health -= amount;

        // Apply instant physical force if Rigidbody exists
        if (rb != null)
        {
            rb.AddForce(hitDirection.normalized * knockbackForce, ForceMode.Impulse);
        }

        if (health <= 0f)
        {
            Die();
        }

    }

    void Die()
    {
        Destroy(gameObject);
    }
}