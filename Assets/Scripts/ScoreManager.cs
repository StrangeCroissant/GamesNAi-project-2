using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    uint qsize = 1;  // number of messages to keep
    Queue myLogQueue = new Queue();

    void Start()
    {
        //Debug.Log("Started up logging.");
    }

    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        myLogQueue.Enqueue("[" + type + "] : " + logString);
        if (type == LogType.Exception)
            myLogQueue.Enqueue(stackTrace);
        while (myLogQueue.Count > qsize)
            myLogQueue.Dequeue();
    }
    private int borderSize=30;
    public Texture2D BoxBorder;
    void OnGUI()
    {
        
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 20;
        myStyle.richText = true;
        myStyle.border = new RectOffset(borderSize, borderSize, borderSize, borderSize);
        myStyle.normal.background = BoxBorder;


        GUILayout.BeginArea(new Rect(0, 0, 400, Screen.height));
        GUILayout.Label("\n" + string.Join("\n", myLogQueue.ToArray()), myStyle);
        GUILayout.EndArea();
        
        
        
    }
}
