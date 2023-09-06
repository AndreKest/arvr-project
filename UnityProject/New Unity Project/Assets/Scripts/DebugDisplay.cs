using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugDisplay : MonoBehaviour
{
    Dictionary<string, string> debugLogs = new Dictionary<string, string>();
    public Text display;
    public bool TrackVariables;



    private void OnEnable()
    {
        if (TrackVariables)
        {
            Application.logMessageReceived += HandleLogTrack;
        }
        else
        {
            Application.logMessageReceived += HandleLog;
        }
    }

    private void OnDisable()
    {
        if (TrackVariables)
        {
            Application.logMessageReceived -= HandleLogTrack;
        }
        else
        {
            Application.logMessageReceived -= HandleLog;
        }
    }

    private void HandleLogTrack(string condition, string stackTrace, LogType type)
    {
        if(type == LogType.Log)
        {
            string[] split = condition.Split(char.Parse(":"));
            string key = split[0];
            string val = split.Length > 1 ? split[0] : "";
            if (debugLogs.ContainsKey(key))
            {
                debugLogs[key] = val;
            }
            else
            {
                debugLogs.Add(key, val);
            }

            string tx = "";
            foreach(KeyValuePair<string,string> log in debugLogs)
            {
                if (log.Value == "")
                {
                    tx += log.Key + "\n";
                }
                else
                {
                    tx += log.Key + ": " + log.Value + "\n";
                }
                display.text = tx;
            }
        }
    }

    private void HandleLog(string condition, string stackTrace, LogType type)
    {
        if(type == LogType.Log)
        {
            display.text += condition + "\n";
        }
    }
}
