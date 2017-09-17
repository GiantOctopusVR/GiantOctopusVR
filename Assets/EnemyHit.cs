using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class EnemyHit : NetworkBehaviour
{

        private float breakForce = 100f;


        public override void OnStartServer()
        {
            GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
        }

        private void OnTriggerEnter(Collider col)
        {
            var collisionForce = GetCollisionForce(col);

        //Destroy(gameObject, 0.05f);
            if (collisionForce > 100f)
            {
                var agent = gameObject.GetComponent<NavMeshAgent>();
                agent.enabled = false;
                gameObject.SetActive(false);
            }
        }

        private float GetCollisionForce(Collider col)
        {
            if (col.gameObject.tag == "Player")
            {
                return 500f;
            }

            if (col.gameObject.tag == "Bullet")
            {
                return 500f;
            }

            if (col.gameObject.tag == "Laser")
            {
                return 500f;
            }

            if (col.gameObject.tag == "Bat")
            {
                return 500f;
            }

            return 0f;
        }


        private void EnemyDestroy(float force)
        {
            //Destroy(gameObject, .05f);

    }
}

