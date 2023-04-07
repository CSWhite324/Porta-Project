using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{

    [SerializeField] GameObject horizontalEnemyPrefab;
    [SerializeField] GameObject verticalEnemyPrefab;
    [SerializeField] GameObject verticalBounceEnemyPrefab;
    [SerializeField] private float spawnInterval = 1000;
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
        if(time % spawnInterval == 0){
            spawnVertical(verticalEnemyPrefab);
        }
        if(time % spawnInterval == spawnInterval/2){
            spawnVerticalBounce(verticalBounceEnemyPrefab);
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

    private void spawnVertical(GameObject enemy){
        // spawn enemy
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-3f, 3f), 6f), Quaternion.identity);
        // rotate newEnemy to point down
        newEnemy.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));

    }

    private void spawnVerticalBounce(GameObject enemy){
        // spawn enemy
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-3f, 3f), 6f), Quaternion.identity);
        // rotate newEnemy to point down/diagonal

        if(Random.Range(0, 2) == 0){
            newEnemy.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 135));
        }else{
            newEnemy.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -135));
        }


    }

}
