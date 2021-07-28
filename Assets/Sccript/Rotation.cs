using UnityEngine;
using Random = UnityEngine.Random;


public class Rotation : MonoBehaviour
{
    private float speedRotation;
    private Vector3[] oldVerts;
    private Vector3[] newVerts;
    
    private void Awake()
    {
        
        oldVerts = gameObject.GetComponent<MeshFilter>().mesh.vertices;
        newVerts = new Vector3[oldVerts.Length];
    }

    private void Start()
    {
        speedRotation = Random.Range(0.1f, 5f);
    }

    private void Update()
    {
        oldVerts = gameObject.GetComponent<MeshFilter>().mesh.vertices;

        Quat quatRot = Quaternion.QuatCalc(new Vector3(10, 1, 1), speedRotation);
        Mat4x4 matRot = Quaternion.QuatToMat4x4(quatRot);
        int i = 0;

        while (i < oldVerts.Length)
        {
            newVerts[i] = Mat4x4.MatMultByRot(matRot,oldVerts[i]);
            i++;
        }

        gameObject.GetComponent<MeshFilter>().mesh.vertices = newVerts;
    }
}
