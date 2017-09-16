using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class NetworkEventManager : MonoBehaviour {

	[Command]
	public void CmdTriggerEvent(string eventName)
	{
		RpcTriggerEvent(eventName);
	}

	[ClientRpc]
	public void RpcTriggerEvent(string eventName)
	{
		EventManager.TriggerEvent(eventName);
	}
}
