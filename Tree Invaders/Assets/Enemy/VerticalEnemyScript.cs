using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalEnemyScript : MonoBehaviour
{
    public float speedModifier = 0.5f;
    public float baseSpeed = 5f;
    public int time = 0;
    public float despawnBoundary = -6f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.up * Time.deltaTime * (baseSpeed + (speedModifier * UI_Manager.instance.score));
        time = time + 1;

        


        // despawn
        if (transform.position.y < despawnBoundary){
            Destroy(gameObject);
        }
    }
}
