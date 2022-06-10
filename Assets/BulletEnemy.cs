using UnityEngine;

public class BulletEnemy : MonoBehaviour {

public float bulletSpeed = 10f;
public int bulletDamage = 40;

private Transform player;
Rigidbody2D rb;

    // Start is called before the first frame update
     private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        rb = GetComponent<Rigidbody2D>();
        Vector2 force = player.position * bulletSpeed;
        rb.AddForce(force, ForceMode2D.Impulse);

        
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.gameObject.CompareTag("Player"))
        {
            Player player = hitInfo.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamagePlayer(bulletDamage);
            }
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
