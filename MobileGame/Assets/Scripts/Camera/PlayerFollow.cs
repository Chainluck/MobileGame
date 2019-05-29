using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    //Playertransform
    public Transform PlayerTransform;
    // cameraOffset
    private Vector3 _cameraOffset;
    // Range for camera SmoothFactor
    [Range(0.01f, 1.0f)]
    //SmootFactor default value
    public float SmoothFactor = 0.5f;
    public bool LookAtPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        _cameraOffset = transform.position - PlayerTransform.position;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPos = PlayerTransform.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        //to make sure camera is always rotated to watch the player
        if(LookAtPlayer)
        {
            transform.LookAt(PlayerTransform);
        }
    }
}
