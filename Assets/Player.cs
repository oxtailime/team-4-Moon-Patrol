using UnityEngine;

public class Player : MonoBehaviour {
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float moveSpeed = 5f;
    

    // Start is called before the first frame update
     void Start()
    {
        
    }

    // Update is called once per frame
     void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
        Jump();

        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }

    }

    private void Jump(){
        if(Input.GetKeyDown(KeyCode.Space)) {
            GetComponent<Rigidbody2D>().
             GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 8), ForceMode2D.Impulse);
     
        }

        
    }
    private void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
        Destroy(bullet, 5f);


    }

    }

