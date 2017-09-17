using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour {

        private float breakForce = 100f;


        private void Start()
        {
            GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
        }

        private void OnCollisionEnter(Collision collision)
        {
            var collisionForce = GetCollisionForce(collision);

            if (collisionForce > 100f)
            {
                Destroy(gameObject, 0.05f);
            }

        }

        private float GetCollisionForce(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                return 500f;
            }

            if (collision.gameObject.tag == "Bullet")
            {
                return 500f;
            }

            if (collision.gameObject.tag == "Laser")
            {
                return 500f;
            }

            if (collision.gameObject.tag == "Bat")
            {
                return 500f;
            }

            return 0f;
        }


        private void EnemyDestroy(float force)
        {
            Destroy(gameObject, .05f);
        }
}

