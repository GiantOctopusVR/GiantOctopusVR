using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class PoolObject : NetworkBehaviour
{

	public virtual void OnObjectReuse(){
		
	}

	void Destroy() {
		//gameObject.SetActive (false);
  //      var agent = gameObject.gameObject.GetComponent<NavMeshAgent>();
  //      agent.enabled = false;
  //      gameObject.gameObject.SetActive(false);
    }
}
