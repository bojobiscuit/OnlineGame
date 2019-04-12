//-------------------------------------------------
//                    TNet 3
// Copyright © 2012-2018 Tasharen Entertainment Inc
//-------------------------------------------------

using UnityEngine;
using System.Collections;
using TNet;

public class AutoCreate : MonoBehaviour
{
    /// <summary>
    /// ID of the channel where the prefab should be created. '0' means "last used channel" (not recommended).
    /// </summary>

    public int channelID = 0;
    public string prefabPath;
    public bool persistent = false;

    IEnumerator Start()
    {
        var onlineDetails = FindObjectOfType<OnlineDetails>();
        if (onlineDetails != null)
        {
            if (onlineDetails.IsClient)
            {
                if (channelID < 1)
                    channelID = TNManager.lastChannelID;

                while (TNManager.isJoiningChannel || !TNManager.IsInChannel(channelID))
                    yield return null;

                TNManager.Instantiate(channelID, "CreateAtPosition", prefabPath, persistent, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
        else
        {
            Debug.LogWarning("No online details found");
        }
    }

    [RCC]
    static GameObject CreateAtPosition(GameObject prefab, Vector3 pos, Quaternion rot)
    {
        GameObject go = prefab.Instantiate();

        Transform t = go.transform;
        t.position = pos;
        t.rotation = rot;
        return go;
    }
}
