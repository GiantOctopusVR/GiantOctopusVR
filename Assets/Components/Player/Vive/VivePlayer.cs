using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VivePlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			var towerBuilder = GameObject.FindObjectOfType<BuildTowerNetworkManager>();

			var tower = new BuildMessage();
			towerBuilder.CmdBuildTower(tower);
		}
	}

}
