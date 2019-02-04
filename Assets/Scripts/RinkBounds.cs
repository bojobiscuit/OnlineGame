using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RinkBounds : MonoBehaviour
{
    public int xRange = 10;
    public int zRange = 5;

    public virtual Vector3? CollisionNormal(Vector3 position, float radius)
    {
        Vector3 normal = Vector3.zero;

        if (Mathf.Abs(position.x) + radius > xRange)
            normal.x = -Mathf.Sign(position.x);

        if (Mathf.Abs(position.z) + radius > zRange)
            normal.z = -Mathf.Sign(position.z);

        if (normal == Vector3.zero)
            return null;

        return normal.normalized;
    }
}

public class CollisionPoint
{
    public Vector3 normal;
    public Vector3 point;
}