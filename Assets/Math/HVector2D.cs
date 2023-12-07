using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//[Serializable]
public class HVector2D
{
    public float x, y;
    public float h;

    public float X { get; internal set; }
    public float Y { get; internal set; }

    public HVector2D(float _x, float _y)
    {
        x = _x;
        y = _y;
        h = 1.0f;
    }

    public HVector2D(Vector2 _vec)
    {
        x = _vec.x;
        y = _vec.y;
        h = 1.0f;
    }

    public HVector2D()
    {
        x = 0;
        y = 0;
        h = 1.0f;
    }

    public static HVector2D operator +(HVector2D a, HVector2D b)
    {
        return new HVector2D(a.x + b.x, a.y + b.y);
    }

    public static HVector2D operator -(HVector2D a, HVector2D b)
    {
        return new HVector2D(a.x = b.x, a.y = b.y);
    }

    public static HVector2D operator *(HVector2D a,float scalar)
    {
        return new HVector2D(a.x * scalar, a.y * scalar);
    }

    public static HVector2D operator /(HVector2D a, float scalar)
    {
        return new HVector2D(a.x / scalar, a.y / scalar);
    }

    public static HVector2D operator *(HMatrix2D matrix, HVector2D vector)
    {
        return new HVector2D
        (
            matrix.Entries[0, 0] * vector.x + matrix.Entries[0, 1] * vector.y + matrix.Entries[0, 2],
            matrix.Entries[1, 0] * vector.x + matrix.Entries[1, 1] * vector.y + matrix.Entries[1, 2]
        );
    }

    public float Magnitude()
    {
        return (float)Math.Sqrt(x * x + y * y);
    }

    public void Normalize()
    {
        float mag = Magnitude();
        x /= mag;
        y /= mag;
    }

    public float DotProduct(HVector2D vec)
    {
        return (x * vec.x + y * vec.y);
    }

   // public HVector2D Projection()
    //{

    //}

    public float FindAngle(HVector2D vec)
    {
        return (float)Mathf.Acos(DotProduct(vec) / (Magnitude() * vec.Magnitude()));
    }

    public Vector2 ToUnityVector2()
    {
        return Vector2.zero; 
    }

    public Vector3 ToUnityVector3()
    {
        return Vector2.zero;
    }

    // public void Print()
    // {

    // }
}
