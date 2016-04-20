using UnityEngine;
using System.Collections;


public class Task1 : MonoBehaviour, IAnimation
{
    public float Amplitude
    {
        get { return _amplitude; }
        set
        {
            if (value <= 0)
                _amplitude = 0.1f;
            else _amplitude = value;
        }
    }
    public float MinSpeedHeight
    {
        get { return _minSpeedHeight; }
        set
        {
            if (value <= 0)
                _minSpeedHeight = 0.1f;
            else _minSpeedHeight = value;
        }
    }
    public float MaxSpeedHeight
    {
        get { return _maxSpeedHeight; }
        set
        {
            if (value <= 0)
                _maxSpeedHeight = 0.1f;
            else _maxSpeedHeight = value;
        }
    }

    float _minSpeedHeight = 0.1f;
    float _maxSpeedHeight = 5.0f;
    float _amplitude = 5.0f;

    float _omega;

    public Vector3 GetPosition(float time)
    {
        return new Vector3( transform.position.x,
            Mathf.Abs(Amplitude * Mathf.Sin(time * _omega)), 
            transform.position.z);
    }

    void Start ()
    {
        _omega = Random.Range(MinSpeedHeight, MaxSpeedHeight) / 10;
    }
}
