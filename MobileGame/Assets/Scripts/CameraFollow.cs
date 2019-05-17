using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform GolemTransform;
    private Vector3 _cameraOffset;
    public float SmoothFactor = 0.5f;
    public bool LookAtPlayer = false;


    // called once when frame starts
    void Start()
    {
        _cameraOffset = transform.position - GolemTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = GolemTransform.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPosition, SmoothFactor);

        if (LookAtPlayer)
        {
            transform.LookAt(GolemTransform);
        }
    }
}
