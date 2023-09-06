using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class StationFood : Station
{
    //public bool EggTaken;
    //public bool WormsTaken;
	[HideInInspector]
	public AudioSource audioSource;
	
	public string sound;

    private bool _EggTaken;

    public bool EggTaken
    {
        get { return _EggTaken; }
        set {
            _EggTaken = value;
            if (EggTaken && WormsTaken)
            {
                base.Completed = true;
            }
        }
    }

    private bool _WormsTaken;

    public bool WormsTaken
    {
        get { return _WormsTaken; }
        set {
            _WormsTaken = value;
            if (EggTaken && WormsTaken)
            {
                base.Completed = true;
            }
        }
    }



    /// <summary>
    /// Liste an Items die nach fertigstellung der Station verschwinden sollen.
    /// </summary>
    public List<GameObject> ItemsToHide;

/**
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		if(checkArea(PlayerBody.transform.position) & !Completed )
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
		
        //if (EggTaken && WormsTaken)
        //{
        //    base.Completed = true;
        //}
		if(!checkArea(PlayerBody.transform.position) & FindObjectOfType<AudioManager>().SoundPlaying(soundName))
		{
			PlaySound = true;
			FindObjectOfType<AudioManager>().StopSound(soundName);	
		}
    }
**/
    public void TakeEgg()
    {
        EggTaken = true;
    }

    public void TakeWorms()
    {
        WormsTaken = true;
    }

    /// <summary>
    /// Lässt GameObjects in der Liste verschwinden.
    /// </summary>
    public void HideItems()
    {
        foreach(var i in ItemsToHide)
        {
            MeshRenderer r;
            XRGrabInteractable interactable;
            i.TryGetComponent<MeshRenderer>(out r);
            if (r != null)
                r.enabled = false;
            i.TryGetComponent<XRGrabInteractable>(out interactable);
            if (interactable != null)
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


