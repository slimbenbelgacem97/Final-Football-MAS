using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class scriptcamera : MonoBehaviour
{
    private bool isTriggering = false;
    private float distanceAdder = 0.0f;
    private float distanceAdder2 = 0.0f;
    private bool isExit = false;
    public Transform target;


    public Vector3 targetOffsetPos;
    private Vector3 oldPos;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Ball").transform;
        targetOffsetPos = new Vector3(-45f, 10f, 25f);
    }

    // Update is called once per frame
    void LateUpdate()
    {     
            oldPos = transform.position;
            Vector3 newPos = new Vector3(target.position.x + targetOffsetPos.x, target.position.y + targetOffsetPos.y, target.position.z + targetOffsetPos.z);

            float lerpX = Mathf.Lerp(oldPos.x, newPos.x, 0.05f);
            float lerpY = Mathf.Lerp(oldPos.y, newPos.y, 0.05f);
            float lerpZ = Mathf.Lerp(oldPos.z, newPos.z, 0.05f);

            transform.position = new Vector3(lerpX, lerpY, lerpZ);
            //transform.LookAt(target);
        
    }
}
