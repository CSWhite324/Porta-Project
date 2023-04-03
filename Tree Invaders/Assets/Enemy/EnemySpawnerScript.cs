using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{

    [SerializeField] GameObject horizontalEnemyPrefab;
    [SerializeField] private float spawnInterval = 500;
    private float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(time % spawnInterval == 0){
            spawnHorizontalRight(horizontalEnemyPrefab);
        }
        if(time % spawnInterval == spawnInterval/2){
            spawnHorizontalLeft(horizontalEnemyPrefab);
        }
        time++;
    }

    private void spawnHorizontalRight(GameObject enemy){
        // spawn enemy
        GameObject newEnemy = Instantiate(enemy, new Vector3( 5f , Random.Range(-2f, 4f)), Quaternion.identity);
        // rotate newEnemy to point left
        newEnemy.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));

    }

    private void spawnHorizontalLeft(GameObject enemy){
        // spawn enemy
        GameObject newEnemy = Instantiate(enemy, new Vector3( -5f , Random.Range(-2f, 4f)), Quaternion.identity);
        // rotate newEnemy to point left
        newEnemy.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));

    }

}
