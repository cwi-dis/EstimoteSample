using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnableOnCollision : MonoBehaviour
{
    public GameObject client_1;
    public GameObject client_2;
    public GameObject client_3;
    public GameObject client_4;
    public GameObject client_5;
    public GameObject client_6;
    
    [SerializeField] public bool debug = true;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    void OnCollisionStay(Collision collision)
    {
        Vector3 myUp = transform.up;
        if (debug) Debug.Log($"Collision enter {gameObject.name} into {collision.gameObject.name}");
        foreach (ContactPoint contact in collision.contacts)
        {
            if (Vector3.Dot(myUp, Vector3.up) > 0.8f)
            {
                Debug.Log($"up, 1");
                if (client_1 != null) client_1.SetActive(true);
            } 
            if (Vector3.Dot(myUp, Vector3.up) < -0.8f)
            {
                Debug.Log($"-up, 6");
                if (client_6 != null) client_6.SetActive(true);
            } 
            if (Vector3.Dot(myUp, Vector3.right) > 0.8f) 
            {
                Debug.Log("right, 3");
                if (client_3 != null) client_3.SetActive(true);
                
            } 
            if (Vector3.Dot(myUp, Vector3.right) < -0.8f)
            {
                Debug.Log("-right, 4");
                if (client_4 != null) client_4.SetActive(true);
            } 
            if (Vector3.Dot(myUp, Vector3.forward) > 0.8f)
            {
                Debug.Log("forward, 2");
                if (client_2 != null) client_2.SetActive(true);
            } 
            if (Vector3.Dot(myUp, Vector3.forward) < -0.8f)
            {
                Debug.Log("-forward, 5");
                if (client_5 != null) client_5.SetActive(true);
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (debug) Debug.Log($"Collision exit {gameObject.name} from  {collision.gameObject.name}");
        if (client_1 != null) client_1.SetActive(false);
        if (client_2 != null) client_2.SetActive(false);
        if (client_3 != null) client_3.SetActive(false);
        if (client_4 != null) client_4.SetActive(false);
        if (client_5 != null) client_5.SetActive(false);
        if (client_6 != null) client_6.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
