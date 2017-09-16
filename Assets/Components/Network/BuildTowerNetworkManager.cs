using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BuildTowerNetworkManager : NetworkBehaviour {

	[Command]
	public void CmdBuildTower(BuildMessage message)
	{
		// receives message from client
		// client has the intent to build a tower

		// validate that player can build tower
		// i.e.
		//    	Does player have enough resources?
		//		Is location available?
		//		Is location valid? (meaning does it block the path? Is there something at that location?)
		//
		

		// call rpc method so that clients build the actual tower in their own game instance

	}

	[ClientRpc]
	public void RpcBuildTower(BuildMessage message)
	{
		// builds tower at given location
	}

}

public struct BuildMessage
{
	public string playerId;
	public string towerId;
	public Vector3 location;
}
