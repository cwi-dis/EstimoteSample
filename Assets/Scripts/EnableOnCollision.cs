using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnCollision : MonoBehaviour
{
    public GameObject client;
    
    [SerializeField] public bool debug = true;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    void OnCollisionEnter(Collision collision)
    {
        if (debug) Debug.Log($"Collision enter {gameObject.name}");
        if (client != null)
        {
            client.SetActive(true);
        }
    }

    void onCollisionExit(Collision collision)
    {
        if (debug) Debug.Log($"Collision exit {gameObject.name}");
        if (client != null) {
            client.SetActive(false);}
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
