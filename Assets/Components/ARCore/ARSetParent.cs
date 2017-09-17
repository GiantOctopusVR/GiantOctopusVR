using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class ARSetParent : MonoBehaviour {
    GameController gameController;

	// Use this for initialization
    private void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        if (gameController.currentPlatform == GameController.GamePlatform.Android)
        {
            transform.SetParent(gameController.worldObject.transform, false);
        }
    }
	
	// Update is called once per frame
	void OnGUI() {
		if (GetComponent<NavMeshAgent>() != null)
        {
            Debug.Log("I've got a nav mesh agent: " + gameObject.name);
            //transform.position += gameController.worldObject.transform.position;
        }
	}
}
