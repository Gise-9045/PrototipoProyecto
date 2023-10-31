using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayVariable : MonoBehaviour
{
    public touchPlatform touchPlatform;
    public Text displayText;
    private float myVariable;
    public GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        myVariable = touchPlatform.usedNumTouches;
        
    }

    // Update is called once per frame
    void Update()
    {
        displayText.text = myVariable.ToString();
    }
}
