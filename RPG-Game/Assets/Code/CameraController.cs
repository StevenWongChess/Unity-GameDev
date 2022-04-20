using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;
    public float smoothness;

    private Vector3 _velocity;

    private void Start()
    {
        if (target)
        {
            offset = transform.position - target.position;
        }
    }

    private void Update()
    {
        if (target)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref _velocity, smoothness);
        }
    }
}
