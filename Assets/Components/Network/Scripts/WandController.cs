using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WandController : MonoBehaviour
{
	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

	private SteamVR_TrackedObject trackedObj;
	private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input ((int)trackedObj.index); } }

	// Use this for initialization
	void Start ()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (controller == null) {
			Debug.Log ("controller not initialized");
			return;
		}
		if (controller.GetPressDown(triggerButton) ){
			Debug.Log("triggered");

			/*
			float minDistance = float.MaxValue;
			float dist;
			foreach (InteractableObject obj in objsHoveringOver) {
				dist = (obj.transform.position - transform.position).sqrMagnitude;
				if (dist < minDistance) {
					minDistance = dist;
					closestObj = obj;
				}
			}

			interactionObj = closestObj;

			if (interactionObj) {
				if (interactionObj.IsInteraction ()) {
					interactionObj.EndInteraction (this);
				}
				interactionObj.BeginInteraction (this);
			}
			*/


		}
		if (controller.GetPressUp (triggerButton) ) {
			Debug.Log ("untrigged");


			//add physics to rigibody

		}



	}

	private void OnTriggerEnter(Collider collider){

	}

	private void OnTriggerExit(Collider collider){

	}
}

