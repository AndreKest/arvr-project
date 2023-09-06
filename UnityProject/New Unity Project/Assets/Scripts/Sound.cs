using UnityEngine;

//Damit sind die public Werte im Unity Projekt sichtbar
[System.Serializable]
/// <summary>
/// Eigenschaften einer Audio.
/// </summary>
public class Sound 
{
    public string name;
    public AudioClip audioClip;
    public bool loop;

    //Slider
    [Range(0f, 1f)]
    public float volume;

    //wird im AudioManager erstellt
    [HideInInspector]
    public AudioSource audioSource;
}
