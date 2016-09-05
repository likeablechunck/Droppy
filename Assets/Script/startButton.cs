using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        this.gameObject.SetActive(false);

    }
	
	// Update is called once per frame
	void Update ()
    {
        //autoText auto = GameObject.Find("AutoText").GetComponent<autoText>();
        //if(GameObject.Find("AutoText").GetComponent<autoText>().isItReady)
        //{
        //    this.gameObject.SetActive(true);
        //}
	
	}
    public void onClick()
    {
        SceneManager.LoadScene(1);
    }

}
