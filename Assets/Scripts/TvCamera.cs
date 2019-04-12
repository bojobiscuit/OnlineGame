using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvCamera : MonoBehaviour
{
    public Transform target;
    public float speedX = 3;
    public float speedZ = 1;
    public Vector2 clampX = new Vector2(-15, 15);
    public Vector2 clampZ = new Vector2(-2, 2);

    void Update()
    {
        _targetPosition = !target ? Vector3.zero : target.position;
        _targetPosition.x = Mathf.Clamp(_targetPosition.x, clampX.x, clampX.y);
        _targetPosition.z = Mathf.Clamp(_targetPosition.z, clampZ.x, clampZ.y);

        _currentPosition.x = Mathf.Lerp(transform.position.x, _targetPosition.x, Time.deltaTime * speedX);
        _currentPosition.z = Mathf.Lerp(transform.position.z, _targetPosition.z, Time.deltaTime * speedZ);
        transform.position = _currentPosition;
    }

    private Vector3 _targetPosition;
    private Vector3 _currentPosition;
}
