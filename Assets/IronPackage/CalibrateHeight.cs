using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrateHeight : MonoBehaviour {
    public float height;
    public GameObject cameraEye;
    public bool liveUpdate = false;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C) || liveUpdate)
        {
            this.Calibrate();
        }
	}

    public void Calibrate()
    {
        float playerHeight = this.cameraEye.transform.localPosition.y;
        Vector3 scale = new Vector3(1, 1, 1);
        scale.y = this.height / playerHeight;
        this.transform.localScale = scale;
    }
}
