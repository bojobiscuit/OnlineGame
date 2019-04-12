using UnityEngine;

public class Rotater : MonoBehaviour
{
    public float lerpRate = 0.1f;
    public bool local = true;
    public bool flip = false;

    private void Update()
    {
        _targetRotation = Quaternion.LookRotation(_lastDirection);

        if (local)
            transform.localRotation = Quaternion.Lerp(transform.localRotation, _targetRotation, lerpRate * Time.deltaTime);
        else
            transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, lerpRate * Time.deltaTime);
    }

    public void UpdateRotationByDirection(Vector3 direction)
    {
        if (flip)
            direction *= -1;

        if(direction != Vector3.zero)
            _lastDirection = direction;
    }

    private Quaternion _targetRotation;
    private Vector3 _lastDirection = Vector3.back;
}
