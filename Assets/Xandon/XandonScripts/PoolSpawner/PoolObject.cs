using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoolObject : MonoBehaviour {

	public virtual void OnObjectReuse(){
		
	}

	void Destroy() {
		gameObject.SetActive (false);
        var agent = gameObject.gameObject.GetComponent<NavMeshAgent>();
        agent.enabled = false;
        gameObject.gameObject.SetActive(false);
    }
}
