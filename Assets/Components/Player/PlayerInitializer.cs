using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInitializer : MonoBehaviour {


	public GameObject VivePlayer;
	public GameObject PCPlayer;
	public GameObject AndroidPlayer;


	private AndroidPlayer android;
	// Use this for initialization
	void Start () {
		
		EventManager.StartListening(GameEvents.BuildTower, BuildTowerTest);

		switch(GameController.Instance.currentPlatform)
		{
			case GameController.GamePlatform.PC:
				Debug.Log("THIS IS A PC INSTANCE");
				Instantiate(PCPlayer);
				break;
			case GameController.GamePlatform.Vive:
				Debug.Log("THIS IS A VIVE INSTANCE");
				Instantiate(VivePlayer);
				break;
			case GameController.GamePlatform.Android:
				Debug.Log("THIS IS AN ANDROID INSTANCE");
				var aaa = Instantiate(AndroidPlayer);
				android = aaa.GetComponent<AndroidPlayer>();
				break;
			default:
				Debug.Log("THIS IS A DEFAULT INSTANCE");
				break;			
		}

		Debug.Log("Init correct player for the correct platform");
	}
	

	public void BuildTowerTest()
	{
		switch(GameController.Instance.currentPlatform)
		{
			case GameController.GamePlatform.PC:
				Debug.Log("BUILD TOWER : IS A PC INSTANCE");
				Instantiate(PCPlayer);
				break;
			case GameController.GamePlatform.Vive:
				Debug.Log("BuiltTowerTest : IS A VIVE INSTANCE");
				Instantiate(VivePlayer);
				break;
			case GameController.GamePlatform.Android:
				Debug.Log("BUILD TOWER : IS AN ANDROID INSTANCE");
				android.SetMessage("BuiltTowerTest - ANDROID");
				break;
			default:
				Debug.Log("THIS IS A DEFAULT INSTANCE");
				break;			
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
