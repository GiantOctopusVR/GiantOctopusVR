using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class VRTrack : NetworkBehaviour {

	public GameObject VRH;
	public GameObject VRL;
	public GameObject VRR;

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



		if (hasAuthority)
		{
			if(VRH == null)
				VRH = GameObject.Find ("VRHead (eye)");
			if(VRL == null)
				VRL = GameObject.Find ("VRLeft");
			if(VRR == null)
				VRR = GameObject.Find ("VRRight");

			if(VRH!=null)
				NetH.transform.position = VRH.transform.position;
			if(VRL!=null)
				NetL.transform.position = VRL.transform.position;
			if(VRR!=null)
				NetR.transform.position = VRR.transform.position;
		}
	}
}
