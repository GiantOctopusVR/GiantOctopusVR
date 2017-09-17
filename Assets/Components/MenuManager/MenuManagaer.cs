using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagaer : MonoBehaviour {
  public GameObject selectMenu;
  public GameObject startMenu;
  public int SceneNum;
  // Use this for initialization
  void Start () {
   Debug.Log("Vim is awesome");

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
		selectMenu.SetActive(true);
      startMenu.SetActive(false);

    }
  }
