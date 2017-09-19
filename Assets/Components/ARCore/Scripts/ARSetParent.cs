using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class ARSetParent : MonoBehaviour {
    private void Start()
    {
        if (GameController.currentPlatform == GameController.GamePlatform.Android)
        {
            transform.SetParent(GameController.worldObject.transform, false);
        }
    }
}