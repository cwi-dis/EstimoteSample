using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;

[Serializable]
public class EstimoteData
{
    [Tooltip("X acceleration (in G-units)")]
    public float x;
    [Tooltip("Y acceleration (in G-units)")]
    public float y;
    [Tooltip("Z acceleration (in G-units)")]
    public float z;
    [Tooltip("True if sensor is currently moving, false if currently static")]
    public bool moving;
    [Tooltip("How long the sensor has been moving/static")]
    public int curMoveDuration;
    [Tooltip("How long the sensor has been moving/static")]
    public string curMoveScale;
    [Tooltip("How long the previous moving/static period was")]
    public int prevMoveDuration;
    [Tooltip("How long the previous moving/static period was")]
    public string prevMoveScale;
    [Tooltip("Current temperature of the sensor")]
    public float temp;
    [Tooltip("Battery voltage")]
    public float voltage;
    [Tooltip("True if voltage was measured with transmitter on, false if sensor was idle")]
    public bool voltageUnderStress;
};

public class EstimoteTracker : MonoBehaviour
{
    
    [SerializeField]
    [Tooltip("The URL of the tracker to query")]
    public string URL;

    [SerializeField]
    [Tooltip("The interval (in seconds) between queries")]
    public float interval = 1;
    
    [SerializeField] 
    [Tooltip("Most recent tracker value received")]
    public EstimoteData lastReading;

    private float _time;
    // Start is called before the first frame update
    
    void Start()
    {
        _time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        if (_time > interval)
        {
            _time = 0;
            Get();
        }
    }

    void Get()
    {
        Debug.Log($"EstimoteTracker: GET {URL}");
        RestClient.Get<EstimoteData>(URL).Then(res =>
        {
            lastReading = res;
        });
    }
}
