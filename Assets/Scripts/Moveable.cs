using System.Collections;
using System.Collections.Generic;
using TNet;
using UnityEngine;

public class Moveable : TNBehaviour
{
    public float speed = 1f;
    public float friction = 5f;
    public float radius = 0.5f;
    public Vector3 netPosition;
    public Vector3 netInput;

    protected override void Awake()
    {
        base.Awake();
    }

    void Update()
    {
        if (tno.isMine)
            MovePosition();
        else
            MovePositionRemote();
    }

    protected virtual void UpdateInput()
    {
        // Let Child Classes Handle Input
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
        UpdateInput();
        _velocity += GetVelocity(_input);
        _previousPosition = transform.position;
        transform.position += _velocity;
        StayInBounds();

        netInput = _input;
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

    private void StayInBounds()
    {
        if (Physics.SphereCast(_previousPosition, radius, _velocity.normalized, out RaycastHit hit, _velocity.magnitude))
        {
            _velocity = Vector3.Reflect(_velocity, hit.normal);
            transform.position = hit.point + (hit.normal * (radius + 0.01f));
        }
    }

    protected Vector3 _input = Vector3.zero;
    protected Vector3 _velocity = Vector3.zero;
    private Vector3 _previousPosition = Vector3.zero;
}
