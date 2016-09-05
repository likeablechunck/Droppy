using UnityEngine;
using System.Collections;

public class Music_Controller : MonoBehaviour
{
    public string state;
    bool tirePlayedBefore;
    bool sadPlayedBefore;
    bool accidentPlayedBefore;
    public AudioSource gameAudio;
    public AudioClip tireSqueeshClip;
    public AudioClip sadClip;
    public AudioClip accidentClip;


    // Use this for initialization
    void Start ()
    {
        tirePlayedBefore = false;
        sadPlayedBefore = false;
        accidentPlayedBefore = false;
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    public void changeState(string newState)
    {
        state = newState;

    }
    public void playClipOnce(AudioClip clip)
    {
        print(string.Format("play  {0}", clip.name));

        if (gameAudio != null)
        {
                gameAudio.clip = clip;
                gameAudio.Play();
                changeState("bequiet");
            
        }
    }
    public void beQuiet()
    {
        //nothing to be done
    }

    public void Tire()
    {
        playClipOnce(tireSqueeshClip);
        
    }
    public void Sad()
    {
        playClipOnce(sadClip);

    }
    public void Accident()
    {
        playClipOnce(accidentClip);

    }
}
