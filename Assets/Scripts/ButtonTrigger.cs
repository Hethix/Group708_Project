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

    void onTriggerEnter(Collider col)
    {
        Debug.Log("Someting on button");

        if (!isButtonActivated && (col.gameObject.name == "CharacterPoint" || col.gameObject.name == "box"));
        {
            isButtonActivated = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(roomNumber != 1)
        {
            isButtonActivated = false;
        }
    }
}
