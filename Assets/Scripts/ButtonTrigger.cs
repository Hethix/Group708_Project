using UnityEngine;
using System.Collections;

public class ButtonTrigger : MonoBehaviour {

    public bool isButtonActivated;
    public byte buttonNumber;
    public short cubesOnButton;

	// Use this for initialization
	void Start () {
        isButtonActivated = false;
        cubesOnButton = 0;
	}
	
	// Update is called once per frame
	void Update () {
        switch (buttonNumber)
        {
            case 1:
                if (cubesOnButton == 1)
                    isButtonActivated = true;
                break;
            case 2:
                if (cubesOnButton == 1)
                    isButtonActivated = true;
                else
                    isButtonActivated = false;
                break;
            case 3:
                if (cubesOnButton == 1)
                    isButtonActivated = true;
                else
                    isButtonActivated = false;
                break;
            case 4:
                if (cubesOnButton == 4)
                    isButtonActivated = true;
                else
                    isButtonActivated = false;
                break;
            case 5:
                if (cubesOnButton == 1)
                    isButtonActivated = true;
                else
                    isButtonActivated = false;
                break;
            default:
                Debug.Log("Button is missing a number");
                break;
        }


    }

    void OnTriggerEnter(Collider other)
    {
        cubesOnButton++;
    }

    void OnTriggerExit(Collider other)
    {
        cubesOnButton--;
    }
}
