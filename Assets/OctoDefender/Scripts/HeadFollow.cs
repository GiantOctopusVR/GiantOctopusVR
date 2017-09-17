using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadFollow : MonoBehaviour {

	public GameObject head;
	public float headoffset = .4f;
	public float bodyoffset = .2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (head) {
			transform.position = new Vector3 (head.transform.position.x, head.transform.position.y - headoffset, head.transform.position.z);
			transform.position = transform.position - (head.transform.forward) * bodyoffset;
		}
	}
}
