using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightFilterToggler : MonoBehaviour
{
    public GameObject toggler;
    public bool explosion = true;
    public static NightFilterToggler instance;
    [SerializeField] GameObject filter;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        toggler.GetComponent<Toggle>().isOn = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void userToggle(bool tog)
    {
        Debug.Log(tog);
        filter.gameObject.SetActive(tog);
    }
}
