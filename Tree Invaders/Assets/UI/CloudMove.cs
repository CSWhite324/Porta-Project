using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{

    private float speed = 1.0f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0.0f);
        Destroy(gameObject, 10.0f); // Destroy after 10 seconds to prevent memory leaks
    }
}
