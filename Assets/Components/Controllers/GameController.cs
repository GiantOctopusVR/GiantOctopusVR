using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController> {

	public enum GamePlatform {Vive, Android, iOS, PC, Hololens }
	public GamePlatform currentPlatform;
    public GameObject worldObject;
	
	// Update is called once per frame
	void Update () {
		
	}
}
