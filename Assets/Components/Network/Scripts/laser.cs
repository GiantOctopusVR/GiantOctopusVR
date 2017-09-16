using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class laser : NetworkBehaviour {

	//public int player = 1;
	public ParticleSystem laserlineL;
	public ParticleSystem laserlineR;
	private bool canShoot;

	// Use this for initialization
	void Start () {
		//laserline = GetComponent<ParticleSystem>();
		//RpcEndFire();
		if (isLocalPlayer) { canShoot = true; }
		else { canShoot = false; }
	}

	// Update is called once per frame
	void Update () {
		/*
        if (!canShoot) { return; }
        int player = playerControllerId + 1;
        if (player == 1)
        {
            if (Input.GetButton("P1-Fire2"))
            {
                CmdStartFire();
            }
            else
            {
                CmdEndFire();
            }
        }
        else
        {
            CmdEndFire();
        }
        */

	}
	public void Lfire(bool b){
		if(b)
			CmdStartLFire ();
		else CmdEndLFire ();
	}
	public void Rfire(bool b){
		if(b)
			CmdStartRFire ();
		else CmdEndRFire ();	
	}

	[Command]
	public void CmdStartLFire()
	{
		RpcStartLFire();
	}

	[Command]
	public void CmdStartRFire()
	{
		RpcStartRFire();
	}

	[Command]
	public void CmdEndLFire()
	{
		RpcEndLFire();
	}

	[Command]
	public void CmdEndRFire()
	{
		RpcEndRFire();
	}
		

	[ClientRpc]
	void RpcStartLFire()
	{
		var em = laserlineL.emission;
		em.enabled = true;
	}

	[ClientRpc]
	void RpcEndLFire()
	{
		var em = laserlineL.emission;
		em.enabled = false;
	}

	[ClientRpc]
	void RpcStartRFire()
	{
		var em = laserlineR.emission;
		em.enabled = true;
	}

	[ClientRpc]
	void RpcEndRFire()
	{
		var em = laserlineR.emission;
		em.enabled = false;
	}

}
