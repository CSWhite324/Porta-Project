using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCanonScript : MonoBehaviour
{

    private Vector3 mousePosition;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        if (UI_Manager.instance != null && UI_Manager.instance.move == true)
        {

            // Get the current mouse position
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Only track the x position of the mouse
            transform.position = new Vector3(mousePosition.x, transform.position.y, transform.position.z);
        }
    }
}
