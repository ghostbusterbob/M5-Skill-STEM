using UnityEngine;
using System;

public class QuadraticFunction
{
    public float a;
    public float b;
    public float c;

    public QuadraticFunction(float a, float b, float c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public float EvaluateValue(float t)
    {
        return (a * t * t) + (b * t) + c;
    }

    public Vector2 FindZero()
    {
        float D = (b * b) - (4 * a * c);

        if (D < 0)
        {
            throw new InvalidOperationException("Geen reële oplossingen.");
        }

        float sqrtD = Mathf.Sqrt(D);
        float t1 = (-b + sqrtD) / (2 * a);
        float t2 = (-b - sqrtD) / (2 * a);

        return new Vector2(t1, t2);
    }
}