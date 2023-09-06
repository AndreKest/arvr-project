using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationPondRobo : Station
{
    /// <summary>
    /// Audioname die im Audiomanager hinterlegt wurde.
    /// </summary>
	public string sound;
	

	public void enterStation()
	{
		if(!Completed){
			FindObjectOfType<AudioManager>().PlaySound(sound);	
			StartCoroutine(wait(FindObjectOfType<AudioManager>().getAudioSource(sound).clip.length));				
		}	
	}
	
	public IEnumerator wait(float lenght)
    {
        yield return new WaitForSeconds(lenght);
		base.Completed = true;
    }
	
	public void exitStation()
	{
		FindObjectOfType<AudioManager>().StopSound(sound);	
	}
	
	
}
