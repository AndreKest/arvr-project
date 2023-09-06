using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawsLightSwitch : MonoBehaviour
{
    public GameObject[] lights;
    public Material PfoteMaterialAus;

    //Das Licht beim Pfotenweg wird ausgeschaltet, wenn eine Station bestanden wird.
    public void DisableLight()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].GetComponent<Light>().enabled = false;
            lights[i].transform.parent.gameObject.GetComponent<MeshRenderer>().material = PfoteMaterialAus;
        }
    }
}
