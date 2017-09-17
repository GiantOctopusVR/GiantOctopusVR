using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HoloNetClientStart : MonoBehaviour {

    NetworkManager netManager;
	// Use this for initialization
	void Start () {
        netManager = gameObject.GetComponent<NetworkManager>();
        netManager.StartClient();
    }

    // Update is called once per frame
    void Update () {
		if(Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Start Client Connection");
            
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("Start HOST Connection");
            netManager.StartHost();
        }
    }
}
