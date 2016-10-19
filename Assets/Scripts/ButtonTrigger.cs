using UnityEngine;
using System.Collections;

public class ButtonTrigger : MonoBehaviour {

    public bool isButtonActivated;
    public byte buttonNumber;
    private short cubesOnButton;

	// Use this for initialization
	void Start () {
        isButtonActivated = false;
        cubesOnButton = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        cubesOnButton++;
        if(buttonNumber == 4 && !isButtonActivated && cubesOnButton >= 5)
        {
            isButtonActivated = true;
        }
        else if (!isButtonActivated && (other.gameObject.name == "CharacterPoint" || other.gameObject.name == "box"));
        {
            isButtonActivated = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        cubesOnButton--;
        if (buttonNumber != 1)
        {
            isButtonActivated = false;
        }
    }
}
