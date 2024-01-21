using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnTime;
    private float spawnTimer;
    private int enemyNum;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer >= spawnTime && enemyNum <=5){
            spawnTimer = 0;
            SpawnEnemy();
        }
        
    }

    void SpawnEnemy(){
        GameObject.Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        enemyNum+=1;
    }
}
