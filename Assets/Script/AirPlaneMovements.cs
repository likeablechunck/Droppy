using UnityEngine;
using System.Collections;

public class AirPlaneMovements : MonoBehaviour
{
    public float mostXBoundry = 13.0f;
    public float leastXBoundry = -16f;
    public int airplaneDirection;
    public Vector3 airplaneStartLocation;

	// Use this for initialization
	void Start ()
    {
        
        transform.position = airplaneStartLocation;
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        //Be aware that those axis are always in global space. 
        //If you want to, for example, translate in the positive X direction of your character 
        //after he rotated(around his Y axis), you want to use the players right direction instead of Vector3.right,
        float xPosition = transform.position.x;

        if (xPosition <= mostXBoundry && xPosition >= leastXBoundry)
        {
            transform.Translate(airplaneDirection*this.transform.right * Time.deltaTime);

        }
        else
            return;

    }
}
