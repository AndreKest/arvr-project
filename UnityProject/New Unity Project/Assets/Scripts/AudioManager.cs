using System;
using UnityEngine;
using System.Collections;

/// <summary>
/// Musikmanager der Für das Suchen, Starten und Stoppen der Audio zuständig ist.
/// </summary>
public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// Benutzerdefinierte Klasse Sound.
    /// </summary>
    public Sound[] sounds;

    void Awake()
    {
        //Nach Szenen wechsel wird der Sound nicht abgeschnitten (Credits)
        DontDestroyOnLoad(gameObject);

        //setzt die Werte der AudioSource Komponente, beim beginn des Spiels
        foreach(Sound s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.audioClip;
            s.audioSource.volume = s.volume;
            s.audioSource.loop = s.loop;
        }
    }

    /// <summary>
    /// Spielt Hintergrund Musik beim Start des Spiels.
    /// </summary>
    void Start()
     {
        PlaySound("theme");
     }

    /// <summary>
    /// Spielt Audio ab, dass in AudioManager aufgelistet ist.
    /// </summary>
    public void PlaySound(string name)
    {
        //Sucht das Audio, das im sounds-Array mit "name" definiert wurde
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Der Sound " + name + " wurde nicht gefunden");
            return;
        }
        s.audioSource.Play();
    }

    /// <summary>
    /// Stoppt die Audio, dass in AudioManager aufgelistet ist
    /// </summary>
    public void StopSound(string name)
    {
        //Sucht das Audio, das im Array mit "name" definiert wurde
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Der Sound " + name + " wurde nicht gefunden");
            return;
        }
        s.audioSource.Stop();
    }

    /// <summary>
    /// Prüfen, ob Sound aktuell abgespielt wird.
    /// </summary>
    public bool SoundPlaying(string name)
	{
		//Sucht das Audio, das im sounds-Array mit "name" definiert wurde
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Der Sound " + name + " wurde nicht gefunden");
            return false;
        }

		if(s.audioSource.isPlaying)
		{
			return true;
		}
		return false;
		
	}

    /// <summary>
    /// Sucht die Audioquelle durch den Audionamen und gibt ihn als Rückgabeparameter weiter.
    /// </summary>
    public AudioSource getAudioSource(string name)
    {
        //Sucht das Audio, das im sounds-Array mit "name" definiert wurde
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Der Sound " + name + " wurde nicht gefunden");
            return null;
        }
        return s.audioSource;

    }    
    
    /// <summary>
    /// Sucht die AudioSource, gibt diese im out parameter aus (Rückgabe True) oder gibt null zurück wenn keine gefunden wurde (Rückgabe False)
    /// </summary>
    public bool TrygetAudioSource(string name, out AudioSource audio)
    {
        //Sucht das Audio, das im sounds-Array mit "name" definiert wurde
        Sound s = Array.Find(sounds, sound => sound.name == name);
        audio = s.audioSource;
        if (s == null)
        {
            Debug.LogWarning("Der Sound " + name + " wurde nicht gefunden");
            return false;
        }
        return true;
    }
}
