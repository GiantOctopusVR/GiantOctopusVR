using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NexusBase : MonoBehaviour {
    public int life;
    public NetworkEventManager NetEventManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy"))
        {
            life--;
            Debug.Log("collided with enemy");
            //Destroy(other.gameObject);
            var agent = other.gameObject.GetComponent<NavMeshAgent>();
            agent.enabled = false;
            other.gameObject.SetActive(false);
            if (life <= 0){
              NetEventManager.CmdTriggerEvent(GameEvents.EndGameEvent);
            }
        }
    }
}
