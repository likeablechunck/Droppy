using UnityEngine;
using System.Collections;

public class cloudMovements : MonoBehaviour
{
    public float xMax = 220f;
    public float xMin = -200f;
    public float zMax = 227f;
    public float zMin = -221f;
    Vector3 location;
    Vector3 speed;
    Vector3 randomSpeedLocation;
    public bool readyToDestroy;

    // Use this for initialization
    void Start ()
    {
        readyToDestroy = false;
        location = new Vector3(Random.Range(xMin, xMax), 0, Random.Range(zMin, zMax));
        print("random location is at :" + location);
        speed = new Vector3(.5f,0,.5f);
        print("speed is : " + speed);
        randomSpeedLocation = new Vector3(0, 0, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Vector3 randomSpeedLocation = Vector3.Scale(location, speed);
        //print("Location * speed is : " + randomSpeedLocation);
        //this.transform.Translate(randomSpeedLocation * Time.deltaTime);
        ////Moving();
        if(readyToDestroy)
        {
            DestroyMe();
        }


    }
    public void Moving()
    {
        //this.transform.Translate(location.x*Time.deltaTime,0, location.z * Time.deltaTime)*speed;
        this.transform.Translate(randomSpeedLocation*Time.deltaTime);

    }
    public void DestroyMe()
    {
        Destroy(this.gameObject);
    }
}
