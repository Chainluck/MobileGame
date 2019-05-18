using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    Vector3 targetPosition;

    // Update is called once per frame
    void Update()
    {
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary || Input.touchCount < 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            SetTargetPosition();
        }

    void SetTargetPosition()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                targetPosition = hit.point;
                this.transform.LookAt(targetPosition);
                Debug.Log("HALO");
            }
        }
    }
}
