using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalEnemyScript : MonoBehaviour
{
    public float speedModifier = 0.1f;
    public float baseSpeed = 1f;
    public int time = 0;
    public float despawnBoundary = 10f;
    private bool started = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!started){
            if(UI_Manager.instance.isStarted){
                started = true;
                baseSpeed++;
            }
        }

        transform.position += transform.up * Time.deltaTime * (baseSpeed + (speedModifier * UI_Manager.instance.score));

        time = time + 1;


        // despawn

        if (transform.position.x > despawnBoundary || transform.position.x < -despawnBoundary){
            Destroy(gameObject);
        }
    }
}
