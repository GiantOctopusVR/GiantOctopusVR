using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScriptAfterMusic : MonoBehaviour {
	public float timeLeft;
	public int scene;

	// Use this for initialization
	void Start () {
		timeLeft = 47f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		timeLeft -= Time.deltaTime;
		if (timeLeft <= 0f) {
			SceneManager.LoadScene (scene);
		}
	}
}
