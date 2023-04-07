using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalBounceEnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10.0f;
    public int time = 0;
    public float xMax = 3f;
    public float xMin = -3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(transform.position.x >= xMax){
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 135));
        }

        if(transform.position.x <= xMin){
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -135));
        }
        
        transform.position += transform.up * Time.deltaTime * speed;

        time = time + 1;

        


        // despawn
        if (time > 100){
            Destroy(gameObject);
        }
    }
}
