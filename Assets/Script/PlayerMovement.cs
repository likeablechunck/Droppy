using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float flyingSpeed;
    public Vector3 minPlayerPosition;
    public Vector3 maxPlayerPosition;
    public Vector3 playerPosition ;
    public float speedConstant;
    public Vector3 resizeConstant;
    public string state;
    Vector3 minScale;
    Vector3 maxScale;
    Vector3 fractionOfMaxScale;
    bool happenedOnce;
    public Vector3 minY;
    string skyScene;
    // Use this for initialization
    void Start ()
    {
        transform.position = playerPosition;
        //minPlayerPosition = new Vector3(-16f,-9999999,-15f);
        //maxPlayerPosition = new Vector3(14f, 9999999, 5f);
        flyingSpeed = -2.6f;
        speedConstant = 1.5f;
        minScale = new Vector3(1, 1, 1);
        maxScale = new Vector3(3, 3, 3);
        fractionOfMaxScale = new Vector3(1.7f, 1.7f, 1.7f);
        resizeConstant = new Vector3 (0.2f,0.2f,0.2f);
        happenedOnce = false;
        minY = new Vector3(90, 0.2f, 100);
        //happenedOnce = false;
        if (Application.loadedLevelName == "City")
        {
            
            state = "onCitySky";
            //For Testing purposes
            //state = "Test";


        }
        else if (Application.loadedLevelName == "Sky")
        {
            state = "onSky";

        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        DroppyBarController db = Camera.main.GetComponent<DroppyBarController>();
        if(state == "onSky")
        {
            onSky();
        }
        if(state == "onCitySky")
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
        else if (state == "Test")
        {
            Test();
        }
        //if player needs to release a drop (if there is one), press O
        //since it released one, it will be faster and size will decrease.
        //droppy bar will decrease.
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (transform.localScale.x > minScale.x && transform.localScale.y > minScale.y && transform.localScale.z > minScale.z)
            {
                transform.localScale = sizeReducction(transform.localScale);
                db.ReduceBar();
            }
            else
            {
                print("I can't reduce the size anymore");
                return;
            }
            // IT IS FLYING SPEED THAT WILL HAVE DIFF STATES BASED ON THE LOCATION OF THE PLAYER
            reduceSpeed(flyingSpeed);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        print("What did I colide? " + other.name);
        print("What is the tag? " + other.tag);
        DroppyBarController db = Camera.main.GetComponent<DroppyBarController>();
        //player collides with another droppy,(max size is 4)
        //it will get bigger and heavier
        //it will move slower
        //droppy bar will be increased
        if (other.tag== ("Droppy"))
        {
            Destroy(other.gameObject);
            //score++;

            if (transform.localScale.x < maxScale.x && transform.localScale.y < maxScale.y && transform.localScale.z < maxScale.z)
            {
                transform.localScale = sizeExpansion(transform.localScale);
                db.IncreaseBar();

            }
            else
            {
                print("I can't increase the size anymore");
                return;
            }
            // IT IS FLYING SPEED THAT WILL CHANGE AND UPDATE WILL TAKE CARE OF DIFFERENT STATES WITH DIFFERENT DIRECTIONS THA PLAYER IS MOVING
            increaseSpeed(flyingSpeed);
        }

        //else if (other.tag == "City_Done")
        //{
        //    print("I finished city level");
        //    SceneManager.LoadScene("SF_Info");

        //}
        else if (other.tag == "Sky_Done")
        {
            print("I finished Sky level");
            SceneManager.LoadScene("SkyToCity");

        }
        else if (other.tag == "Good_Car")
        {
            Music_Controller mc = Camera.main.GetComponent<Music_Controller>();
            print("What is my size:" + transform.localScale);
            if (transform.localScale.x >= fractionOfMaxScale.x && transform.localScale.y >= fractionOfMaxScale.y && transform.localScale.z >= fractionOfMaxScale.z)
            {
                
                mc.Accident();
                Destroy(other.gameObject);

            }
            else
            {
                mc.Sad();
                Invoke("reloadTheCityScene", 3);
            }

        }
        else if (other.tag == "Bad_Car")
        {
            Music_Controller mc = Camera.main.GetComponent<Music_Controller>();
            mc.Sad();
            Invoke("reloadTheCityScene", 3);

        }
    }
    public void reloadTheCityScene()
    {
        SceneManager.LoadScene("City");

    }

    public void rotation(Vector3 targetRotation)
    {
        happenedOnce = true;
        float rotationSpeed = 0;
        float rotationSpeedModifyer = .2f;

        while (transform.eulerAngles != targetRotation)
        {
            rotationSpeed += Time.deltaTime * rotationSpeedModifyer;
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetRotation, rotationSpeed);

            //yield return new WaitForEndOfFrame();
        }

    }
    //***INCREASE OR DECREASE THE SIZE OF THE PLAYER BASED ON COLLISION EVENTS***
    public Vector3 sizeExpansion(Vector3 oldSize)
    {     
        Vector3 newSize = oldSize + resizeConstant;
        return newSize;
    }
    public Vector3 sizeReducction (Vector3 oldSize)
    {       
            Vector3 newSize = oldSize - resizeConstant;
            return newSize;      
    }
    //***increase or decrease the speed by a fixed amount***
    public float increaseSpeed(float currentSpeed)
    {
        float newSpeed = currentSpeed + speedConstant;
        return newSpeed;
    }
    public float reduceSpeed(float currentSpeed)
    {
        float newSpeed = currentSpeed - speedConstant;
        return newSpeed;
    }
    //Changing the states based on the location of the player
    public void changeState(string newState )
    {
        state = newState;      
    }
    // Functions 1-6 will calculate the behaviour of the player in each street based on the rotation around Y-axis that needs to happen
    // 1)When player is on sky
    public void onSky()
    {
        transform.Translate(Input.GetAxis("Horizontal")*0.3f, flyingSpeed * Time.deltaTime, Input.GetAxis("Vertical") * 0.3f);

    }
    public void onCitySky()
    {
        print("My current state is : " + state);
        PlayerFollower pf = Camera.main.GetComponent<PlayerFollower>();
        Music_Controller mc = Camera.main.GetComponent<Music_Controller>();
        pf.buffer = new Vector3 (0,10,0);
        transform.Translate(0, flyingSpeed * Time.deltaTime, 0);
        if(transform.position.y <= 1.5f)
        {
            mc.Tire();
            changeState("skyToLand");
            print("I am changing my state to state : " + state);
        }

    }   
    // 2) when it is landing from sky to the city
    public void skyToLand()
    {
        print("My current state is : " + state);
        PlayerFollower pf = Camera.main.GetComponent<PlayerFollower>();
        Music_Controller mc = Camera.main.GetComponent<Music_Controller>();
        pf.buffer = new Vector3(-10, 0, 0);
        transform.Translate(-flyingSpeed * Time.deltaTime, 0, -Input.GetAxis("Horizontal")*0.3f);
        print("Player position : " + transform.position);
        if (transform.position.x >= 41)
        {
            mc.Tire();
            changeState("firstRightTurn");
            print("I am changing my state to state : " + state);
        }
        happenedOnce = false;
    }
    public void Test()
    {
        print("My current state is : " + state);
        PlayerFollower pf = Camera.main.GetComponent<PlayerFollower>();
        pf.buffer = new Vector3(-10, 0, 0);
        transform.Translate(Input.GetAxis("Vertical")*0.5f, 0, -Input.GetAxis("Horizontal") * 0.3f);

    }
    // 3) when player is in first street and hits the first turn
    public void firstRightTurn()
    {
        print("My current state is : " + state);
        PlayerFollower pf = Camera.main.GetComponent<PlayerFollower>();
        Music_Controller mc = Camera.main.GetComponent<Music_Controller>();
        pf.buffer = new Vector3(0, 0, 10);       
        transform.Translate(-Input.GetAxis("Horizontal")*0.3f, 0, flyingSpeed*Time.deltaTime);
        if (transform.position.z <= -13)
        {
            mc.Tire();
            changeState("secondRightTurn");
            print("I am changing my state to state : " + state);
        }
        happenedOnce = false;
    }
    //4) when player is in second street and hits the second turn
    public void secondRightTurn()
    {
        print("My current state is : " + state);
        PlayerFollower pf = Camera.main.GetComponent<PlayerFollower>();
        Music_Controller mc = Camera.main.GetComponent<Music_Controller>();
        pf.buffer = new Vector3(10, 0, 0);
        transform.Translate(flyingSpeed * Time.deltaTime, 0, Input.GetAxis("Horizontal")*0.3f);
        if (transform.position.x <= 15)
        {
            mc.Tire();
            changeState("thirdRightTurn");
            print("I am changing my state to state : " + state);
        }
        happenedOnce = false;

    }
    // 5) when player is in third street and hits the third turn
    public void thirdRightTurn()
    {
        print("My current state is : " + state);
        PlayerFollower pf = Camera.main.GetComponent<PlayerFollower>();
        Music_Controller mc = Camera.main.GetComponent<Music_Controller>();
        pf.buffer = new Vector3(0, 0, -10);      
        transform.Translate(Input.GetAxis("Horizontal")*0.3f, 0, -flyingSpeed * Time.deltaTime);
        if (transform.position.z >= 2f)
        {
            mc.Tire();
            changeState("lastLeftTurn");
            print("I am changing my state to state : " + state);
        }
        happenedOnce = false;
    }
    // 6) when player is in last street and hits the first LEFT turn
    public void lastLeftTurn()
    {
        print("My current state is : " + state);
        PlayerFollower pf = Camera.main.GetComponent<PlayerFollower>();
        Music_Controller mc = Camera.main.GetComponent<Music_Controller>();
        pf.buffer = new Vector3(10, 0, 0);
        transform.Translate(flyingSpeed * Time.deltaTime, 0, Input.GetAxis("Horizontal")*0.3f);
        if (transform.position.x <= -6.5f)
        {
            mc.Tire();
            changeState("cityEnd");
            print("I am changing my state to state : " + state);
        }
        happenedOnce = false;
    }
    // 7) this is when player hits the end of road (DEAD END)
    public void cityEnd()
    {
        print("My current state is : " + state);
        SceneManager.LoadScene("SF_Info");
    }   
}
