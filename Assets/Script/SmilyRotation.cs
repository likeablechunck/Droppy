using UnityEngine;
using System.Collections;

public class SmilyRotation : MonoBehaviour
{
    public float rotationSpeed = 80f;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.World);

    }
}
