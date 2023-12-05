using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMesh : MonoBehaviour
{
    [HideInInspector]
    public Vector3[] vertices { get; private set; }

   
    public HMatrix2D transformMatrix = new HMatrix2D();
    HMatrix2D toOriginMatrix = new HMatrix2D();
    HMatrix2D fromOriginMatrix = new HMatrix2D();
    HMatrix2D rotateMatrix = new HMatrix2D();

    private MeshManager meshManager;
    HVector2D pos = new HVector2D();
    private object translationMatrix;

    //references
    public void SetIdentity();

    void Start()
    {
        meshManager = GetComponent<MeshManager>();
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y);

    }


    void Translate(float x, float y)
    {
        translationMatrix.SetIdentity();
        translationMatrix.SetTranslationMatr(x, y);
        Transform();

        pos = transformMatrix * pos;
    }

    void Rotate(float angle)
    {
        HMatrix2D toOriginMatrix = new HMatrix2D();
        HMatrix2D fromOriginMatrix = new HMatrix2D();
        HMatrix2D rotateMatrix = new HMatrix2D();

        toOriginMatrix.SetTranslationMatrix(-pos.X, -pos.Y);
        fromOriginMatrix.SetTranslationMat(pos.X, pos.Y);

        rotateMatrix.SetRotationMatrix();

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
