using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : SingletonOct<GameController> {

	public enum GamePlatform {Vive, Android, iOS, PC, Hololens }
	public GamePlatform currentPlatform;
	
	// Update is called once per frame
	void Update () {
		
	}
}
