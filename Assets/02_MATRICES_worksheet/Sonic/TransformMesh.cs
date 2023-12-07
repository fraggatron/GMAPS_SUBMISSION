using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TransformMesh : MonoBehaviour
{
    [HideInInspector]
    public Vector3[] vertices { get; private set; }

    public HMatrix2D transformMatrix = new HMatrix2D();
    HMatrix2D toOriginMatrix = new HMatrix2D();
    HMatrix2D fromOriginMatrix = new HMatrix2D();
    HMatrix2D rotateMatrix = new HMatrix2D();

    private MeshManager meshManager;
    HMatrix2D translationMatrix = new HMatrix2D();
    HVector2D pos = new HVector2D();

    void Start()
    {
        meshManager = GetComponent<MeshManager>();
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y);
    }

    void Translate(float x, float y)
    {
        translationMatrix.SetIdentity();
        translationMatrix.SetTranslationMat(x, y);
        Transform();

        HVector2D newPos = transformMatrix * pos;
        pos.X = newPos.X;
        pos.Y = newPos.Y;
    }

    void Rotate(float angle)
    {
        toOriginMatrix.SetTranslationMat(-pos.X, -pos.Y);
        fromOriginMatrix.SetTranslationMat(pos.X, pos.Y);

        rotateMatrix.SetIdentity();
        rotateMatrix.SetRotationMat(angle);

        transformMatrix.SetIdentity();
        transformMatrix = fromOriginMatrix * rotateMatrix * toOriginMatrix;

        Transform();
    }

    private void Transform()
    {
        vertices = meshManager.clonedMesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            HVector2D vert = new HVector2D(vertices[i].x, vertices[i].y);
            vert = transformMatrix * vert;

            vertices[i].x = vert.X;
            vertices[i].y = vert.Y;
        }

        meshManager.clonedMesh.vertices = vertices;
    }
}
