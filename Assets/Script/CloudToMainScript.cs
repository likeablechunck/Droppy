using UnityEngine;
using System.Collections;

public class CloudToMainScript : MonoBehaviour {

    public AudioClip typingSound;
    //public AudioClip rainSound;
    public AudioSource audio;
    public bool isItReady;
    bool typedBefore;
    bool characterIsNull;
    string myString = " Congratulations Droppy\n Now it's time to try your first experience on Sky.";
    public GameObject button;

    // Use this for initialization
    void Start()
    {

        StartCoroutine("typeText");
        isItReady = false;
        typedBefore = false;

    }


    IEnumerator typeText()
    {
        foreach (char letter in myString.ToCharArray())
        {
            if(!typedBefore)
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
            
            GetComponent<GUIText>().text += letter;
            yield return 0;
            yield return new WaitForSeconds(.04f);
        }

        //after finishing with all the letters in string, set the button to active so player can go to the next level
        isItReady = true;
        characterIsNull = true;

    }
    void Update()
    {
        //audio.clip = rainSound;
        //playing();

        if (isItReady && characterIsNull)
        {
            //We cann't use GameObject.Find("Button").SetActive(true);
            //Because it has been set to false in startButton therefore we have to assign a game object at the beginning THEN assign the button there and use the SetActive here
            button.SetActive(true);
            audio.Stop();

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
