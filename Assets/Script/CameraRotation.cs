using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour
{
    bool happenedOnce;
    string state;
    bool rotationStarted = false;
    bool rotationFinished = false;

	// Use this for initialization
	void Start ()
    {

        if (Application.loadedLevelName == "City")
        {
            state = "onCitySky";

        }
        else if (Application.loadedLevelName == "Sky")
        {
            state = "onSky";

        }
        state = "onCitySky";


    }
	
	// Update is called once per frame
	void Update ()
    {
        if (state == "onSky")
        {
            onSky();
        }
        else if (state == "onCitySky")
        {
            onCitySky();
        }
        else if (state == "skyToLand")
        {
            skyToLand();
        }
        else if (state == "firstRightTurn")
        {
            firstRightTurn();
        }
        else if (state == "secondRightTurn")
        {
            secondRightTurn();
        }
        else if (state == "thirdRightTurn")
        {
            thirdRightTurn();
        }
        else if (state == "lastLeftTurn")
        {
            lastLeftTurn();
        }
        else if (state == "cityEnd")
        {
            cityEnd();
        }

    }

    public void rotation(Vector3 targetRotation)
    {

        if (rotationFinished)
        {
            return;
        }
        else
        {



            float rotationSpeed = 0;
            float rotationSpeedModifyer = .8f;

            if (!rotationStarted)
            {
                rotationStarted = true;
            }
            if (transform.eulerAngles != targetRotation)
            {
                rotationSpeed += Time.deltaTime * rotationSpeedModifyer;
                transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetRotation, rotationSpeed);
                //line above is the problem. Lerp is not the right function to use.LERP CAN"T do the NEgative things.
                //Use Itween library which will do all the math calculations and you technically use their functions.

                //yield return new WaitForEndOfFrame();
            }
            else
            {
                rotationFinished = true;
            }
        }
    }

    public void changeState(string newState)
    {
        rotationStarted = false;
        rotationFinished = false;
        state = newState;
    }
    // Functions 1-6 will calculate the behaviour of the player in each street based on the rotation around Y-axis that needs to happen
    // 1)When player is on sky
    public void onSky()
    {

    }
    public void onCitySky()
    {
        //print("My current CAMERA state is : " + state);
        if (transform.position.y <= 11.5f  )
        {
            changeState("skyToLand");
            //print("I am changing my state to CAMERA state : " + state);
        }
        

    }
    // 2) when it is landing from sky to the city
    public void skyToLand()
    {
        //print("My current CAMERA state is : " + state);
      
        {
            rotation(new Vector3(0, 90, 0));

        }
        //print("Camera position : " + transform.position);
        if (transform.position.x >= 37)
        {
            changeState("firstRightTurn");
            //print("I am changing my state to CAMERA state : " + state);
        }
      

    }
    // 3) when player is in first street and hits the first turn
    public void firstRightTurn()
    {
        rotation(new Vector3(0, 180, 0));
        
        if (transform.position.z <= -6)
        {
            changeState("secondRightTurn");
            //print("I am changing my state to CAMERA state : " + state);
        }
    }
    //4) when player is in second street and hits the second turn
    public void secondRightTurn()
    {
        //print("My current CAMERA state is : " + state);
      
        {
            rotation(new Vector3(0, 270, 0));

        }

        if (transform.position.x <= 23.5f)
        {
            changeState("thirdRightTurn");
            //print("I am changing my state to CAMERA state : " + state);
        }
       

    }
    // 5) when player is in third street and hits the third turn
    public void thirdRightTurn()
    {
       // print("My current CAMERA state is : " + state);
        
        {
            rotation(new Vector3(0, 0, 0));

        }
        if (transform.position.z >= -8f)
        {
            changeState("lastLeftTurn");
            //print("I am changing my state to CAMERA state : " + state);
        }
        

    }
    // 6) when player is in last street and hits the first LEFT turn
    public void lastLeftTurn()
    {
        //print("My current CAMERA state is : " + state);
        
        {
            rotation(new Vector3(0, 270, 0));

        }
        if (transform.position.x <= -2)
        {
            changeState("cityEnd");
            //print("I am changing my state to CAMERA state : " + state);
        }
        
    }
    // 7) this is when player hits the end of road (DEAD END)
    public void cityEnd()
    {
        
    }
}
