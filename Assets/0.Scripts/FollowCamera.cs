using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Vector3 offset;
    float followSpeed = 0.015f;
    [SerializeField] private Transform target;
    
    void Update()
    {
        Vector3 cPos = target.transform.position + offset;
        Vector3 lerpPos = Vector3.Lerp(transform.position, cPos, followSpeed);
        transform.position = lerpPos;

        transform.rotation = target.rotation;
        
        transform.LookAt(target.transform);
    }
}
