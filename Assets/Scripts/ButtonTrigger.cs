using UnityEngine;
using System.Collections;

public class ButtonTrigger : MonoBehaviour {

    public bool isButtonActivated;
    public byte roomNumber;

	// Use this for initialization
	void Start () {
        isButtonActivated = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void onCollisionEnter(Collision col)
    {
        if (!isButtonActivated && (col.gameObject.name == "CharacterPoint" || col.gameObject.name == "box"));
        {
            isButtonActivated = true;
        }
    }

    void onCollisionExit(Collision col)
    {
        if(roomNumber != 1)
        {
            isButtonActivated = false;
        }
    }
}
