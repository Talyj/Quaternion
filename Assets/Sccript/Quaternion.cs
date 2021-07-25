using System;
using UnityEngine;

namespace Bob.Project
{
        public class QuaternionProject : Component
        {
        public float X;
        public float Y;
        public float Z;
        public float W;

        public QuaternionProject(float x, float y, float z, float w)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }  

        // Addition 
        public static QuaternionProject operator +(QuaternionProject value1, QuaternionProject value2) {
            QuaternionProject result = new QuaternionProject(0, 0, 0, 0);
            result.X = value1.X + value2.X;
            result.Y = value1.Y + value2.Y;
            result.Z = value1.Z + value2.Z;
            result.W = value1.W + value2.W;
            return result;
        }

        // Multiplication
        public static QuaternionProject operator *(QuaternionProject value1, float value2) {
            QuaternionProject result = new QuaternionProject(0, 0, 0, 0);
            result.X = value1.X * value2;
            result.Y = value1.Y * value2;
            result.Z = value1.Z * value2;
            result.W = value1.W * value2;
            return result;
        }

        // Produit scalaire
        public static float Dot(QuaternionProject a, QuaternionProject b) => (float) ((double) a.X * (double) b.X + (double) a.Y * (double) b.Y + (double) a.Z * (double) b.Z + (double) a.W * (double) b.W);

        //public static QuaternionProject Euler(Vector3 euler) => Quaternion.Internal_FromEulerRad(euler * ((float) Math.PI / 180f));
    }
}