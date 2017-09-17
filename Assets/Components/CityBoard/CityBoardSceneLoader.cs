using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CityBoardSceneLoader : MonoBehaviour {

	public string cityBoardSceneName;
	// Use this for initialization
	void Start () {
		EventManager.StartListening(GameEvents.PlayerInitialized, LoadCityBoardScene);
	}
	

	private void LoadCityBoardScene()
	{
		Debug.Log("LoadCity");
		SceneManager.LoadScene(cityBoardSceneName, LoadSceneMode.Additive);
		EventManager.TriggerEvent(GameEvents.CityBoardLoaded);
	}

}
