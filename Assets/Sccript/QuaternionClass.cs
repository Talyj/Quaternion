using UnityEngine;

public struct Quat
{
    public Vector4 dir;
}
    
public struct Mat4x4
{
    public float m00,m01,m02,m03,m10,m11,m12,m13,m20,m21,m22,m23,m30,m31,m32,m33;
    
    public static Vector3 MatMultByRot(Mat4x4 matriceRotation, Vector3 point)
    {
        Vector3 vector3;
        vector3.x = (float) ((double) matriceRotation.m00 * (double) point.x + (double) matriceRotation.m01 * (double) point.y + (double) matriceRotation.m02 * (double) point.z) + matriceRotation.m03;
        vector3.y = (float) ((double) matriceRotation.m10 * (double) point.x + (double) matriceRotation.m11 * (double) point.y + (double) matriceRotation.m12 * (double) point.z) + matriceRotation.m13;
        vector3.z = (float) ((double) matriceRotation.m20 * (double) point.x + (double) matriceRotation.m21 * (double) point.y + (double) matriceRotation.m22 * (double) point.z) + matriceRotation.m23;
        return vector3;
    }
}

public static class Quaternion
{
    // creation de quaternion q= (w,[x,y,z])

    public static Quat AdditionQuat(Quat quatA, Quat quatB)
    {
        Quat quatC;
        quatC.dir.w = quatA.dir.w + quatB.dir.w;
        quatC.dir.x = quatA.dir.x + quatB.dir.x;
        quatC.dir.y = quatA.dir.y + quatB.dir.y;
        quatC.dir.z = quatA.dir.z + quatB.dir.z;
        return quatC;
    }

    // Conjugué du quaternion passé en paramètre 
    public static Quat ConjQuat(Quat quatA)
    {
        Quat quatB;
        quatB.dir.w = quatA.dir.w;
        quatB.dir.x = -quatA.dir.x;
        quatB.dir.y = -quatA.dir.y;
        quatB.dir.z = -quatA.dir.z;
        return quatB;
    }
    
    public static Quat MultQuat(Quat quatA, Quat quatB)
    {
        Quat quatC;
        // (aa' − bb' − cc' − dd')
        quatC.dir.w = (quatA.dir.w * quatB.dir.w) - (quatA.dir.x * quatB.dir.x) - (quatA.dir.y * quatB.dir.y) - (quatA.dir.z * quatB.dir.z);
        // (ab' + ba' + cd' − dc')
        quatC.dir.x = (quatA.dir.w * quatB.dir.x) + (quatA.dir.x * quatB.dir.w) + (quatA.dir.y * quatB.dir.z) - (quatA.dir.z * quatB.dir.y);
        // (ac' − bd' + ca' + db')
        quatC.dir.y = (quatA.dir.w * quatB.dir.y) - (quatA.dir.x * quatB.dir.z) + (quatA.dir.y * quatB.dir.w) + (quatA.dir.z * quatB.dir.x);
        // (ad' + bc' − cb' + da')
        quatC.dir.z = (quatA.dir.w * quatB.dir.z) + (quatA.dir.x * quatB.dir.y) - (quatA.dir.y * quatB.dir.x) + (quatA.dir.z * quatB.dir.w);
        return quatC;
    }

    //Calcul de la norme du quaternion passé en parametre 
    public static float Norme(Vector3 u)
    { 
       float result;
       result = u.x * u.x + u.y * u.y + u.z * u.z;
       return Mathf.Sqrt(result);
    }

    public static float ScalQuat(Quat quatA, Quat quatB)
    {
        return quatA.dir.w * quatB.dir.w + quatA.dir.x * quatB.dir.x + (quatA.dir.y * quatB.dir.y) + (quatA.dir.z * quatB.dir.z);
    }

    public static Mat4x4 QuatToMat4x4(Quat quatA)
    {
        float w = quatA.dir.w;
        float x = quatA.dir.x;
        float y = quatA.dir.y;
        float z = quatA.dir.z;

        Mat4x4 matrice = new Mat4x4();
        // positions dans la matrice
        //float p00, p01, p02, p10, p11, p12, p20, p21, p22;

        matrice.m00 = 1 - (2 * (y * y)) + (2 * (z * z));
        matrice.m01 = (2 * (x * y)) - (2 * (z * w));
        matrice.m02 = (2 * (x * z)) + (2 * (y * w));
        matrice.m03 = 0.0f;

        matrice.m10 = (2 * (x * y)) + (2 * (z * w));
        matrice.m11 = 1 - (2 * (x * x)) + (2 * (z * z));
        matrice.m12 = (2 * (y * z)) - (2 * (x * w));
        matrice.m13 = 0.0f;

        matrice.m20 = (2 * (x * z)) - (2 * (y * w));
        matrice.m21 = (2 * (y * z)) + (2 * (x * w));
        matrice.m22 = 1 - (2 * (x * x)) + (2 * (y * y));
        matrice.m23 = 0.0f;

        matrice.m30 = 0.0f;
        matrice.m31 = 0.0f;
        matrice.m32 = 0.0f;
        matrice.m33 = 1.0f;
        
        

        //float[,] matrice = new float[4, 4] { { p00, p01, p02,0.0f }, { p10, p11, p12,0.0f }, { p20, p21, p22, 0.0f },{0.0f, 0.0f, 0.0f, 1.0f} };
        return matrice;
    }

    public static Quat QuatCalc(Vector3 u,float theta)
    {
       float norme;
       Quat q;
       norme = Norme(u);
       u.x = u.x / norme;
       u.y = u.y / norme;
       u.z = u.z / norme;
        

       //u = Vector3.Normalize(u);
       theta = theta * (Mathf.PI / 180);

       q.dir.w = Mathf.Cos(theta / 2);
       q.dir.x = u.x *Mathf.Sin(theta / 2);
       q.dir.y = u.y * Mathf.Sin(theta / 2);
       q.dir.z = u.z * Mathf.Sin(theta / 2);

       return q;
    }
}
