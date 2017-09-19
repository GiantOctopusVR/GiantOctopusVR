using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController> {
    public enum GamePlatform {Vive, Android, iOS, PC, Hololens }
    public static GamePlatform currentPlatform;
    public static GameObject worldObject;

    public GameObject[] disableARCoreObjects;
    public GameObject[] enableARCoreObjects;

    void Awake () {
#if UNITY_ANDROID
        Debug.Log("Android detected, setting game platform...");
        currentPlatform = GamePlatform.Android;
#endif
    }

    void Start()
    {
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
        }
    }
}
