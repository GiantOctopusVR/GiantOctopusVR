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

	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
	private SteamVR_TrackedObject LtrackedObj;
	private SteamVR_Controller.Device Lcontroller {
        get {
            if (LtrackedObj != null)
            {
                return SteamVR_Controller.Input((int)LtrackedObj.index);
            } else
            {
                return null;
            }
        }
    }

	private SteamVR_TrackedObject RtrackedObj;
    private SteamVR_Controller.Device Rcontroller
    {
        get
        {
            if (RtrackedObj != null)
            {
                return SteamVR_Controller.Input((int)RtrackedObj.index);
            }
            else
            {
                return null;
            }
        }
    }
    // Use this for initialization
    void Start () {
		if(GameController.Instance.currentPlatform != GameController.GamePlatform.Vive)
		{
			//Network.Destroy(GetComponent<NetworkView>().viewID);
			return;
		}

		VRH = GameObject.Find ("VRHead (eye)");
		VRL = GameObject.Find ("VRLeft");
		VRR = GameObject.Find ("VRRight");

		LtrackedObj = VRL.GetComponent<SteamVR_TrackedObject> ();
		RtrackedObj = VRR.GetComponent<SteamVR_TrackedObject> ();

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

			if (VRH != null) {
				NetH.transform.position = VRH.transform.position;
				NetH.transform.rotation = VRH.transform.rotation;
			}
			if (VRL != null) {
				NetL.transform.position = VRL.transform.position;
				NetL.transform.rotation = VRL.transform.rotation;
			}
			if (VRR != null) {
				NetR.transform.position = VRR.transform.position;
				NetR.transform.rotation = VRR.transform.rotation;
			}
			if (Lcontroller == null) {
				//Debug.Log ("Lcontroller not initialized");
			} else if (Lcontroller.GetPress (triggerButton)) {
				Debug.Log ("Ltriggered");
				GetComponent<laser> ().Lfire (true);
			} else {
				GetComponent<laser> ().Lfire (false);
			}

			if (Rcontroller == null) {
				//Debug.Log ("Rcontroller not initialized");
			} else if (Rcontroller.GetPress (triggerButton)) {
				Debug.Log ("Rtriggered");
				GetComponent<laser> ().Rfire (true);
			} else {
				GetComponent<laser> ().Rfire (false);
			}

		}
	}
}
