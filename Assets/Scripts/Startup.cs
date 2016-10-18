using UnityEngine;
using System.Collections;

public class Startup : MonoBehaviour {

    public GameObject vrCameraPos;
    public Transform vrCameraRig;

	// Use this for initialization
	void Start () {
        this.transform.position = vrCameraPos.transform.position;
        vrCameraRig.parent = this.transform;
	}
	
	// Update is called once per frame
	void Update () {

	
	}
}
