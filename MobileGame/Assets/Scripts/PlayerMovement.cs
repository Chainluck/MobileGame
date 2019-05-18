﻿using System.Collections;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    //flag to check if the user has tapped / clicked.
    //Set to true on click. Reset to false on reaching destination
    private bool flag = false;
    //destination point
    private Vector3 endPoint;
    //alter this to change the speed of the movement of player / gameObject
    public float duration = 50.0f;
    //vertical position of the gameobject
    private float yAxis;
    // Animation
    Animator anim;
    //destination point for target
    Vector3 targetPosition;
    // destination point for "face direction" target
    Vector3 lookAtTarget;
    // How the player rotates
    Quaternion playerRot;
    // rotation speed
    float rotSpeed = 100;

    void Start()
    {
        //save the y axis value of gameobject
         yAxis = gameObject.transform.position.y;


    }

    // Update is called once per frame
    void Update()
    {
        //check if the screen is touched, declaring Stationary and Began touches also
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary || Input.touchCount < 0 && Input.GetTouch(0).phase == TouchPhase.Began)) 
        {
            //declare a variable of RaycastHit struct
            RaycastHit hit;
            //Make ray for clicked position
            Ray ray;

            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            



            //Check if the ray hits any collider
            if (Physics.Raycast(ray, out hit))
            {
                //set a flag to indicate to move the gameobject
                flag = true;
                //save the click / tap position
                endPoint = hit.point;
                //as we do not want to change the y axis value based on touch position, reset it to original y axis value
                endPoint.y = yAxis;
                Debug.Log(endPoint);

                targetPosition = hit.point;
                //this.transform.LookAt(targetPosition);
                //Assign positions for rotating
                lookAtTarget = new Vector3(targetPosition.x - transform.position.x, transform.position.y, targetPosition.z - transform.position.z);
                // When player taps the screen, "flag" target will be looked
                playerRot = Quaternion.LookRotation(lookAtTarget);
                // calling  void Move function
                Move();


            }
        }
        //check if the flag for movement is true and the current gameobject position is not same as the clicked / tapped position
        if (flag && !Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude))
        { 
            //move the gameobject to the desired position
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, endPoint, 1 / (duration * (Vector3.Distance(gameObject.transform.position, endPoint))));
        }
        //set the movement indicator flag to false if endPoint and current position are equal
        else if (flag && Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude))
        {
            flag = false;
            Debug.Log("Reached flag!");
        }

    }
    //Using Slerp for handling the rotation
    void Move()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, playerRot, rotSpeed * Time.deltaTime);
    }
}

