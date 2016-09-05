using UnityEngine;
using System.Collections;

public class Car_Control : MonoBehaviour
{
    public GameObject[] set1;
    public GameObject[] set2;
    public bool shouldIInstantiateSet1;
    public bool shouldIInstantiateSet2;
    int set1Length;
    int set2Length;
    int set1Index;
    int set2Index;
    public Vector3 busLocation;
    public Vector3 raceCarLocation;


    // Use this for initialization
    void Start ()
    {
        set1Length = 0;
        set2Length = 0;
        shouldIInstantiateSet1 = true;
        shouldIInstantiateSet2 = true;
        set1 = Resources.LoadAll<GameObject>("Set1");
        set2 = Resources.LoadAll<GameObject>("Set2");
        busLocation = new Vector3(14, 0, -10);
        raceCarLocation = new Vector3(13.5f, 0, 6);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (shouldIInstantiateSet1)
        {
            set1Instantiation(raceCarLocation);
        }
        else
        {

        }
        if (shouldIInstantiateSet2)
        {
            set2Instantiation(busLocation);
        }
        else
        {

        }

    }
    public void set1Instantiation(Vector3 vehicleLocation)
    {
        print("I am about to instantiate a Race Car");
        set1Length = set1.Length;
        set1Index = Random.Range(0, set1Length );
        GameObject rs1 = Instantiate(set1[set1Index], vehicleLocation, Quaternion.identity) as GameObject;
        rs1.name = "race-" + Random.Range(1, 1000);
        shouldIInstantiateSet1 = false;
    }
    public void set2Instantiation(Vector3 vehicleLocation)
    {
        print("I am about to instantiate a Bus");
        set2Length = set2.Length;
        set2Index = Random.Range(0, set2Length );
        GameObject rs2 = Instantiate(set2[set2Index], vehicleLocation, Quaternion.identity) as GameObject;
        rs2.name = "bus-" + Random.Range(1, 1000);
        shouldIInstantiateSet2 = false;
    }

}
