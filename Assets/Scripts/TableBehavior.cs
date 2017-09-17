using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
public class TableBehavior : MonoBehaviour, IInputClickHandler {
    private GameObject cubePrefab;
    private TextMesh UIText;
    private void Start()
    {
        cubePrefab = GameObject.FindGameObjectWithTag("Tower");
        UIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TextMesh>();
    }
    public void OnInputClicked(InputClickedEventData eventData)
    {
        Debug.Log("Trying to instantiate cube on table plane");
        UIText.text = "Trying to instantiate cube on table plane";
        Instantiate(cubePrefab, GazeManager.Instance.HitPosition, Quaternion.identity);
    }
}
