using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagaer : MonoBehaviour {
  public GameObject selectMenu;
  public GameObject startMenu;
  public int SceneNum;
	public static int creatureNum;
  // Use this for initialization
  void Start () {
   Debug.Log("Vim is awesome");
		creatureNum = 0;

  }
 // Update is called once per frame
  void Update () {
	
  }
  public void LoadOcto (){
    SceneManager.LoadScene(4);
	creatureNum = 0;
    Debug.Log("Loading Scence 2");
  }
  public void LoadIron (){
    SceneManager.LoadScene(4);
		creatureNum = 1;
    Debug.Log("Loading Scence 3");
  }
  public void ButtonQuit(){
    Application.Quit();
    Debug.Log("Qutiting Application");
  }
  public void OpenSelect(){
		SceneManager.LoadScene (SceneNum);
    }
  }
