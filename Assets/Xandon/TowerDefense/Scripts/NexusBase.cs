using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class NexusBase : NetworkBehaviour
{
    public int life;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy"))
        {
            life--;
            Debug.Log("collided with enemy");
            ////Destroy(other.gameObject);
            var agent = other.gameObject.GetComponent<NavMeshAgent>();
            agent.enabled = false;
            other.gameObject.SetActive(false);
        }
    }
}