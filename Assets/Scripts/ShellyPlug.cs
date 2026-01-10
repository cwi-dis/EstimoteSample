using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;

public class ShellyPlug : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The URL of the shelly plug control port")]
    public string URL = "http://shellyplugsg3-d0cf13c779fc.local/";

    [SerializeField] 
    [Tooltip("partial URL to turn on")]
    public string turnOn = "relay/0?turn=on";
    [SerializeField] 
    [Tooltip("partial URL to turn off")]
    public string turnOff = "relay/0?turn=off";

    [SerializeField] 
    [Tooltip("Turn on/off based on GameObject enabled state")]
    private bool followEnabled = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        if (followEnabled) TurnOn();
    }

    void OnDisable()
    {
        if (followEnabled) TurnOff();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void TurnOn()
    {
        string thisUrl = URL + turnOn;
        Debug.Log($"ShellyPlug: TurnOn: {thisUrl}");
        RestClient.Get(thisUrl).Then(response =>
        {
            Debug.Log($"ShellyPlug: TurnOn Response: {response}");
        });
    }

    void TurnOff()
    {
        string thisUrl = URL + turnOff;
        Debug.Log($"ShellyPlug: TurnOff: {thisUrl}");
        RestClient.Get(thisUrl).Then(response =>
        {
            Debug.Log($"ShellyPlug: TurnOn Response: {response}");
        });    }
}
