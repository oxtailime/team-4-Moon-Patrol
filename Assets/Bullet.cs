using UnityEngine;

public class Bullet : MonoBehaviour {

public float bulletSpeed = 10f;
public float bulletDamage = 10f;

Rigidbody2D rb;

    // Start is called before the first frame update
     private void Start() {
        rb = GetComponent<Rigidbody2D>();
        Vector2 force = transform.right * bulletSpeed;
        rb.AddForce(force, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject);
    }
}
