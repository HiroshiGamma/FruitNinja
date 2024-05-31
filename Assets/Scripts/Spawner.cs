using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] fruitPrefabs;

    [SerializeField] float minForce = 13f;
    [SerializeField] float maxForce = 15.5f;

    float maxWidth;

    void Start()
    {
        float camWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0f,0f)).x;

        maxWidth = camWidth - 1.5f;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Spawn();
        }
        
    }

    void Spawn(){

        int rndIndex = Random.Range(0,fruitPrefabs.Length);
        GameObject fruit = Instantiate(fruitPrefabs[rndIndex],transform);
        Vector3 spawnPos = new Vector3(Random.Range(-maxWidth,maxWidth),transform.position.y,transform.position.z);
        fruit.transform.position = spawnPos;
        fruit.GetComponent<ThrowObject>().Throw(Random.Range(minForce,maxForce));
    }
}
