using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeafsToCollect : MonoBehaviour
{

    /// <summary>
    /// Event listener der die Blätter zählz
    /// </summary>
    public GameObject EventListener;
	public Station station;
    public AudioSource audio1;



    public void Start()
    {
        EventListener = GameObject.Find("GameEventManager");
    }

    /// <summary>
    /// Aufrufen der Methode im EventListener um die Blätter zu zählen. 
    /// Blätter werden in einem Extra Objekt gezähl, Prüfung der Blätter von einem einzigen objekt abhängig zu machen und nicht von allen Blättern.
    /// </summary>
    public void CollectLeave()
    {
        EventListener.GetComponent<LeafCounter>().SendMessage("CollectLeaf");
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        audio1.Play();

        StartCoroutine(destroyAfterDelay(audio1.clip.length, gameObject));

        if (station)
		{
			station.Completed =true;
		}			
    }

    public IEnumerator destroyAfterDelay(float length, GameObject objectToDestroy)
    {
        yield return new WaitForSeconds(length);
        //objectToDisable.SetActive(false);
        Destroy(objectToDestroy);

    }
}
