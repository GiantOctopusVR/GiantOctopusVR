using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.AI;

public class ObjectInstance : NetworkBehaviour {
		public GameObject gameObject;
		Transform transform;

		bool hasPoolObjectComponent;
		PoolObject poolObjectScript;

		public ObjectInstance(GameObject objectInstance)
		{
			Debug.Log("ObjectInstance what whaaaaaaaaa");
			gameObject = objectInstance;
			transform = gameObject.transform;
			gameObject.SetActive(false);
            var agent = gameObject.GetComponent<NavMeshAgent>();
            agent.enabled = false;

            if (gameObject.GetComponent<PoolObject>()) {
				hasPoolObjectComponent = true;
				poolObjectScript = gameObject.GetComponent<PoolObject>();
			}
		}


		[ClientRpc]
		public void RpcReuse(GameObject obj) 
		{
			Debug.Log("CLIENT RPC-REUSE");
			obj.SetActive (true);
		}

		public void Reuse(Vector3 position, Quaternion rotation, float scale, Transform nexus) {

			Debug.Log("REUSE");
			if (hasPoolObjectComponent) {
				poolObjectScript.OnObjectReuse ();
			}

			gameObject.SetActive(true);
			RpcReuse(gameObject);
			transform.position = position;
			transform.rotation = rotation;
            transform.localScale = new Vector3(scale, scale, scale);
            var agent = gameObject.GetComponent<NavMeshAgent>();
            agent.enabled = true;
            agent.SetDestination(nexus.position);
        }

		public void setParent(Transform parent){
			transform.parent = parent;
		}
}
