using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerEnemy : MonoBehaviour {
    public int health = 100;
    public GameObject deathEffect;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public int bulletDamage = 40;
    private float timeBtwShots;
    [SerializeField]
    private float startTimeBtwShots;

    public GameObject projectile;
    private Transform player;
   
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) > stoppingDistance ){
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        } else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance){
            transform.position = this.transform.position;
        } else if(Vector2.Distance(transform.position, player.position) < retreatDistance){
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }


        if(timeBtwShots <= 0){

            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        } else {
            timeBtwShots -= Time.deltaTime;
        }
    }
    public void TakeDamage(int bulletDamage)
    {
        health = health - bulletDamage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        StartCoroutine(Break());

        Destroy(gameObject);
    }
    private IEnumerator Break()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(2000);
    }






}
