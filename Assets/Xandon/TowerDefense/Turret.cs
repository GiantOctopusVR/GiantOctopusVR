using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    private Transform target;

    [Header("Attributes")]
    public float range = 15f;
    public string enemyTag = "Enemy";
    public float turnSpeed = 10f;

    [Header("Unity Setup Fields")]
    public float fireRate = 1f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private float fireCountdown = 0f;

	void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}
	

    void UpdateTarget()
    {
        var enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                Debug.Log("FOUND ENEMY");
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }


        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        } else
        {
            target = null;
        }

    }

	void Update () {

        if(fireCountdown > 0)
        {
            fireCountdown -= Time.deltaTime;
        }

        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);


        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        
	}


    void Shoot()
    {
        var bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
