using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleCollider : MonoBehaviour {

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag.Equals("Enemy")) {
			Destroy(collision.gameObject);
		}
	}
}
