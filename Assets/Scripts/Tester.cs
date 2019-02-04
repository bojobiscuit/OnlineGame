using System.Collections;
using System.Collections.Generic;
using TNet;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public Player player;
    public Moveable ball;
    public float speed;
    public GameObject ballPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!ball)
            {
                var moves = FindObjectsOfType<Moveable>();
                foreach(var move in moves)
                {
                    if (move.name == "Ball")
                        ball = move;
                }
            }

            if (ball)
                ball.SetVelocity(Vector3.forward * speed);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (ball)
                return;

            if (TNManager.isConnected && !TNManager.IsInChannel(TNManager.lastChannelID))
                return;

            CreateBall();
        }
    }


    void CreateBall()
    {
        Debug.Log(TNManager.lastChannelID);
        TNManager.Instantiate(TNManager.lastChannelID, "CreateBall", "Ball", false, Vector3.zero);
    }

    [RCC]
    static GameObject CreateBall(GameObject prefab, Vector3 pos)
    {
        GameObject go = prefab.Instantiate();
        go.transform.position = pos;
        return go;
    }
}
