using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

    public Animator anim;
    public ButtonTrigger button;

	// Use this for initialization
	void Start () {
        anim = anim.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (button.isButtonActivated)
        {
            anim.SetBool("OpenDoor", true);
        }
	
	}
}
