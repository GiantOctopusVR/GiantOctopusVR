using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
public class CityBuild : MonoBehaviour, IInputClickHandler {
    public GameObject tower;
    public TextMesh UIText;
    public void OnInputClicked(InputClickedEventData eventData)
    {
        Debug.Log("Trying to instantiate cube on table plane");
        UIText.text = "Trying to instantiate cube on table plane";
        Instantiate(tower, GazeManager.Instance.HitPosition, Quaternion.identity);
    }
}
