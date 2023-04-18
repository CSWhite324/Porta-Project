using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private Vector3 mousePosition;
    public bool pink;
    private bool shot = false;
    private bool hit = false;
    public GameObject horizontalEnemy;
    public GameObject verticalEnemy;
    public GameObject verticalBounceEnemy;
    public AudioSource audioSource;
    public AudioClip laser;
    public AudioClip explosion;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (UI_Manager.instance != null && UI_Manager.instance.move == true)
        {

            // Get the current mouse position
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Only track the x position of the mouse
            transform.position = new Vector3(mousePosition.x, transform.position.y, transform.position.z);


            if (Input.GetMouseButtonDown(0))
            {
                audioSource.clip = laser;
                if (laser != null)
                {
                    audioSource.Play();
                }
                shot = true;
                StartCoroutine(Fire());
                StartCoroutine(Shoot());
                if (!hit && !UI_Manager.instance.firstKill)
                {
                    UI_Manager.instance.subScore();
                }
                UI_Manager.instance.isVisible = false;      
            }
        }
        hit = false;

    }

    IEnumerator Shoot() {
        yield return new WaitForSeconds(.1f);
        shot = false;
    }
    IEnumerator Fire()
    {
        if (pink)
        {
            Vector3 newPos = transform.position;
            newPos.z = 0f;
            transform.position = newPos;
        }
        // Calculate the rotation amount and speed
        float rotationAmount = 90f;
        float rotationSpeed = rotationAmount / 0.1f;


        // Rotate the object over 0.1 seconds
        float timeElapsed = 0f;
        while (timeElapsed < 0.1f)
        {
            float rotation = rotationSpeed * Time.deltaTime;
            transform.Rotate(new Vector3(0f, rotation, 0f));
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = Quaternion.identity;
        if (pink)
        {
            Vector3 newPos = transform.position;
            newPos.z = -20f;
            transform.position = newPos;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(shot == true && collision.gameObject.tag == "Enemy")
        {
            hit = true;
            audioSource.clip = explosion;
            if(explosion != null)
            {
                audioSource.Play();
            }
            UI_Manager.instance.addScore();
            //Destroy(collision.gameObject);
            collision.gameObject.GetComponent<enemyScript>().destroyEnemy();
        }
    }
}
