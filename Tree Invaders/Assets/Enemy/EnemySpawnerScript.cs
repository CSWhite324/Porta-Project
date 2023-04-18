using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{

    [SerializeField] GameObject greenPrefab;
    [SerializeField] GameObject yellowPrefab;
    [SerializeField] GameObject bouncePrefab;
    [SerializeField] GameObject whitePrefab;
    [SerializeField] GameObject whiteSlowPrefab;
    [SerializeField] private float spawnInterval = 1000;
    private float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //spawn green enemy either left or right
        if(Random.Range(0, 50) == 0){
            if(Random.Range(0, 2) == 0){
                spawnHorizontalRight(greenPrefab);
            }else{
                spawnHorizontalLeft(greenPrefab);
            }
        }
        //spawn vertical enemy, either yellow, bounce, white, or whiteSlow
        if(Random.Range(0, 50) == 0 && UI_Manager.instance.isStarted){
            if(Random.Range(0, 2) == 0){
                if(Random.Range(0, 2) == 0){
                    spawnVerticalBounce(bouncePrefab);
                }else{
                    spawnVertical(yellowPrefab, "yellow");
                }
            }else{
                if(Random.Range(0, 2) == 0){
                    spawnVertical(whitePrefab, "white");
                }else{
                    spawnVertical(whiteSlowPrefab, "whiteSlow");
                }
            }
            
        }


    }

    private void spawnHorizontalRight(GameObject enemy){
        // spawn enemy
        GameObject newEnemy = Instantiate(enemy, new Vector3( 5f , Random.Range(-2f, 4f)), Quaternion.identity);
        // rotate newEnemy to point left
        newEnemy.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        newEnemy.GetComponent<enemyScript>().setType("green");

    }

    private void spawnHorizontalLeft(GameObject enemy){
        // spawn enemy
        GameObject newEnemy = Instantiate(enemy, new Vector3( -5f , Random.Range(-2f, 4f)), Quaternion.identity);
        // rotate newEnemy to point left
        newEnemy.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
        newEnemy.GetComponent<enemyScript>().setType("green");

    }

    private void spawnVertical(GameObject enemy, string type){
        // spawn enemy
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-3f, 3f), 6f), Quaternion.identity);
        // rotate newEnemy to point down
        newEnemy.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
        newEnemy.GetComponent<enemyScript>().setType(type);

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
        newEnemy.GetComponent<enemyScript>().setType("bounce");


    }

}
