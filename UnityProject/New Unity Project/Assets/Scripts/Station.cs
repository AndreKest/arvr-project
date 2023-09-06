using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Station : MonoBehaviour
{

    private bool _completed;

	public UnityEvent CompletedEvent;

    public bool Completed
    {
        get { return _completed; }
        set {
			_completed = value;
            if (value)
            {
				CompletedEvent.Invoke();
            }
		}
    }


    //public bool Completed = false;  	//Aufgabe erfüllt
	public bool ColletedItem = false;   //Item eingesammelt
	public GameObject Item; 			
	
	public Collider StationArea;
	public Transform PlayerBody;
	
	public bool PlaySound = true;
	//Anpassen
	//public Audio audio;
	public string Text = "";

	
	//Prüfen, ob sich Position in StationArea befindet
	public bool checkArea(Vector3 position)
	{
		return StationArea.bounds.Contains(position);
	}



}