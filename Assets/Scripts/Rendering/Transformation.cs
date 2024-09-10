using UnityEngine;
using System.Collections.Generic;

public abstract class Transformation: MonoBehaviour
{
    public abstract Matrix4x4 Matrix { get; }

    Matrix4x4 transformation;
    public Vector3 Apply(Vector3 point)
    {
        return Matrix.MultiplyPoint(point);
    }
}