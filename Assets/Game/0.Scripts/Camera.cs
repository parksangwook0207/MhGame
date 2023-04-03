using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Vector3 offset;
    public float followSpeed = 0.01f;

    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    private void FixedUpdate()
    {
        Vector3 camera_pos = player.transform.position + offset;
        Vector3 lerp_pos = Vector3.Lerp(transform.position, camera_pos, followSpeed);
        transform.position = lerp_pos;
        transform.LookAt(player.transform);
    }
}
