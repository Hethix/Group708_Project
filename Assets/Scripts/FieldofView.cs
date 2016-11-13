using UnityEngine;
using System.Collections;

public class FieldofView : MonoBehaviour {
    public float fieldOfView;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Camera.main.fieldOfView = 80;
	}
}
