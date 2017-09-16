using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour {

    public KeyCode spawnKey;
    public GameObject enemy;
    public Transform enemyContainer;
    private Transform nexus;



	// Use this for initialization
	void Start () {
        nexus = GameObject.FindGameObjectWithTag("Nexus").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(spawnKey))
        {
            SpawnEnemy();
        }
	}

    void SpawnEnemy()
    {
        var e = Instantiate(enemy, transform.position, Quaternion.identity, enemyContainer);

        var agent = e.GetComponent<NavMeshAgent>();

        agent.SetDestination(nexus.position);
    }
}
