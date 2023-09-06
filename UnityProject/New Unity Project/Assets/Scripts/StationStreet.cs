using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StationStreet : Station
{
	[HideInInspector]
	public AudioSource audioSource;
	
	public string sound1;
	public string sound2;

    public GameObject Bubble500k;
    public GameObject Bubble300k;
    public GameObject Bubble100k;

    public Material CorrectMaterial;
    public Material IncorrectMaterial;

    public void Option500k()
    {
        Bubble500k.GetComponent<MeshRenderer>().material = CorrectMaterial;
        Completed = true;

        //Zukünftige Interaktionen verhindern
        //Bubble500k.GetComponent<MeshCollider>().enabled = false;
        //Bubble300k.GetComponent<MeshCollider>().enabled = false;
        //Bubble100k.GetComponent<MeshCollider>().enabled = false;

		XRGrabInteractable interactable;
		if (Bubble500k.TryGetComponent<XRGrabInteractable>(out interactable))
			interactable.enabled = false;
		if (Bubble300k.TryGetComponent<XRGrabInteractable>(out interactable))
			interactable.enabled = false;
		if (Bubble100k.TryGetComponent<XRGrabInteractable>(out interactable))
			interactable.enabled = false;

	}

    public void Option300k()
    {
        Bubble300k.GetComponent<MeshRenderer>().material = IncorrectMaterial;
    }

    public void Option100k()
    {
        Bubble100k.GetComponent<MeshRenderer>().material = IncorrectMaterial;
    }
	
	/**
	void Update()
	{
			
		if(checkArea(PlayerBody.transform.position) & !Completed)
		{
			
			//Prüfen, ob die Station zum ersten mal betreten wird
			if(PlaySound)
			{
				//Audio
				FindObjectOfType<AudioManager>().PlaySound(soundName);				
				PlaySound = false;
			}
			
			//Blatt anzeigen, wenn Audioausgabe abgeschlossen ist
			if(!FindObjectOfType<AudioManager>().SoundPlaying(soundName))
			{
				Item.GetComponent<BouncingLeaf_Tutorial>().showLeaf = true;

			}

		} 
		
		//Wenn Spieler nicht in Area ist prüfen ob Sound noch abgespielt wird 
		//Wenn ja Soundwiedrgabe abbrechen
		if(!checkArea(PlayerBody.transform.position) & FindObjectOfType<AudioManager>().SoundPlaying(soundName))
		{
			PlaySound = true;
			FindObjectOfType<AudioManager>().StopSound(soundName);	
		}


	}**/
	
	public void enterStation()
	{
		if(!Completed){
			FindObjectOfType<AudioManager>().PlaySound(sound1);	
		}	
	}
	
	public void exitStation()
	{
		FindObjectOfType<AudioManager>().StopSound(sound1);	
		FindObjectOfType<AudioManager>().StopSound(sound2);	
	}
	
	public void completedStation()
	{
		FindObjectOfType<AudioManager>().PlaySound(sound2);	
	}
	
}
