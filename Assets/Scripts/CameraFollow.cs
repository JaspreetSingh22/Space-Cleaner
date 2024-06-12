using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Tooltip("Object camera is tracking")]
    public Transform Target;

    [Space(10)]
    [Tooltip("Minimum constaint for our camera")]
    public Vector2 MinXandY;

    [Tooltip("Max constaint for our camera")]
    public Vector2 MaxXandY;

    [Space(10)]
    [Tooltip("Distance from the target from which our camera will start moving")]
    public Vector2 Margins;

    [Tooltip("How much, as a decimal percentage our camera tries to follow every frame")]
    public Vector2 Easing;
    

    // Update is called once per frame
    void Update()
    {
        //Get the initial postion of our target object 
        float targetX = Target.position.x;
        float targetY = Target.position.y;

        //clamp forces our value to be between the w defined extreme.
        //in this case target x/ y will always be the same or bigger than MinXandY or
        //smaller the MaxXandY
        targetX = Mathf.Clamp(targetX, MinXandY.x, MaxXandY.x);
        targetY = Mathf.Clamp(targetY, MinXandY.y, MaxXandY.y);

        //lerp( linear Interpolation)
        //(B-A)* t +A
        //Mathd.lerp(2,4,0.5f)

        //2      3       4
        //|------|-------|
        
        //(4-2)*0.5f+2
        //2*0.5+2
        //1+2
        //3

        //check if our character is beyond our margines and if so move the camera.
        if(Mathf.Abs(transform.position.x - targetX) > Margins.x)
        {
           targetX = Mathf.Lerp(transform.position.x, targetX, Easing.x);
        }
        else
        {
            targetX = transform.position.x;
        }
        if (Mathf.Abs(transform.position.y - targetY) > Margins.y)
        {
            targetY = Mathf.Lerp(transform.position.y, targetY, Easing.y);
        }
        else
        {
            targetY = transform.position.y;
        }

        transform.position = new Vector3(targetX, targetY,transform.position.z);
    }
}
