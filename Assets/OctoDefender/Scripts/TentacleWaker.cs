using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleWaker : MonoBehaviour {
	private Animator animator;

	void Start() {
		animator = GetComponent<Animator>();
		animator.SetBool("isRaised", true);
		StartCoroutine(DoSomething());
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

	IEnumerator DoSomething()
  {
       yield return new WaitForSeconds(1);
	animator.SetBool("isRaised", false);
	   
  }
}
