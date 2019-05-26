using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField]
    private KeyCode moveL;
    [SerializeField]
    private KeyCode moveR;
    private  float horizVel = 0;
    private int laneNum = 2;
    private string controlLocked = "n";

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;


    public float get_HorizVal()
    {
        return horizVel;
    }
    //Keyboard interaction
    /*
     * LaneNum 
     * Left:1 Middle:2 Right:3
     * controlLocked to handle press during Coroutine
     * HorizVel: Horizontal Velocity to change Lanes
     */
    public void Keyboard()
    {
        if (Input.GetKeyDown(moveL) && laneNum > 1 && controlLocked == "n")
        {
            
            horizVel = -2;
            StartCoroutine(StopSlide());
            laneNum -= 1;
            controlLocked = "y";
        }
        if (Input.GetKeyDown(moveR) && laneNum < 3 && controlLocked == "n")
        {
            horizVel = 2;
            StartCoroutine(StopSlide());
            laneNum += 1;
            controlLocked = "y";
        }
    }


    //This code source https://forum.unity.com/threads/swipe-in-all-directions-touch-and-mouse.165416/
    //As I have never implemented a swiple feature in my unity games
    public void Swipe()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                //save began touch 2d point
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Ended)
            {
                //save ended touch 2d point
                secondPressPos = new Vector2(t.position.x, t.position.y);

                //create vector from the two points
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                //normalize the 2d vector
                currentSwipe.Normalize();


                //swipe left
                if (currentSwipe.x < 0 && currentSwipe.y > -1 && currentSwipe.y < 1 && laneNum > 1 && controlLocked == "n")
                {
                    horizVel = -2;
                    StartCoroutine(StopSlide());
                    laneNum -= 1;
                    controlLocked = "y";
                }
                //swipe right
                if (currentSwipe.x > 0 && currentSwipe.y > -1 && currentSwipe.y < 1 && laneNum < 3 && controlLocked == "n")
                {
                    horizVel = 2;
                    StartCoroutine(StopSlide());
                    laneNum += 1;
                    controlLocked = "y";
                }
            }
        }
    }

    //Courtine idea is not mine
    IEnumerator StopSlide()
    {
        yield return new WaitForSeconds(0.2f);
        horizVel = 0;
        controlLocked = "n";
    }
}
