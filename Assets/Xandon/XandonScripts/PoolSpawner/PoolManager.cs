using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class PoolManager : NetworkBehaviour { 
	Dictionary<int,Queue<ObjectInstance>> poolDictionary = new Dictionary<int, Queue<ObjectInstance>> ();

	static PoolManager _instance;

    private Transform nexus;

    void Start()
    {
        nexus = GameObject.FindGameObjectWithTag("Nexus").transform;
    }


    public static PoolManager instance {
		get{ 
			if (_instance == null) {
				_instance = FindObjectOfType<PoolManager> ();
			}
			return _instance;
		}
	}

	public void CreatePool(GameObject prefab, int poolSize){
		int poolKey = prefab.GetInstanceID ();

		GameObject poolHolder = new GameObject (prefab.name + " pool");
		poolHolder.transform.parent = transform;

		if(!poolDictionary.ContainsKey (poolKey)) {
			poolDictionary.Add (poolKey, new Queue<ObjectInstance> ());

			for(int i = 0; i< poolSize; i++){

                GameObject enemy = Instantiate(prefab) as GameObject;
                NetworkServer.Spawn(enemy);
                ObjectInstance newObject = new ObjectInstance (enemy);
                poolDictionary [poolKey].Enqueue (newObject);
				newObject.setParent (poolHolder.transform);
			}
		}
	}

	public void ReuseObject(GameObject prefab, Vector3 position, Quaternion rotation, float scale) {
        Debug.Log(position);
		int poolKey = prefab.GetInstanceID ();

		if (poolDictionary.ContainsKey (poolKey)) {
			ObjectInstance ObjectToReuse = poolDictionary [poolKey].Dequeue ();
			poolDictionary [poolKey].Enqueue (ObjectToReuse);

			ObjectToReuse.Reuse (position, rotation, scale, nexus);
        }
    }

	public class ObjectInstance {

		public GameObject gameObject;
		Transform transform;

		bool hasPoolObjectComponent;
		PoolObject poolObjectScript;

		public ObjectInstance(GameObject objectInstance){
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
			obj.SetActive (true);
		}

		public void Reuse(Vector3 position, Quaternion rotation, float scale, Transform nexus) {

			if (hasPoolObjectComponent) {
				poolObjectScript.OnObjectReuse ();
			}

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
}
