using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvCamera : MonoBehaviour
{
    public Transform target;
    public float speed = 1;

    void Update()
    {
        Vector3 pos = !target ? Vector3.zero : target.position;
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * speed);
    }
}
