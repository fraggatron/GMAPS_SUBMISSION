using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HMatrix2D
{
    public float[,] Entries { get; set; } = new float[3, 3];

    public void SetIdentity()
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                for (int z = 0; z < 3; z++)
                {
                    if (x == z)
                    {
                        Entries[y, x] = 1;
                    }
                    else
                    {
                        Entries[y, x] = 0;
                    }
                }
            }
        }
    }

    // SIMPLIFIED SetIdentity()

    // public void SetIdentity()
    //{
    //  for (int y = 0; y< 3; y++)
    //{
    //  for (int x = 0; x< 3; x++)
    //{
    //  Entries[y, x] = (x == y) ? 1 : 0;
    //}
    //}
    //}

    public HMatrix2D(float[,] multiArray)
    {
        Entries = new float[3, 3];

        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                Entries[y, x] = multiArray[y, x];
            }
        }
    }

    public HMatrix2D(float m00, float m01, float m02,
                 float m10, float m11, float m12,
                 float m20, float m21, float m22)
    {
        Entries = new float[3, 3];

        Entries[0, 0] = m00;
        Entries[0, 1] = m01;
        Entries[0, 2] = m02;

        Entries[1, 0] = m10;
        Entries[1, 1] = m11;
        Entries[1, 2] = m12;

        Entries[2, 0] = m20;
        Entries[2, 1] = m21;
        Entries[2, 2] = m22;
    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D();

        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                result.Entries[y, x] = left.Entries[y, x] + right.Entries[y, x];
            }
        }

        return result;
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D();

        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                result.Entries[y, x] = left.Entries[y, x] - right.Entries[y, x];
            }
        }

        return result;
    }

    public static HMatrix2D operator *(HMatrix2D matrix, float scalar)
    {
        HMatrix2D result = new HMatrix2D();

        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                result.Entries[y, x] = matrix.Entries[y, x] * scalar;
            }
        }

        return result;
    }

 
   
    public class HVector2D
    {
        private float resultX;
        private float resultY;

        public HVector2D(float resultX, float resultY)
        {
            this.resultX = resultX;
            this.resultY = resultY;
        }

        public float X { get; set; }
        public float Y { get; set; }

     
    }

    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        return new HVector2D
        (
            left.Entries[0, 0] * right.X + left.Entries[0, 1] * right.Y + left.Entries[0, 2] * 1.0f,
            left.Entries[1, 0] * right.X + left.Entries[1, 1] * right.Y + left.Entries[1, 2] * 1.0f
        );
    }


    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D
        (
            left.Entries[0, 0] * right.Entries[0, 0] + left.Entries[0, 1] * right.Entries[1, 0] + left.Entries[0, 2] * right.Entries[2, 0],
            left.Entries[0, 0] * right.Entries[0, 1] + left.Entries[0, 1] * right.Entries[1, 1] + left.Entries[0, 2] * right.Entries[2, 1],
            left.Entries[0, 0] * right.Entries[0, 2] + left.Entries[0, 1] * right.Entries[1, 2] + left.Entries[0, 2] * right.Entries[2, 2],

            left.Entries[1, 0] * right.Entries[0, 0] + left.Entries[1, 1] * right.Entries[1, 0] + left.Entries[1, 2] * right.Entries[2, 0],
            left.Entries[1, 0] * right.Entries[0, 1] + left.Entries[1, 1] * right.Entries[1, 1] + left.Entries[1, 2] * right.Entries[2, 1],
            left.Entries[1, 0] * right.Entries[0, 2] + left.Entries[1, 1] * right.Entries[1, 2] + left.Entries[1, 2] * right.Entries[2, 2],

            left.Entries[2, 0] * right.Entries[0, 0] + left.Entries[2, 1] * right.Entries[1, 0] + left.Entries[2, 2] * right.Entries[2, 0],
            left.Entries[2, 0] * right.Entries[0, 1] + left.Entries[2, 1] * right.Entries[1, 1] + left.Entries[2, 2] * right.Entries[2, 1],
            left.Entries[2, 0] * right.Entries[0, 2] + left.Entries[2, 1] * right.Entries[1, 2] + left.Entries[2, 2] * right.Entries[2, 2]
        );
    }

    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                if (left.Entries[y, x] != right.Entries[y, x])
                {
                    return false;
                }
            }
        }

        return true;
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                if (left.Entries[y, x] != right.Entries[y, x])
                {
                    return true;
                }
            }
        }

        return false;
    }

    public HMatrix2D Transpose()
    {
        // Implement matrix transposition
    }

    public float GetDeterminant()
    {
        // Implement determinant calculation
    }

    public void SetTranslationMat(float transX, float transY)
    {
        SetIdentity();

        Entries[0, 2] = transX;
        Entries[1, 2] = transY;
    }

    public void SetRotationMat(float rotDeg)
    {
        SetIdentity();
        float rad = MathF.PI * rotDeg / 180.0f; // Convert degrees to radians
        Entries[0, 0] = MathF.Cos(rad);
        Entries[0, 1] = -MathF.Sin(rad);
        Entries[1, 0] = MathF.Sin(rad);
        Entries[1, 1] = MathF.Cos(rad);
    }

    public void SetScalingMat(float scaleX, float scaleY)
    {
        // Implement scaling matrix creation
    }

    public void Print()
    {
        string result = "";
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                result += entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}
