using UnityEngine;
using System.Collections;
using Image = UnityEngine.UI.Image;

public class DroppyBarController : MonoBehaviour
{
    public int collisionCounter;
    public int MaxFill;
    public int MinFill;
    Image DroppyBar;

	// Use this for initialization
	void Start ()
    {
        //Get the Canvas and Blue Bar inside the Canvas. Later we will mess with it's filling vals
        DroppyBar = GameObject.Find("Canvas").transform.FindChild("Blue_Bar").GetComponent<Image>();
        MaxFill = 1;
        MinFill = 0;
        DroppyBar.fillAmount = MinFill;
        collisionCounter = 0;
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void IncreaseBar()
    {
        print("Collision counter Before O : " + collisionCounter);
        collisionCounter++;
        print("Collision counter after O : " + collisionCounter);
        if (collisionCounter >= 0 && collisionCounter <= 4f)
        {
            DroppyBar.fillAmount += .25f;

        }
        else
        {
            return;
        }
    }

    public void ReduceBar()
    {
        print("Collision counter before P : " + collisionCounter);
        collisionCounter = collisionCounter - 1;
        print("Collision counter after P : " + collisionCounter);
        if (collisionCounter >= 0 && collisionCounter <= 4f)
        {
            DroppyBar.fillAmount -= .25f;
        }
        else
        {
            return;

        }
            
    }
}
