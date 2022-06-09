using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmieSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject umiePrefab;
    [SerializeField]
    private float umieInterval = 3.3f;

    [SerializeField]
    private GameObject FlyerPrefab;
    [SerializeField]
    private float FlyerInterval = 8f; 
    void Start()
    {
        StartCoroutine(spawnEnemy(umieInterval, umiePrefab));
        StartCoroutine(spawnEnemy(FlyerInterval, FlyerPrefab));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(8f, 11), Random.Range(-3f, 4f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
