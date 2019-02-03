using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TNet;

public class Player : TNBehaviour
{
    public float speed = 1f;
    public float friction = 5f;
    public Vector3 netPosition;
    public Vector3 netInput;

    public GameObject indicator;
    public GameObject body;

    private void Start()
    {
        if (tno.isMine)
        {
            var meshRenderer = body.GetComponent<MeshRenderer>();
            meshRenderer.material.color = Color.cyan;
        }
        else
        {
            indicator.SetActive(false);
        }
    }

    void Update()
    {
        if (tno.isMine)
            MovePosition();
        else
            MovePositionRemote();
    }

    private void MovePositionRemote()
    {
        _velocity += GetVelocity(netInput);
        transform.position += _velocity;
        transform.position = Vector3.Lerp(transform.position, netPosition, Time.deltaTime);

        if (Vector3.Distance(transform.position, netPosition) > 2)
            transform.position = Vector3.Lerp(transform.position, netPosition, 0.5f);
    }

    private void MovePosition()
    {
        Vector3 input = GetInputDirection();
        _velocity += GetVelocity(input);
        transform.position += _velocity;

        netInput = input;
        netPosition = transform.position;
    }

    private Vector3 GetVelocity(Vector3 input)
    {
        return GetVelocity(input, Time.deltaTime);
    }
    private Vector3 GetVelocity(Vector3 input, float deltaTime)
    {
        return (input * speed * deltaTime) - (_velocity * friction * deltaTime);
    }

    private static Vector3 GetInputDirection()
    {
        Vector3 input = Vector3.zero;
        input.x = Input.GetAxis(inHorizontal);
        input.z = Input.GetAxis(inVertical);
        return input.normalized;
    }

    private Vector3 _velocity = Vector3.zero;

    private static readonly string inHorizontal = "Horizontal";
    private static readonly string inVertical = "Vertical";
}
