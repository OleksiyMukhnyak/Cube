using UnityEngine;
using System.Collections.Generic;

public class WaveHelper : MonoBehaviour
{
    List<Impuls> WaveImpuls = new List<Impuls>();
    List<Vector2> WaveCenters = new List<Vector2>();
    List<float> WaveTime = new List<float>();

    float _height = 0;
    float _speedInitAnimation = 2.0f;
    float _speedAnimation = 4.0f;
    float _timeAnimation = 6.0f;

    void Start()
    {

    }

    void Update()
    {
        if (WaveImpuls.Count == 0)
        {
            transform.position = Vector3.Lerp(transform.position, 
                transform.GetComponent<IAnimation>().GetPosition(Time.time), 
                Time.deltaTime * _speedInitAnimation);

            return;
        }


        _height = 0;

        for (int i = 0; i < WaveImpuls.Count; i++)
        {
            _height += WaveImpuls[i].GetImpuls(new Vector2(WaveCenters[i].x, WaveCenters[i].y),
                new Vector2(transform.position.x, transform.position.z), Time.time - WaveTime[i]);

            if (Time.time - WaveTime[i] > _timeAnimation)
            {
                WaveImpuls.Remove(WaveImpuls[i]);
                WaveCenters.Remove(WaveCenters[i]);
                WaveTime.Remove(WaveTime[i]);
                _height = 0;
            }
        }
        transform.position = Vector3.Lerp(transform.position,
                 new Vector3(transform.position.x, _height, transform.position.z), Time.deltaTime * _speedAnimation);
    }

    public void AddCenter(Vector2 center)
    {
        WaveImpuls.Add(new Impuls());
        WaveCenters.Add(center);
        WaveTime.Add(Time.time);
    }
}
