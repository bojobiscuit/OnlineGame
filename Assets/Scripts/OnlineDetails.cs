using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineDetails : MonoBehaviour
{
    public bool IsClient = true;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    //private void OnGUI()
    //{
    //    GUI.Label(new Rect(20, 20, 200, 50), "Is Client: " + IsClient.ToString());
    //}
}
