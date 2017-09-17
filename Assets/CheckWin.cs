using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWin : MonoBehaviour {
  
  public static bool win;
  public GameObject winMenu;
  public GameObject loseMenu;

	// Use this for initialization
	void Start () {
    if (win){
      winMenu.SetActive(true);
      loseMenu.SetActive(false);
    }
    else if (!win){
      winMenu.SetActive(false);
      loseMenu.SetActive(true);

    }
	  	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
