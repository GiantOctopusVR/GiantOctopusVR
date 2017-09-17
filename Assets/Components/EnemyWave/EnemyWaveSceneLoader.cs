using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyWaveSceneLoader : MonoBehaviour {

    public string sceneWave;
    // Use this for initialization
    void Start()
    {
        //EventManager.StartListening(GameEvents.CityBoardLoaded, LoadEnemyWave);
        SceneManager.LoadScene("CityScape", LoadSceneMode.Additive);
    }


    private void LoadEnemyWave()
    {
        Debug.Log("Load EnemyWave Scene");
        SceneManager.LoadScene(sceneWave, LoadSceneMode.Additive);
        EventManager.TriggerEvent(GameEvents.EnemyWaveLoaded);
    }

}
