using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ShowAnimation : MonoBehaviour {

    private Animator anim;                      
    private AnimatorStateInfo currentState;
    private float hSliderValue = 0.0f;
    private float vSliderValue = 1.0f;
    private float X, Y;
    public GameObject mainCamera;
    private Vector3 offset;
    private bool toggleBool = false;

    void Start () {
        anim = GetComponent<Animator>();
        currentState = anim.GetCurrentAnimatorStateInfo(0);
        
        offset = new Vector3(-1.24f, 1.47f, offset.z);
        mainCamera.transform.position = transform.position + offset;
    }

    void OnGUI()
    {
        currentState = anim.GetCurrentAnimatorStateInfo(0);
        GUI.Box(new Rect(Screen.width - 200, 45, 120, 320), "");

        /*if (GUI.Button(new Rect(Screen.width - 190, 60, 100, 20), "Off/On"))
        {
            anim.enabled = !anim.enabled;
        }*/
        if (GUI.Button(new Rect(Screen.width - 190, 60, 100, 20), "Idle"))
        {
            if (currentState.IsName("Walk"))
                anim.SetBool("Walk", false);
            if (currentState.IsName("Run"))
                anim.SetBool("Run", false);
            if (currentState.IsName("Death"))
                anim.SetBool("Death", false);
        }
        if (GUI.Button(new Rect(Screen.width - 190, 90, 100, 20), "Walk"))
        {
            if (currentState.IsName("Run"))
                anim.SetBool("Run", false);
            if (currentState.IsName("Death"))
                anim.SetBool("Death", false);

            anim.SetBool("Walk", true);
        }

        if (GUI.Button(new Rect(Screen.width - 190, 120, 100, 20), "Run"))
        {
            if (currentState.IsName("Walk"))
                anim.SetBool("Walk", false);
            if (currentState.IsName("Death"))
                anim.SetBool("Death", false);

            anim.SetBool("Run", true);
        }
            
        if (GUI.Button(new Rect(Screen.width - 190, 150, 100, 20), "Jump"))
        {

            if (currentState.IsName("Walk"))
                anim.SetBool("Walk", false);
            if (currentState.IsName("Run"))
                anim.SetBool("Run", false);
            if (currentState.IsName("Death"))
                anim.SetBool("Death", false);

            anim.SetBool("Jump", true);
        }
            
        if (GUI.Button(new Rect(Screen.width - 190, 180, 100, 20), "GetHit"))
        {
            if (currentState.IsName("Walk"))
                anim.SetBool("Walk", false);
            if (currentState.IsName("Run"))
                anim.SetBool("Run", false);
            if (currentState.IsName("Death"))
                anim.SetBool("Death", false);

            anim.SetBool("GetHit", true);
        }
            
        if (GUI.Button(new Rect(Screen.width - 190, 210, 100, 20), "BlockGetHit"))
        {
            if (currentState.IsName("Walk"))
                anim.SetBool("Walk", false);
            if (currentState.IsName("Run"))
                anim.SetBool("Run", false);
            if (currentState.IsName("Death"))
                anim.SetBool("Death", false);

            anim.SetBool("BlockGetHit", true);
        }
            
        if (GUI.Button(new Rect(Screen.width - 190, 240, 100, 20), "Attack1"))
        {
            if (currentState.IsName("Walk"))
                anim.SetBool("Walk", false);
            if (currentState.IsName("Run"))
                anim.SetBool("Run", false);
            if (currentState.IsName("Death"))
                anim.SetBool("Death", false);

            anim.SetBool("Attack1", true);
        }
            
        if (GUI.Button(new Rect(Screen.width - 190, 270, 100, 20), "Attack2"))
        {
            if (currentState.IsName("Walk"))
                anim.SetBool("Walk", false);
            if (currentState.IsName("Run"))
                anim.SetBool("Run", false);
            if (currentState.IsName("Death"))
                anim.SetBool("Death", false);

            anim.SetBool("Attack2", true);
        }
            
        if (GUI.Button(new Rect(Screen.width - 190, 300, 100, 20), "Attack3"))
        {
            if (currentState.IsName("Walk"))
                anim.SetBool("Walk", false);
            if (currentState.IsName("Run"))
                anim.SetBool("Run", false);
            if (currentState.IsName("Death"))
                anim.SetBool("Death", false);

            anim.SetBool("Attack3", true);
        }
            
        if (GUI.Button(new Rect(Screen.width - 190, 330, 100, 20), "Death"))
        {
            if (currentState.IsName("Walk"))
                anim.SetBool("Walk", false);
            if (currentState.IsName("Run"))
                anim.SetBool("Run", false);

            anim.SetBool("Death", true);
        }

        if (GUI.Button(new Rect(Screen.width - 190, Screen.height - 130, 100, 20), "Exit"))
        {
            Application.Quit();
        }

        GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height - 130, 100, 30), "<< Rotation >>");
        hSliderValue = GUI.HorizontalSlider(new Rect(Screen.width/2-200, Screen.height - 100, 400, 30), hSliderValue, 0.0f, 360.0f);
        if (transform.rotation.y != hSliderValue)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, hSliderValue, transform.rotation.z);
        }

        toggleBool = GUI.Toggle(new Rect(Screen.width / 2 - 75, Screen.height - 50, 150, 30), toggleBool, "Automatic rotation");
        if (toggleBool)
        {
            Y += 0.25f * 2;
            transform.localEulerAngles = new Vector3(0, Y, 0);
        }
        if (!toggleBool)
        {
            Y = 0;
        }

        GUI.Label(new Rect(100, Screen.height / 2 - 230, 100, 30), "Zoom -");
        vSliderValue = GUI.VerticalSlider(new Rect(100, Screen.height/2-200, 100, 400), vSliderValue, 2.0f, 0.0f);
        if (mainCamera.transform.position.z != vSliderValue+2.5f)
        {
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, vSliderValue+2.5f);
        }
        GUI.Label(new Rect(100, Screen.height / 2 + 210, 100, 30), "Zoom +");

    }
}
