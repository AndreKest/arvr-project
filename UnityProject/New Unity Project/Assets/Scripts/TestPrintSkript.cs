using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPrintSkript : MonoBehaviour
{
    public AudioSource audio1 ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void printTest()
    {
        audio1.enabled = true;
        audio1.Play();
        Debug.Log("HALLO");
    }
}
