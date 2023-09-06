using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// Skript nur f�r BoxCollider, um Erz�hlerstimme zu triggern und zu stoppen
/// </summary>
public class TriggerControl : MonoBehaviour
{
    /// <summary>
    /// Stationsbereich
    /// </summary>
    public GameObject area;
    private bool cleared = false;
    /// <summary>
    /// Checkbox ob der Box Collider nach dem bestehen der Station aktiviert wird oder nicht
    /// </summary>
    public bool enableBoxCollider = true;
    
    /// <summary>
    /// EventEnter der eintritt, wenn der Spieler den Box Collider betritt.
    /// </summary>
    public UnityEvent EnterEvent;
    /// <summary>
    /// ExitEvent der eintritt, wenn der Spieler den Box Collider betritt.
    /// </summary>
    public UnityEvent ExitEvent;
    


    /// <summary>
    /// Beim betreten der Station wird die Erz�hlerstimme gestartet, bei Bedarf die Sprechblase aktiviert und bei Bedarf der EventHandler f�r
    /// EnterEvent aktiviert.
    /// </summary>
    private void OnTriggerEnter(Collider c)
    {
        //@Saniye:
        //Hab ich hinzugef�gt damit nicht jedes Objekt den Sound Triggert, sondern nur der Spieler

        if (c.gameObject.tag != "Player")
        {
            return;
        }

        //Aktiviert EventHandler EnterEvent
        EnterEvent.Invoke();


        if (cleared)
        {
            //L�scht ColliderBox, wenn die Station erledigt wurde.
            if (enableBoxCollider)
            {
                area.GetComponent<Collider>().enabled = false;
                //deleteBoxCollider = false;
            }
        }
    }

    /// <summary>
    /// Beim verlassen der Station wird die Erz�hlerstimme gestoppt, bei Bedarf die Sprechblase deaktiviert und bei Bedarf der EventHandler f�r
    /// ExitEvent aktiviert.
    /// </summary>
    private void OnTriggerExit(Collider c)
    {
        //@Saniye:
        //Hab ich hinzugef�gt damit nicht jedes Objekt den Sound Triggert, sondern nur der Spieler
        if (c.gameObject.tag != "Player")
        {
            return;
        }

        //Aktiviert EventHandler ExitEvent
        ExitEvent.Invoke();

    }

    /// <summary>
    /// Station wurde bew�ltigt. Cleared wird auf true gesetzt.
    /// </summary>
    public void StationCleared()
    {
        cleared = true;
    }
}

