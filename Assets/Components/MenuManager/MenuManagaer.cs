using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagaer : MonoBehaviour {
  public GameObject selectMenu;
  public int SceneNum;
  // Use this for initialization
  void Start () {

  }

  // Update is called once per frame
  void Update () {

  }
  public void LoadScence2 (){
    SceneManager.LoadScene(2);
    Debug.Log("Loading Scence 2");
  }
  public void LoadScence3 (){
    SceneManager.LoadScene(3);
    Debug.Log("Loading Scence 3");
  }
  public void ButtonQuit(){
    Application.Quit();
    Debug.Log("Qutiting Application");
  }
  public void OpenSelect(){
    if(selectMenu.active){
      selectMenu.SetActive(false);
      Debug.Log("Enabling");
    }
    else {
      selectMenu.SetActive(true);
      Debug.Log("Disabling");
    }
  }
}
