using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerClearedOnEnter : MonoBehaviour
{
    public Station StationToClear;
    public void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.tag == "Player")
        {
            StationToClear.Completed = true;
        }

        Debug.Log(c.gameObject.name);
    }

    
}
