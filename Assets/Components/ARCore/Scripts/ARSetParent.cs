using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class ARSetParent : MonoBehaviour {
    private void Start()
    {
        if (GameController.Instance.currentPlatform == GameController.GamePlatform.Android)
        {
            transform.SetParent(GameController.Instance.worldObject.transform, false);
        }
    }
}