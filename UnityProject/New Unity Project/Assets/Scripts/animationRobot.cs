using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationRobot : MonoBehaviour
{
    private Animation anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        anim.Play("radDrehen");
    }



}
