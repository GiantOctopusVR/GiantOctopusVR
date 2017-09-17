using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkAutoConnect : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<NetworkManager>().StartClient();
    }
}