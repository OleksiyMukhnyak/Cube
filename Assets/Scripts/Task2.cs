using UnityEngine;
using System.Collections;

public class Task2 : MonoBehaviour, IAnimation
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
    public float Lenght
    {
        get { return _lenght; }
        set
        {
            if (value <= 0)
                _lenght = 0.1f;
            else _lenght = value;
        }
    }
    public float Speed
    {
        get { return _speed; }
        set
        {
            if (value <= 0)
                _speed = 0.1f;
            else _speed = value;
        }
    }
    public Vector2 Center
    {
        get { return _center; }
        set { _center = value; }
    }

    float _amplitude = 5.0f;
    float _lenght = 100.0f;
    float _speed = 50.0f;
    Vector2 _center = new Vector2(10.5f, 18.5f);

    float _omega;

    public Vector3 GetPosition(float time)
    {
        return new Vector3(transform.position.x,
           Mathf.Abs(Amplitude * Mathf.Sin((Mathf.Pow(transform.position.x - Center.x, 2) +
           Mathf.Pow(transform.position.z - Center.y, 2)) * _omega + Time.time * _omega * Speed)),
            transform.position.z);
    }

    void Start()
    {
        _omega = 2 * Mathf.PI / Lenght;
    }
}
