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

    void onTriggerEnter(Collider other)
    {
        Debug.Log("Someting on button");

        if (!isButtonActivated && (other.gameObject.name == "CharacterPoint" || other.gameObject.name == "box"));
        {
            isButtonActivated = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(roomNumber != 1)
        {
            isButtonActivated = false;
        }
    }
}
