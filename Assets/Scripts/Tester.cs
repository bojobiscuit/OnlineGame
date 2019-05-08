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
            FindPuck();

            if (ball)
                ball.SetVelocity(Vector3.forward * speed);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            FindPuck();

            if (ball)
                return;

            if (TNManager.isConnected && !TNManager.IsInChannel(TNManager.lastChannelID))
                return;

            CreateBall();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (!player)
                return;

            if (TNManager.isConnected && !TNManager.IsInChannel(TNManager.lastChannelID))
                return;

            player.ChangeJerseyColorRandom();
        }
    }

    private void FindPuck()
    {
        if (!ball)
        {
            var moves = FindObjectsOfType<Moveable>();
            foreach (var move in moves)
            {
                if (move.name == "Puck")
                    ball = move;
            }
        }
    }

    void CreateBall()
    {
        Debug.Log(TNManager.lastChannelID);
        TNManager.Instantiate(TNManager.lastChannelID, "CreatePuck", "Puck", true, Vector3.zero);
    }

    [RCC]
    static GameObject CreatePuck(GameObject prefab, Vector3 pos)
    {
        GameObject go = prefab.Instantiate();
        go.transform.position = pos;
        return go;
    }
}
