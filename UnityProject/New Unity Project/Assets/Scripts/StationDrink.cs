using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StationDrink : Station
{
    //public bool WaterTaken;
	[HideInInspector]
	public AudioSource audioSource;
	
	public string sound;

    private bool _WaterTaken;

    public bool WaterTaken
    {
        get { return _WaterTaken; }
        set { 
            _WaterTaken = value;
            if (_WaterTaken)
            {
                Completed = true;
            }
        }
    }


    /// <summary>
    /// Liste an Items die nach fertigstellung der Station verschwinden sollen.
    /// </summary>
    public List<GameObject> ItemsToHide;

/**
    // Update is called once per frame
    void Update()
    {
        //if (WaterTaken)
        //{
        //    base.Completed = true;
        //}
		if(checkArea(PlayerBody.transform.position) & !Completed)
		{
			
			//Prüfen, ob die Station zum ersten mal betreten wird
			if(PlaySound)
			{
				//Audio 1
				FindObjectOfType<AudioManager>().PlaySound(soundName);				
				PlaySound = false;
			}			

		} 		
		
		//Wenn Spieler nicht in Area ist prüfen ob Sound noch abgespielt wird 
		//Wenn ja Soundwiedrgabe abbrechen
		else if(FindObjectOfType<AudioManager>().SoundPlaying(soundName))
		{
			PlaySound = true;
			FindObjectOfType<AudioManager>().StopSound(soundName);	
		}
		
		if(!checkArea(PlayerBody.transform.position) & FindObjectOfType<AudioManager>().SoundPlaying(soundName))
		{
			PlaySound = true;
			FindObjectOfType<AudioManager>().StopSound(soundName);	
		}
    }
**/
    public void TakeWater()
    {
        WaterTaken = true;
    }

    /// <summary>
    /// Lässt GameObjects in der Liste verschwinden.
    /// </summary>
    public void HideItems()
    {
        foreach (var i in ItemsToHide)
        {
            MeshRenderer r;
            XRGrabInteractable interactable;
            i.TryGetComponent<MeshRenderer>(out r);
            if (r != null)
                r.enabled = false;
            i.TryGetComponent<XRGrabInteractable>(out interactable);
            if(interactable != null)
            {
                interactable.enabled = false;
            }
        }
    }
	
	public void enterStation()
	{
		if(!Completed){
			FindObjectOfType<AudioManager>().PlaySound(sound);	
		}	
	}
	
	public void exitStation()
	{
		FindObjectOfType<AudioManager>().StopSound(sound);	
	}
	

	

}
