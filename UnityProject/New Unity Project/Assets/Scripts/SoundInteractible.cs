using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class SoundInteractible : MonoBehaviour
{
    //Text der angezeigt werden soll
    public string Text;

    //Soundeffeekt der abgespielt werden soll
    public AudioSource audioSource;

    /// <summary>
    /// Textbox die angezeigt werden soll
    /// </summary>
    public GameObject Textbox;

    /// <summary>
    /// Y Offest für die Textbox, damit diese nicht im Boden spawnt
    /// </summary>
    public float TextboxYOffset;

    /// <summary>
    /// Mesh Renderer des Objekts das verborgen werden soll
    /// </summary>
    private MeshRenderer renderer;

    /// <summary>
    /// Event für das Nehemn des Onjekts
    /// </summary>
    public UnityEvent ObjektGrabbed;

    /// <summary>
    /// Wenn es sich um ein Objekt in einer Station handelt, kann angegeben werden, dass es sich um eine Station handelt.
    ///  dann wird das Objekt nach der Textbox nicht mehr angezeigt, wenn dei Station als completet markiert wurde.
    /// </summary>
    public Station Station;

    private bool active;


    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Diese Methode soll ausgeführt werden wenn der Spieler mit dem Objekt interagiert.
    /// </summary>
    public void GrabSelection()
    {
        if (active)
            return;
        active = true;

        if (renderer.enabled)
        {
            renderer.enabled = false;
        }

        var spawnposition = transform.position;
        spawnposition.y += TextboxYOffset;

        var tbox = Instantiate(Textbox, spawnposition, transform.rotation);
        TMPro.TextMeshPro UiText = tbox.transform.GetChild(0).transform.GetChild(0).GetComponent<TMPro.TextMeshPro>();
        UiText.text = Text;
        audioSource.Play();
        if(ObjektGrabbed != null)
        {
            ObjektGrabbed.Invoke();
        }
        StartCoroutine(ResetInteractible(audioSource.clip.length, tbox, renderer));

    }

    /// <summary>
    /// Stellt den ursprungszustand des Objekts wieder her
    /// </summary>
    /// <param name="lenght">zeit nach der zurückgesetzt werden soll</param>
    /// <param name="objectToDestroy">objekt das ausgeblendet wird</param>
    /// <param name="objectToEnable">objekt das wieder eingeblendet wird</param>
    /// <returns></returns>
    public IEnumerator ResetInteractible(float lenght, GameObject objectToDestroy, MeshRenderer objectToEnable)
    {
        yield return new WaitForSeconds(lenght);
        //objectToDisable.SetActive(false);
        Destroy(objectToDestroy);
        if (Station != null)
        {
            if (!Station.Completed)
            {
                objectToEnable.enabled = true;
            }
        }
        else
        {
            objectToEnable.enabled = true;
        }
        active = false;
    }
}
