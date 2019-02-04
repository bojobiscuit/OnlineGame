using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TNet;
using UnityEngine.SceneManagement;

public class CheckIfConnected : MonoBehaviour
{
    void Start()
    {
        if(TNManager.isConnected)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            SceneManager.LoadScene("AutoJoin");
        }
    }
}
