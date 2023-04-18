using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeScript : MonoBehaviour
{

    public string type;
    public SpriteRenderer spriteRenderer;
    
    public float speed = 1f;
    public Color tempColor;
    public int time = 0;


    public void setType(string pType){
        type = pType;

        if(pType == "yellow"){
            spriteRenderer.color = Color.yellow; 
        }else if(pType == "green"){
            spriteRenderer.color = Color.green; 
        }else if(pType == "whiteSlow"){
            Color tempColor = spriteRenderer.color;
            tempColor.a = 0.5f;
            spriteRenderer.color = tempColor;
        }


        // randomize speed
        speed = speed + Random.Range(-0.3f, 0.3f);

        // randomize direction
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(-15f, 15f)));

        // randomize size (scale)
        transform.localScale = new Vector3(Random.Range(0.7f, 1.3f), Random.Range(1f, 1.6f), 1);

        // randomize transparency
        tempColor = spriteRenderer.color;
        tempColor.a = Random.Range(0.3f, 0.4f);
        spriteRenderer.color = tempColor;



    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.up * Time.deltaTime * speed;
        tempColor = spriteRenderer.color;
        tempColor.a = tempColor.a - 0.005f;
        spriteRenderer.color = tempColor;

        if(time > 80){
            Destroy(gameObject);
        }
        time++;
    }
}
