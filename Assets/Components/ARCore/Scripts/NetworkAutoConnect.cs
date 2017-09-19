using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkAutoConnect : MonoBehaviour {
    public NetworkManager networkManager;

	// Use this for initialization
	void Start () {
        if (GameController.currentPlatform == GameController.GamePlatform.Android)
        {
            Debug.Log("Auto connecting to server: " + networkManager.networkAddress);
            networkManager.StartClient();
        }
    }
}
