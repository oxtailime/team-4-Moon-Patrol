using UnityEngine;

public class BulletEnemy : MonoBehaviour {

public float bulletSpeed = 10f;
public int bulletDamage = 40;

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

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamagePlayer(bulletDamage);
        }
        Destroy(gameObject);
    }
}
