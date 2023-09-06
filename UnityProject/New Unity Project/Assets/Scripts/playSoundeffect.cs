using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSoundeffect : MonoBehaviour
{
	[HideInInspector]
	public AudioSource audioSource;
	public string soundName;
    // Start is called before the first frame update

	
	void playSound()
	{
		FindObjectOfType<AudioManager>().PlaySound(soundName);	
	}
	
}
