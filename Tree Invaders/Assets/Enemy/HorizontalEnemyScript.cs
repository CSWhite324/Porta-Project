using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalEnemyScript : MonoBehaviour
{
    public float speed = 10.0f;
    public int time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.up * Time.deltaTime * speed;

        time = time + 1;


        // despawn
        if (time > 100){
            Destroy(gameObject);
        }
    }
}
