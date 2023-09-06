using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeafCounter : MonoBehaviour
{
    /// <summary>
    /// Bl?tter die der Spieler gesammelt hat
    /// </summary>
    private int _LeafsCollected=0;

    /// <summary>
    /// Anzahl an Bl?ttern die der Spiler sammeln muss um zu gewinnen
    /// </summary>
    public int LeafsWinValue;

    /// <summary>
    /// Events die Ausgef?hrt werden, wenn der Spieler gewinnt
    /// </summary>
    public UnityEvent WinEvent;

    /// <summary>
    /// Anzahl an gesammelten Bl?ttern, l?st WinEvent aus wenn gen?gend Bl?tter gesammelt wurden.
    /// </summary>
    public int LeafsCollected
    {
        get { return _LeafsCollected; }
        set {           
            _LeafsCollected = value;
            if(_LeafsCollected == LeafsWinValue)
            {
                WinEvent.Invoke();
				StartCoroutine(wait(3));				

            }
        
        }
    }

    /// <summary>
    /// F?gt dem LeafCounter ein Blatt hinzu.
    /// </summary>
    public void CollectLeaf()
    {
        LeafsCollected++;
        Debug.Log("Leafs collected in Leaf Counter: " + LeafsCollected);
    }

    /// <summary>
    /// Testmethode um Ende des Spiels festzustellen
    /// </summary>
    public void TestWin()
    {
        Debug.Log("SPIEL GEWONNEN!!!!");
    }

	public IEnumerator wait(float lenght)
    {
        yield return new WaitForSeconds(lenght);
		FindObjectOfType<AudioManager>().PlaySound("TheEnd");	
    }

}
