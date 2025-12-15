using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDiceBehaviour : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The estimote to track")]
    EstimoteTracker estimoteTracker;

    [SerializeField] private bool isMoving;
    [SerializeField] private bool wasMoving;

    private Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        EstimoteData curReading = estimoteTracker.lastReading;
        isMoving = curReading.moving;
        if (isMoving && !wasMoving)
        {
            StartMoving();
        }
        else if (isMoving)
        {
            IsMoving();
        }

        if (!isMoving && wasMoving)
        {
            StopMoving(curReading);
        }
        wasMoving = isMoving;
    }

    void StartMoving()
    {
        
        rigidBody.isKinematic = false;
        rigidBody.useGravity = false;
        transform.position += new Vector3(0, 1, 0);
    }

    void IsMoving()
    {
        // We should wiggle it
    }

    void StopMoving(EstimoteData curReading)
    {
        rigidBody.isKinematic = false;
        rigidBody.useGravity = true;
        Vector3 acceleration = new Vector3(curReading.x, curReading.y, curReading.z);

        transform.rotation = Quaternion.Euler(acceleration * 90);
    }
}
