using UnityEngine;

public struct Quater
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
    public static float Norme(Vector3 u)
    { 
        float result;
        result = u.x * u.x + u.y * u.y + u.z * u.z;
        return Mathf.Sqrt(result);
    }
    
    public static Mat4x4 QuatToMat4x4(Quater quat1)
    {
        float w = quat1.dir.w;
        float x = quat1.dir.x;
        float y = quat1.dir.y;
        float z = quat1.dir.z;

        Mat4x4 matrice = new Mat4x4();

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

        return matrice;
    }
    
    public static Quater QuatCalc(Vector3 u,float theta)
    {
        float norme;
        Quater quater;
        norme = Norme(u);
        u.x = u.x / norme;
        u.y = u.y / norme;
        u.z = u.z / norme;

        theta = theta * (Mathf.PI / 180);

        quater.dir.w = Mathf.Cos(theta / 2);
        quater.dir.x = u.x *Mathf.Sin(theta / 2);
        quater.dir.y = u.y * Mathf.Sin(theta / 2);
        quater.dir.z = u.z * Mathf.Sin(theta / 2);

        return quater;
    }

    public static Quater AdditionQuat(Quater quat1, Quater quat2)
    {
        Quater quat3;
        quat3.dir.w = quat1.dir.w + quat2.dir.w;
        quat3.dir.x = quat1.dir.x + quat2.dir.x;
        quat3.dir.y = quat1.dir.y + quat2.dir.y;
        quat3.dir.z = quat1.dir.z + quat2.dir.z;
        return quat3;
    }

    public static Quater ConjQuat(Quater quat1)
    {
        Quater quat2;
        quat2.dir.w = quat1.dir.w;
        quat2.dir.x = -quat1.dir.x;
        quat2.dir.y = -quat1.dir.y;
        quat2.dir.z = -quat1.dir.z;
        return quat2;
    }
    
    public static Quater MultQuat(Quater quat1, Quater quat2)
    {
        Quater quat3;
        // (aa' − bb' − cc' − dd')
        quat3.dir.w = (quat1.dir.w * quat2.dir.w) - (quat1.dir.x * quat2.dir.x) - (quat1.dir.y * quat2.dir.y) - (quat1.dir.z * quat2.dir.z);
        // (ab' + ba' + cd' − dc')
        quat3.dir.x = (quat1.dir.w * quat2.dir.x) + (quat1.dir.x * quat2.dir.w) + (quat1.dir.y * quat2.dir.z) - (quat1.dir.z * quat2.dir.y);
        // (ac' − bd' + ca' + db')
        quat3.dir.y = (quat1.dir.w * quat2.dir.y) - (quat1.dir.x * quat2.dir.z) + (quat1.dir.y * quat2.dir.w) + (quat1.dir.z * quat2.dir.x);
        // (ad' + bc' − cb' + da')
        quat3.dir.z = (quat1.dir.w * quat2.dir.z) + (quat1.dir.x * quat2.dir.y) - (quat1.dir.y * quat2.dir.x) + (quat1.dir.z * quat2.dir.w);
        return quat3;
    }

    public static float ScalQuat(Quater quat1, Quater quat2)
    {
        return quat1.dir.w * quat2.dir.w + quat1.dir.x * quat2.dir.x + (quat1.dir.y * quat2.dir.y) + (quat1.dir.z * quat2.dir.z);
    }
}
