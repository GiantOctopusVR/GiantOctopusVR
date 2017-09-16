using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagaer : MonoBehaviour {
  public GameObject settingsMenu;
  // Use this for initialization
  void Start () {

  }

  // Update is called once per frame
  void Update () {

  }
  public void loadScence(){
    SceneManager.LoadScene(1);
    Debug.Log("Loading Scence 1");
  }
  public void buttonQuit(){
    Application.Quit();
    Debug.Log("Qutiting Application");
  }
  public void openSettings(){
    if(settingsMenu.active){
      settingsMenu.SetActive(false);
      Debug.Log("Enabling");
    }
    else {
      settingsMenu.SetActive(true);
      Debug.Log("Disabling");
    }
  }
}
