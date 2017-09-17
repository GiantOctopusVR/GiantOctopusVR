using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracadeHealth : MonoBehaviour {
  public float timeLeft;
  public GameObject fullBarrack;
  public GameObject lowBarrack;
  public GameObject colBarrack;
	// Use this for initialization
	void Start () {
	   timeLeft = 20f;	
     colBarrack.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
    SubTime();
    CheckTime();
    }
  private void CheckTime (){
    if (timeLeft >= 10f) {
      fullBarrack.SetActive(true);
      lowBarrack.SetActive(false);
    }
    else if (timeLeft <= 10f){
      fullBarrack.SetActive(false);
      lowBarrack.SetActive(true);
    }
    if (timeLeft <= 0f){
      fullBarrack.SetActive(false);
      lowBarrack.SetActive(false);
      colBarrack.SetActive(false);
    }
    
  }
    private void SubTime (){
      if (timeLeft >= 0f){
        timeLeft -= Time.deltaTime;	
      }
    }
	}
