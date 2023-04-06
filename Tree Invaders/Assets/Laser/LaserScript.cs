using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private Vector3 mousePosition;
    public bool pink;
    private bool shot = false;


    void Update()
    {
        
        // Get the current mouse position
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Only track the x position of the mouse
        transform.position = new Vector3(mousePosition.x, transform.position.y, transform.position.z);


        if (Input.GetMouseButtonDown(0))
        {
            shot = true;
            Debug.Log(shot);
            UI_Manager.instance.gameStart();
            StartCoroutine(Shoot());

        }
        if(Input.GetMouseButtonUp(0))
        {
            shot=false;
            Debug.Log(shot);
        }
    }

    IEnumerator Shoot()
    {
        if (pink)
        {
            Vector3 newPos = transform.position;
            newPos.z = -1f;
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
            newPos.z = 1f;
            transform.position = newPos;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (shot && collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Passed Thru");
            Destroy(collision.gameObject);
        }
        
    }

}
