using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountLeafs : MonoBehaviour
{
    GameObject leafCounter;
    // Start is called before the first frame update
    void Start()
    {
        leafCounter = GameObject.Find("leafCounter");
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    leafCounter.GetComponent<Text>().text = "Blatt: "+ LeafsToCollect.leafs.ToString();

    //    //wenn alle stationen durch sind -> eine nachricht dass alle aufgaben gemeistert wurden oder irgendwas anderes
    //    if(LeafsToCollect.leafs == 4)
    //    {
    //        leafCounter.GetComponent<Text>().text = "Alle Blättre gesammelt!";
    //    }
    //}
}
