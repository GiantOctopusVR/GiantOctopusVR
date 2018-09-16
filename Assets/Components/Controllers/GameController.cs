using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameController : Singleton<GameController> {
    protected GameController() { } // guarantee this will be always a singleton only

    public enum GamePlatform {Vive, Android, iOS, PC, Hololens }
    public GamePlatform currentPlatform;
    public GameObject worldObject;
    public NetworkManager networkManager;

    public GameObject[] disableARCoreObjects;
    public GameObject[] enableARCoreObjects;
    public GameObject removeARCoreSpawnObject;

    void Awake () {
#if UNITY_ANDROID
        Debug.Log("Android detected, setting game platform...");
        currentPlatform = GamePlatform.Android;
#endif
    
        // Android specific settings
        if (currentPlatform == GamePlatform.Android)
        {
            // Disable components that shouldn't be on for ARCore
            foreach (GameObject disableARCoreObject in disableARCoreObjects)
            {
                Debug.Log("Disabling object: " + disableARCoreObject.name);
                disableARCoreObject.SetActive(false);
            }

            // Enable components that should be on for ARCore
            foreach (GameObject enableARCoreObject in enableARCoreObjects)
            {
                Debug.Log("Enabling object: " + enableARCoreObject.name);
                enableARCoreObject.SetActive(true);
            }

            // Disable Invader
            // TODO: Enable this again once we fix network positioning
            networkManager.spawnPrefabs.Remove(removeARCoreSpawnObject);
        }
    }
}
