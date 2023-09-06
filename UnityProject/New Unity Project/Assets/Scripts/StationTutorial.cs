using UnityEngine;
using System.Collections;

public class StationTutorial : Station
{
	
	[HideInInspector]
	public AudioSource audioSource;
	
	public string enterSound;
	public string exitSound;
	public string leafSound;
	public Animator doorAnimator;

	//public Animator doorAnimator;
	
/**
	void Update()
	{
			
		if(checkArea(PlayerBody.transform.position) & !Completed)
		{
			
			//Prüfen, ob die Station zum ersten mal betreten wird
			if(PlaySound)
			{
				//Audio 1
				FindObjectOfType<AudioManager>().PlaySound(soundName1);				
				PlaySound = false;
			}
			
			//Blatt anzeigen, wenn Audioausgabe abgeschlossen ist
			if(!FindObjectOfType<AudioManager>().SoundPlaying(soundName1))
			{
				//Item.GetComponent<BouncingLeaf_Tutorial>().showLeaf();
				Item.GetComponent<BouncingLeaf_Tutorial>().showLeaf = true;

			}

		} 
		
		if(Completed){
			//Audio 3
			FindObjectOfType<AudioManager>().PlaySound(soundName2);	
			
			//Tür öffnen
			doorAnimator.SetBool("TutorialCompleted", true);
		}
		
		//Wenn Spieler nicht in Area ist prüfen ob Sound noch abgespielt wird 
		//Wenn ja Soundwiedrgabe abbrechen
		if(!checkArea(PlayerBody.transform.position) & (FindObjectOfType<AudioManager>().SoundPlaying(soundName1) || FindObjectOfType<AudioManager>().SoundPlaying(soundName2)))
		{
			PlaySound = true;
			FindObjectOfType<AudioManager>().StopSound(soundName1);	
			FindObjectOfType<AudioManager>().StopSound(soundName2);	
		}
	

	}
**/	
	public void enterStation()
	{
		if(!Completed){
			FindObjectOfType<AudioManager>().PlaySound(enterSound);	
			StartCoroutine(wait(FindObjectOfType<AudioManager>().getAudioSource(enterSound).clip.length));				
		}	
	}
	
	public void exitStation()
	{
		FindObjectOfType<AudioManager>().StopSound(enterSound);	
		FindObjectOfType<AudioManager>().StopSound(exitSound);	
		FindObjectOfType<AudioManager>().StopSound(leafSound);	
	}
	
	public IEnumerator wait(float lenght)
    {
        yield return new WaitForSeconds(lenght);
		Item.GetComponent<BouncingLeaf_Tutorial>().showLeaf = true;
    }
	
	public void triggerLeaf()
	{
		FindObjectOfType<AudioManager>().StopSound(leafSound);	
	}
	
	public void completedStation()
	{
		doorAnimator.SetBool("TutorialCompleted", true);
		FindObjectOfType<AudioManager>().PlaySound(exitSound);	
		//StartCoroutine(wait(FindObjectOfType<AudioManager>().getAudioSource(sound2).clip.length));		
	}
	

}