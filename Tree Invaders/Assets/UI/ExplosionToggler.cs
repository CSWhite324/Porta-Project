using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplosionToggler : MonoBehaviour
{
    public GameObject toggler;
    public bool explosion = true;
    public static ExplosionToggler instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;    
        toggler.GetComponent<Toggle>().isOn = true ;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void userToggle(bool tog)
    {
        Debug.Log(tog);
        explosion = tog;
    }
}
