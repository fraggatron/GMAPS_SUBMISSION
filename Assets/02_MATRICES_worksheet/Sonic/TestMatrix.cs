using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestMatrix : MonoBehaviour
{
    private HMatrix2D mat = new HMatrix2D();

    void Start()
    {
        mat.setIdentity();
        mat.Print();
    }

    private void Question2()
    {
        // Hardcode 3x3 matrices
        HMatrix2D mat1 = new HMatrix2D
        (
            1, 2, 3,
            4, 5, 6,
            7, 8, 9
        );

        HMatrix2D mat2 = new HMatrix2D
        (
            9, 8, 7,
            6, 5, 4,
            3, 2, 1
        );

        HMatrix2D resultMat;

        // Hardcode 3x1 vector
        HMatrix2D.HVector2D vec1 = new HMatrix2D.HVector2D(2, 3);

        // Perform 3x3 * 3x3 matrix multiplication
        resultMat = mat1 * mat2;

        // Print the result
        Console.WriteLine("Matrix Multiplication Result:");
        Console.WriteLine(resultMat);

        // Perform 3x3 * 3x1 matrix multiplication
        HMatrix2D.HVector2D resultVec = mat1 * vec1;

        // Print the result
        Console.WriteLine("Vector Multiplication Result:");
        Console.WriteLine($"X: {resultVec.X}, Y: {resultVec.Y}");
    }
}

