using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    Rigidbody rb; 

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    public void Throw(float force){

        Vector3 directionToCenter = (Vector3.zero - transform.position).normalized;
        Vector3 direction = new Vector3(directionToCenter.x * 0.5f,1,0);

        rb.AddForce(direction * force, ForceMode.Impulse);

        float forceRot = force * 0.01f;

        float rotX = Random.Range(-forceRot, forceRot);
        float rotY = Random.Range(-forceRot, forceRot);
        float rotZ = Random.Range(-forceRot, forceRot);
        Vector3 torque = new Vector3(rotX,rotY,rotZ);

        rb.AddTorque(torque,ForceMode.Impulse);



    }

    private void Update()
    {
        if(transform.localPosition.y < 0 ){
            Destroy(gameObject);
        }
    }
}
