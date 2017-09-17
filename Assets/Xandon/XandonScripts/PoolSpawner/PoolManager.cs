using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class PoolManager : NetworkBehaviour { 
	Dictionary<int,Queue<ObjectInstance>> poolDictionary = new Dictionary<int, Queue<ObjectInstance>> ();

	static PoolManager _instance;

    public Transform nexus;

    public override void OnStartServer()
    {
        //if (isServer)
        //{
        //    nexus = GameObject.FindGameObjectWithTag("Nexus").transform;
        //}
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

		if(!poolDictionary.ContainsKey (poolKey)) 
		{
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

	[ClientRpc]
	public void ReuseObject(GameObject prefab, Vector3 position, Quaternion rotation, float scale) {
        Debug.Log(position);
		int poolKey = prefab.GetInstanceID ();

		if (poolDictionary.ContainsKey (poolKey)) {
			ObjectInstance ObjectToReuse = poolDictionary [poolKey].Dequeue ();
			poolDictionary [poolKey].Enqueue (ObjectToReuse);

			ObjectToReuse.Reuse (position, rotation, scale, nexus);
        }
    }
}
