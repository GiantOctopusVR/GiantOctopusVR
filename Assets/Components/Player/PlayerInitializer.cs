using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerInitializer : NetworkBehaviour {


	public GameObject VivePlayer;
	public GameObject VivePlayer2;
	public GameObject PCPlayer;
	public GameObject AndroidPlayer;


	private AndroidPlayer android;
	// Use this for initialization
	void Start () {
		
		if(!isLocalPlayer)
		{
			return;
		}

		EventManager.StartListening(GameEvents.BuildTower, BuildTowerTest);
		EventManager.StartListening(GameEvents.CityBoardLoaded, InitPlayerAfterCityIsLoaded);
		EventManager.StartListening(GameEvents.EndGameEvent, EndGame);
		
		switch(GameController.Instance.currentPlatform)
		{
			case GameController.GamePlatform.PC:
				Debug.Log("THIS IS A PC INSTANCE");
				Instantiate(PCPlayer);
				break;
			case GameController.GamePlatform.Vive:
				Debug.Log("THIS IS A VIVE INSTANCE");
				CmdSpawnVive(gameObject);
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
		EventManager.TriggerEvent(GameEvents.PlayerInitialized);
	}
	

	public void InitPlayerAfterCityIsLoaded()
	{
		Debug.Log("DO Stuff that depends on the city being loaded first - like placing the player with the board");
		EventManager.StopListening(GameEvents.CityBoardLoaded, InitPlayerAfterCityIsLoaded);
	}

  public void EndGame() {
    // Handle End Game on all platforms
    Debug.Log("Ending Game");
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
				CmdSpawnVive( gameObject);
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

	[Command] void CmdSpawnVive(GameObject player){
		GameObject spawn;
		if (GameObject.Find ("octo") != null) {
			spawn = Instantiate (VivePlayer);
		} else {
			spawn = Instantiate (VivePlayer2);
		}	
		NetworkServer.SpawnWithClientAuthority (spawn, connectionToClient);
	}
}
