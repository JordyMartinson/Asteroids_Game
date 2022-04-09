using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Player player;
    // public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPos = player.transform.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, newPos, smoothSpeed);
        transform.position = smoothPos;
    }
}
