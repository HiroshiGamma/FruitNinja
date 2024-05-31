using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    
    public GameObject sliced;
    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Slicer"))
        {
            Destroy(gameObject);
        }
    }

    void Slice(Vector3 direction,Vector3 pos)
    {
        sliced.SetActive(true);
        Vector3 directionRot = direction;
        if(direction.magnitude <= 0 )
        {
            directionRot = pos - transform.position;
           
        }

        Quaternion rotation = Quaternion.LookRotation(direction.normalized);
        sliced.transform.localRotation = rotation;

        foreach(Transform slice in sliced.transform)
        {
            Rigidbody rbSlice = slice.GetComponent<Rigidbody>();
            rbSlice.velocity = rb.velocity;
            Vector3 dir = slice.position - pos;
            rbSlice.AddForceAtPosition(dir.normalized,pos,ForceMode.Impulse); 


        }

        sliced.transform.parent = null;
        sliced.transform.position = transform.position;
        Destroy(sliced,5f);
    }
}
