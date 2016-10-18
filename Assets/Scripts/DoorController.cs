using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

    public Animator anim;
    public ButtonTrigger button;
    public GameObject blocker;
    public bool enteredNextRoom;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        enteredNextRoom = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!enteredNextRoom)
        {
            if (button.isButtonActivated)
            {
                anim.SetBool("CloseDoor", false);
                anim.SetBool("OpenDoor", true);
                blocker.SetActive(false);
            }
            else if (!button.isButtonActivated)
            {
                anim.SetBool("OpenDoor", false);
                anim.SetBool("CloseDoor", true);
                blocker.SetActive(true);
            }
        }
    }


    //Entering the next room
    void onTriggerEnter(Collider col)
    {
        if (!enteredNextRoom)
        {
            Debug.Log("HELLO");
            anim.SetBool("CloseDoor", true); //Closing the door
            blocker.SetActive(true); //Enabling blocker so they can't go back
            enteredNextRoom = true;
        }
    }
}
