using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform PlayerTransform;
    private Vector3 _cameraOffset;
    public float SmoothFactor = 0.5f;
    public bool LookAtPlayer = false;


    // called once when frame starts
    void Start()
    {
        _cameraOffset = transform.position - PlayerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = PlayerTransform.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPosition, SmoothFactor);

        if (LookAtPlayer)
        {
            transform.LookAt(PlayerTransform);
        }
    }
}
