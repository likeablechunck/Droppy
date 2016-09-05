using UnityEngine;
using System.Collections;

public class Car_Movement : MonoBehaviour
{
    string state;
    public string whoami;
    public float movingSpeed = 3;
    bool rotationFinished = false;
    bool rotationStarted = false;

    // Use this for initialization
    void Start ()
    {
        if(whoami == "bus")
        {
            state = "busStartState";
            
        } else if (whoami == "racecar")
        {
            state = "raceCarStartState";
        }
        rotationStarted = false;
        rotationFinished = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
            if (state == "busStartState")
            {
                busStartState();

            }
            else if (state == "busRightTurnState")
            {
                busRightTurnState();

            } else if (state == "raceCarStartState")
            {
                raceCarStartState();

            }
            else if (state == "raceCarFirstRightTurnState")
            {
                raceCarFirstRightTurnState();

            }
            else if (state == "secondRightTurnState")
            {
                secondRightTurnState();

            }
            else if (state == "endState")
            {
                endState();
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
            float rotationSpeedModifier = 1f;
            if (!rotationStarted)
            {
                rotationStarted = true;
            }
           // print("transform.eulerAngles is " + transform.eulerAngles + "targetRotation is " + targetRotation);
            if (Mathf.Abs(transform.eulerAngles.y - targetRotation.y) > 2.0f)
            {

                transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetRotation, 
                    Time.deltaTime * rotationSpeedModifier);

            }
            else
            {
                print("rotation finished");
                rotationFinished = true;
            }
        }
    }
    public void changeState(string newstate)
    {
        rotationStarted = false;
        rotationFinished = false;
        state = newstate;

    }

    public void busStartState()
    {
        print("Bus state is: " + state);
        Car_Control cc = GameObject.Find("Car_Spawner").GetComponent<Car_Control>();
        if (cc.shouldIInstantiateSet2)
        {
            cc.set2Instantiation(cc.busLocation);
        }
        transform.Translate(0, 0, movingSpeed * Time.deltaTime);
        if (this.transform.position.z >= 2)
        {
            changeState("busRightTurnState");
            print("Bus is changing state to: " + state);
        }

    }
    public void busRightTurnState()
    {
        print("Bus state is: " + state);
        rotation(new Vector3(0, 90, 0));
        if (rotationStarted && rotationFinished)
        {
            print("busLeftTurnState rotation completed");
            // why is this going to -x . you have turned left so now bus
            // faces north
            transform.Translate(0, 0, movingSpeed * Time.deltaTime);
            if (this.transform.position.x >= 32)
            {
                changeState("endState");
                print("Bus is changing state to: " + state);
            }
        }
        
    }
    public void raceCarStartState()
    {
        print("Race car state is: " + state);
        Car_Control cc = GameObject.Find("Car_Spawner").GetComponent<Car_Control>();
        if (cc.shouldIInstantiateSet1)
        {
            cc.set1Instantiation(cc.raceCarLocation);
        }
        transform.Translate(0, 0, movingSpeed * Time.deltaTime);
        if (this.transform.position.z >= 18.5f)
        {
            changeState("raceCarFirstRightTurnState");
            print("Race Car is changing state to: " + state);
        }
    }
    public void raceCarFirstRightTurnState()
    {
        print("Race car state is: " + state);
        rotation(new Vector3(0, 90, 0));
        transform.Translate(0, 0, movingSpeed * Time.deltaTime);
        if (this.transform.position.x >= 35)
        {
            changeState("secondRightTurnState");
            print("Race Car is changing state to: " + state);
        }

    }

    public void secondRightTurnState()
    {
        print("Race car state is: " + state);
        rotation(new Vector3(0, 180, 0));
        transform.Translate(0, 0, movingSpeed * Time.deltaTime);
        if (this.transform.position.z <= -12)
        {
            changeState("endState");
            print("Race Car is changing state to: " + state);
        }
    }
    public void endState()
    {
        // if i am bus only re-instantiate a bus
        // if i am a car only re-instantiate a car
        if(whoami == "bus")
        {
            Invoke("whenToInstantiate2", 3);
        }
        if(whoami == "racecar")
        {
            Invoke("whenToInstantiate1", 3);
        }
        Invoke("destroyMe",1);
        changeState("imDead");
    }
    public void whenToInstantiate2()
    {
        Car_Control cc = GameObject.Find("Car_Spawner").GetComponent<Car_Control>();
        
        cc.shouldIInstantiateSet2 = true;
    }

    public void whenToInstantiate1()
    {
        Car_Control cc = GameObject.Find("Car_Spawner").GetComponent<Car_Control>();
        cc.shouldIInstantiateSet1 = true;

    }

    public void destroyMe()
    {
        Destroy(gameObject, 2.1f);
    }
}
