using System;
using TreeEditor;
using UnityEngine;
using Random = UnityEngine.Random;


public class Quaternionrotation : MonoBehaviour
{
    private float speedRotation;
    private Vector3[] origVerts;
    private Vector3[] newVerts;
    
    

    void Awake()
    {
        
        origVerts = gameObject.GetComponent<MeshFilter>().mesh.vertices;
        newVerts = new Vector3[origVerts.Length];
    }

    private void Start()
    {
        speedRotation = Random.Range(0.1f, 5f);
    }

    void Update()
    {
        origVerts = gameObject.GetComponent<MeshFilter>().mesh.vertices;

        Quat quatRot = Quaternion.QuatCalc(new Vector3(10, 1, 1), speedRotation);
        Mat4x4 matRot = Quaternion.QuatToMat4x4(quatRot);
        int i = 0;

        while (i < origVerts.Length)
        {
            newVerts[i] = Mat4x4.MatMultByRot(matRot,origVerts[i]);
            i++;
        }

        gameObject.GetComponent<MeshFilter>().mesh.vertices = newVerts;
    }
}
