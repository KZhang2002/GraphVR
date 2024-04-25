using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnet : MonoBehaviour {
    private Rigidbody rb, connectedRb, previousRB;
    Vector3 connectionWorldPosition, connectionVelocity;
    [SerializeField] private GameObject Platform;
    private Platform pScript;
    
    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void Start() {
        pScript = Platform.GetComponent<Platform>();
    }

    // Update is called once per frame
    // void FixedUpdate() {
    //     connectedRb = collision.rigidbody;
    // }

    private void FixedUpdate() {
        if (connectedRb && pScript.moveFlag) {
            Debug.Log(connectedRb.name + " just entered the trigger!");
            //UpdateConnectionState();
            connectedRb.gameObject.transform.position += pScript.offSet;
        }
    }
    
    void UpdateConnectionState () {
        Vector3 connectionMovement =
            connectedRb.position - rb.position;
        connectionVelocity = connectionMovement / Time.deltaTime;
        connectionWorldPosition = connectedRb.position;
    }

    private void OnTriggerEnter(Collider other) {
        previousRB = other.attachedRigidbody;
        Debug.Log(other.name + " just entered the trigger!");
    }

    private void OnTriggerStay(Collider other) {
        connectedRb = other.attachedRigidbody;
        previousRB = connectedRb;
        Debug.Log(other.name + " just stayed in the trigger!");
    }
    
    
}