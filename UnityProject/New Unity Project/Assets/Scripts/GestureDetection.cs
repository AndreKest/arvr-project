using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class GestureDetection : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject RightController;
    public GameObject LeftController;
    public GameObject HeadCamera;
    public GameObject BlackScreenCanvas;
    public GameObject XR_Origin;
    public Transform CaveLocation;
    public GameObject preTeleport;
    public ActionBasedContinuousMoveProvider MovementSystemToDisableInCave;


    [Space]
    public float TriggerDistance;
    public float TriggerTimeInSeconds;

    public UnityEvent TriggerEvent;

    private bool holding = false;
    private bool defending = false;
    private float holdTime = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        var distR = CalculateDistance(HeadCamera, RightController);
        var distL = CalculateDistance(HeadCamera, LeftController);
        if(distL <= TriggerDistance && distR <= TriggerDistance)
        {
            if (!holding)
            {
                holding = true;
                holdTime = 0;
            }
            else
            {
                holdTime += Time.deltaTime;
                if(holdTime > TriggerTimeInSeconds && !defending)
                {

                    DefendPlayer();
                }
            }
        }
        else
        {
            if (defending)
            {
                Debug.Log("Port Back");
                XR_Origin.transform.position = preTeleport.transform.position;
                XR_Origin.transform.rotation = preTeleport.transform.rotation;
                MovementSystemToDisableInCave.enabled = true;
            }
            defending = false;
            holding = false;
            //BlackScreenCanvas.SetActive(false);
        }
    }

    /// <summary>
    /// Berechnet Distanz in World Space zwischen 2 Objekten in Local Space
    /// </summary>
    /// <param name="object1"></param>
    /// <param name="object2"></param>
    /// <returns></returns>
    private float CalculateDistance(GameObject object1, GameObject object2)
    {
        return Vector3.Distance(object1.transform.TransformPoint(0, 0, 0), object2.transform.TransformPoint(0, 0, 0));
    }
     
    ///// <summary>
    ///// Triggert die "Einigeln" Mechanik
    ///// </summary>
    ///// <param name="holdtime">Zeit die der Spieler die Position  zum einigel halten muss</param>
    ///// <param name="distR">Distanz des rechten Controllers zum Headset</param>
    ///// <param name="distL">Distanz des linken Controllers zum Headset</param>
    ///// <returns></returns>
    //public IEnumerator DefendPlayer(float holdtime, float distR, float distL)
    //{
    //    yield return new WaitForSeconds(holdtime);
    //    if (distL <= TriggerDistance && distR <= TriggerDistance)
    //    {
    //        TriggerEvent.Invoke();
    //        BlackScreenCanvas.SetActive(true);
    //    }
    //    timerTriggerd = false;
    //}

    /// <summary>
    /// Triggert die "Einigeln" Mechanik
    /// </summary>
    /// <param name="holdtime">Zeit die der Spieler die Position  zum einigel halten muss</param>
    /// <param name="distR">Distanz des rechten Controllers zum Headset</param>
    /// <param name="distL">Distanz des linken Controllers zum Headset</param>
    /// <returns></returns>
    public void DefendPlayer()
    {
        defending = true;
        TriggerEvent.Invoke();
        //BlackScreenCanvas.SetActive(true);

        preTeleport.transform.position = XR_Origin.transform.position;
        preTeleport.transform.rotation = XR_Origin.transform.rotation;
        XR_Origin.transform.position = CaveLocation.position;
        XR_Origin.transform.rotation = CaveLocation.rotation;
        MovementSystemToDisableInCave.enabled = false;
        holding = false;
    }
}
