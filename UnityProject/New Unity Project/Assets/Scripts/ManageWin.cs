using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageWin : Station
{
    bool b_FlagWin;

    // Start is called before the first frame update
    void Start()
    {
        b_FlagWin = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if player is in Tutorial Station and all leaves are collected
        if(checkArea(PlayerBody.transform.position) & b_FlagWin)
        {
            Debug.Log("Win and change scene!");
            // Change scene
            SceneManager.LoadScene("Credits");
        }


    }

    // WinEvent GameEventManager set WinFlag
    public void Set_WinFlag()
    {
        Debug.Log("WinFlag gesetzt!");
        b_FlagWin = true;
    }
}
