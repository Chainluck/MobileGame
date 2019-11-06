using System.Collections;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    //flag to check if the user has tapped / clicked.
    //Set to true on click. Reset to false on reaching point
    private bool flag = false;
    //destination point
    private Vector3 endPoint;
    //alter this to change the speed of the movement of player / gameObject
    public float duration = 50.0f;
    //vertical position of the gameobject
    private float yAxis;
    // Animation
    Animator anim;


    void Start()
    {
        //save the y axis value of gameobject
         yAxis = gameObject.transform.position.y;
        // Get Golem Animator
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //check if the screen is touched, declaring Stationary and Began touches also
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)) 
        {
            //declare a variable of RaycastHit struct
            RaycastHit hit;
            //Make ray for clicked position on screen
            Ray ray;

            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            //Check if the ray hits any collider
            if (Physics.Raycast(ray, out hit))
            {
                //set a flag to indicate to move the gameobject
                flag = true;
                //save the click / tap position
                endPoint = hit.point;
              
                endPoint.y = yAxis;
                // Debug some locations
                Debug.Log(endPoint);
          
                //Rotate character based on raycast hitpoints
                Vector3 lookAt = new Vector3(hit.point.x, 0.055f, hit.point.z);
                transform.LookAt(lookAt);
            }
        }
        //check if the flag for movement is true and the current gameobject position is not same as the clicked / tapped position
        if (flag && !Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude))
        { 
            //move the gameobject to the desired position
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, endPoint, 1 / (duration * (Vector3.Distance(gameObject.transform.position, endPoint))));
            //if player is running, set animation "Run" true
            anim.SetBool("Run", true);
        }
        //set the movement indicator flag to false if endPoint and current position are equal
        else if (flag && Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude))
        {
            flag = false;
            Debug.Log("Reached flag!");
            // set run animation to false
            anim.SetBool("Run", false);
        }
    }
}

