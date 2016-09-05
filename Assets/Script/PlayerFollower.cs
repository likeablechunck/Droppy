using UnityEngine;
using System.Collections;

public class PlayerFollower : MonoBehaviour
{
    public Vector3 buffer;
    public Transform player;

	// Use this for initialization
	void Start ()
    {
        buffer = new Vector3(0, 10, 0);
        this.transform.position = player.transform.position + buffer;


    }
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.position= player.transform.position + buffer;
	
	}
}
