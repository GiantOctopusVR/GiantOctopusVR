using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleWaker : MonoBehaviour {
	private Animator animator;

	void Start() {
		animator = GetComponent<Animator>();
	}

	void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag.Equals("Player")) {
			print("trigger player");
			animator.SetBool("isRaised", true);
		}
    }

	void OnTriggerExit(Collider other) {
        if (other.gameObject.tag.Equals("Player")) {
			print("trigger player");
			animator.SetBool("isRaised", false);
		}
    }
}
