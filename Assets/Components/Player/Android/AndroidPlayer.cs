using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AndroidPlayer : MonoBehaviour {

	public GameObject AndroidUIPrefab;
	public GameObject EventSystemPrefab;
	public Text uiConsole;

	// Use this for initialization
	void Start () {
		Instantiate(EventSystemPrefab);
		var obj = Instantiate(AndroidUIPrefab);
		var panel = obj.transform.Find("Panel");
		var log = panel.transform.Find("AndroidLog");
		var comp = log.GetComponent<Text>();
		uiConsole = comp;
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

	public void SetMessage(string message)
	{
		Debug.Log(message);
		uiConsole.text = message;
	}
}
