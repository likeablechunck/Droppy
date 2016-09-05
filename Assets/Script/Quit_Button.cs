using UnityEngine;
using System.Collections;

public class Quit_Button : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        this.gameObject.SetActive(false);
	
	}

    public void onClick()
    {
        Application.Quit();
    }
}
