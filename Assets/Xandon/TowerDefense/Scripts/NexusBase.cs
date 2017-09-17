using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class NexusBase : NetworkBehaviour
{
    public int life;
	public static bool win;


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
		if (life <= 0){
			win = false;
			SceneManager.LoadScene (7);

    }
}
}
	