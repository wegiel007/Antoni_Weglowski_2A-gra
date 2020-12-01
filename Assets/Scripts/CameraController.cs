﻿using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
