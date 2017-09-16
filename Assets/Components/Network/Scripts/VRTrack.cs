using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class VRTrack : NetworkBehaviour {

	private GameObject VRH;
	private GameObject VRL;
	private GameObject VRR;

	public GameObject NetH;
	public GameObject NetL;
	public GameObject NetR;

	private GameController gameController;

	// Use this for initialization
	void Start () {
		
		var obj = GameObject.FindWithTag("GameController");

		gameController = obj.GetComponent<GameController>();

		if(gameController.currentPlatform != GameController.GamePlatform.Vive)
		{
			//Network.Destroy(GetComponent<NetworkView>().viewID);
			return;
		}

		VRH = GameObject.Find ("VRHead (eye)");
		VRL = GameObject.Find ("VRLeft");
		VRR = GameObject.Find ("VRRight");
	}
	
	// Update is called once per frame
	void Update () {
		if (isLocalPlayer)
		{
			if(VRH!=null)
				NetH.transform.position = VRH.transform.position;
			if(VRL!=null)
				NetL.transform.position = VRL.transform.position;
			if(VRR!=null)
				NetR.transform.position = VRR.transform.position;
		}
	}
}
