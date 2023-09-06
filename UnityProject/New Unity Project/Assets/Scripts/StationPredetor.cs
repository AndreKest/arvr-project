using UnityEngine;
using System.Collections;

public class StationPredetor : Station
{
	[HideInInspector]
	public AudioSource audioSource;
	
	public string sound1;
	public string sound2;
	
	public Animator bush1;
	public Animator bush2;
	
	public string soundBush;
	
	/**
	void Update()
	{
		
		if(checkArea(PlayerBody.transform.position) & !Completed)
		{
			if(PlaySound)
			{
				//Audio ausgeben
				//FindObjectOfType<AudioManager>().PlaySound("stationPredetorEntry");
				FindObjectOfType<AudioManager>().PlaySound(soundName1);
				
				PlaySound = false;
			}
					
			/*
			if(player defended)
			{
				//Audio ausgeben
				//FindObjectOfType<AudioManager>().PlaySound("stationPredetorDefended");
				
				//Item runterlassen
				Item.cleared = true;
				Completed = true;
			}
			*/
			/**
		} 	
		
		//Wenn Spieler nicht in Area ist prüfen ob Sound noch abgespielt wird 
		//Wenn ja Soundwiedrgabe abbrechen
		if(!checkArea(PlayerBody.transform.position) & (FindObjectOfType<AudioManager>().SoundPlaying(soundName1) || FindObjectOfType<AudioManager>().SoundPlaying(soundName2)))
		{
			PlaySound = true;
			FindObjectOfType<AudioManager>().StopSound(soundName1);	
			FindObjectOfType<AudioManager>().StopSound(soundName2);	
		}
	}**/
	
	
	public void PlayerDefend()
    {
		if (checkArea(PlayerBody.transform.position) & !FindObjectOfType<AudioManager>().SoundPlaying(sound1))
        {
			Completed = true;
			FindObjectOfType<AudioManager>().PlaySound(sound2);
		}
		Debug.Log("Defend Successfull");
	}
	

	public void enterStation()
	{
		if(!Completed){
			FindObjectOfType<AudioManager>().PlaySound(sound1);	
			startAnimation();
		}	
	}
	
	public void exitStation()
	{
		FindObjectOfType<AudioManager>().StopSound(sound1);	
		//FindObjectOfType<AudioManager>().StopSound(sound2);	
		stopAnimation();

	}
	
	public void stopAnimation()
	{
		bush1.SetBool("animateBush", false);
		bush2.SetBool("animateBush", false);
		FindObjectOfType<AudioManager>().StopSound(soundBush);	
	}
		
	public void startAnimation()
	{
		bush1.SetBool("animateBush", true);
		bush2.SetBool("animateBush", true);
	}
}
	


