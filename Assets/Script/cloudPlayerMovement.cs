using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class cloudPlayerMovement : MonoBehaviour
{
    
    public GameObject cloud1;
    public GameObject cloud2;
    public GameObject cloud3;
    public GameObject cloud4;
    public GameObject cloud6;
    ArrayList cloudNames;
    bool isCloud1Ready = false;
    bool isCloud2Ready = false;
    bool isCloud3Ready = false;
    bool isCloud4Ready = false;
    bool isCloud6Ready = false;
    //public AudioClip sunny;
    //AudioSource audio_sunny;
    //public AudioClip thunderStrike;
    //AudioSource audio_thunderStrike;
    //public AudioClip startRaining;
    //AudioSource audio_startRaining;



    // Use this for initialization
    void Start ()
    {
        GameObject.Find("cloud1_replica").SetActive(false);
        GameObject.Find("cloud2_replica").SetActive(false);
        GameObject.Find("cloud3_replica").SetActive(false);
        GameObject.Find("cloud4_replica").SetActive(false);
        GameObject.Find("cloud6_replica").SetActive(false);
        cloudNames = new ArrayList();
        //audio_thunderStrike = GetComponent<AudioSource>();
        //audio_sunny = GetComponent<AudioSource>();
        //audio_startRaining = GetComponent<AudioSource>(); 
        

    }
	
	// Update is called once per frame
	void Update ()
    {

        this.transform.Translate(Input.GetAxis("Horizontal"),-1* Input.GetAxis("Vertical"), 0);

        //every frame we should check and see if the player hit a cloud, instantiate the one that has been associated with it
        if (cloudNames.Contains("cloud1"))
        {
            if (!cloud1.activeInHierarchy)
            {

                cloud1.SetActive(true);
            }
        }
        if (cloudNames.Contains("cloud2"))
        {
            if (!cloud2.activeInHierarchy)
            {
                cloud2.SetActive(true);
            }

        }
        if (cloudNames.Contains("cloud3"))
        {
            if (!cloud3.activeInHierarchy)
            {
                cloud3.SetActive(true);
            }

        }
        if (cloudNames.Contains("cloud4"))
        {
            if (!cloud4.activeInHierarchy)
            {
                cloud4.SetActive(true);
            }

        }
        if (cloudNames.Contains("cloud6"))
        {
            if (!cloud6.activeInHierarchy)
            {
                cloud6.SetActive(true);
            }

        }
    }

    void OnCollisionEnter(Collision other)
    {
        GameObject.Find("MusicController").GetComponent<Music>().changeState("thunder");
        print("I hit :" + other.gameObject.name);
        if(GameObject.Find("Player") != null)
        {
            print("player is not null");
            if(other.gameObject.GetComponent<cloudMovements>() != null)
            {
                print("I could access the CloudMovement");
                other.gameObject.GetComponent<cloudMovements>().readyToDestroy = true;
                cloudNames.Add(other.gameObject.name);
            }
            else
            {
                print("I can't access the CloudMovement");

            }
            
            //readyToDestroy = false;

        }
        else
        {
            print("player IS null");

        }
       
        if (cloudNames.Count == 5)
        {
            GameObject.Find("MusicController").GetComponent<Music>().changeState("raining");
            print("You have picked all clouds, now it's time for a rain");
            Invoke("changingScene", 3f);
        }
      

    }
    void changingScene()
    {
        SceneManager.LoadScene(2);
    }
}
