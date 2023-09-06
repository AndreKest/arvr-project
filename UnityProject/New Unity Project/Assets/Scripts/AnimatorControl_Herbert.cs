using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControl_Herbert : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void Animation_festgehangen() {
        if (anim != null) {
            anim.Play("Armature|festgehangen");
        }
    }

    public void Animation_festgehangen_Hilfe() {
        if (anim != null) {
            anim.Play("Armature|festgehangen_mit_hilfe");
        }
    }

    public void Animation_idle() {
        if (anim != null) {
            anim.Play("Armature|idle");
        }
    }

    public void Animation_Default() {
        if (anim != null) {
            anim.Play("Default");
        }
    }
}

