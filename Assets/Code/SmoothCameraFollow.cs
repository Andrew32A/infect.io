using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform target;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        Vector3 positionLerp = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
        positionLerp.z = transform.position.z;
        transform.position = positionLerp;
    }
}
