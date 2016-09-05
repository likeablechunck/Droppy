using UnityEngine;
using System.Collections;


public class SF_Info : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip typingSound;
    bool typedBefore;
    public bool isItReady;
    string myString = " Congratulations Droppy\n The city you just discovered was \nSan Francisco.\nSan Francisco (Spanish for Saint Francis) was founded on June 29, 1776,\nwhen colonists from Spain established Presidio of San Francisco at the Golden Gate and Mission San Francisco.\nI Know you had fun, trust me I am working on more fun places for you\nto explore.\nJust bare with me for more discoveries in the future...";
    public GameObject button;
    bool characterIsNull;
    // Use this for initialization
    void Start()
    {

        StartCoroutine("typeText");
        isItReady = false;
        typedBefore = false;
        characterIsNull = false;

    }


    IEnumerator typeText()
    {
        foreach (char letter in myString.ToCharArray())
        {
            

            GetComponent<GUIText>().text += letter;
            yield return 0;
            yield return new WaitForSeconds(.04f);
        }

        //after finishing with all the letters in string, set the button to active so player can go Quit
        isItReady = true;
        characterIsNull = true;
    }
    void Update()
    {
        if (!typedBefore && !characterIsNull)
        {
            if (audio.clip = typingSound)
            {
                playing();
            }
            else
            {
                audio.clip = typingSound;
            }
        }
        else if (characterIsNull)
        {
            audio.Stop();
        }
     

        if (isItReady)
        {
            
            button.SetActive(true);

        }
    }
    public void playing()
    {
        if (!audio.isPlaying)
        {

            audio.Play();
        }

    }

}

