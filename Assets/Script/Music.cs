using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour
{
    public string state;
    public AudioSource audio;
    public AudioClip sunnyClip;
    public AudioClip thunderStrikeClip;
    public AudioClip startRainClip;
    bool hasPlayedBefore;

	// Use this for initialization
	void Start ()
    {
        state = "normal";
        hasPlayedBefore = false;
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(state == "normal")
        {
            normal();
        }
        if( state == "thunder")
        {
            thunder();
        }
        if (state == "raining")
        {
            raining();
        }
	
	}

    public void changeState(string stateName)
    {
        state = stateName;
    }

    public void normal()
    {

        if( audio.clip == sunnyClip)
        {
            if(!audio.isPlaying)
            {
                audio.Play();

            }
          
        } else
        {
            audio.clip = sunnyClip;
        }
       

    }

    public void thunder()
    {
        if (audio.clip == thunderStrikeClip)
        {
            if (audio.isPlaying)
            {
                hasPlayedBefore = true;
            }
            else
            {
                if(!hasPlayedBefore)
                {
                    audio.Play();
                }
                else
                {
                    hasPlayedBefore = false;
                    changeState("normal");

                }
            }
        }
        else
        {
            audio.clip = thunderStrikeClip;
        }

    }

    public void raining()
    {
        if (audio.clip == startRainClip)
        {
            if (!audio.isPlaying)
            {
                audio.Play();

            }

        }
        else
        {
            audio.clip = sunnyClip;
        }


    }
}
