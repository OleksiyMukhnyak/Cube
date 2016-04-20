using UnityEngine;
using System.Collections;

public class Impuls
{
    float A;
    float L;
    float k;
    float om;

    public Impuls()
    {
        A = 10.0f;
        L = 1.0f;
        k = 2 * Mathf.PI / L;
        om = 1.0f;
    }

    public Impuls(float amplitude, float lenght, float omega)
    {
        A = amplitude;
        L = lenght;
        k = 2 * Mathf.PI / L;
        om = omega;
    }

    public float GetImpuls(Vector2 center, Vector2 position, float time)
    {
        return A * Mathf.Abs(Mathf.Sin(om * time)) *
            Mathf.Exp(-time * (Mathf.Sqrt(Mathf.Pow(position.x - center.x, 2) + Mathf.Pow(position.y - center.y, 2)) + 1) / k);
    }
}
