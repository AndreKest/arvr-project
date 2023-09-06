using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationPondRobo2 : Station
{
    [HideInInspector]
    public AudioSource audioSource;
    /// <summary>
    /// Audioname die im Audiomanager hinterlegt wurde.
    /// </summary>
	
	/**
    public string soundName;
    private bool triggerArea = false;

    // Update is called once per frame
    void Update()
    {
        //Überprüft ob Station betreten worden ist und ob die Audio fertig abgespielt ist. Setzt danach die Station auf bestanden.
        if (triggerArea)
        {
            if(FindObjectOfType<AudioManager>().getAudioSource(soundName))
            {
                audioSource = FindObjectOfType<AudioManager>().getAudioSource(soundName);
                if (!audioSource.isPlaying)
                {
                    base.Completed = true;
                }
            }
        }
    }

    /// <summary>
    /// Setzt triggerArea auf true. Der Spieler betritt die Station.
    /// </summary>
    public void EnterArea()
    {
        triggerArea = true;
    }

    /// <summary>
    /// Setzt triggerArea auf false. Der Spieler verlässt die Station.
    /// </summary>
    public void ExitArea()
    {
        triggerArea = false;
    }
	**/
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
