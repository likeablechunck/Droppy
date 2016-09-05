using UnityEngine;
using System.Collections;

public class SkyToCity : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip typingSound;
    bool typedBefore;
    public bool isItReady;
    string myString = " I am so proud of you Droppy\nYou got a brief sense of how to move and how you can control\nyour speed by attaching or detaching to other Droppies (Team Work ROCKS).\nNow you can use your skills to survive in a big city.\ngood Luck.";
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
