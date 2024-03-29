using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyScript : MonoBehaviour
{
    // type of enemy

    public string type;
    public string direction = "vertical";

    public float speedModifier;
    public float baseSpeed;


    public SpriteRenderer spriteRenderer;
    [SerializeField] GameObject smokePrefab;
    //[SerializeField] public Sprite greenSprite;
    //[SerializeField] public Sprite yellowSprite;
    //[SerializeField] public Sprite whiteSprite;
    //[SerializeField] public Sprite whiteSlowSprite;

    public float xBounceMax = 3f;
    public float xBounceMin = -3f;
    public float verticalDespawnBoundary = -6f;
    public float horizontalDespawnBoundary = 10f;

    public static enemyScript instance;
    public bool explosion;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;    
    }

    public void setType(string pType){
        type = pType;

        if(pType == "bounce"){
            speedModifier = 0.1f;
            baseSpeed = 1f;
            //spriteRenderer.sprite = whiteSprite; 
        }else if(pType == "yellow"){
            speedModifier = 0.5f;
            baseSpeed = 5f;
            //spriteRenderer.sprite = yellowSprite;
            spriteRenderer.color = Color.yellow; 
        }else if(pType == "green"){
            speedModifier = 0.1f;
            baseSpeed = 1f;
            direction = "horizontal";
        }else if(pType == "white"){
            speedModifier = 0.1f;
            baseSpeed = 1f;
        }else if(pType == "whiteSlow"){
            speedModifier = 0.05f;
            baseSpeed = 0.5f;
            Color tempColor = spriteRenderer.color;
            tempColor.a = 0.5f;
            spriteRenderer.color = tempColor;
        }
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {

        if (UI_Manager.instance.move == true)
        {
            // move enemy forward
            transform.position += transform.up * Time.deltaTime * (baseSpeed + (speedModifier * UI_Manager.instance.score));
            if (direction == "vertical")
            {
                bounceCheck();
            }


            // despawn
            if (type == "vertical")
            {
                if (transform.position.y < verticalDespawnBoundary)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                if (transform.position.x > horizontalDespawnBoundary || transform.position.x < -horizontalDespawnBoundary)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    void bounceCheck()
    {
        if(transform.position.x >= xBounceMax){
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 135));
        }

        if(transform.position.x <= xBounceMin){
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -135));
        }
    }

    public void destroyEnemy() {
        Debug.Log(" EXPLOSION " + ExplosionToggler.instance.explosion);
        if (ExplosionToggler.instance.explosion)
        {
            for (int i = 0; i < 6; i++)
            {
                Debug.Log("explode");
                GameObject newSmoke = Instantiate(smokePrefab, new Vector3(transform.position.x - Random.Range(-0.3f, 0.3f), transform.position.y - Random.Range(-0.3f, 0.3f)), Quaternion.identity);
                newSmoke.GetComponent<SmokeScript>().setType(type);
            }
        }
        Destroy(gameObject);
    }
}