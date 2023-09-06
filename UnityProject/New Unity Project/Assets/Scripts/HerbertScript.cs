using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HerbertScript : MonoBehaviour
{
    // Start is called before the first frame update

    private AnimatorControl_Herbert controller;
    public Transform PositionComplete;
    public Station Station;
    public float Holdtime;
    private bool helping;
    private float helpingTime = 0;
    private AudioManager manager;
    private AudioSource pain1;
    private AudioSource pain2;
    private bool pain1found;
    private bool pain2found;

    public string soundNamePain1;
    public string soundNamePain2;
    [HideInInspector]
    public bool playPains = true;
    [HideInInspector]
    public bool playFirstPain = true;
    [HideInInspector]
    public bool playSecondPain = true;



    void Start()
    {
        controller = GetComponent<AnimatorControl_Herbert>();
        controller.SendMessage("Animation_festgehangen");

        manager = FindObjectOfType<AudioManager>();

        pain1found = manager.TrygetAudioSource(soundNamePain1, out pain1);
        pain2found = manager.TrygetAudioSource(soundNamePain2, out pain2);

        if((!pain1found || !pain2found) && playPains)
        {
            Debug.LogWarning("Keine Painsounds gefunden obwohl Painsounds aktiviert");
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool helpcon = helpingTime > Holdtime;
        if (helping)
        {
            helpingTime += Time.deltaTime;

            //Spiele zwei unterschiedliche Sounds ab
            if (playPains)
            {
                if (pain1found)
                {
                    if (!pain1.isPlaying && playFirstPain)
                    {
                        pain1.Play();
                        playFirstPain = false;
                    }     
                }
                if (pain2found)
                {
                    if (!pain2.isPlaying && playSecondPain && !pain1.isPlaying)
                    {
                        pain2.Play();
                        playSecondPain = false;
                    }
                }             
                if(pain1found && pain2found)
                    helpcon = (helpingTime > pain1.clip.length + pain2.clip.length && helpingTime > Holdtime);
            }


            if (helpcon)
            {
                HelpComplete();
            }
            //helpingTime += Time.deltaTime;
            //if (helpingTime > Holdtime)
            //{
            //    HelpComplete();
            //}
        }
    }

    private void HelpComplete()
    {
        helping = false;
        gameObject.transform.position = PositionComplete.position;
        gameObject.transform.rotation = PositionComplete.rotation;
        controller.SendMessage("Animation_idle");
        Station.Completed = true;

        //Interactable deaktivieren
        XRGrabInteractable interactable;
        if(TryGetComponent<XRGrabInteractable>(out interactable))
        {
            interactable.enabled = false;
        }
        //Debug.Log("Help Completed!");
    }

    public void AbortHelp()
    {
        if (pain2found)
        {
            if (!pain1.isPlaying && playFirstPain)
            {
                pain1.Stop();
                playFirstPain = false;
            }
        }
        if (pain2found)
        {
            if (!pain2.isPlaying && playSecondPain && !pain1.isPlaying)
            {
                pain2.Stop();
                playSecondPain = false;
            }
        }
        controller.SendMessage("Animation_festgehangen");
        helping = false;
        helpingTime = 0;
    }
    public void StartHelp()
    {
        controller.SendMessage("Animation_festgehangen_Hilfe");
        helping = true;
        helpingTime = 0;
    }
    //private IEnumerator Helping(float holdtime)
    //{
    //    var starthold = Time.time;

    //    //yield return new WaitForSeconds(holdtime); ;
    //    yield return null;
    //}
}
