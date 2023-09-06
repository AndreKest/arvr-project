using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFromPlayer : MonoBehaviour
{
    /// <summary>
    /// Referenzobjekt zu dem Rotiert wird
    /// </summary>
    public GameObject player;

    /// <summary>
    /// Geschwindigkeit mit der das Objekt rotiert werden soll
    /// </summary>
    public int TurnSpeed;

    /// <summary>
    /// Gibt an ob zu dem objekt hin oder von dem objekt weg rotiert werden soll
    /// </summary>
    public bool away;

    // Start is called before the first frame update
    void Start()
    {
        if(player == null)
        {
            player = GameObject.Find("Main Camera");
        }
    }

    // Update is called once per frame
    void Update()
    {
        RotateAwayFrom(player.transform.position);
    }

    /// <summary>
    /// Rotiert das Objekt entsprechend zu einer Position
    /// </summary>
    /// <param name="position">Position zu/von der Rotiert werden soll</param>
    private void RotateAwayFrom(Vector3 position)
    {
        Vector3 facing = transform.position - position;
        //if (facing.magnitude < RotationMargin) { return; }

        // Rotate the rotation AWAY from the player...
        Quaternion awayRotation = Quaternion.LookRotation(facing);
        Vector3 euler = awayRotation.eulerAngles;
        if (!away)
        {
            euler.y -= 180;
        }
        awayRotation = Quaternion.Euler(euler);

        // Rotate the game object.
        transform.rotation = Quaternion.Slerp(transform.rotation, awayRotation, TurnSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }
}
