using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloudToggler : MonoBehaviour
{
    public GameObject toggler;
    public bool clouds = true;
    public static CloudToggler instance;
    [SerializeField] GameObject cloud;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        toggler.GetComponent<Toggle>().isOn = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void userToggle(bool tog)
    {
        Debug.Log(tog);
        cloud.gameObject.SetActive(tog);
    }
}
