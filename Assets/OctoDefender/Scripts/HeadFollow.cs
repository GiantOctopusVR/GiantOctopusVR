using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadFollow : MonoBehaviour {

	public GameObject head;
	public float headoffset = .4f;
	public float bodyoffset = .2f;

	private float h = 1.7f;

	private float sx,sy,sz;

	// Use this for initialization
	void Start () {
		sx = transform.localScale.x;
		sy = transform.localScale.y;
		sz = transform.localScale.z;
	}
	
	// Update is called once per frame
	void Update () {
		if (head) {
            //float h_scale = head.transform.position.y / h;
            float h_scale = 1;

            transform.position = new Vector3 (head.transform.position.x, head.transform.position.y - (headoffset*h_scale), head.transform.position.z);
			transform.position = transform.position - (head.transform.forward) * bodyoffset;

			transform.localScale = new Vector3 (sx, sy * h_scale, sz);
		}
	}
}
