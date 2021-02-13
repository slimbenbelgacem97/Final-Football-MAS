using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nomscript : MonoBehaviour
{
    public GameObject plyerobject;


    // Start is called before the first ;rame update
    void Start()
    {

        plyerobject = GameObject.FindGameObjectsWithTag("player")[0];

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(plyerobject.transform.position.x , plyerobject.transform.position.y+2, plyerobject.transform.position.z);
    }
}

