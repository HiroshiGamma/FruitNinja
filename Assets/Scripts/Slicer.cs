using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slicer : MonoBehaviour
{
    public Vector3 direction {get;private set;}
    Collider sliceCollider;
    Camera mainCamera;
    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;

        direction = newPosition - transform.position;
        if(direction.magnitude > 0.01f){
            sliceCollider.enabled = true;
        }
        else{
            
            sliceCollider.enabled = false;
        }

        transform.position = newPosition;
        
    }
}
