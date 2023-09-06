using UnityEngine;

public class BouncingLeaf : MonoBehaviour
{
    /// <summary>
    /// Ob eine Station bestanden wurde.
    /// </summary>
    public bool cleared = false;
    private bool music = true;
    /// <summary>
    /// Geschwindigkeit des Hüpfenden Blattes.
    /// </summary>
    public float bouncingSpeed = 1.5f;
    /// <summary>
    /// Die Höhe die gehüpft wird.
    /// </summary>
    public float bouncingHeight = 0.5f;
    /// <summary>
    /// Die End Höhe des Blattes, wenn eine Station bestanden ist.
    /// </summary>
    public float endY = 1f;
    /// <summary>
    /// Die Start Höhe des Blattes, wenn eine Station bestanden ist.
    /// </summary>
    public float startY = 10.25f;
    
    void Update()
    {
        //Station bestanden
        if (cleared)
        {
            //Funktion wird nur einmal aufgerufen, damit der Sound beim bestehen der Station abgespielt wird.
            if (music == true)
            {
                FindObjectOfType<AudioManager>().PlaySound("stageCleared");
                music = false;
            }

            //Position des Blattes bleibt bestehen
            if (transform.position.y <= endY)
            {
                //Rotation
                transform.Rotate(0f, 20 * Time.deltaTime, 0f, Space.Self);
                //Stoppt die Animation
                Vector3 newPosition = new Vector3(transform.position.x, endY, transform.position.z);
                transform.position = newPosition;
            }

            //Blatt bewegt sich nach unten zum Spieler
            else
            {
                //Down
                transform.Translate(Vector3.down * 2 * Time.deltaTime, Space.World);
                //Rotation
                transform.Rotate(0f, 20 * Time.deltaTime, 0f, Space.Self);
            }
        }
        //Station nicht bestanden
        else
        {
            //Rotation
            transform.Rotate(0f, 20 * Time.deltaTime, 0f, Space.Self);

            //Bouncing
            var pos = transform.position;
            var newY = startY + bouncingHeight * Mathf.Sin(Time.time * bouncingSpeed);
            transform.position = new Vector3(pos.x, newY, pos.z);
        }
    }

    /// <summary>
    /// Setzt die Station auf bestanden.
    /// </summary>
    public void Drop()
    {
        cleared = true;
    }
}
